using Microsoft.AspNetCore.Mvc;

namespace MyBeerCRMApp.Models
{
    public class CalcModel
    {
        public double Price { get; set; }
        
        public double Volume { get; set; }

        public double Result { get; set; }
    }
}
