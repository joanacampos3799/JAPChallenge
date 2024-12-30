using JAPChallenge.Enums;
using JAPChallenge.Models;
using JAPChallenge.Repositories;
using JAPChallenge.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace JAPChallenge.Controllers
{
    public class RentingController : Controller
    {
        private readonly ILogger<RentingController> _logger;

        private IRentingRepository _rentingRepository;
        private IClientRepository _clientRepository;
        private IVehicleRepository _vehicleRepository;

        public RentingController(ILogger<RentingController> logger, IRentingRepository rentingRepository, IClientRepository clientRepository, IVehicleRepository vehicleRepository)
        {
            _logger = logger;
            _rentingRepository = rentingRepository;
            _clientRepository = clientRepository;
            _vehicleRepository = vehicleRepository;
        }

        [HttpGet("/Renting")]
        public IActionResult Index()
        {
            var rentings = _rentingRepository.ListRentings();

            ViewBag.Clients = _clientRepository.ListClients()
                         .Select(c => new SelectListItem
                         {
                             Value = c.Id.ToString(),
                             Text = c.FullName
                         }).ToList();

            ViewBag.Vehicles = _vehicleRepository.ListVehicles()
                                  .Select(v => new SelectListItem
                                  {
                                      Value = v.Id.ToString(),
                                      Text = $"{v.Brand} {v.Model} ({v.Registration})"
                                  }).ToList();
            return View("RentingsPage", rentings);
        }

        [HttpPost]

        public IActionResult RegisterRenting(RentingModel renting)
        {
            
                _rentingRepository.AddRenting(renting);
                return RedirectToAction("Index");
            
        }
    }
}
