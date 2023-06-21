using Microsoft.AspNetCore.Mvc;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using MyApp1.Models;
using System.Diagnostics;
using System.Text;

namespace MyApp1.Controllers
{
    public class BreweryController : Controller
    {
       
        ApplicationContext db;
        public BreweryController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> BreweryIndex()
        {
            return View(await db.breweries.ToListAsync());
        }


        //РОЗОБРАТЬСЯ В СОРТИРОВКЕ********************************************************************************************************************************************
       
        
        
        //ЗДЕСЬ ВНУТРИ СОРТИРОВКА ДЛДЯ ПИВА!
        
        
        
        /*public async Task <IActionResult> BreweryIndex(SortStateBeer sortStateBeer = SortStateBeer.NameDesc)
        {
            IQueryable<Beer>? beersSort = db.beers.Include(x => x.name);

            ViewData["NameSort"] = sortStateBeer == SortStateBeer.NameDesc ? SortStateBeer.NameAsc: SortStateBeer.NameDesc;
            ViewData["QuantitySort"] = sortStateBeer == SortStateBeer.QuantityDesc ? SortStateBeer.QuantityAsc : SortStateBeer.QuantityDesc;

            beersSort = sortStateBeer switch
            {
                SortStateBeer.NameDesc => beersSort.OrderByDescending(x => x.name),
                SortStateBeer.NameAsc => beersSort?.OrderBy(x => x.name),
                SortStateBeer.QuantityAsc => beersSort.OrderByDescending(y => y.quantity),
                SortStateBeer.QuantityDesc => beersSort.OrderBy(y => y.quantity)
            };
            return View(await beersSort.AsNoTracking().ToListAsync());
        }**********************************************************************************************************************************************************************/

        public IActionResult CreateBreweries()
        {
            return View();
        }

        [HttpPost]

        public async Task <IActionResult> CreateBreweries(Brewery brewery)
        {
            db.breweries.Add(brewery);
            await db.SaveChangesAsync();
            return Redirect("BreweryIndex");
        }

        [HttpPost]

        public async Task <IActionResult> DeleteBreweries(int? id) //Крайний раз написали делете
        {
            if (id != null)
            {
                Brewery? brewery = await db.breweries.FirstOrDefaultAsync(x => x.Id == id);

                if (brewery != null)
                {
                    db.breweries.Remove(brewery);
                    await db.SaveChangesAsync();
                    return RedirectToAction("BreweryIndex");
                }

               
            }
            return NotFound();
        }


        [HttpGet]

        public async Task<IActionResult> EditBreweries(int? id)
        {
            if (id != null)
            {
                Brewery? brewery = await db.breweries.FirstOrDefaultAsync(y => y.Id == id);
                if (brewery != null) return View(brewery);
            }
            return NotFound();
        }

        [HttpPost]

        public async Task<IActionResult> EditBreweries(Brewery brewery)
        {
            db.breweries.Update(brewery);
            db.SaveChangesAsync();
            return RedirectToAction("BreweryIndex");
        }
       
    }
}