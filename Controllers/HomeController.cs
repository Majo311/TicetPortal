﻿using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using TicetPortal.Models;
using TicetPortal.Others;

namespace TicetPortal.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly IConfiguration _configuration;
        public HomeController(ILogger<HomeController> logger,IConfiguration configuration)
        {
            _logger = logger;
            _configuration = configuration;
        }

        public IActionResult Index()
        {
            MsSqlAdoNet_Reader msSqlAdoNet_Reader = new MsSqlAdoNet_Reader(_configuration);
            msSqlAdoNet_Reader.GetStoredProcedureResult("", "");
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