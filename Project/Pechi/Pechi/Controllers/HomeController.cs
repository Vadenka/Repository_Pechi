using CalculationLibrary;
using CalculationLibrary.DataModels;
using Microsoft.AspNetCore.Mvc;
using Pechi.Data;
using Pechi.Models;
using System.Diagnostics;

namespace Pechi.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private readonly DatabaseContext _context;

        public HomeController(ILogger<HomeController> logger, DatabaseContext context)
        {
            _logger = logger;
            _context = context;
        }

        public IActionResult Index()
        {
            var userId = GetUserId();
            var inputDatas = _context.DataRows.Where(x => x.UserID == userId || x.UserID == null).ToList();
            return View(inputDatas);
        }

        [HttpPost]
        public IActionResult Result(ResultPageModel model)
        {
            if (model.DataRow == null) { return View(); }

            var transferData = new InputDataModel
            {
                RasH = model.DataRow.RasH,
                RasTm = model.DataRow.RasTm,
                RasTg = model.DataRow.RasTg,
                RasV = model.DataRow.RasV,
                RasTemG = model.DataRow.RasTemG,
                RasRas = model.DataRow.RasRas,
                RasTemM = model.DataRow.RasTemM,
                RasTepl = model.DataRow.RasTepl,
                RasD = model.DataRow.RasD,
            };
            var output = ModelCalculation.Calculate(transferData);
            model.OutputDataModel = output;

            model.DataRow.UserID = GetUserId();
            if (model.save)
            {
                _context.DataRows.Add(model.DataRow);
                _context.SaveChanges();
            }
            return View(model);
        }

        [HttpGet]
        public IActionResult Result([FromQuery] int variant)
        {
            var userId = GetUserId();
            if (variant == 0) return View();
            var vardata = _context.DataRows.FirstOrDefault(x => x.ID == variant && (x.UserID == userId || x.UserID == null));
            var data = new ResultPageModel
            {
                DataRow = vardata,
            };
            data.DataRow = vardata;
            return View(data);
        }


        [HttpGet]
        public IActionResult Delete(int id)
        {
            var userId = GetUserId();
            var vardata = _context.DataRows.FirstOrDefault(x => x.ID == id && x.UserID == userId);
            if (vardata != null)
            {
                _context.DataRows.Remove(vardata);
                _context.SaveChanges();
            }

            return RedirectToAction(nameof(Index));
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

        private int? GetUserId()
        {
            var userIdString = User.FindFirst("Id")?.Value;
            int? userId = userIdString != null ? Convert.ToInt32(userIdString) : null;
            return userId;
        }
    }
}