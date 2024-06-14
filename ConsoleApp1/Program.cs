// File: Appliance.cs
using System;
using System.Collections.Generic;
using System.IO;
using ConsoleApp1;
using System.Linq;


namespace ModernAppliances
{
    // Abstract Appliance class
    public abstract class Appliance
    {
        public string ItemNumber { get; set; }
        public string Brand { get; set; }
        public int Quantity { get; set; }
        public int Wattage { get; set; }
        public string Color { get; set; }
        public decimal Price { get; set; }

        public Appliance(string itemNumber, string brand, int quantity, int wattage, string color, decimal price)
        {
            ItemNumber = itemNumber;
            Brand = brand;
            Quantity = quantity;
            Wattage = wattage;
            Color = color;
            Price = price;
        }

        public abstract override string ToString();
    }

    // Main Program class
    class Program
    {
        static List<Appliance> appliances = new List<Appliance>();

        static void Main(string[] args)
        {
            LoadAppliances("appliances.txt");
            bool exit = false;

            while (!exit)
            {
                Console.WriteLine("Welcome to Modern Appliances!");
                Console.WriteLine("How may we assist you?");
                Console.WriteLine("1 – Check out appliance");
                Console.WriteLine("2 – Find appliances by brand");
                Console.WriteLine("3 – Display appliances by type");
                Console.WriteLine("4 – Produce random appliance list");
                Console.WriteLine("5 – Save & exit");
                Console.Write("\nEnter option:\n ");
                switch (Console.ReadLine())
                {
                    case "1":
                        CheckoutAppliance();
                        break;
                    case "2":
                        FindAppliancesByBrand();
                        break;
                    case "3":
                        DisplayAppliancesByType();
                        break;
                    case "4":
                        ProduceRandomApplianceList();
                        break;
                    case "5":
                        SaveAndExit("appliances.txt");
                        exit = true;
                        break;
                    default:
                        Console.WriteLine("Invalid option. Please try again.");
                        break;
                }
            }
        }

        static void LoadAppliances(string filePath)
        {
            foreach (var line in File.ReadLines(filePath))
            {
                var parts = line.Split(';');
                string itemNumber = parts[0];
                string brand = parts[1];
                int quantity = int.Parse(parts[2]);
                int wattage = int.Parse(parts[3]);
                string color = parts[4];
                decimal price = decimal.Parse(parts[5]);

                switch (itemNumber[0])
                {
                    case '1':
                        appliances.Add(new Refrigerator(itemNumber, brand, quantity, wattage, color, price, int.Parse(parts[6]), int.Parse(parts[7]), int.Parse(parts[8])));
                        break;
                    case '2':
                        appliances.Add(new Vacuum(itemNumber, brand, quantity, wattage, color, price, parts[6], parts[7]));
                        break;
                    case '3':
                        appliances.Add(new Microwave(itemNumber, brand, quantity, wattage, color, price, double.Parse(parts[6]), parts[7]));
                        break;
                    case '4':
                    case '5':
                        appliances.Add(new Dishwasher(itemNumber, brand, quantity, wattage, color, price, parts[6], parts[7]));
                        break;
                }
            }
        }

        static void CheckoutAppliance()
        {
            Console.Write("Enter the item number of an appliance:\n ");
            string itemNumber = Console.ReadLine();

            var appliance = appliances.FirstOrDefault(a => a.ItemNumber == itemNumber);
            if (appliance == null)
            {
                Console.WriteLine(" No appliances found with that item number. ");
                return;
            }

            if (appliance.Quantity > 0)
            {
                appliance.Quantity--;               
                Console.WriteLine($"\nAppliance \"{itemNumber}\" has been checked out.\n");
            }
            else
            {
                Console.WriteLine("\n The appliance is not available to be checked out.\n ");
            }
        }

        static void FindAppliancesByBrand()
        {
            Console.Write("\n Enter brand to search for:\n ");
            string brand = Console.ReadLine();

            var matchingAppliances = appliances.Where(a => a.Brand.Equals(brand, StringComparison.OrdinalIgnoreCase)).ToList();
            if (matchingAppliances.Any())
            {
                Console.WriteLine(" Matching Appliances:\n ");
                foreach (var appliance in matchingAppliances)
                {
                    Console.WriteLine(appliance);
                    Console.WriteLine($"\n");
                }
            }
            else
            {
                Console.WriteLine(" No matching appliances found. \n");
            }
        }

        static void DisplayAppliancesByType()
        {
            Console.WriteLine("\nAppliance Types");
            Console.WriteLine("1 – Refrigerators");
            Console.WriteLine("2 – Vacuums");
            Console.WriteLine("3 – Microwaves");
            Console.WriteLine("4 – Dishwashers");
            Console.Write(" Enter type of appliance:\n ");
            string type = Console.ReadLine();

            switch (type)
            {
                case "1":
                    Console.Write("\n Enter number of doors: 2 (double door) 3 (three doors) or 4 (four doors): ");
                    int doors = int.Parse(Console.ReadLine());
                    var refrigerators = appliances.OfType<Refrigerator>().Where(r => r.NumberOfDoors == doors).ToList();
                    if (refrigerators.Any())
                    {
                        Console.WriteLine(" Matching refrigerators: \n");
                        foreach (var fridge in refrigerators)
                        {
                            Console.WriteLine(fridge);
                            Console.WriteLine($"\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine(" \nNo matching refrigerators found.\n ");
                    }
                    break;
                case "2":
                    Console.Write(" \nEnter battery voltage value. 18 V (low) or 24 V (high): \n ");
                    string voltage = Console.ReadLine();
                    var vacuums = appliances.OfType<Vacuum>().Where(v => v.BatteryVoltage == voltage).ToList();
                    if (vacuums.Any())
                    {
                        Console.WriteLine(" \nMatching vacuums: \n");
                        foreach (var vacuum in vacuums)
                        {
                            Console.WriteLine(vacuum);
                            Console.WriteLine($"\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine(" \nNo matching vacuums found.\n ");
                    }
                    break;
                case "3":
                    Console.Write("\n Room where the microwave will be installed: K (kitchen) or W (work site): \n ");
                    string roomType = Console.ReadLine();
                    var microwaves = appliances.OfType<Microwave>().Where(m => m.RoomType.Equals(roomType, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (microwaves.Any())
                    {
                        Console.WriteLine("\n Matching microwaves: \n");
                        foreach (var microwave in microwaves)
                        {
                            Console.WriteLine(microwave);
                            Console.WriteLine($"\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n No matching microwaves found. \n");
                    }
                    break;
                case "4":
                    Console.Write("\n Enter the sound rating of the dishwasher: Qt (Quietest) Qr (Quieter) Qu(Quiet) or M (Moderate):  \n");
                    string soundRating = Console.ReadLine();
                    var dishwashers = appliances.OfType<Dishwasher>().Where(d => d.SoundRating.Equals(soundRating, StringComparison.OrdinalIgnoreCase)).ToList();
                    if (dishwashers.Any())
                    {
                        Console.WriteLine("\n Matching dishwashers: \n");
                        foreach (var dishwasher in dishwashers)
                        {
                            Console.WriteLine(dishwasher);
                            Console.WriteLine($"\n");
                        }
                    }
                    else
                    {
                        Console.WriteLine("\n No matching dishwashers found. \n");
                    }
                    break;
                default:
                    Console.WriteLine("\n Invalid appliance type. \n");
                    break;
            }
        }

        static void ProduceRandomApplianceList()
        {
            Console.Write("\n Enter number of appliances:\n");
            int number = int.Parse(Console.ReadLine());

            var randomAppliances = appliances.OrderBy(a => Guid.NewGuid()).Take(number).ToList();
            Console.WriteLine("\n Random appliances:\n");
            foreach (var appliance in randomAppliances)
            {
                Console.WriteLine(appliance);
            }
        }

        static void SaveAndExit(string filePath)
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                foreach (var appliance in appliances)
                {
                    switch (appliance)
                    {
                        case Refrigerator r:
                            writer.WriteLine($"{r.ItemNumber};{r.Brand};{r.Quantity};{r.Wattage};{r.Color};{r.Price};{r.NumberOfDoors};{r.Height};{r.Width}");
                            break;
                        case Vacuum v:
                            writer.WriteLine($"{v.ItemNumber};{v.Brand};{v.Quantity};{v.Wattage};{v.Color};{v.Price};{v.Grade};{v.BatteryVoltage}");
                            break;
                        case Microwave m:
                            writer.WriteLine($"{m.ItemNumber};{m.Brand};{m.Quantity};{m.Wattage};{m.Color};{m.Price};{m.Capacity};{m.RoomType}");
                            break;
                        case Dishwasher d:
                            writer.WriteLine($"{d.ItemNumber};{d.Brand};{d.Quantity};{d.Wattage};{d.Color};{d.Price};{d.Feature};{d.SoundRating}");
                            break;
                    }
                }
            }

            Console.WriteLine(" \nChanges saved. Exiting program.");
        }
    }
}
