using App.Domain.Core.AppServices;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.Car.Controllers
{
    public class ModelController : Controller
    {
        private readonly ICarModelAppServices _CarModelAppServices;

        public ModelController(ICarModelAppServices carModelAppServices)
        {
            _CarModelAppServices = carModelAppServices;
        }
        public async Task<IActionResult> Index(CancellationToken cToken)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            var models = await _CarModelAppServices.CarModels(cToken);
            return View(models);
        }
        [HttpGet]
        public IActionResult Create()
        {

            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            return View();

        }
        [HttpPost]
        public async Task<IActionResult> Create(Model model, CancellationToken cToken)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            var result = await _CarModelAppServices.CreateModel(model, cToken);
            if (result.IsSuccess)
            {
                ViewBag.SuccessMessage = result.IsMessage;

            }
            else
            {
                ViewBag.ErrorMessage = result.IsMessage;
            }
            return View();

        }
        [HttpGet]
        public async Task<IActionResult> Preview(int id, CancellationToken cToken)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            var model = await _CarModelAppServices.GetModelById(id, cToken);



            return View(model);

        }
        [HttpGet]
        public async Task<IActionResult> Delete(int id, CancellationToken cToken)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            await _CarModelAppServices.DeleteModel(id, cToken);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public async Task<IActionResult> Update(int id, CancellationToken cToken)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            var model = await _CarModelAppServices.GetModelById(id, cToken);


            return View(model);
        }
        [HttpPost]
        public async Task<IActionResult> Update(Model model, CancellationToken cToken)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            var result = await _CarModelAppServices.UpdateModel(model, cToken);
            if (result.IsSuccess)
            {
                ViewBag.SuccessMessage = result.IsMessage;

            }
            else
            {
                ViewBag.ErrorMessage = result.IsMessage;
            }
            return View(model);


        }
        private bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(HttpContext.Session.GetString("UserName"));
        }
    }
}
