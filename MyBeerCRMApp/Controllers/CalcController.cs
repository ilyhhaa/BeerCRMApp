using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyBeerCRMApp.Migrations;
using MyBeerCRMApp.Models;

namespace MyBeerCRMApp.Controllers
{
    public class CalcController : Controller
    {
        ApplicationContext db;
        
        [Authorize]
        public IActionResult Calculate()
        {
            return View(new CalcModel());
        }

        [HttpPost]
        [Authorize]

        
        public IActionResult Calculate(CalcModel c, string calculate)
        {
            if (calculate == "Calculate_Beer")
            {
                c.Total = c.Calc_BeerPrice * c.Calc_BeerQuantity;
            }
            else if (calculate == "Calculate_Change")
            {
                c.Change = c.Cash - c.Total;
            }
            
            

            return View(c);
        }
       
    }
}
