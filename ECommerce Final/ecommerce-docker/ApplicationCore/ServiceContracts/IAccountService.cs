using ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.ServiceContracts;

public interface IAccountService
{
    public Task<IdentityResult> SignUpAsync(SignUpModel signUpModel);
    public Task<string> LoginAsync(LoginModel loginModel);
}