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

            var token = GenerateToken();

            return Ok(token);
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
                Password = ComputeSha256Hash(request.Password)
            };
            _dbContext.Users.Add(newUser);
            _dbContext.SaveChanges();

            return Ok();
        }

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
        private JwtSecurityToken GenerateToken()
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(_configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                issuer: _configuration["JWT:ValidIssuer"],
                audience: _configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(3),
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
                );

            return token;
        }
    }
}
