using Ambev.DeveloperEvaluation.Domain.EventPublishing;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using RabbitMQ.Client;
using System.Text;
using System.Text.Json;

namespace Ambev.DeveloperEvaluation.ORM.EventPublishing
{
    public class EventPublisher(IConfiguration configuration) : IEventPublisher, IAsyncDisposable, IHostedService
    {
        private IConnection? _connection;
        private IChannel? _channel;
        private readonly string _exchangeName = "domain_events";
        private readonly string _queueName = "domain_events_queue";

        public async Task InitializeAsync()
        {
            if (_connection != null)
                return;

            var factory = new ConnectionFactory
            {
                HostName = configuration.GetValue<string>("RabbitMQ:HostName") ?? "localhost",
                Port = configuration.GetValue<int>("RabbitMQ:Port") != 0 ? configuration.GetValue<int>("RabbitMQ:Port") : 5672,
                UserName = configuration.GetValue<string>("RabbitMQ:UserName") ?? "admin",
                Password = configuration.GetValue<string>("RabbitMQ:Password") ?? "admin"
            };

            _connection = await factory.CreateConnectionAsync();
            _channel = await _connection.CreateChannelAsync();

            await _channel.ExchangeDeclareAsync(exchange: _exchangeName, type: ExchangeType.Topic, durable: true);
            await _channel.QueueDeclareAsync(queue: _queueName, durable: true, exclusive: false, autoDelete: false, arguments: null);
        }

        public async Task PublishAsync<T>(T message, Guid entityId, string eventName)
        {
            if (_channel == null)
                throw new InvalidOperationException("Connection not initialized. Call InitializeAsync first.");

            if (string.IsNullOrWhiteSpace(eventName))
                throw new ArgumentException("Exchange (eventName) must be provided.", nameof(eventName));

            var routingKey = eventName;

            var json = JsonSerializer.Serialize(message);
            var body = Encoding.UTF8.GetBytes(json);

            var properties = new BasicProperties
            {
                Persistent = true,
                Type = typeof(T).FullName,
                MessageId = Guid.NewGuid().ToString(),
                Timestamp = new AmqpTimestamp(DateTimeOffset.UtcNow.ToUnixTimeSeconds())
            };

            try
            {

                await _channel.QueueBindAsync(
                    queue: _queueName,
                    exchange: _exchangeName,
                    routingKey: routingKey
                );

                await _channel.BasicPublishAsync(
                    exchange: _exchangeName,
                    routingKey: routingKey,
                    mandatory: false,
                    basicProperties: properties,
                    body: body
                );
            }
            catch (Exception ex)
            {
                throw new InvalidOperationException($"Failed to publish event to exchange '{eventName}'.", ex);
            }
        }


        public async ValueTask DisposeAsync()
        {
            if (_channel != null)
            {
                await _channel.CloseAsync();
                _channel.Dispose();
            }

            if (_connection != null)
            {
                await _connection.CloseAsync();
                _connection.Dispose();
            }
        }

        public async Task StartAsync(CancellationToken cancellationToken)
        {
            await InitializeAsync();
        }

        public async Task StopAsync(CancellationToken cancellationToken)
        {
            await DisposeAsync();
        }
    }
}