namespace ResumeFiltering.Data.Model.Entities
{
    public class Resume
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int CategoryId { get; set; }
        public int SkillId { get; set; }
        public string Experience { get; set; }
        public string FilePath { get; set; }
    }
}
