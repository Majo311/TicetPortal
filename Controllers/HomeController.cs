using Microsoft.AspNetCore.Mvc;
using System.Data;
using System.Diagnostics;
using TicetPortal.Models;
using TicetPortal.Others;
using System.Linq;
using TicetPortal.Others.Extensions;

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
        [HttpPost]
        public IActionResult SearchPersonData(string parameterTxt)
        {
            MsSqlAdoNet_Reader msSqlAdoNet_Reader = new MsSqlAdoNet_Reader(_configuration);
            DataTable dt = msSqlAdoNet_Reader.GetStoredProcedureResult("dbo.GetPersons", "Duffy").GetPersonAsDataTable();
            return View(dt);
        }
        [HttpPost]
        public IActionResult Index(string parameterTxt)
        {
            if(!String.IsNullOrEmpty(parameterTxt))
            parameterTxt= parameterTxt.Remove(0, parameterTxt.IndexOf('=')+1);

            List<Person> persons = new List<Person>();
            if (!String.IsNullOrEmpty(parameterTxt))
            {
                MsSqlAdoNet_Reader msSqlAdoNet_Reader = new MsSqlAdoNet_Reader(_configuration);
                persons = msSqlAdoNet_Reader.GetStoredProcedureResult("dbo.GetPersons", "Duffy").GetPersonAsList();
            }
            return View(persons);
        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Privacy()
        {
            return View();
        }


    }
}