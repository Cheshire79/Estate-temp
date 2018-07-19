using System;
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

        public async Task Update(RealEstate realEstate)
        {
            var originRealEstate = await _db.RealEstates.FindAsync(realEstate.Id);
            if (originRealEstate == null)
                throw new ArgumentException("Real estate was not updated. Cannot find Real estate with Id = " + realEstate.Id);
            originRealEstate.Appartment = realEstate.Appartment;
            originRealEstate.Area = realEstate.Area;
            originRealEstate.Building = realEstate.Building;
            //originRealEstate.CreationDate = realEstate.;
            originRealEstate.Description = realEstate.Description;
            originRealEstate.Floor = realEstate.Floor;
            originRealEstate.Height = realEstate.Height;
            originRealEstate.Image = realEstate.Image;
            originRealEstate.Price = realEstate.Price;
            //originRealEstate.RealtorId = realEstate.RealtorId;
            originRealEstate.RoomNumber = realEstate.RoomNumber;
            originRealEstate.StreetId = realEstate.StreetId;
        }

        public async Task Delete(int id)
        {
            var realEstate = await _db.RealEstates.FindAsync(id);
            if (realEstate == null)
                throw new ArgumentException("Real estate was not updated. Cannot find Real estate with Id = " + id);

            _db.RealEstates.Remove(realEstate);
        }
    }
}
