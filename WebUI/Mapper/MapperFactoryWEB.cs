
using AutoMapper;
using Identity.BLL.Interface.Data;
using KnowledgeManagement.BLL.Interface.Date;
using System;
using WebUI.Models;
using WebUI.Models.KnowledgeManagement;
using WebUI.Models.Realtor;
using WebUI.Models.UsersAndRoles;
using WebUI.Models.UsersSearch;

namespace WebUI.Mapper
{
    public class MapperFactoryWEB : IMapperFactoryWEB
    {
        private IMapper _mapper { get; set; }
        public MapperFactoryWEB()
        {
            var config = new MapperConfiguration(cfg =>
            {
                // source , destination
                // when do i need directly set up mapping ? (because sometime i cam miss and it still works)
                cfg.CreateMap<SpecifyingSkillForSearchSaveModel, SpecifyingSkillForSearchDTO>();
                cfg.CreateMap<User, UserViewModel>();
                cfg.CreateMap<Role, RoleViewModel>();

                cfg.CreateMap<UserLoginViewModel, User>().ForMember(x => x.Name,
                    x => x.MapFrom(m => m.UserName)).ForMember(x => x.Password,
                    x => x.MapFrom(m => m.Password));

                cfg.CreateMap<UserRegisterViewModel, User>().ForMember(x => x.Name,
                    x => x.MapFrom(m => m.UserName)).ForMember(x => x.Password,
                    x => x.MapFrom(m => m.Password));
                cfg.CreateMap<SkillDTO, SkillViewModel>();
                cfg.CreateMap<SkillViewModel, SkillDTO>();
                cfg.CreateMap<SubSkillDTO, SubSkillViewModel>();
                cfg.CreateMap<SubSkillViewModel, SubSkillDTO>();

                cfg.CreateMap<LevelViewModel, LevelDTO>();

                cfg.CreateMap<CityDistrictView, CityDistrictDTO>();
                cfg.CreateMap<CityDistrictDTO, CityDistrictView>();

                cfg.CreateMap<ChoosenSearchParametrsForRealtorView, ChoosenSearchParametersForRealtorDTO>()

                .ForMember(x => x.AreaFrom, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.AreaFrom) ? -1 : Int32.Parse(s.AreaFrom)))
                .ForMember(x => x.AreaFromIgnored, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.AreaFrom) ? true : false))

                .ForMember(x => x.AreaTo, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.AreaTo) ? -1 : Int32.Parse(s.AreaTo)))
                .ForMember(x => x.AreaToIgnored, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.AreaTo) ? true : false))

                .ForMember(x => x.FloorFrom, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.FloorFrom) ? -1 : Int32.Parse(s.FloorFrom)))
                .ForMember(x => x.FloorFromIgnored, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.FloorFrom) ? true : false))

                .ForMember(x => x.FloorTo, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.FloorTo) ? -1 : Int32.Parse(s.FloorTo)))
                .ForMember(x => x.FloorToIgnored, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.FloorTo) ? true : false))

                .ForMember(x => x.HeightFrom, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.HeightFrom) ? -1 : Int32.Parse(s.HeightFrom)))
                .ForMember(x => x.HeightFromIgnored, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.HeightFrom) ? true : false))

                .ForMember(x => x.HeightTo, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.HeightTo) ? -1 : Int32.Parse(s.HeightTo)))
                .ForMember(x => x.HeightToIgnored, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.HeightTo) ? true : false))

                .ForMember(x => x.PriceFrom, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.PriceFrom) ? -1 : Decimal.Parse(s.PriceFrom)))
                .ForMember(x => x.PriceFromIgnored, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.PriceFrom) ? true : false))

                .ForMember(x => x.PriceTo, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.PriceTo) ? -1 : Decimal.Parse(s.PriceTo)))
                .ForMember(x => x.PriceToIgnored, o =>
                    o.MapFrom(s => string.IsNullOrWhiteSpace(s.PriceTo) ? true : false)
                );

                cfg.CreateMap<RealEstateForRealtor, RealEstateForRealtorView>();

                cfg.CreateMap<DataForSearchParametersRealtorView, DataForSearchParametersDTO>();

            });
            _mapper = config.CreateMapper();
        }

        public IMapper CreateMapperWEB()
        {
            return _mapper;
        }
    }
}



