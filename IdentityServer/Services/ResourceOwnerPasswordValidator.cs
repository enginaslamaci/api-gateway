using IdentityModel;
using IdentityServer4.Test;
using IdentityServer4.Validation;

namespace IdentityServer.Services
{
    public class ResourceOwnerPasswordValidator : IResourceOwnerPasswordValidator
    {
        private readonly List<TestUser> _users;

        public ResourceOwnerPasswordValidator()
        {
            _users = Config.TestUsers;
        }

        public async Task ValidateAsync(ResourceOwnerPasswordValidationContext context)
        {
            var user = _users.FirstOrDefault(r => r.Username == context.UserName && r.Password == context.Password);
            if (user == null)
            {
                var errors = new Dictionary<string, object>();
                errors.Add("error", "Authentication failed");
                context.Result.CustomResponse = errors;

                return;
            }

            context.Result = new GrantValidationResult(user.SubjectId, OidcConstants.AuthenticationMethods.Password);
        }
    }
}
