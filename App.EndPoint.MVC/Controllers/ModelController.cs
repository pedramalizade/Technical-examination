using App.Domain.Core.AppServices;
using App.Domain.Core.Entities;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.MVC.Controllers
{
    public class ModelController : Controller
    {
        private readonly ICarModelAppServices _CarModelAppServices;

        public ModelController(ICarModelAppServices carModelAppServices)
        {
            _CarModelAppServices = carModelAppServices;
        }
        public IActionResult Index()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            var models = _CarModelAppServices.CarModels();
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
        public IActionResult Create(Model model)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            var result = _CarModelAppServices.CreateModel(model);
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
        public IActionResult Preview(int id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            var model = _CarModelAppServices.GetModelById(id);



            return View(model);

        }
        [HttpGet]
        public IActionResult Delete(int id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            _CarModelAppServices.DeleteModel(id);
            return RedirectToAction("Index");

        }
        [HttpGet]
        public IActionResult Update(int id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            var model = _CarModelAppServices.GetModelById(id);


            return View(model);
        }
        [HttpPost]
        public IActionResult Update(Model model)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            var result = _CarModelAppServices.UpdateModel(model);
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
