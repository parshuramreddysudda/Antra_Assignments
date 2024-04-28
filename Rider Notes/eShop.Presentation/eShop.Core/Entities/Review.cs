namespace eShop.Core;

public class Review
{
    public int Id { get; set; }
    public int ProductId { get; set; }
    public string? PersonName { get; set; }
    public string? ReviewInformation { get; set; }
}