using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using ResumeFiltering.API.DTO;
using ResumeFiltering.Data.Model;
using ResumeFiltering.Data.Model.Entities;

namespace ResumeFiltering.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class JobsController : ControllerBase
    {
        private readonly AppDbContext _context;

        public JobsController(AppDbContext context)
        {
            _context = context;
        }

        [HttpPost]
        public IActionResult AddJob(JobDTO jobDTO)
        {
            Job job = new Job
            {
                Title = jobDTO.Title,
                CategoryId = jobDTO.CategoryId
            };

            _context.Jobs.Add(job);
            _context.SaveChanges();

            foreach (var skillId in jobDTO.SkillIds)
            {
                JobSkill jobSkill = new JobSkill
                {
                    JobId = job.Id,
                    SkillId = skillId
                };
                _context.JobSkills.Add(jobSkill);
                _context.SaveChanges();
            }


            return Ok("Job added successfully!");
        }

    }

}
