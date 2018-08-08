using System;
using System.Data.Entity.Migrations;
using System.Linq;
using System.Threading.Tasks;
using KnowledgeManagement.DAL.Interface;
using KnowledgeManagement.DAL.Interface.Date;

namespace KnowledgeManagement.DAL.Repository
{
    public class RealEstateRepository : IRepository<RealEstate>
    {
        private IDataContext _db;

        public RealEstateRepository(IDataContext context)
        {
            _db = context;
        }

        public IQueryable<RealEstate> GetAll()
        {
            return _db.RealEstates;
        }

        public async Task<RealEstate> GetByIdAsync(int id)
        {
            return await _db.RealEstates.FindAsync(id);
        }

        public void Create(RealEstate realEstate)
        {
            _db.RealEstates.Add(realEstate);
        }


        public async Task Delete(int id)
        {
            var realEstate = await _db.RealEstates.FindAsync(id);
            if (realEstate == null)
                throw new ArgumentException("Real estate was not updated. Cannot find Real estate with Id = " + id);
            _db.RealEstates.Remove(realEstate);
        }

        public async Task Update(RealEstate realEstate)
        {
            var originRealEstate = await _db.RealEstates.FindAsync(realEstate.Id);
            if (originRealEstate == null)
                throw new ArgumentException("Real estate was not updated. Cannot find Real estate with Id = " + realEstate.Id);
            realEstate.RealtorId = originRealEstate.RealtorId;
            realEstate.CreationDate = originRealEstate.CreationDate;
            _db.RealEstates.AddOrUpdate(realEstate);
        }
    }
}
