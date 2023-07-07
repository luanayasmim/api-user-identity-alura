using Microsoft.AspNetCore.Authorization;
using System.Security.Claims;

namespace UserApi.Authorization
{
    public class AgeAuthorization : AuthorizationHandler<MinimumAge>
    {
        protected override Task HandleRequirementAsync(AuthorizationHandlerContext context, MinimumAge requirement)
        {
            var birthDateClaim = context.User.FindFirst(claim => claim.Type == ClaimTypes.DateOfBirth);

            if (birthDateClaim is null)
                return Task.CompletedTask;

            var birthDate = Convert.ToDateTime(birthDateClaim.Value);

            var age = DateTime.Today.Year - birthDate.Year;

            if (birthDate > DateTime.Today.AddYears(-age))
                age--;

            if (age >= requirement.Age)
                context.Succeed(requirement);

            return Task.CompletedTask;
        }
    }
}