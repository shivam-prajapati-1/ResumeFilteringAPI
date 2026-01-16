using ResumeFiltering.Data.Model.Entities;

namespace ResumeFiltering.API.DTO
{
    public class JobDTO
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public int CategoryId { get; set; }
        public List<int> SkillIds { get; set; }
    }
}
