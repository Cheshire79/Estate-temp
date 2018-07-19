using System.Linq;
using System.Threading.Tasks;
using KnowledgeManagement.DAL.Interface;
using KnowledgeManagement.DAL.Interface.Date;

namespace KnowledgeManagement.DAL.Repository
{
    public class LevelReadOnlyRepository : IReadOnlyRepository<Level>
    {
        private IDataContext _db;

        public LevelReadOnlyRepository(IDataContext context)
        {
            _db = context;
        }

        public IQueryable<Level> GetAll()
        {
            return _db.Levels;
        }
        
        public async Task<Level> GetByIdAsync(int id)
        {
            return await _db.Levels.FindAsync(id);
        }
    }
}
