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
    // Dishwasher class
    public class Dishwasher : Appliance
    {
        public string Feature { get; set; }
        public string SoundRating { get; set; }
        public const string SoundRatingQuietest = "Qt";
        public const string SoundRatingQuieter = "Qr";
        public const string SoundRatingQuiet = "Qu";
        public const string SoundRatingModerate = "M";
        public string SoundRatingDisplay
        {
            get
            {
                switch (SoundRating)
                {
                    case SoundRatingQuietest:
                        return "Quietest";
                    case SoundRatingQuieter:
                        return "Quieter";
                    case SoundRatingQuiet:
                        return "Quiet";
                    case SoundRatingModerate:
                        return "Moderate";
                    default:
                        return "(Unknown)";
                }
            }
        }


        public Dishwasher(string itemNumber, string brand, int quantity, int wattage, string color, decimal price, string feature, string soundRating)
            : base(itemNumber, brand, quantity, wattage, color, price)
        {
            Feature = feature;
            SoundRating = soundRating;
        }

        public override string ToString()
        {
            return $"Item Number: {ItemNumber}\nBrand: {Brand}\nQuantity: {Quantity}\nWattage: {Wattage}\nColor: {Color}\nPrice: {Price}\nFeature: {Feature}\nSound Rating: {SoundRatingDisplay}";
        }
    }
}
