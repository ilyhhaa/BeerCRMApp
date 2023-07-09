using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Routing.Constraints;

namespace MyBeerCRMApp.Models
{
    public class CalcModel
    {
        public double Price { get; set; }
        
        public double Volume { get; set; }

        public double Result { get; set; }

        public double Cash { get; set; }

        public double Change { get; set; }
    }
}
