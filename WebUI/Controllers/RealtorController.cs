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
			DataForRealtorView dataForRealtorView = await PreparedRealEstates(searchParameters);
			return View(dataForRealtorView);
		}

		[HttpPost]
		public async Task<ActionResult> RealEstates(ChoosenSearchParametrsForRealtorView searchParametersForRealtor)
		{
			DataForRealtorView dataForRealtorView;

			if (ModelState.IsValid)
			{
				try
				{
					dataForRealtorView = await PreparedRealEstates(searchParametersForRealtor);
					return View(dataForRealtorView);
				}
				catch (Exception ex)
				{
					//todo
				}
			}

			searchParametersForRealtor = new ChoosenSearchParametrsForRealtorView();
			dataForRealtorView = await PreparedRealEstates(searchParametersForRealtor);

			return View(dataForRealtorView);
		}


		public async Task<ActionResult> CreateRealEstate(string returnUrl)
		{
			DataForCreateRealEstateView skillViewModel =
				_mapper.Map<DataForCreateRealEstateDTO, DataForCreateRealEstateView>(await _realtorService.InitiateDataForRealEstateCreation());
			//todo
			return View(skillViewModel);
		}

		[HttpPost]
		public async Task<ActionResult> CreateRealEstate(RealEstateToSaveView realEstate, HttpPostedFileBase uploadImage)
		{
			if (ModelState.IsValid)
			{
				if (uploadImage != null)
				{ 
					byte[] imageData = null;
				// считываем переданный файл в массив байтов
				using (var binaryReader = new BinaryReader(uploadImage.InputStream))
				{
					imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
				}
					// установка массива байтов
					realEstate.Image = imageData;
			}
					var realEstatelDTO = _mapper.Map<RealEstateToSaveView, RealEstateDTO>(realEstate);
				//   skillDTO.Id = new RealEstateDTO().Id;
				string realtorId = HttpContext.User.Identity.GetUserId();
				await _realtorService.Create(realEstatelDTO, realtorId);
			}
			return RedirectToAction("RealEstates"); // todo  returnUrl
		}
		[HttpPost]
		public async Task<ActionResult> MarkAsSold(int? id)
		{
			if (id!=null)
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
			var cities = _mapper.Map<List<StreetDTO>, List<StreetView>>(await _realtorService.GetStreetsByDistrctId(districtId));
			return Json(cities, JsonRequestBehavior.AllowGet);
		}
		private async Task<DataForRealtorView> PreparedRealEstates(ChoosenSearchParametrsForRealtorView choosenSearchParameters)
		{
			ChoosenSearchParametersForRealtorDTO choosenSearchParametersDTO = _mapper.Map<ChoosenSearchParametrsForRealtorView, ChoosenSearchParametersForRealtorDTO>
					   (choosenSearchParameters);

			string userId = HttpContext.User.Identity.GetUserId();
			if (!_realtorService.GetRealEstates().Any())
			{
				await _realtorService.SetInitialData(userId);
			}

			var users = await (from u in _identityService.GetUsers().ProjectTo<UserViewModel>(_mapper.ConfigurationProvider) select u).ToListAsync();

			List<RealEstateForRealtorView> realEstates = _mapper.Map<List<RealEstateForRealtor>, List<RealEstateForRealtorView>>(
				await (_realtorService.GetRealEstates(userId, choosenSearchParametersDTO)).ToListAsync());

			realEstates.Join(users, (r) => r.RealtorId, (u) => u.Id, (r, u) =>
			{
				r.RealtorName = u.Name;
				r.RealtorEmail = u.Email;
				return r;
			});

			DataForRealtorView dataForRealtorView = new DataForRealtorView
			{
				ChoosenSearchParametersForRealtor = choosenSearchParameters,
				RealEstates = realEstates,
				SearchParameters = _mapper.Map<DataForSearchParametersDTO, DataForSearchParametersRealtorView>(await _realtorService.InitiateSearchParameters())
			};
			return dataForRealtorView;
		}



		public async Task<ActionResult> CreatePic()
		{
			DataForCreateRealEstateView skillViewModel =
				_mapper.Map<DataForCreateRealEstateDTO, DataForCreateRealEstateView>(await _realtorService.InitiateDataForRealEstateCreation());
			//todo
			return View(skillViewModel);
		}

		[HttpPost]
		public ActionResult CreatePic( HttpPostedFileBase uploadImage)
		{
			if (ModelState.IsValid && uploadImage != null)
			{
				byte[] imageData = null;
				// считываем переданный файл в массив байтов
				using (var binaryReader = new BinaryReader(uploadImage.InputStream))
				{
					imageData = binaryReader.ReadBytes(uploadImage.ContentLength);
				}
				// установка массива байтов
				//pic.Image = imageData;



				return RedirectToAction("Index");
			}
			return View();
		}
	}
}
