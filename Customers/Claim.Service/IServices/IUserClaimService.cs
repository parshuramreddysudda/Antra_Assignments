using System.Linq.Expressions;
using ApplicationCore.Entities;
using Claim.DTO;

namespace Claim.Service.IServices;

public interface IUserClaimService
{
    Task<List<UserClaimDTO>> GetUserClaims(Expression<Func<AppUserClaim, bool>> expression);
}