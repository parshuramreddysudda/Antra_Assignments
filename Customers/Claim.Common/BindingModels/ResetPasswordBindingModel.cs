namespace Claim.Common.BindingModels;

public class ResetPasswordBindingModel
{
    public string Email { get; set; }
    public string OldPassword { get; set; }
    public string NewPassword { get; set; }
}