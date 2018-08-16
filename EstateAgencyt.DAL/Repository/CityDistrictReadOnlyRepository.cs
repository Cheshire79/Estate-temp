using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EstateAgencyt.DAL.Interface;
using EstateAgencyt.DAL.Interface.Date;

namespace EstateAgencyt.DAL.Repository
{
    public class CityDistrictReadOnlyRepository : IReadOnlyRepository<CityDistrict>
    {
        private IDataContext _db;

        public CityDistrictReadOnlyRepository(IDataContext context)
        {
            _db = context;
        }

        public IQueryable<CityDistrict> GetAll()
        {
            return _db.CityDistricts;
        }

        public async Task<CityDistrict> GetByIdAsync(int id)
        {
            return await _db.CityDistricts.FindAsync(id);
        }
    }
}
