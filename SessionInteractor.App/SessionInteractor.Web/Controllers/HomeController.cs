using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using SessionInteractor.Web.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using SessionInteractor.Adapters.Input;
using SessionInteractor.Adapters.Output;
using SessionInteractor.Domain;

namespace SessionInteractor.Web.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly ISessionRetriever _sessionRetriever;
        private readonly ISessionPersister _sessionPersister;
        private Guid vehicleId = Guid.NewGuid();

        public HomeController(ILogger<HomeController> logger, ISessionRetriever sessionRetriever, ISessionPersister sessionPersister)
        {
            _logger = logger;
            _sessionRetriever = sessionRetriever;
            _sessionPersister = sessionPersister;
        }

        public IActionResult Index()
        {
            _sessionPersister.SetValue(new Vehicle
            {
                MakeModel = "Dios Fancy Car",
                Registration = "D10"
            }, vehicleId);

            var vehicle = _sessionRetriever.
                GetValue<Vehicle>(vehicleId);
            return View(vehicle);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}