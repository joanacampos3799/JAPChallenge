using JAPChallenge.Models;
using JAPChallenge.Repositories;
using JAPChallenge.Enums;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using JAPChallenge.RepositoryInterfaces;

namespace JAPChallenge.Controllers
{
    public class VehicleController : Controller
    {
        private readonly ILogger<VehicleController> _logger;

        private IVehicleRepository _vehicleRepository;

        public VehicleController(ILogger<VehicleController> logger, IVehicleRepository vehicleRepository)
        {
            _logger = logger;
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet("/vehicles")]
        public IActionResult Index()
        {
            var vehicles = _vehicleRepository.ListVehicles();
            ViewBag.FuelTypes = Enum.GetValues(typeof(FuelTypeEnum))
                            .Cast<FuelTypeEnum>()
                            .Select(ft => new SelectListItem
                            {
                                Value = ft.ToString(),
                                Text = ft.ToString()
                            }).ToList();
            return View("VehiclesPage", vehicles ?? new List<VehicleViewModel>());
        }

        [HttpPost]
        public IActionResult RegisterVehicle(VehicleViewModel vehicle)
        {
            
            _vehicleRepository.AddVehicle(vehicle);
            return RedirectToAction("Index");
            
           

        }

        [HttpGet]
        public JsonResult CheckLicencePlate(string licencePlate)
        {
            var isUnique = !_vehicleRepository.ListVehicles().Any(v => v.Registration == licencePlate);
            return Json(isUnique);
        }

    }
}
