using System;
using System.ComponentModel.DataAnnotations;

namespace ApplicationCore.Entities.Reviews
{
    public class CustomerReview
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int CustomerId { get; set; }
        public Customer.Customer Customer { get; set; }

        [Required]
        public string CustomerName { get; set; }

        [Required]
        public int OrderId { get; set; }
        public DateOnly OrderDate { get; set; }

        [Required]
        public int ProductId { get; set; }
        public Product.Product Product { get; set; }

        [Required]
        public string ProductName { get; set; }

        [Required]
        [Range(1, 5)]
        public int RatingValue { get; set; }

        public string Comment { get; set; }
        public DateOnly ReviewDate { get; set; }
    }
} 