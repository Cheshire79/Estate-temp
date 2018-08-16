using System;
using System.Linq;
using System.Threading.Tasks;
using EstateAgency.BLL.Interface.Date;

namespace EstateAgency.BLL.Interface
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
