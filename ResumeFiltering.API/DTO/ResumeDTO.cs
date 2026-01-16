using ResumeFiltering.Data.Model.Entities;

namespace ResumeFiltering.API.DTO
{
    public class ResumeDTO
    {
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int SkillId { get; set; }
        public string Experience { get; set; }
        public IFormFile Image { get; set; }
    }

    public class ResumeSearchDTO
    {
        public int CategoryId { get; set; }
        public int SkillId { get; set; }
    }
}
