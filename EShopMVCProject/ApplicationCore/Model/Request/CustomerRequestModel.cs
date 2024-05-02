namespace ApplicationCore.Model.Request;

public class CustomerRequestModel
{
    public int CustomerId { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Gender { get; set; }
    public string Phone { get; set; }
    public string ProfilePic { get; set; }
    public int UserId { get; set; }
}