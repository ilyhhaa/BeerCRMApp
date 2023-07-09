using Microsoft.AspNetCore.Mvc;
using MyBeerCRMApp.Models;

namespace MyBeerCRMApp.Controllers
{
    public class CalcController : Controller
    {
        ApplicationContext db;
        public CalcController(ApplicationContext context)
        {
            db = context;
        }
        [HttpGet]
        public ActionResult CalcBeer() => View();
        [HttpPost]
        public double CalcBeer(CalcModel model)
        {
            model.Result = model.Price * model.Volume;
            return (model.Result);
        }
        
    }
}
