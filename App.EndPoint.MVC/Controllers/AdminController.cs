using App.Domain.Core.AppServices;
using Microsoft.AspNetCore.Mvc;

namespace App.EndPoints.Mvc.Car.Controllers
{
    public class OPratorController : Controller
    {
        private readonly IAdminAppServices _OPratorAppServices;
        private readonly ICarModelAppServices _CarModelAppServices;
        public OPratorController(IAdminAppServices oPratorAppServices, ICarModelAppServices carModelAppServices)
        {
            _OPratorAppServices = oPratorAppServices;
            _CarModelAppServices = carModelAppServices;
        }


        [HttpGet]
        public IActionResult Login()
        {
            return View();
        }

        public async Task<IActionResult> Login(string username, string password, CancellationToken cToken)
        {

            var result = await _OPratorAppServices.Login(username, password, cToken);

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
        public async Task<IActionResult> Index(CancellationToken cToken)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }

            var Cars = await _OPratorAppServices.GetList(cToken);

            return View("ListCars", Cars);


        }

        [HttpGet]
        public async Task<IActionResult> Confirmation(int id, CancellationToken cToken)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            var result = await _OPratorAppServices.Confirmation(id, cToken);
            if (result.IsSuccess)
            {

                ViewBag.SuccessMessage = result.IsMessage;

            }
            else
            {
                ViewBag.ErrorMessage = result.IsMessage;

            }
            var Cars = await _OPratorAppServices.GetList(cToken);
            return View("ListCars", Cars);
        }
        [HttpGet]
        public async Task<IActionResult> Rejected(int id, CancellationToken cToken)
        {
            if (!IsLoggedIn())
            {
                return RedirectToAction("Login", "OPrator");
            }
            var result = await _OPratorAppServices.Rejected(id, cToken);
            if (result.IsSuccess)
            {

                ViewBag.SuccessMessage = result.IsMessage;

            }
            else
            {
                ViewBag.ErrorMessage = result.IsMessage;

            }
            var Cars = await _OPratorAppServices.GetList(cToken);
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
