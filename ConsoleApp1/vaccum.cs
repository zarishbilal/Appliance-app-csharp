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
    // Vacuum class
    public class Vacuum : Appliance
    {
        public string Grade { get; set; }
        public string BatteryVoltage { get; set; }
        public const string BatteryVoltageLow = "18";
        public const string BatteryVoltageHigh = "24";

        public string BatteryVoltageDisplay
        {
            get
            {
                switch (BatteryVoltage)
                {
                    case BatteryVoltageLow:
                        return "Low";
                    default:
                        return "High";
                }
            }
        }

        public Vacuum(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, string grade, string batteryVoltage)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            Grade = grade;
            BatteryVoltage = batteryVoltage;
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nGrade: {Grade}\nBattery Voltage: {BatteryVoltageDisplay}";
        }
    }
}
