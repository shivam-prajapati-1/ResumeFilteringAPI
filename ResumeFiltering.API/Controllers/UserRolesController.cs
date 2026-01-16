using Microsoft.AspNetCore.Mvc;
using ResumeFiltering.Data.Model;
using ResumeFiltering.Data.Model.Entities;

namespace ResumeFiltering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserRolesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public UserRolesController(AppDbContext context)
        {
            _context = context;
        }

        // GET: api/userroles
        [HttpGet]
        public IActionResult GetUserRoles()
        {
            return Ok(_context.UserRoles.ToList());
        }

        // GET: api/userroles/5
        [HttpGet("{id}")]
        public IActionResult GetUserRole(int id)
        {
            var userRole = _context.UserRoles.Find(id);
            if (userRole == null)
                return NotFound("UserRole not found");

            return Ok(userRole);
        }

        // POST: api/userroles
        [HttpPost]
        public IActionResult AddUserRole(UserRole userRole)
        {
            _context.UserRoles.Add(userRole);
            _context.SaveChanges();
            return Ok("UserRole added successfully!");
        }

        // PUT: api/userroles
        [HttpPut]
        public IActionResult UpdateUserRole(UserRole userRole)
        {
            _context.UserRoles.Update(userRole);
            _context.SaveChanges();
            return Ok("UserRole updated successfully!");
        }

        // DELETE: api/userroles/5
        [HttpDelete("{id}")]
        public IActionResult DeleteUserRole(int id)
        {
            var userRole = _context.UserRoles.Find(id);
            if (userRole == null)
                return NotFound("UserRole not found");

            _context.UserRoles.Remove(userRole);
            _context.SaveChanges();
            return Ok("UserRole deleted successfully!");
        }
    }
}
