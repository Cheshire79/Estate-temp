
namespace KnowledgeManagement.DAL.Interface.Date
{
    public class SpecifyingSkill
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public int LevelId { get; set; }
        public int SubSkillId { get; set; }
        public  Level Levels { get; set; }
        public  SubSkill SubSkills { get; set; }
    }
}
