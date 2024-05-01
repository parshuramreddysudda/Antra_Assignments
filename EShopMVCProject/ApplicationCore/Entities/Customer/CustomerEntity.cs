using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

public class CustomerEntities
{
    public class Customer
    {
        [Required]
        public int CustomerId { get; set; }
        [Required]
        public string FirstName { get; set; }= string.Empty;
        public string LastName { get; set; }= string.Empty;
        [Required]
        public string Gender { get; set; }= string.Empty;
        [Required]
        public string Phone { get; set; }= string.Empty;
        public string ProfilePic { get; set; }= string.Empty;
        public int UserId { get; set; } 
    }

    public class UserAddress
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public int CustomerId { get; set; } // FK for Customer
        [Required]
        public int AddressId { get; set; } // FK for Address
        // Navigation properties
        public virtual Customer Customer { get; set; }
        public virtual Address Address { get; set; }
        public int IsDefaultAddress { get; set; }
    }

    public class Address
    {
        [Required]
        public int Id { get; set; }
        [Required]
        public string Street1 { get; set; }= string.Empty;
        [Required]
        public string City { get; set; }= string.Empty;
        [Required]
        public string Zipcode { get; set; }= string.Empty;
        [Required]
        public string State { get; set; }= string.Empty;
        [Required]
        public string Country { get; set; }= string.Empty;
        // Navigation property for user addresses
        public virtual ICollection<UserAddress> UserAddresses { get; set; }
    }
}