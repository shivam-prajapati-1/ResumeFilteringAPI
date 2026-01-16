using Microsoft.AspNetCore.Mvc;
using ResumeFiltering.Data.Model;
using ResumeFiltering.Data.Model.Entities;

namespace ResumeFiltering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class RolesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public RolesController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetRoles()
        {
            return Ok(_context.Roles.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetRole(int id)
        {
            var role = _context.Roles.Find(id);
            if (role == null)
                return NotFound("Role not found");

            return Ok(role);
        }

        [HttpPost]
        public IActionResult AddRole(Role role)
        {
            _context.Roles.Add(role);
            _context.SaveChanges();
            return Ok("Role added successfully!");
        }

        [HttpPut]
        public IActionResult UpdateRole(Role role)
        {
            _context.Roles.Update(role);
            _context.SaveChanges();
            return Ok("Role updated successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteRole(int id)
        {
            var role = _context.Roles.Find(id);
            _context.Roles.Remove(role);
            _context.SaveChanges();
            return Ok("Role deleted successfully!");
        }
    }

}
