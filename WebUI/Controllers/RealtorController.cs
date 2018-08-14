using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Web;
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
        private int _pageSize = 8;

        public RealtorController(IRealtorService realtorService, IIdentityService identityService, IMapperFactoryWEB mapperFactory)
        {
            _realtorService = realtorService;
            _identityService = identityService;
            _mapper = mapperFactory.CreateMapperWEB();

        }
        // GET: Realtor
        public async Task<ActionResult> RealEstates()
        {
            ChoosenSearchParametrsForRealtorView searchParameters = new ChoosenSearchParametrsForRealtorView();
			DataAboutRealEstatesForRealtorView dataForRealtor= await PreparedRealEstates(searchParameters);
            return View(dataForRealtor);
        }

        [HttpPost]
        public async Task<ActionResult> RealEstates(ChoosenSearchParametrsForRealtorView searchParametersForRealtor)
        {
			DataAboutRealEstatesForRealtorView dataForRealtor;
            if (ModelState.IsValid)
            {
                try
                {
                    dataForRealtor = await PreparedRealEstates(searchParametersForRealtor);
                    return View(dataForRealtor);
                }
                catch (Exception ex)
                {
                    //todo
                }
            }
            searchParametersForRealtor = new ChoosenSearchParametrsForRealtorView();
            dataForRealtor = await PreparedRealEstates(searchParametersForRealtor);
            return View(dataForRealtor);
        }


        public async Task<ActionResult> CreateRealEstate(string returnUrl)
        {
            DataForManipulateRealEstateView dataForManipulateRealEstate =
                _mapper.Map<DataForManipulateRealEstateDTO, DataForManipulateRealEstateView>(await _realtorService.GetDataForRealEstateCreation());
            dataForManipulateRealEstate.ReturnUrl =
                string.IsNullOrWhiteSpace(returnUrl) ? Url.Action("RealEstates") : returnUrl;
            return View(dataForManipulateRealEstate);
        }

        [HttpPost]
        public async Task<ActionResult> CreateRealEstate(RealEstateToSaveView realEstate, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }
                    realEstate.Image = imageData;
                }
                var realEstatelDTO = _mapper.Map<RealEstateToSaveView, RealEstateDTO>(realEstate);
                string realtorId = HttpContext.User.Identity.GetUserId();
                await _realtorService.Create(realEstatelDTO, realtorId);
            }
            return RedirectToAction("RealEstates"); // todo  returnUrl
        }
        [HttpPost]
        public async Task<ActionResult> MarkAsSold(int? id)
        {
            if (id != null)
                await _realtorService.MarkRealEstateAsSold(id.Value);

            return RedirectToAction("RealEstates"); // todo  returnUrl
        }
        [HttpPost]
        public async Task<ActionResult> DeleteRealEstate(int? id)
        {
            if (id != null)
                await _realtorService.DeleteRealEstate(id.Value);
            return RedirectToAction("RealEstates"); // todo  returnUrl
        }

        public async Task<ActionResult> FillStreet(int districtId = 1)
        {
            var cities = _mapper.Map<List<StreetDropDownItemDTO>, List<StreetDropItemView>>(await _realtorService.GetStreetsForDropDownByDistrctId(districtId));
            return Json(cities, JsonRequestBehavior.AllowGet);
        }
        private async Task<DataAboutRealEstatesForRealtorView> PreparedRealEstates(ChoosenSearchParametrsForRealtorView choosenSearchParameters)
        {
            ChoosenSearchParametersForRealtorDTO choosenSearchParametersDTO = _mapper.Map<ChoosenSearchParametrsForRealtorView, ChoosenSearchParametersForRealtorDTO>
                       (choosenSearchParameters);
            string userId = HttpContext.User.Identity.GetUserId();
            if (!_realtorService.GetRealEstates().Any())
            {
                await _realtorService.SetInitialData(userId);
            }
            
            var users = await _identityService.GetUsers().ProjectTo<UserViewModel>(_mapper.ConfigurationProvider).ToListAsync();

			List<RealEstateForRealtorDTO> realEstatesDTO = await(_realtorService.GetRealEstates(userId, choosenSearchParametersDTO)
                .Skip((choosenSearchParameters.Page - 1) * _pageSize)
                .Take(_pageSize).ToListAsync());

            List<RealEstateForRealtorView> realEstates =
                _mapper.Map<List<RealEstateForRealtorDTO>, List<RealEstateForRealtorView>>(realEstatesDTO);

            realEstates= realEstates.Join(users, (r) => r.RealtorId, (u) => u.Id, (r, u) =>
            {
                r.RealtorName = u.Name;
                r.RealtorEmail = u.Email;
                return r;
            }).ToList();

			DataAboutRealEstatesForRealtorView dataForRealtor = new DataAboutRealEstatesForRealtorView
			{
                ChoosenSearchParametersForRealtor = choosenSearchParameters,
                RealEstates = realEstates,
                SearchParameters = _mapper.Map<DataForSearchParametersDTO, DataForSearchParametersRealtorView>(await _realtorService.InitiateSearchParameters()),
                PagingInfo = new PagingInfo
                {
                    CurrentPage = choosenSearchParameters.Page,
                    ItemsPerPage = _pageSize,
                    TotalItems = await _realtorService.GetRealEstates(userId, choosenSearchParametersDTO).CountAsync()
                }
            };
            return dataForRealtor;
        }

        public async Task<ActionResult> EditRealEstate(int? id, string returnUrl)
        {
            string realtorId = HttpContext.User.Identity.GetUserId();
            EditRealEstateView skillViewModel =
                _mapper.Map<EditRealEstateDTO, EditRealEstateView>(await _realtorService.GetDataForRealEstateEditing(id.Value, realtorId));
            skillViewModel.ReturnUrl =
                string.IsNullOrWhiteSpace(returnUrl) ? Url.Action("RealEstates") : returnUrl;
            return View(skillViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> EditRealEstate(RealEstateToSaveView realEstate, HttpPostedFileBase uploadImage)
        {
            if (ModelState.IsValid)
            {
                if (uploadImage != null)
                {
                    byte[] imageData = null;
                    using (var binaryReader = new BinaryReader(uploadImage.InputStream))
                    {
                        imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
                    }

                    realEstate.Image = imageData;
                }

                var realEstatelDTO = _mapper.Map<RealEstateToSaveView, RealEstateDTO>(realEstate);
                await _realtorService.Save(realEstatelDTO);
            }

            return RedirectToAction("RealEstates"); // todo  returnUrl
        }

        protected override void Dispose(bool disposing)
        {
            _realtorService.Dispose();
            _identityService.Dispose();
            base.Dispose(disposing);
        }
    }
}
