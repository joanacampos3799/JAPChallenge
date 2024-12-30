using JAPChallenge.Models;
using JAPChallenge.Repositories;
using JAPChallenge.RepositoryInterfaces;
using Microsoft.AspNetCore.Mvc;


namespace JAPChallenge.Controllers
{
    public class ClientController : Controller
    {
        private readonly ILogger<ClientController> _logger;

        private IClientRepository _clientRepository;

        public ClientController(ILogger<ClientController> logger, IClientRepository clientRepository)
        {
            _logger = logger;
            _clientRepository = clientRepository;
        }

        [HttpGet("/Clients")]
        public IActionResult Index()
        {
            var clients = _clientRepository.ListClients();

            return View("ClientsPage",clients);
        }
            [HttpPost]

        public IActionResult RegisterClient(ClientModel client)
        {
            
            _clientRepository.AddClient(client);
            return RedirectToAction("Index");

        }

        [HttpGet]
        public JsonResult CheckEmail(string email)
        {
            var isUnique = !_clientRepository.ListClients().Any(c => c.Email == email);
            return Json(isUnique);
        }

    }
}
