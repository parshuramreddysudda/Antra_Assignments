using ApplicationCore.Model.Request;
using Microsoft.AspNetCore.Identity;

namespace ApplicationCore.RepositoryContracts;

public interface IAccountRepository
{
    public Task<IdentityResult > SignUpAsync(SignUpModel signUpModel);
    public Task<SignInResult> LoginAsync(LoginModel loginModel);
}