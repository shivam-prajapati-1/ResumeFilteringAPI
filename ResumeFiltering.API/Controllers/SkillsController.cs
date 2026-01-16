using Microsoft.AspNetCore.Mvc;
using ResumeFiltering.Data.Model;
using ResumeFiltering.Data.Model.Entities;

namespace ResumeFiltering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SkillsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SkillsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetSkills()
        {
            return Ok(_context.Skills.ToList());
        }

        [HttpGet("{id}")]
        public IActionResult GetSkill(int id)
        {
            var skill = _context.Skills.Find(id);
            if (skill == null)
                return NotFound("Skill not found");

            return Ok(skill);
        }

        [HttpPost]
        public IActionResult AddSkill(Skill skill)
        {
            _context.Skills.Add(skill);
            _context.SaveChanges();
            return Ok("Skill added successfully!");
        }

        [HttpPut]
        public IActionResult UpdateSkill(Skill skill)
        {
            _context.Skills.Update(skill);
            _context.SaveChanges();
            return Ok("Skill updated successfully!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteSkill(int id)
        {
            var skill = _context.Skills.Find(id);
            _context.Skills.Remove(skill);
            _context.SaveChanges();
            return Ok("Skill deleted successfully!");
        }
    }
}
