using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeManagement.BLL.Interface.Date;

namespace KnowledgeManagement.BLL.Interface
{
    public interface IUserService : IDisposable 
    {
        IQueryable<SkillDTO> Skills();
        IQueryable<SubSkillDTO> SubSkills(int skillId);
        IQueryable<SubSkillDTO> SubSkills();
        Task SaveSpecifyingSkill(List<SpecifyingSkillDTO> list, string userId);
        IQueryable<LevelDTO> GetLevels();
        IQueryable<SpecifyingSkillDTO> GetSpecifyingSkills();
        IEnumerable<string> GetUsersIdByCriteria(IEnumerable<SpecifyingSkillForSearchDTO> specifyingSkillsForSearch);
        Task<int> GetIdForMinLevelValue();
    }
}
