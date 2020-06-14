using System.Collections.Generic;

namespace ConsoleApp.Exercise4.Models
{
    public class ManufacturerService
    {
        private static List<Manufacturer> _manufacturers = new List<Manufacturer>()
        {
            new Manufacturer() {Name = "Abba"}, new Manufacturer() {Name = "Arla"},
            new Manufacturer() {Name = "Heinz"}, new Manufacturer() {Name = "Önos"}
        };

        public static Manufacturer GetManufacturer(int id)
        {
            return _manufacturers[id];
        }
    }
}