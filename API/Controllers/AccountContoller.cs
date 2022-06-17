using System.Security.Cryptography;
using System.Threading.Tasks;
using API.data;
using API.DTOs;
using API.DTOS;
using API.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers   
{
    public  class AccountContoller :BaseAPIContoller
    {
        private readonly DataContext context;

        public AccountContoller(DataContext context )
        {
            this.context = context;
        }
        [HttpPost("Register")]
        public async Task<ActionResult<AppUser>>  Register(RegisterDTO registerDTO)
        {
            using var hmac = new HMACSHA512();

            if(await UserExists(registerDTO.Username)) return BadRequest("username allready exixsts");
            var user = new AppUser {
                UserName=registerDTO.Username,
                PasswordHash=hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(registerDTO.Password)),
                PasswordSelt=hmac.Key
                
            };
            context.Users.Add(user);
            await context.SaveChangesAsync();
            return user;
        }
        private async Task<bool> UserExists(string username)
        {
            return await context.Users.AnyAsync(x => x.UserName.ToLower() ==username.ToLower());
        }

        [HttpPost("login")]
        public async Task<ActionResult<AppUser>>  Login(LoginDTO loginDTo)
        {
            var user = await this.context.Users.FirstOrDefaultAsync(x => x.UserName == loginDTo.username);
            if(user==null) return Unauthorized("invaild user");

            using var hmac = new HMACSHA512(user.PasswordSelt);
            var computeHash = hmac.ComputeHash(System.Text.Encoding.UTF8.GetBytes(loginDTo.password));
            for(int i =0 ; i < computeHash.Length ;i++) 
            {
                if(computeHash[i]!=user.PasswordHash[i]) return Unauthorized("invaild password");
            }
            return user;

        }
            
    }
}