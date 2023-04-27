using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using PCBuilder.Models.DB;
using PCBuilder.Models.Request;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace PCBuilder.Controllers
{
    [Route("[controller]/[action]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IConfiguration _configuration;
        private readonly PCBuilderDbContext _dbContext;

        public UserController(PCBuilderDbContext dbContext, IConfiguration configuration)
        {
            _configuration = configuration;
            _dbContext = dbContext;
        }

        [HttpPost]
        public ActionResult SignIn(UserSignInRequest request)
        {
            var user = _dbContext.Users.FirstOrDefault(x => x.Email == request.Email && x.Password == ComputeSha256Hash(request.Password));

            if (user is null)
                return BadRequest("Incorect credentials");

            var encryptedToken = GenerateJwtToken(user);

            return Ok(encryptedToken);
        }

        [HttpPost] 
        public ActionResult SignUp(UserSignUpRequest request)
        {
            if (request.FullName.Length < 5)
                return BadRequest("Full name is too short");
            if (request.Password.Length < 6)
                return BadRequest("Password must be longer than 6 characters");


            var newUser = new User
            {
                FullName = request.FullName,
                Email = request.Email,
                Password = ComputeSha256Hash(request.Password),
                Role = request.Role
            };
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return Ok();
        }
        [Authorize]
        [HttpDelete]
        public ActionResult Delete(int id)
        {
            var userForDeletion = _dbContext.Users.FirstOrDefault(x => x.Id == id);

            if(userForDeletion is null) 
                return BadRequest("User not found");

            _dbContext.Users.Remove(userForDeletion);
            _dbContext.SaveChanges();

            return Ok();
        }

        private string ComputeSha256Hash(string rawData)
        {
            // Create a SHA256   
            using (SHA256 sha256Hash = SHA256.Create())
            {
                // ComputeHash - returns byte array  
                byte[] bytes = sha256Hash.ComputeHash(Encoding.UTF8.GetBytes(rawData));

                // Convert byte array to a string   
                StringBuilder builder = new StringBuilder();
                for (int i = 0; i < bytes.Length; i++)
                {
                    builder.Append(bytes[i].ToString("x2"));
                }
                return builder.ToString();
            }
        }
        private string GenerateJwtToken(User user)
        {
            var tokenHandler = new JwtSecurityTokenHandler();
            var key = Encoding.ASCII.GetBytes(_configuration["JWT:Key"]);
            var tokenDescriptor = new SecurityTokenDescriptor
            {
                Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id.ToString()), new Claim(ClaimTypes.Role, user.Role) }),
                Expires = DateTime.UtcNow.AddHours(3),
                SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature),
                Issuer = _configuration["JWT:Issuer"],
                Audience = _configuration["JWT:Audience"]
            };
            var token = tokenHandler.CreateToken(tokenDescriptor);
            var encryptedToken = tokenHandler.WriteToken(token);

            return encryptedToken;
        }
    }
}
