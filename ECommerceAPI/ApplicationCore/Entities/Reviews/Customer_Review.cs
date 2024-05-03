namespace ApplicationCore.Entities.Reviews;

public class Customer_Review
{
    public int Id { get; set; }
    public int Customer_Id { get; set; }
    public Customer.Customer Customer { get; set; }
    public string Customer_Name { get; set; }
    public int Order_Id { get; set; }
    public DateOnly OrderDate { get; set; }
    public int Product_Id { get; set; }
    public Product.Product Product { get; set; }
    public string Product_Name { get; set; }
    public int Rating_value { get; set; }
    public string Comment { get; set; }
    public DateOnly Review_Date { get; set; }
}