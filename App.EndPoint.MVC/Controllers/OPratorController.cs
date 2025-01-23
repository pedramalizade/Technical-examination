using App.Domain.Core.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoint.MVC.Controllers
{
    public class OPratorController : Controller
    {
        private readonly IOPratorAppServices _OPratorAppServices;
        private readonly ICarModelAppServices _CarModelAppServices;
        public OPratorController(IOPratorAppServices oPratorAppServices, ICarModelAppServices carModelAppServices)
        {
            _OPratorAppServices = oPratorAppServices;
            _CarModelAppServices = carModelAppServices;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public IActionResult Login(string username, string password)
        {

            var result = _OPratorAppServices.Login(username, password);

            if (result.IsSuccess)
            {
                HttpContext.Session.SetString("UserName", username);
                return RedirectToAction("Index", "Home");

            }
            else
            {
                ViewBag.ErrorMessage = result.IsMessage;

            }

            return View();


        }
        [HttpGet]
        public IActionResult Index()
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }

            var Cars = _OPratorAppServices.GetList();

            return View("ListCars", Cars);


        }

        [HttpGet]
        public IActionResult Confirmation(int id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            var result = _OPratorAppServices.Confirmation(id);
            if (result.IsSuccess)
            {

                ViewBag.SuccessMessage = result.IsMessage;

            }
            else
            {
                ViewBag.ErrorMessage = result.IsMessage;

            }
            var Cars = _OPratorAppServices.GetList();
            return View("ListCars", Cars);
        }
        [HttpGet]
        public IActionResult Rejected(int id)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            var result = _OPratorAppServices.Rejected(id);
            if (result.IsSuccess)
            {

                ViewBag.SuccessMessage = result.IsMessage;

            }
            else
            {
                ViewBag.ErrorMessage = result.IsMessage;

            }
            var Cars = _OPratorAppServices.GetList();
            return View("ListCars", Cars);
        }
        public IActionResult Logout()
        {
            HttpContext.Session.Remove("UserName");
            return RedirectToAction("Login");
        }
        private bool IsLoggedIn()
        {
            return !string.IsNullOrEmpty(HttpContext.Session.GetString("UserName"));
        }
    }
}
