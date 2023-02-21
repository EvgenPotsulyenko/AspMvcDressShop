using AspMvcDressShop.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;


namespace AspMvcDressShop.Controllers
{
    public class HomeController : Controller
    {
        ApplicationContext db = new ApplicationContext();

        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }
        public IActionResult Create()
        {
            return View("CreateDress");
        }
        public IActionResult Delete()
        {
            return View("DeleteDress");
        }
        public async Task<IActionResult> Index()
        {
            return View("Index", await db.Dresses.ToListAsync());
        }
        public IActionResult Privacy()
        {
            return View();
        }
        public async Task<IActionResult> CreateDress(ViewImage dres)
        {
            try
            {
                Dress person = dres.Dress;
                if (dres.Avatar != null)
                {
                    byte[] imageData = null;
                    // считываем переданный файл в массив байтов
                    using (var binaryReader = new BinaryReader(dres.Avatar.OpenReadStream()))
                    {
                        imageData = binaryReader.ReadBytes((int)dres.Avatar.Length);
                    }
                    // установка массива байтов
                    person.Img = imageData;
                }
                db.Dresses.Add(person);
                db.SaveChanges();
            }
            catch
            {
                Eror eror = new Eror();
                eror.message = "Введите значения во все поля, название должно быть уникальным.Попробуйте снова";
                return View("ErorCatch", eror);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> DeleteDress(Dress dres)
        {
            try
            {


                var at = db.Dresses.ToList();
                foreach (Dress a in at)
                {
                    if (a.Name == dres.Name)
                    {
                        db.Dresses.Remove(a);
                        db.SaveChanges();
                    }
                }
            }
            catch
            {
                Eror eror = new Eror();
                eror.message = "Попробуйте снова";
                return View("ErorCatch", eror);
            }
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> SelectCost(string cost) // поиск по цене от
        {
            var select = db.Dresses.Where(a => a.Cost > Convert.ToInt32(cost)).ToListAsync();
            return View("Index", await select);
        }
        public async Task<IActionResult> SelectCostDo(string cost) // поиск по цене до
        {
            var select = db.Dresses.Where(a => a.Cost < Convert.ToInt32(cost)).ToListAsync();
            return View("Index", await select);
        }
        public async Task<IActionResult> SelectSize(string cost) // поиск размеру
        {
            var select = db.Dresses.Where(a => a.Size == Convert.ToInt32(cost)).ToListAsync();
            return View("Index", await select);
        }
        public async Task<IActionResult> SelectColour(string cost) // поиск размеру
        {
            var select = db.Dresses.Where(a => a.Colour == cost).ToListAsync();
            return View("Index", await select);
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}