using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using ApplicationCore.Entities.Product; // Assuming the namespace for the Product class

namespace ApplicationCore.Entities.Orders
{
    public class Order_Details
    {
        [Required(ErrorMessage = "Id is required")]
        public int Id { get; set; }
        
        public int Qty { get; set; }

        public int Price { get; set; }

        public int Discount { get; set; }

    }
}