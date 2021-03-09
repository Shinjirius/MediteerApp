using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MediteerApp.Models;
using MediteerApp.Data.Repositories;

namespace MediteerApp.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly MeditationRepository _repository;

        public HomeController(MeditationRepository repository, ILogger<HomeController> logger)
        {
            _logger = logger;
            _repository = repository;
        }

        public IActionResult Index()
        {
            var docs = _repository.GetAll(Guid.Parse("74E1ABD2-9143-41B2-8704-A4C77B6B6300"));
            return View();
        }

        public IActionResult Meditations()
        {
            var docs = _repository.GetAll(Guid.Parse("74E1ABD2-9143-41B2-8704-A4C77B6B6300"));
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
