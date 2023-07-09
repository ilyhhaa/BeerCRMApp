using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyBeerCRMApp.Models;

using System.Xml.Linq;

namespace MyBeerCRMApp.Controllers
{
    [Authorize]
    public class BeerController : Controller
    {
        ApplicationContext db;
        public BeerController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> BeerIndex()
        {

            return View(await db.beers.ToListAsync());
        }

        
        

        public IActionResult CreateBeer()
        {

            return View();
        }
        

        [HttpPost]

        public async Task<IActionResult> CreateBeer(Beer beer)
        {
            db.beers.Add(beer);
            await db.SaveChangesAsync();
            return Redirect("BeerIndex");
        }

        [HttpPost]
        public async Task<IActionResult> DeleteBeer(int? id) //Крайний раз написали делете
        {
            if (id != null)
            {
                Beer? beer = db.beers.FirstOrDefault(x => x.id == id);
                
                if (beer != null)
                {
                    db.beers.Remove(beer);
                    await db.SaveChangesAsync();
                    return RedirectToAction("BeerIndex");
                }
            }
            return NotFound();
        }

        [HttpGet]
        public async Task<IActionResult>BeerEdit(int? id)
        {
            if (id != null)
            {
                Beer? beer = db.beers.FirstOrDefault(x=>x.id == id);
                if (beer != null) return View(beer);
                
            }
            return NotFound();
        }

        [HttpPost]
        public async Task<IActionResult> BeerEdit(Beer beer)
        {
            db.beers.Update(beer);
            db.SaveChangesAsync();
            return RedirectToAction("BeerIndex");
        }
    }
}
