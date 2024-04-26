using IdentityServer.Models;
using IdentityServer4.Test;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using static IdentityServer4.IdentityServerConstants;

namespace IdentityServer.Controllers
{
    [Route("api/v1/[controller]")]
    [ApiController]
    [Authorize(LocalApi.PolicyName)]
    public class AccountController : ControllerBase
    {
        private readonly List<TestUser> _users;
        public AccountController()
        {
            _users = Config.TestUsers;
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody] RegisterDto register)
        {
            //todo: register process
            return Ok($"user register succesfully for {register.username} - {register.email}");
        }

        [HttpGet("user")]
        public async Task<IActionResult> GetUser()
        {
            var userId = User.Claims.FirstOrDefault(x => x.Type == JwtRegisteredClaimNames.Sub);
            if (userId == null) return BadRequest();

            var user = _users.FirstOrDefault(r => r.SubjectId == userId.Value);
            if (user == null) return BadRequest();

            var response = new { Id = user.SubjectId, Username = user.Username, claims = user.Claims.Select(r => new { r.Type, r.Value }) };
            return Ok(response);
        }
    }

}
