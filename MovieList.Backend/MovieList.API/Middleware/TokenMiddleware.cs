using System.IdentityModel.Tokens.Jwt;
using System.Text;
using Microsoft.IdentityModel.Tokens;

namespace MovieList.API.Middleware
{
    public class TokenMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly string _secret;

        public TokenMiddleware(RequestDelegate next, string secret)
        {
            _next = next ?? throw new ArgumentNullException(nameof(next));
            _secret = secret ?? throw new ArgumentNullException(nameof(secret));
        }

        public async Task Invoke(HttpContext context)
        {
            var excludedPaths = new[] { "/api/users/login", "/api/users/register", "/swagger" };
            if (excludedPaths.Any(path => context.Request.Path.StartsWithSegments(path, StringComparison.OrdinalIgnoreCase)))
            {
                await _next(context);
                return;
            }

            var token = context.Request.Headers["Authorization"].FirstOrDefault()?.Split(" ").Last();
            
            if (token == null || !ValidateTokenAndAttachUser(context, token))
            {
                context.Response.StatusCode = StatusCodes.Status401Unauthorized;
                await context.Response.WriteAsync("Unauthorized: Invalid or missing token.");
                return;
            }

            await _next(context);
        }

        private bool ValidateTokenAndAttachUser(HttpContext context, string token)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_secret);
            SecurityToken validatedToken;

            try
            {
                tokenHandler.ValidateToken(token, new TokenValidationParameters
                {
                    ValidateIssuerSigningKey = true,
                    IssuerSigningKey = new SymmetricSecurityKey(key),
                    ValidateIssuer = false,
                    ValidateAudience = false,
                    ClockSkew = TimeSpan.Zero
                }, out validatedToken);
            }
            catch
            {
                context.Items["UserId"] = null;
                return false;
            }

            if (validatedToken is JwtSecurityToken jwtToken)
            {
                var userIdString = jwtToken.Claims.FirstOrDefault(x => x.Type == "nameid")?.Value;

                if (int.TryParse(userIdString, out int userId))
                {
                    context.Items["UserId"] = userId;
                    return true;
                }
            }

            context.Items["UserId"] = null;
            return false;
        }
    }
}
