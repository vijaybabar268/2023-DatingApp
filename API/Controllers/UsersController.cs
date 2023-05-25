using API.Data;
using API.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API.Controllers
{
    public class UsersController : BaseApiController
    {
        private readonly DataContext _context;

        public UsersController(DataContext context)
        {
            _context = context;            
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<AppUser>>> GetUsers()
        {
            var users = await _context.Users.ToListAsync();

            return users;
        }

        [Authorize]
        [HttpGet("{id}")]
        public async Task<ActionResult<AppUser>> GetUser(int id)
        {
            var user = await _context.Users.FindAsync(id);

            return user;
        }

        [HttpPost]
        public void AddUser(AppUser user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        [HttpPut("{id}")]
        public void UpdateUser(int id, AppUser user)
        {
            AppUser userInDb = _context.Users.Find(id);

            userInDb.UserName = user.UserName;

            _context.SaveChanges();
        }

        [HttpDelete("{id}")]
        public void RemoveUser(int id)
        {
            AppUser user = _context.Users.Find(id);
            _context.Users.Remove(user);
            _context.SaveChanges();
        }
    }
}