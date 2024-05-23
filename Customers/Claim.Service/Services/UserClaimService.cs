using System.Linq.Expressions;
using ApplicationCore;
using ApplicationCore.Entities;
using Claim.DTO;
using Claim.Service.IServices;
using Microsoft.EntityFrameworkCore;

namespace Claim.Service.Services;

public class UserClaimService:IUserClaimService
{
    private readonly AppDbContext _appDbContext;
    public UserClaimService(AppDbContext appDbContext)
    {
        _appDbContext = appDbContext;
    }
    public async Task<List<UserClaimDTO>> GetUserClaims(Expression<Func<AppUserClaim, bool>> expression)
    {
        return await (from claim in _appDbContext.AppUserClaim.Where(expression)
            select new UserClaimDTO()
            {
                ClaimType = claim.ClaimType,
                ClaimValue = claim.ClaimValue,
            }).ToListAsync();
    }
}