using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using API.data;
using API.Entites;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseAPIContoller
    {
        private readonly DataContext _context;
        public UsersController(DataContext context)
        {
          _context = context;

        }
        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var Users=await _context.Users.ToListAsync(); 
            return Users;
            
        }
        [HttpGet("{id}")]
        public async Task <ActionResult<AppUser>> GetUser(int id)
        {
            var Users=await _context.Users.FindAsync(id);
            return Users;
            
        }

    }
}