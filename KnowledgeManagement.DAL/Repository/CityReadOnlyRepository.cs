using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using KnowledgeManagement.DAL.Interface;
using KnowledgeManagement.DAL.Interface.Date;

namespace KnowledgeManagement.DAL.Repository
{
    public class CityReadOnlyRepository : IReadOnlyRepository<City>
    {
        private IDataContext _db;

        public CityReadOnlyRepository(IDataContext context)
        {
            _db = context;
        }

        public IQueryable<City> GetAll()
        {
            return _db.Cities;
        }

        public async Task<City> GetByIdAsync(int id)
        {
            return await _db.Cities.FindAsync(id);
        }
    }
}
