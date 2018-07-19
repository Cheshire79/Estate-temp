using System;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeManagement.DAL.Interface;
using KnowledgeManagement.DAL.Interface.Date;

namespace KnowledgeManagement.DAL.Repository
{
    public class StreetReadOnlyRepository : IReadOnlyRepository<Street>
    {
        private IDataContext _db;

        public StreetReadOnlyRepository(IDataContext context)
        {
            _db = context;
        }

        public IQueryable<Street> GetAll()
        {
            return _db.Streets;
        }

        public async Task<Street> GetByIdAsync(int id)
        {
            return await _db.Streets.FindAsync(id);
        }
    }
}
