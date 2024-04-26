using IdentityModel;
using IdentityServer4;
using IdentityServer4.Models;
using IdentityServer4.Test;
using System.Security.Claims;

namespace IdentityServer
{
    public static class Config
    {
        public static IEnumerable<ApiScope> ApiScopes =>
          new[] { new ApiScope("customerAPI", "Customer API"),
                  new ApiScope("productAPI", "Product API"),
                  new ApiScope("gateway_access","Gateway API"),
                  new ApiScope(IdentityServerConstants.LocalApi.ScopeName) };

        public static IEnumerable<IdentityResource> GetIdentityResources()
        {
            return new IdentityResource[] { new IdentityResources.OpenId(),
                                            new IdentityResources.Profile(),
                                            new IdentityResources.Email(),
                                            new IdentityResource() { Name = "roles", DisplayName = "Roles", Description = "User Roles", UserClaims = new[] { ClaimTypes.Role } } };
        }

        public static IEnumerable<ApiResource> GetApis()
        {
            return new[]
            {
                new ApiResource
                {
                    Name = "resource_customerAPI",
                    Scopes = { "customerAPI" }
                },
                new ApiResource
                {
                    Name = "resource_productAPI",
                    Scopes = { "productAPI" }
                },
                new ApiResource
                {
                    Name = "resource_gateway",
                    Scopes = { "gateway_access" }
                },
                new ApiResource
                {
                    Name = IdentityServerConstants.LocalApi.ScopeName
                }
            };
        }

        public static IEnumerable<Client> GetClients()
        {
            return new Client[]
            {
                new Client
                {
                    ClientName="API Gateway App",
                    ClientId="credential_client",
                    ClientSecrets= {new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ClientCredentials,
                    AllowedScopes={ "customerAPI", "productAPI", "gateway_access", IdentityServerConstants.LocalApi.ScopeName }
                },
                new Client
                {
                    ClientName="API Gateway App",
                    ClientId="resourceowner_client",
                    ClientSecrets= {new Secret("secret".Sha256())},
                    AllowedGrantTypes= GrantTypes.ResourceOwnerPassword,
                    AllowedScopes={ "customerAPI", "productAPI","gateway_access", IdentityServerConstants.LocalApi.ScopeName, IdentityServerConstants.StandardScopes.Email, IdentityServerConstants.StandardScopes.OpenId,IdentityServerConstants.StandardScopes.Profile, IdentityServerConstants.StandardScopes.OfflineAccess, IdentityServerConstants.LocalApi.ScopeName,"roles" },
                    AllowOfflineAccess =true,
                    AccessTokenLifetime=3600, //1 hour
                    RefreshTokenExpiration=TokenExpiration.Absolute, //refresh token lifecycle
                    AbsoluteRefreshTokenLifetime= (int) (DateTime.Now.AddDays(60)- DateTime.Now).TotalSeconds, //60 day
                    RefreshTokenUsage= TokenUsage.ReUse
                },
            };

        }

        public static List<TestUser> TestUsers
        {
            get
            {
                return new List<TestUser>
                {
                    new TestUser
                    {
                        SubjectId = "11111",
                        Username = "User1",
                        Password = "123456",
                        Claims =
                        {
                            new Claim(JwtClaimTypes.Name, "User1 Lastname1"),
                            new Claim(JwtClaimTypes.GivenName, "User1"),
                            new Claim(JwtClaimTypes.FamilyName, "Lastname1"),
                            new Claim(JwtClaimTypes.Email, "User1@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.Role, "user")
                        }
                    },
                    new TestUser
                    {
                        SubjectId = "22222",
                        Username = "User2",
                        Password = "123456",
                        Claims =
                        {
                           new Claim(JwtClaimTypes.Name, "User2 Lastname2"),
                            new Claim(JwtClaimTypes.GivenName, "User2"),
                            new Claim(JwtClaimTypes.FamilyName, "Lastname2"),
                            new Claim(JwtClaimTypes.Email, "User2@email.com"),
                            new Claim(JwtClaimTypes.EmailVerified, "true", ClaimValueTypes.Boolean),
                            new Claim(JwtClaimTypes.Role, "admin")
                        }
                    }
                };
            }
        }
    }
}
