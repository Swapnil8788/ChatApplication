using ChatApplication.Data;
using ChatApplication.DTOs.Auth;
using ChatApplication.DTOs.UserDTOs;
using ChatApplication.Models;
using ChatApplication.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace ChatApplication.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly ChatDbContext _dbContext;
        private readonly JwtService _jwtService;
        public AuthController(ChatDbContext dbContext, JwtService jwtService)
        {
            _dbContext = dbContext;
            _jwtService = jwtService;
        }
        [HttpPost("Login")]
        public ActionResult Login()
        {
            return Ok("Login done");
        }

        [HttpPost("Register")]
        public async Task<ActionResult> Register([FromBody] RegisterRequest dto)
        {
            if (dto == null)
            {
                return BadRequest(new { Message = "User cannot be null" });
            }
            var existingUser = await _dbContext.Users.FirstOrDefaultAsync(u =>
                    u.Email == dto.Email);
            if (existingUser != null)
            {
                return BadRequest(new { Message = "User Already Exists" });

            }
            var existingRole = await _dbContext.Roles.FirstOrDefaultAsync(u=>u.RoleName == dto.Role);
            if(existingRole == null)
            {
                 var roleToCreate = new Role
                 {
                     RoleName = dto.Role
                 };
                 await _dbContext.Roles.AddAsync(roleToCreate);
                 await _dbContext.SaveChangesAsync();
                 existingRole = roleToCreate;
            }
            var hashPassword = BCrypt.Net.BCrypt.HashPassword(dto.Password);

            var user = new User
            {
                Name = dto.Name,
                Email = dto.Email,
                CreateAt = DateTime.UtcNow,
                UpdatedAt = DateTime.UtcNow,
                Password = hashPassword,
                UserRoles = new List<UserRole>
                {
                    new UserRole
                    {
                        RoleId = existingRole.RoleId
                    }
                }
            };

            await _dbContext.Users.AddAsync(user);
            await _dbContext.SaveChangesAsync();

            var token = _jwtService.GenerateToken(dto);

            var userToSend = new RegisteredResponseDTO
            {
              Name = user.Email,
              Email = user.Name  
            };
            return Ok(new {token, user = userToSend});
        }
    }
}
