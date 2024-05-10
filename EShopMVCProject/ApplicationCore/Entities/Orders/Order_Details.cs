using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities.Product; // Assuming the namespace for the Product class

namespace ApplicationCore.Entities.Orders
{
    public class Order_Details
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }

        [Required(ErrorMessage = "Order_Id is required")]
        public int Order_Id { get; set; }

        // Navigation property for the order
        public Order Order { get; set; }

        [Required(ErrorMessage = "ProductID is required")]
        public int ProductID { get; set; }

        // Navigation property for the product
        public Product.Product Product { get; set; }

        // Other properties
        public string ProductName { get; set; } = string.Empty;

        public int Qty { get; set; }

        public int Price { get; set; }

        public int Discount { get; set; }

    }
}