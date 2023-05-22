using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.EntityFrameworkCore;
using NPOI.SS.Formula.Functions;
using NPOI.Util;
using Org.BouncyCastle.Utilities;
using System.Text.Json;
using WeatherDataWebManager.Data;
using WeatherDataWebManager.Models;
using WeatherDataWebManager.Services.Classes;

namespace WeatherDataWebManager.Controllers
{
    public class WeatherDataModelsController : Controller
    {

        List<WeatherDataModel> _weatherDataModelsFromExcel;
        ExcelWeatherDataModelsImporter _excelWeatherDataModelsImporter = new();
        IWebHostEnvironment _environment;
        public WeatherDataModelsController(IWebHostEnvironment environment)
        {
            ViewBag.PageSize = 5;
            _weatherDataModelsFromExcel = _excelWeatherDataModelsImporter.Import();

        }
        public IActionResult Index(int pageNumber = 1, int pageSize = 5)
        {
            int count = _weatherDataModelsFromExcel.Count;
            IEnumerable<WeatherDataModel> weatherDataModels = _weatherDataModelsFromExcel.Skip((pageNumber - 1) * pageSize).Take(pageSize);

            PageViewModel pageViewModel = new(count, pageNumber, pageSize);
            IndexViewModel indexViewModel = new IndexViewModel
            {
                PageViewModel = pageViewModel,
                WeatherDataModels = weatherDataModels
            };
            return PartialView(indexViewModel);
        }

        public IActionResult Main()
        {
            return View();
        }
    }
}
