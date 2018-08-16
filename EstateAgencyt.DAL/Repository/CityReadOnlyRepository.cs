using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using EstateAgencyt.DAL.Interface;
using EstateAgencyt.DAL.Interface.Date;

namespace EstateAgencyt.DAL.Repository
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
