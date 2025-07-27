using Ambev.DeveloperEvaluation.Common.Validation;
using Ambev.DeveloperEvaluation.Domain.Common;
using Ambev.DeveloperEvaluation.Domain.Validation;

namespace Ambev.DeveloperEvaluation.Domain.Entities
{
    /// <summary>
    /// Represents a product in the system.
    /// This class is part of the domain layer and encapsulates the properties and behaviors of a product.
    /// </summary>
    public class Product : BaseEntity
    {
        /// <summary>
        /// Gets or sets the name associated with the object.
        /// </summary>
        public string Name { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the description text.
        /// </summary>
        public string Description { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the price of the item.
        /// </summary>
        public decimal Price { get; set; } = 0.0m;

        /// <summary>
        /// Gets or sets the category associated with the item.
        /// </summary>
        public string Category { get; set; } = string.Empty;

        /// <summary>
        /// Gets or sets the quantity of the product available.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// Gets the date and time when the product was created.
        /// </summary>
        public DateTime CreatedAt { get; set; }

        /// <summary>
        /// Gets the date and time of the last update to the product's information.
        /// </summary>
        public DateTime? UpdatedAt { get; set; }

        /// <summary>
        /// Gets a value indicating whether the product is active.
        /// </summary>
        public bool IsActive { get; set; } = true;

        /// <summary>
        /// Verifies if the product is currently in stock.
        /// </summary>
        public bool IsInStock => Quantity > 0;

        /// <summary>
        /// Performs validation on the product properties.
        /// </summary>
        /// <returns>
        /// A <see cref="ValidationResultDetail"/> containing:
        /// - IsValid: Indicates whether all validation rules passed
        /// - Errors: Collection of validation errors if any rules failed
        /// </returns>
        /// <remarks>
        /// <listheader>The validation includes checking:</listheader>
        /// <list type="bullet">Name is not empty</list>"
        /// <list type="bullet">Description is not empty</list>"
        /// <list type="bullet">Price is greater than zero</list>"
        /// <list type="bullet">Category is not empty</list>"
        /// <list type="bullet">IsActive is true or false</list>"
        /// 
        /// </remarks>
        public ValidationResultDetail Validate()
        {
            var validator = new ProductValidator();
            var result = validator.Validate(this);
            return new ValidationResultDetail
            {
                IsValid = result.IsValid,
                Errors = result.Errors.Select(o => (ValidationErrorDetail)o)
            };
        }

        /// <summary>
        /// Activates the product account.
        /// Changes the product's status to Active.
        /// </summary>
        public void Activate()
        {
            IsActive = true;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Deactivates the product account.
        /// Changes the product's status to Inactive.
        /// </summary>
        public void Deactivate()
        {
            IsActive = false;
            UpdatedAt = DateTime.UtcNow;
        }

        /// <summary>
        /// Sets the product as out of stock.
        /// Clears the quantity and updates the last modified date.
        /// </summary>
        public void SetOutOfStock()
        {
            Quantity = 0;
            UpdatedAt = DateTime.UtcNow;
        }
    }
}
