using System.Diagnostics;
using AutoMapper;
using KnowledgeManagement.BLL.Interface;
using KnowledgeManagement.BLL.Interface.Date;
using KnowledgeManagement.DAL.Interface.Date;

namespace KnowledgeManagement.BLL.Mapper
{

    public class MapperFactory : IMapperFactory
    {
        private IMapper _mapper { get; set; }
        public MapperFactory()
        {
            var config = new MapperConfiguration(cfg =>
            {
                Debug.WriteLine("Mapper KnowledgeManagement");
                cfg.CreateMap<Skill, SkillDTO>();
                cfg.CreateMap<SkillDTO, Skill>();
                cfg.CreateMap<SubSkill, SubSkillDTO>();
                cfg.CreateMap<SubSkillDTO, SubSkill>();


                cfg.CreateMap<City, CityDTO>();
                cfg.CreateMap<CityDTO, City>();
                cfg.CreateMap<CityDistrict, CityDistrictDTO>();
                cfg.CreateMap<CityDistrictDTO, CityDistrict>();
                cfg.CreateMap<Street, StreetDTO>();
                cfg.CreateMap<StreetDTO, Street>();
                cfg.CreateMap<RealEstate, RealEstateDTO>();
                cfg.CreateMap<RealEstateDTO, RealEstate>();

            });
            _mapper = config.CreateMapper();
        }

        public IMapper CreateMapper()
        {
            return _mapper;
        }
    }
}



