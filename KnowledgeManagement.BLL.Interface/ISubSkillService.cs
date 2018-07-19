using System;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeManagement.BLL.Interface.Date;

namespace KnowledgeManagement.BLL.Interface
{
    public interface ISubSkillService : IDisposable 
    {
        IQueryable<SubSkillDTO> GetAll();
        Task<SubSkillDTO> GetByIdAsync(int id);
        Task Create(SubSkillDTO subSkillDTO);
        Task Update(SubSkillDTO subSkillDTO);
        Task Delete(int id);
        Task<IQueryable<SubSkillDTO>> GetSubSkillBySkillsId(int id);
    }
}
