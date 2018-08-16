using System;
using System.Threading.Tasks;
using EstateAgencyt.DAL.Interface.Date;

namespace EstateAgencyt.DAL.Interface
{
    public interface IUnitOfWork : IDisposable
    {
        IRepository<RealEstate> RealEstates { get; }
        IReadOnlyRepository<City> Cities { get; }
        IReadOnlyRepository<CityDistrict> CityDistricts { get; }
        IReadOnlyRepository<Street> Streets { get; }

        Task SaveAsync();
    }
}
