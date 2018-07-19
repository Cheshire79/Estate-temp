using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using KnowledgeManagement.BLL.Interface;
using KnowledgeManagement.BLL.Interface.Date;
using KnowledgeManagement.DAL.Interface;
using KnowledgeManagement.DAL.Interface.Date;

namespace KnowledgeManagement.BLL.Services
{
    public class RealtorService : IRealtorService
    {
        private IUnitOfWork _unitOfWork;
        private IMapper _mapper;

        private int _cityKievId;

        public RealtorService(IUnitOfWork unitOfWork, IMapperFactory mapperFactory)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapperFactory.CreateMapper();
            var cityKiev = _unitOfWork.Cities.GetAll().FirstOrDefault(x => x.Name == "Киев");
            if (cityKiev != null)
                _cityKievId = cityKiev.Id;

        }

        public async Task SetInitialData(string realtorId)
        {
            var streetInKiev = _unitOfWork.Streets.GetAll().FirstOrDefault(x => x.Name == "Чорновола");
            if (streetInKiev != null)
            {
                _unitOfWork.RealEstates.Create(new RealEstate()
                    {
                        Building = "33/30",
                        Appartment = "24",
                        Floor = 6,
                        Height = 9,
                        Area = 54.7f,
                        Price = 36.000M,
                        RoomNumber = 2,
                        CreationDate = DateTime.Now,
                        Description = "test",
                        IsSold = false,
                        StreetId = streetInKiev.Id,
                        RealtorId = realtorId
                    }
                );
                _unitOfWork.RealEstates.Create(new RealEstate()
                    {
                        Building = "3",
                        Appartment = "4",
                        Floor = 2,
                        Height = 19,
                        Area = 154.7f,
                        Price = 56.000M,
                        RoomNumber = 2,
                        CreationDate = DateTime.Now,
                        Description = "test",
                        IsSold = false,
                        StreetId = streetInKiev.Id,
                        RealtorId = realtorId
                    }
                );
            }
             streetInKiev = _unitOfWork.Streets.GetAll().FirstOrDefault(x => x.Name == "Саксаганского");
            if (streetInKiev != null)
            {
                _unitOfWork.RealEstates.Create(new RealEstate()
                    {
                        Building = "30",
                        Appartment = "14",
                        Floor = 2,
                        Height = 4,
                        Area = 74.7f,
                        Price = 86.000M,
                        RoomNumber = 3,
                        CreationDate = DateTime.Now,
                        Description = "test 2",
                        IsSold = false,
                        StreetId = streetInKiev.Id,
                        RealtorId = realtorId
                    }
                );
                _unitOfWork.RealEstates.Create(new RealEstate()
                    {
                        Building = "123",
                        Appartment = "94",
                        Floor = 12,
                        Height = 19,
                        Area = 154.7f,
                        Price = 516.000M,
                        RoomNumber = 4,
                        CreationDate = DateTime.Now,
                        Description = "test",
                        IsSold = false,
                        StreetId = streetInKiev.Id,
                        RealtorId = realtorId
                    }
                );
            }
            await _unitOfWork.SaveAsync();
        }
        public IQueryable<CityDistrictDTO> GetKievDistricts()// just for Kiev city
        {
            if (_cityKievId == 0)
            {
                throw new ArgumentException("Cannot find Kiev. Working just for area of Kiev city.");
            }

            var c = _unitOfWork.CityDistricts.GetAll().ToList();
            return _unitOfWork.CityDistricts.GetAll().Where(x => x.CityId == _cityKievId).ProjectTo<CityDistrictDTO>(_mapper.ConfigurationProvider);
        }
        public IQueryable<RealEstateDTO> GetRealEstates()
        {
            if (_cityKievId == 0)
            {
                throw new ArgumentException("Cannot find Kiev. Working just for area of Kiev city.");
            }
            return _unitOfWork.RealEstates.GetAll().ProjectTo<RealEstateDTO>(_mapper.ConfigurationProvider);
        }
    }
}
