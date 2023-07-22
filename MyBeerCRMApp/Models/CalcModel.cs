using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace MyBeerCRMApp.Models
{
    public class CalcModel
    {
        public double Calc_BeerPrice { get; set; }

        public double Calc_BeerQuantity { get; set; }

        public double Total { get; set; }

        public double Change { get; set; }

        public double Cash { get; set; }
    }
}
