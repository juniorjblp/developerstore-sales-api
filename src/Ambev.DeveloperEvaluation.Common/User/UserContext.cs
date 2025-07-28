using Ambev.DeveloperEvaluation.Common.Security;
using Microsoft.AspNetCore.Http;
using System.Security.Claims;


namespace Ambev.DeveloperEvaluation.Common.User
{
    public class UserContext(IHttpContextAccessor accessor) : IUser
    {
        public string Id => accessor.HttpContext?.User?.FindFirst(ClaimTypes.NameIdentifier)?.Value ?? string.Empty;
        public string Username => accessor.HttpContext?.User?.Identity?.Name ?? string.Empty;
        public string Role => accessor.HttpContext?.User?.FindFirst(ClaimTypes.Role)?.Value ?? string.Empty;
    }
}
