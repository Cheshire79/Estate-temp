using System;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeManagement.DAL.Interface;
using KnowledgeManagement.DAL.Interface.Date;

namespace KnowledgeManagement.DAL.Repository
{

    public class SpecifyingSkillRepository : IRepository<SpecifyingSkill>
    {
        private IDataContext _db;

        public SpecifyingSkillRepository(IDataContext context)
        {
            _db = context;
        }

        public IQueryable<SpecifyingSkill> GetAll()
        {
            return _db.SpecifyingSkills;
        }

        public async Task<SpecifyingSkill> GetByIdAsync(int id)
        {
            return await _db.SpecifyingSkills.FindAsync(id);
        }

        public void Create(SpecifyingSkill specifyingSkill)
        {
            _db.SpecifyingSkills.Add(specifyingSkill);
        }

        public Task Update(SpecifyingSkill specifyingSkill)
        {
            throw new NotImplementedException();
        }

        public async Task Delete(int id)
        {
            SpecifyingSkill specifyingSkill = await _db.SpecifyingSkills.FindAsync(id);
            if (specifyingSkill != null)
                _db.SpecifyingSkills.Remove(specifyingSkill);
        }

    }
}
