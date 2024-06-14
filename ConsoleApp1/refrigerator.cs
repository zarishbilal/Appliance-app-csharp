using ModernAppliances;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    // Refrigerator class
    public class Refrigerator : Appliance
    {
        public int NumberOfDoors { get; set; }
        public int Height { get; set; }
        public int Width { get; set; }
        public const int NumberOfDoorsThree = 3;
        public const int NumberOfDoorsTwo = 2;
        public const int NumberOfDoorsFour = 4;

        public string NumberOfDoorsDisplay
        {
            get
            {
                switch (NumberOfDoors)
                {
                    case NumberOfDoorsThree:
                        return "Three Doors";
                    case NumberOfDoorsFour:
                        return "Four Doors";
                    default:
                        return "Double Doors";
                }
            }
        }
        public Refrigerator(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, int numberOfDoors, int height, int width)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            NumberOfDoors = numberOfDoors;
            Height = height;
            Width = width;
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nNumber Of Doors: {NumberOfDoorsDisplay}\nHeight: {Height} \nWidth: {Width}";
        }
    }
}
