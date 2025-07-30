# Developer Store Sales API
A RESTful API built with .NET 8, PostgreSQL and MediatR, following Clean Architecture, SOLID principles, and using Entity Framework Core. The API is designed for managing product sales, discounts, and customers, with features such as soft delete and event-driven architecture via RabbitMQ.

## Features
- **Sales Management**: Create, Read, Update and Delete Sales.
- **Customer Management**: Create, Read and Delete Customers.
- **Product Management**: Read Products.
- **Branches Management**: Read Branches.

## Technologies Used
- .NET 8
- PostgreSQL
- MediatR
- Entity Framework Core
- RabbitMQ

## Business Rules
**Discount Rules**
- Purchases of 4 to 9 identical items: 10% discount

- Purchases of 10 to 20 identical items: 20% discount

- Purchases of less than 4 items: no discount

- Purchases of more than 20 identical items are not allowed

## Requirements
To run this API project locally using Docker, make sure you have the following installed and properly configured on your machine:

- [Docker](https://www.docker.com/get-started)

- [Docker Compose](https://docs.docker.com/compose/install/)

- [Postman](https://www.postman.com/downloads/) for API testing

## How to Run
1. Clone the repository:
   ```bash
   git clone https://github.com/juniorjblp/developerstore-sales-api.git
   ```
2. Navigate to the project directory:
   ```bash
   cd developerstore-sales-api
   ```
3. Run docker compose to start the Api, PostgreSQL and RabbitMQ services:
   ```bash
   docker-compose up -d
   ```
4. Open your browser and navigate to `http://localhost:8080/health` to check the health of the API.
   
5. Use a tool like Postman or curl to interact with the API endpoints.

## Database
The API uses **PostgreSQL** as the database. The connection string is configured in the `appsettings.json` file. Ensure that the PostgreSQL service is running and accessible.

## Configuration
The API configuration is managed through the `appsettings.json` file. You can modify the connection string, logging settings, and other configurations as needed.

## Local Environment Configuration

If you're running the application locally, make sure to update the following configurations in the `appsettings.json` file:

- **DefaultConnection**: Change the `Server` value to `localhost` so the application can connect to your local SQL Server instance.
- **RabbitMQ**: Update the `Hostname` to `localhost` to connect to your local RabbitMQ server.

```json
"ConnectionStrings": {
  "DefaultConnection": "Server=localhost;Database=YourDatabaseName;User Id=...;Password=...;"
},
"RabbitMQ": {
  "Hostname": "localhost",
  "Username": "guest",
  "Password": "guest"
}
```


## RabbitMQ
The API uses RabbitMQ for event-driven architecture. Ensure that the RabbitMQ service is running and accessible. The connection settings are configured in the `appsettings.json` file.

## Seed Data
The API includes a seeding mechanism to populate the database with initial data. This can be done by running the application, which will automatically seed the database with predefined data for products and branches.

## API Usage
To use the API, you need to send HTTP requests to the appropriate endpoints. You can use tools like Postman or curl to interact with the API.

## Postman Collection
A Postman collection is available via the link below to help you test the API endpoints. Simply import the collection into Postman and start making requests to the API.

[Click here](https://www.postman.com/docking-module-observer-61100346/workspace/public/collection/19375131-3cfc10c0-1074-4972-8926-b128cc6483c5?action=share&creator=19375131) to access the Postman collection.


## API Endpoints
### Sales
- **Create Sale**: `POST /api/sales`
- **Get All Sales**: `GET /api/sales?userId={userId}&startDate={startDate}&endDate={endDate}&pageNumber={pageNumber}&pageSize={pageSize}`
- **Cancel Sale**: `PUT /api/sales/{id}`
- **Delete Sale**: `DELETE /api/sales/{id}`

### Users
- **Create User**: `POST /api/Users`
- **Delete User**: `DELETE /api/Users/{id}`
- **Get User by ID**: `GET /api/Users/{id}`

### Auth
- **Login**: `POST /api/auth`

### Products
- **Get All Products**: `GET /api/products?pageNumber={pageNumber}&pageSize={pageSize}`

### Branches
- **Get All Branches**: `GET /api/branches?pageNumber={pageNumber}&pageSize={pageSize}`

## API Documentation
The API documentation is available at `http://localhost:<PORT>/swagger` after running the application. It provides detailed information about the available endpoints, request/response formats, and examples.

## 🧪 Testing
To run the tests, you can use the following command in the terminal:
```bash
dotnet test
```

