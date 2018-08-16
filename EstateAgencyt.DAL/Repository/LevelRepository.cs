using System.Linq;
using System.Threading.Tasks;
using EstateAgencyt.DAL.Interface;
using EstateAgencyt.DAL.Interface.Date;

namespace EstateAgencyt.DAL.Repository
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
