using Microsoft.AspNetCore.Mvc;
using Microsoft.JSInterop.Infrastructure;
using ResumeFiltering.API.DTO;
using ResumeFiltering.Data.Model;
using ResumeFiltering.Data.Model.Entities;

namespace ResumeFiltering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ResumesController : ControllerBase
    {
        private readonly AppDbContext _context;
        private readonly IWebHostEnvironment _env;

        public ResumesController(AppDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: api/Resumes?CategoryId=1&SkillId=2
        [HttpGet]
        public IActionResult GetResumes(int? categoryId, int? skillId)
        {
            var query = _context.Resumes.AsQueryable();

            if (categoryId > 0)
                query = query.Where(r => r.CategoryId == categoryId);

            if (skillId > 0)
                query = query.Where(r => r.SkillId == skillId);

            return Ok(query.ToList());
        }

        // POST: api/Resumes
        [HttpPost]
        public async Task<IActionResult> AddResume([FromForm] ResumeDTO dto)
        {
            if (!ModelState.IsValid)
                return BadRequest(ModelState);

            string fileName = null;

            if (dto.Image != null)
            {
                fileName = $"{Guid.NewGuid()}{Path.GetExtension(dto.Image.FileName)}";
                var folder = Path.Combine(_env.WebRootPath, "Uploads");
                Directory.CreateDirectory(folder);

                var path = Path.Combine(folder, fileName);
                using var stream = new FileStream(path, FileMode.Create);
                await dto.Image.CopyToAsync(stream);
            }

            var resume = new Resume
            {
                Name = dto.Name,
                CategoryId = dto.CategoryId,
                SkillId = dto.SkillId,
                Experience = dto.Experience,
                FilePath = fileName
            };

            _context.Resumes.Add(resume);
            _context.SaveChanges();

            return Ok(new { message = "Resume added successfully" });
        }
    }
}
