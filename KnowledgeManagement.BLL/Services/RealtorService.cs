using System;
using System.Collections.Generic;
using System.Data.Entity;
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
        private IFactoryRealeEstateOrder _factoryRealeEstateOrder;

        private int _cityKievId;

        public RealtorService(IUnitOfWork unitOfWork, IMapperFactory mapperFactory, IFactoryRealeEstateOrder factoryRealeEstateOrder)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapperFactory.CreateMapper();
            _factoryRealeEstateOrder = factoryRealeEstateOrder;
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
                    Area = 54,
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
                    Area = 154,
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
                    Area = 74,
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
                    Area = 154,
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
            streetInKiev = _unitOfWork.Streets.GetAll().FirstOrDefault(x => x.Name == "Ружинская ул.");
            if (streetInKiev != null)
            {
                _unitOfWork.RealEstates.Create(new RealEstate()
                {
                    Building = "26",
                    Appartment = "9",
                    Floor = 4,
                    Height = 5,
                    Area = 30,
                    Price = 32500.000M,
                    RoomNumber = 1,
                    CreationDate = DateTime.Now,
                    Description = "1 комнатная квартира студио на Нивках, 4/5 этажного, 30 кв.м., улица Ружинська 26 (бывшая Вильгельма Пика). Евроремонт, в пешей доступности 3 станции метро – Нивки, Берестейская, Сырецкая. Квартира продается с мебелью и техникой. Комфортный для проживания район – парковая зона, школы, садики, маркеты, рынок, лес. Также отличный вариант под арендный бизнес.",
                    IsSold = false,
                    StreetId = streetInKiev.Id,
                    RealtorId = realtorId
                }
                );
            }
            streetInKiev = _unitOfWork.Streets.GetAll().FirstOrDefault(x => x.Name == "Победы просп.");
            if (streetInKiev != null)
            {
                _unitOfWork.RealEstates.Create(new RealEstate()
                {
                    Building = "5б",
                    Appartment = "223",
                    Floor = 10,
                    Height = 34,
                    Area = 44,
                    Price = 49500.000M,
                    RoomNumber = 1,
                    CreationDate = DateTime.Now,
                    Description = "Предлагается к продаже 1 к. квартира 45 кв. м на 10-м этаже в доме премиум класса по пр. Победы 5б - ЖК Victory V, застройщик bUd development, запланированная дата ввода в эксплуатацию 3 квартал 2018г. Большой дом на 34 этажа изящной, лаконичной архитектурной формы, расположенный в центральной части Киева",
                    IsSold = false,
                    StreetId = streetInKiev.Id,
                    RealtorId = realtorId
                }
                );
                _unitOfWork.RealEstates.Create(new RealEstate()
                {
                    Building = "26",
                    Appartment = "9",
                    Floor = 18,
                    Height = 32,
                    Area = 44,
                    Price = 88500.000M,
                    RoomNumber = 1,
                    CreationDate = DateTime.Now,
                    Description = "Квартира з ремонтом в новому ЖК 'Smart Plaza Polytech'. ЄВРОРЕМОНТ. Вбудовані меблі, побутова техніка, на підлозі ламінат та кахель, встановлений кондиціонер та бойлер. З вікон відкривається ПАНОРАМА на місто та парк на даху ТРЦ. ",
                    IsSold = false,
                    StreetId = streetInKiev.Id,
                    RealtorId = realtorId
                }
                );
                _unitOfWork.RealEstates.Create(new RealEstate()
                {
                    Building = "67",
                    Appartment = "78",
                    Floor = 2,
                    Height = 16,
                    Area = 48,
                    Price = 32500.000M,
                    RoomNumber = 1,
                    CreationDate = DateTime.Now,
                    Description = "1 комнатная квартира в ЖК ’’Нивки парк’’ с ремонтом (без ремонта 44300$ на 7 этаже 3й дом) 2/16 этажного дома 48/19/13, закрытая охраняемая территория, метро Нивки 5 минут пешком",
                    IsSold = false,
                    StreetId = streetInKiev.Id,
                    RealtorId = realtorId
                }
                );
                _unitOfWork.RealEstates.Create(new RealEstate()
                {
                    Building = "127",
                    Appartment = "23",
                    Floor = 8,
                    Height = 9,
                    Area = 58,
                    Price = 43000.000M,
                    RoomNumber = 3,
                    CreationDate = DateTime.Now,
                    Description = "Продается теплая, светлая квартира на пр.Победы, 127. Метраж: 58/41/7 на 8/9эт.В квартире 3 года назад сделан ремонт, замена всего, установлена встроенная кухня, шкафы, официальный перевод на горячую воду через бойлер, счетчики.",
                    IsSold = false,
                    StreetId = streetInKiev.Id,
                    RealtorId = realtorId
                }
                );
            }
            streetInKiev = _unitOfWork.Streets.GetAll().FirstOrDefault(x => x.Name == "Жмаченко генерала ул.");
            if (streetInKiev != null)
            {
                _unitOfWork.RealEstates.Create(new RealEstate()
                {
                    Building = "28",
                    Appartment = "123",
                    Floor = 19,
                    Height = 26,
                    Area = 68,
                    Price = 78000.000M,
                    RoomNumber = 2,
                    CreationDate = DateTime.Now,
                    Description = "ВЛАДЕЛЕЦ!!! ЖК Автограф. переуступка права собственности. комплекс победитель 2017г. в наминации Комфорт класс. Здача конец 2018г. Консьерж сервисс, три лифта, своя территория, подземный паркинг",
                    IsSold = false,
                    StreetId = streetInKiev.Id,
                    RealtorId = realtorId
                }
                );
                _unitOfWork.RealEstates.Create(new RealEstate()
                {
                    Building = "28",
                    Appartment = "9",
                    Floor = 19,
                    Height = 26,
                    Area = 115,
                    Price = 127000.000M,
                    RoomNumber = 4,
                    CreationDate = DateTime.Now,
                    Description = "ЖК Автограф. Объединение двух квартир 2+1. переуступка права собственности. Аналога в комплексе нет. комплекс победитель 2017г. в наминации Комфорт класс. Здача конец 2018г.",
                    IsSold = false,
                    StreetId = streetInKiev.Id,
                    RealtorId = realtorId
                }
                );

            }
            streetInKiev = _unitOfWork.Streets.GetAll().FirstOrDefault(x => x.Name == "Строителей ул.");
            if (streetInKiev != null)
            {
                _unitOfWork.RealEstates.Create(new RealEstate()
                {
                    Building = "32/2",
                    Appartment = "83",
                    Floor = 5,
                    Height = 5,
                    Area = 64,
                    Price = 42900.000M,
                    RoomNumber = 3,
                    CreationDate = DateTime.Now,
                    Description =
                            "Продаётся 3х квартира. Сталинка. с/у/р 5/5. Состояние под ремонт. Чистый подъезд. До М.Дарница 500 метров. Рядом школа, торговый центры. Хорошая транспортная развяска. Срочная продажа.Торг.",
                    IsSold = false,
                    StreetId = streetInKiev.Id,
                    RealtorId = realtorId
                }
                );
                _unitOfWork.RealEstates.Create(new RealEstate()
                {
                    Building = "39",
                    Appartment = "19",
                    Floor = 3,
                    Height = 4,
                    Area = 43,
                    Price = 394000.000M,
                    RoomNumber = 2,
                    CreationDate = DateTime.Now,
                    Description =
                            "2х комнатная квартира 45м2, ул.Строителей 39, м. Дарница 3 мин пешком, Днепровский район. Сталинка, h=2.9м, площадь 43/24/9м2. 3 этаж, комнаты раздельные, окна во двор, балкон застеклен. Пластиковые окна, кондиционер, жилое состояние( требуется косметический ремонт).",
                    IsSold = false,
                    StreetId = streetInKiev.Id,
                    RealtorId = realtorId
                }
                );
            }


            streetInKiev = _unitOfWork.Streets.GetAll().FirstOrDefault(x => x.Name == "Тампере ул.");
            if (streetInKiev != null)
            {
                _unitOfWork.RealEstates.Create(new RealEstate()
                {
                    Building = "12Б",
                    Appartment = "13",
                    Floor = 2,
                    Height = 5,
                    Area = 41,
                    Price = 37000.000M,
                    RoomNumber = 2,
                    CreationDate = DateTime.Now,
                    Description = "смежно – раздельная квартира, 2 этаж 5 - эт.тома, 41 / 25 / 7кв.м., санузел раздельный, поменяна сантехника, балкон застеклен, стеклопакеты, кафель,",
                    IsSold = false,
                    StreetId = streetInKiev.Id,
                    RealtorId = realtorId
                }
                );
                _unitOfWork.RealEstates.Create(new RealEstate()
                {
                    Building = "8А",
                    Appartment = "29",
                    Floor = 1,
                    Height = 5,
                    Area = 49,
                    Price = 360000.000M,
                    RoomNumber = 1,
                    CreationDate = DateTime.Now,
                    Description = "Без комиссии!!! О квартире.Общая площадь 49 м2, большая комната - 18 м2 и просторная кухня – 10 м2.Две лоджии(4м2 и 2, 5м2), в одной из них кладовка.Лоджии опоясывают квартиру, создавая дополнительную воздушную подушку.Благодаря этому зимой в квартире тепло, а летом прохладно.На полу – паркет.Шкаф - купе.В ванной установлен бойлер на 50л. ",
                    IsSold = false,
                    StreetId = streetInKiev.Id,
                    RealtorId = realtorId
                }
                );
                _unitOfWork.RealEstates.Create(new RealEstate()
                {
                    Building = "11",
                    Appartment = "49",
                    Floor = 2,
                    Height = 5,
                    Area = 49,
                    Price = 320000.000M,
                    RoomNumber = 2,
                    CreationDate = DateTime.Now,
                    Description = "Срочно продам свою двухкомнатную квартиру с ремонтом, мебелью и всей бытовой техникой. На полу паркет, интернет кабельное ТВ. Квартира находиться на высоком 1 этаже в доме после капитального ремонта на улице. ",
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
        public IQueryable<RealEstateDTO> GetRealEstates(ChoosenSearchParametersForRealtorDTO parameters)
        {
            if (_cityKievId == 0)
            {
                throw new ArgumentException("Cannot find Kiev. Working just for area of Kiev city.");
            }
            var order = _factoryRealeEstateOrder.Create(parameters.SortOrder);
            return _unitOfWork.RealEstates.GetAll().ProjectTo<RealEstateDTO>(_mapper.ConfigurationProvider);
        }
        public IQueryable<StreetDTO> GetStreets()
        {
            return _unitOfWork.Streets.GetAll().ProjectTo<StreetDTO>(_mapper.ConfigurationProvider);
        }

        public async Task <List<StreetDTO>> GetStreetsByDistrctId(int districtId)
        {

            List<StreetDTO> streets =(await _unitOfWork.Streets.GetAll().Where(x=>x.CityDistrictId==districtId).ProjectTo<StreetDTO>(_mapper.ConfigurationProvider).ToListAsync());
            if (streets.Count == 0)
                streets.Add(new StreetDTO() { Id = -1, Name = "Empty List" });
            return streets;
        }
        public async Task Create(RealEstateDTO realEstateDTO)
        {
            var realEstate = _mapper.Map<RealEstateDTO, RealEstate>(realEstateDTO);
            realEstate.Id = new RealEstate().Id;
            _unitOfWork.RealEstates.Create(realEstate);
            await _unitOfWork.SaveAsync();
        }

        public IQueryable<RealEstateForRealtor> GetRealEstates(string userId, ChoosenSearchParametersForRealtorDTO parameters)
        {
            IQueryable<RealEstateForRealtor> realEstates =

                 (from realEstate in FilteredRealEstates(GetRealEstates(parameters), parameters, userId)
                  join street in GetStreets() on realEstate.StreetId equals street.Id
                  join district in FilteredDistricts(GetKievDistricts(), parameters) on street.CityDistrictId equals district.Id
                  select new RealEstateForRealtor
                  {
                      Id = realEstate.Id,
                      Building = realEstate.Building,
                      Appartment = realEstate.Appartment,
                      Floor = realEstate.Floor,
                      Height = realEstate.Height,
                      Area = realEstate.Area,
                      Price = realEstate.Price,
                      RoomNumber = realEstate.RoomNumber,
                      CreationDate = realEstate.CreationDate,
                      Description = realEstate.Description,
                      IsSold = realEstate.IsSold,
                      RealtorId = realEstate.RealtorId,
                      StreetName = street.Name,
                      DistrictName = district.Name,
                      IsOwner = (userId == realEstate.RealtorId)
                  });
            var order = _factoryRealeEstateOrder.Create(parameters.SortOrder);
            return order.Order(realEstates);
        }

        public async Task<DataForSearchParametersDTO> InitiateSearchParameters()
        {
            var searchParameters = new DataForSearchParametersDTO();
            searchParameters.Districts = new List<CityDistrictDTO>() { new CityDistrictDTO() { Id = -1, Name = "No matter" } };
            searchParameters.Districts.AddRange(await GetKievDistricts().OrderBy(x => x.Name).ToListAsync());

            searchParameters.RoomNumbers = new List<RoomNumberDTO>()
                { new RoomNumberDTO() { Id = -1, Name = "No matter" },
                    new RoomNumberDTO(){Id=1,Name = "1"},
                    new RoomNumberDTO(){Id=2,Name = "2"},
                    new RoomNumberDTO(){Id=3,Name = "3"},
                    new RoomNumberDTO(){Id=4,Name = "4"},
                    new RoomNumberDTO(){Id=5,Name = "5"}
                };

            searchParameters.SortOrders = new List<SortOrderDTO>()
                {
                    new SortOrderDTO(){Id=1,Name = "By date listed (new – old)"},
                    new SortOrderDTO(){Id=2,Name = "By date listed (old – new)"},
                    new SortOrderDTO(){Id=3,Name = "By price (min – max)"},
                    new SortOrderDTO(){Id=4,Name = "By price (max – min)"},
                    new SortOrderDTO(){Id=5,Name = "Total area (min – max)"},
                    new SortOrderDTO(){Id=6,Name = "Total area (max – min)"}
                };
            return searchParameters;
        }
        public async Task<DataForCreateRealEstateDTO> InitiateDataForRealEstateCreation()
        {
            var searchParameters = new DataForCreateRealEstateDTO();

            searchParameters.Districts = await GetKievDistricts().OrderBy(x => x.Name).ToListAsync();
            if (searchParameters.Districts.Count == 0)
                searchParameters.Districts.Add(new CityDistrictDTO(){ Id = -1, Name = "Empty List" });
            int fisrtDistrictId = searchParameters.Districts.First().Id;
            searchParameters.Streets = await _unitOfWork.Streets.GetAll().Where(x => x.CityDistrictId == fisrtDistrictId).ProjectTo<StreetDTO>(_mapper.ConfigurationProvider).OrderBy(x => x.Name).ToListAsync();
            if (searchParameters.Streets.Count==0)
                searchParameters.Streets.Add(new StreetDTO(){Id = -1,Name="Empty List"});
            searchParameters.RoomNumbers = new List<RoomNumberDTO>()
            {
                new RoomNumberDTO(){Id=1,Name = "1"},
                new RoomNumberDTO(){Id=2,Name = "2"},
                new RoomNumberDTO(){Id=3,Name = "3"},
                new RoomNumberDTO(){Id=4,Name = "4"},
                new RoomNumberDTO(){Id=5,Name = "5"}
            };
            return searchParameters;
        }

        private IQueryable<CityDistrictDTO> FilteredDistricts(IQueryable<CityDistrictDTO> districts, ChoosenSearchParametersForRealtorDTO parameters)
        {
            return districts.Where(x => (parameters.DistrictId != -1 && x.Id == parameters.DistrictId) || parameters.DistrictId == -1);
        }
        private IQueryable<RealEstateDTO> FilteredRealEstates(IQueryable<RealEstateDTO> realEstates, ChoosenSearchParametersForRealtorDTO parameters, string userId)
        {
            return realEstates.Where(x => (parameters.RoomNumber != -1 && x.RoomNumber == parameters.RoomNumber) || parameters.RoomNumber == -1)
                                   .Where(x => (!parameters.AreaFromIgnored && x.Area >= parameters.AreaFrom) || parameters.AreaFromIgnored)
                                   .Where(x => (!parameters.AreaToIgnored && x.Area <= parameters.AreaTo) || parameters.AreaToIgnored)
                                   .Where(x => (!parameters.PriceFromIgnored && x.Price >= parameters.PriceFrom) || parameters.PriceFromIgnored)
                                   .Where(x => (!parameters.PriceToIgnored && x.Price <= parameters.PriceTo) || parameters.PriceToIgnored)
                                .Where(x => (!parameters.HeightFromIgnored && x.Height >= parameters.HeightFrom) || parameters.HeightFromIgnored)
                                .Where(x => (!parameters.HeightToIgnored && x.Height <= parameters.HeightTo) || parameters.HeightToIgnored)
                                .Where(x => (!parameters.FloorFromIgnored && x.Floor >= parameters.FloorFrom) || parameters.FloorFromIgnored)
                                .Where(x => (!parameters.FloorToIgnored && x.Floor <= parameters.FloorTo) || parameters.FloorToIgnored)
                                .Where(x => (parameters.ShowOnlyMyOwn && x.RealtorId == userId) || !parameters.ShowOnlyMyOwn)
                               ;
        }
    }
}
