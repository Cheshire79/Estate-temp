using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Threading.Tasks;
using System.Web.Mvc;
using AutoMapper;
using AutoMapper.QueryableExtensions;
using Identity.BLL.Interface;
using KnowledgeManagement.BLL.Interface;
using KnowledgeManagement.BLL.Interface.Date;
using Microsoft.AspNet.Identity;
using WebUI.Mapper;
using WebUI.Models;
using WebUI.Models.Realtor;
using WebUI.Models.UsersAndRoles;

namespace WebUI.Controllers
{
    public class RealtorController : Controller
    {
        private IRealtorService _realtorService;
        private IIdentityService _identityService;
        private IMapper _mapper;

        public RealtorController(IRealtorService realtorService, IIdentityService identityService, IMapperFactoryWEB mapperFactory)
        {
            _realtorService = realtorService;
            _identityService = identityService;
            _mapper = mapperFactory.CreateMapperWEB();

        }
        // GET: Realtor
        public async Task<ActionResult> RealEstates()
        {

            string userId = HttpContext.User.Identity.GetUserId();
            if (!_realtorService.GetRealEstates().Any())
            {
                await _realtorService.SetInitialData(userId);
            }

            DataForRealtorView dataForRealtorView =
                new DataForRealtorView
                {
                    SearchParameters = new SearchParametersRealtorView(),
                    SearchParametersForRealtorSave =
                        new SearchParametersForRealtorSave() {DistrictId = -1, RoomNumber = -1}
                };
            dataForRealtorView.SearchParameters.Districts = new List<CityDistrictView>(){new CityDistrictView(){Id = -1,Name="No matter"}};
            dataForRealtorView.SearchParameters.Districts.AddRange(
            _mapper.Map<IEnumerable<CityDistrictDTO>, IEnumerable<CityDistrictView>>
                (await _realtorService.GetKievDistricts().OrderBy(x => x.Name).ToListAsync()));
            dataForRealtorView.SearchParameters.RoomNumber = new List<RoomNumberView>()
            { new RoomNumberView() { Id = -1, Name = "No matter" },
                new RoomNumberView(){Id=1,Name = "1"},
                new RoomNumberView(){Id=2,Name = "2"},
                new RoomNumberView(){Id=3,Name = "3"},
                new RoomNumberView(){Id=4,Name = "4"},
                new RoomNumberView(){Id=5,Name = "5"}
            };
            var users = await (from u in _identityService.GetUsers().ProjectTo<UserViewModel>(_mapper.ConfigurationProvider) select u).ToListAsync();
            IEnumerable<RealEstateForRealtorView> realEstates = await GetRealEstates(userId);

            realEstates.Join(users, (r) => r.RealtorId, (u) => u.Id, (r, u) =>
            {
                r.RealtorName = u.Name;
                r.RealtorEmail = u.Email;
                return r;
            }).ToList();

            dataForRealtorView.RealEstates = realEstates;
            return View(dataForRealtorView);
        }

    

             [HttpPost]
        public async Task<ActionResult> RealEstates(SearchParametersForRealtorSave searchParametersForRealtorSave)
        {
           
            if (ModelState.IsValid)
            {

                string userId = HttpContext.User.Identity.GetUserId();
                if (!_realtorService.GetRealEstates().Any())
                {
                    await _realtorService.SetInitialData(userId);
                }

                DataForRealtorView dataForRealtorView = new DataForRealtorView();
                dataForRealtorView.SearchParametersForRealtorSave = searchParametersForRealtorSave;
                dataForRealtorView.SearchParameters = new SearchParametersRealtorView();
                dataForRealtorView.SearchParameters.Districts = new List<CityDistrictView>() { new CityDistrictView() { Id = -1, Name = "No matter" } };
                dataForRealtorView.SearchParameters.Districts.AddRange(
                    _mapper.Map<IEnumerable<CityDistrictDTO>, IEnumerable<CityDistrictView>>
                        (await _realtorService.GetKievDistricts().OrderBy(x => x.Name).ToListAsync()));
                dataForRealtorView.SearchParameters.RoomNumber = new List<RoomNumberView>()
                { new RoomNumberView() { Id = -1, Name = "No matter" },
                    new RoomNumberView(){Id=1,Name = "1"},
                    new RoomNumberView(){Id=2,Name = "2"},
                    new RoomNumberView(){Id=3,Name = "3"},
                    new RoomNumberView(){Id=4,Name = "4"},
                    new RoomNumberView(){Id=5,Name = "5"}
                };
                var users = await (from u in _identityService.GetUsers().ProjectTo<UserViewModel>(_mapper.ConfigurationProvider) select u).ToListAsync();
                IEnumerable<RealEstateForRealtorView> realEstates = await GetRealEstates(userId);

                realEstates.Join(users, (r) => r.RealtorId, (u) => u.Id, (r, u) =>
                {
                    r.RealtorName = u.Name;
                    r.RealtorEmail = u.Email;
                    return r;
                }).ToList();

                dataForRealtorView.RealEstates = realEstates;
                return View(dataForRealtorView);
            }

           
            return View();
        }


        public ActionResult CreateRealEstate(string returnUrl)
        {
            CreateRealEstateView skillViewModel = new CreateRealEstateView();
            return View(skillViewModel);
        }

        [HttpPost]

        public async Task<ActionResult> CreateRealEstate(CreateRealEstateView model)
        {
            if (ModelState.IsValid)
            {
                var skillDTO = _mapper.Map<CreateRealEstateView, RealEstateDTO>(model);
                //   skillDTO.Id = new RealEstateDTO().Id;
                await _realtorService.Create(skillDTO);
            }
            return RedirectToAction("RealEstates"); // todo  returnUrl
        }

        private async Task<IEnumerable<RealEstateForRealtorView>> GetRealEstates(string userId)
        {
            IEnumerable<RealEstateForRealtorView> realEstates =

                await (from realEstate in _realtorService.GetRealEstates()
                    join street in _realtorService.GetStreets() on realEstate.StreetId equals street.Id
                    join district in _realtorService.GetKievDistricts() on street.CityDistrictId equals district.Id
                    //join user in user1 on realEstate.RealtorId equals user.Id
                    select new RealEstateForRealtorView
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
                        //Image { get; set; }
                        IsSold = realEstate.IsSold,
                        RealtorId = realEstate.RealtorId,
                        // RealtorName = user.Name,
                        //  RealtorEmail = user.Email
                        StreetName = street.Name,
                        DistrictName = district.Name,
                        IsOwner = (userId == realEstate.RealtorId)
                    }).ToListAsync();
            return realEstates;
        }
    }
}