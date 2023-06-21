using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MyApp1.Models;

namespace MyApp1.Controllers
{
    public class BeerController : Controller
    {
        readonly ApplicationContext db;
        public BeerController(ApplicationContext context)
        {
            db = context;
        }

        public async Task<IActionResult> BeerIndex()
        {

            return View(await db.beers.ToListAsync());
        }

        //РАЗОБРАТЬСЯ С СОРТИРОВКОЙ *********************************************************************************************************************
        public async Task<IActionResult> BeerSort(SortStateBeer sortStateBeer = SortStateBeer.NameDesc)
        {
            IQueryable<Beer>? beersSort = db.beers.Include(x => x.name);

            ViewData["NameSort"] = sortStateBeer == SortStateBeer.NameDesc ? SortStateBeer.NameAsc : SortStateBeer.NameDesc;
            ViewData["QuantitySort"] = sortStateBeer == SortStateBeer.QuantityDesc ? SortStateBeer.QuantityAsc : SortStateBeer.QuantityDesc;

            beersSort = sortStateBeer switch
            {
                SortStateBeer.NameDesc => beersSort.OrderByDescending(x => x.name),
                SortStateBeer.NameAsc => beersSort.OrderBy(x => x.name),
                SortStateBeer.QuantityAsc => beersSort.OrderByDescending(x => x.quantity),
                SortStateBeer.QuantityDesc => beersSort.OrderBy(x => x.quantity),
                _=>beersSort.OrderByDescending(x => x.name),
            };
            return View(await beersSort.ToListAsync());
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
