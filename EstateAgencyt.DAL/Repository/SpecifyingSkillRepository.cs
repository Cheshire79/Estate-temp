using System;
using System.Linq;
using System.Threading.Tasks;
using EstateAgencyt.DAL.Interface;
using EstateAgencyt.DAL.Interface.Date;

namespace EstateAgencyt.DAL.Repository
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

        public void Update(SpecifyingSkill specifyingSkill)
        {
            throw new NotImplementedException();
        }

        public void Delete(SpecifyingSkill specifyingSkill)
        {
          //  SpecifyingSkill specifyingSkill = await _db.SpecifyingSkills.FindAsync(id);
           // if (specifyingSkill != null)
                _db.SpecifyingSkills.Remove(specifyingSkill);
        }

    }
}
