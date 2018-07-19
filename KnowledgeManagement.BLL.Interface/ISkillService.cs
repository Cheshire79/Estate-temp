using System;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeManagement.BLL.Interface.Date;

namespace KnowledgeManagement.BLL.Interface
{
    public interface ISkillService : IDisposable
    {
        IQueryable<SkillDTO> GetAll();
        Task<SkillDTO> GetByIdAsync(int id);
        Task Create(SkillDTO skillDTO);
        Task Update(SkillDTO skillDTO);
        Task Delete(int id);
    }
}
