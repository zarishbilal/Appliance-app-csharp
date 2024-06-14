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
    // Microwave class
    public class Microwave : Appliance
    {
        public double Capacity { get; set; }
        public string RoomType { get; set; }
        public const string RoomTypework = "W";
        public const string RoomTypeKitchen = "K";
        public string RoomTypeDisplay
        {
            get
            {
                switch (RoomType)
                {
                    case RoomTypework:
                        return "Work Site ";
                    default:
                        return "Kitchen";
                }
            }
        }

        public Microwave(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, double capacity, string roomType)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            Capacity = capacity;
            RoomType = roomType;
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nCapacity: {Capacity}\nRoom Type: {RoomTypeDisplay}";
        }
    }
}
