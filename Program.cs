using Classes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;


List<Plant> plants = new List<Plant>
{
    new Plant { Species = "Dafodil", LightNeeds = 3, AskingPrice = 30, City = "Seattle", ZIP = "98101", Sold = false },
    new Plant { Species = "Cactus", LightNeeds = 2, AskingPrice = 20, City = "Seattle", ZIP = "98101", Sold = false },
    new Plant { Species = "Trefold", LightNeeds = 3, AskingPrice = 40, City = "Seattle", ZIP = "98101", Sold = false },
    new Plant { Species = "Hosta Plant", LightNeeds = 2, AskingPrice = 15, City = "Seattle", ZIP = "98101", Sold = false },
    new Plant { Species = "Swiss Cheese Plant", LightNeeds = 2, AskingPrice = 10, City = "Seattle", ZIP = "98101", Sold = true }
};

Console.WriteLine("Welcome to the plant adoption market. Select and option below to perform the action!");
Console.WriteLine(" ");
Console.WriteLine("\ta - Display all plants");
Console.WriteLine("\tb - Post a plant to be adopted");
Console.WriteLine("\tc - Adopt a plant");
Console.WriteLine("\td - Delist a plant");
Console.WriteLine("\nEnter your selection:");

string selection = Console.ReadLine().ToLower();

switch (selection)
{
    case "a":
        Console.WriteLine("Here are all the plants available for adoption:");
        for(int i = 0; i < plants.Count; i++)
        {
            Plant plant = plants[i];
            Console.WriteLine($"{i+1}. {plant.Species} in {plant.City} {(plant.Sold ? "was sold" : "is available")} for the price of ${plant.AskingPrice} dollars");
         }
        break;
    case "b":
        Console.WriteLine("Enter the species of the plant you would like to post for adoption:");
        string species = Console.ReadLine();
        Console.WriteLine("Enter the light needs of the plant:");
        int lightNeeds = Convert.ToInt32(Console.ReadLine());
        Console.WriteLine("Enter the asking price of the plant:");
        decimal askingPrice = Convert.ToDecimal(Console.ReadLine());
        Console.WriteLine("Enter the city where the plant is located:");
        string city = Console.ReadLine();
        Console.WriteLine("Enter the ZIP code where the plant is located:");
        string zip = Console.ReadLine();
        plants.Add(new Plant { Species = species, LightNeeds = lightNeeds, AskingPrice = askingPrice, City = city, ZIP = zip, Sold = false });
        Console.WriteLine("Plant posted successfully!");
        break;
    case "c":
        Console.WriteLine("Enter the species of the plant you would like to adopt:");
        string speciesToAdopt = Console.ReadLine();
        Plant plantToAdopt = plants.Find(plant => plant.Species == speciesToAdopt && plant.Sold == false);
        if (plantToAdopt != null)
        {
            plantToAdopt.Sold = true;
            Console.WriteLine("Plant adopted successfully!");
        }
        else
        {
            Console.WriteLine("Plant not found or already adopted.");
        }
        break;
    case "d":
        Console.WriteLine("Enter the species of the plant you would like to delist:");
        string speciesToDelist = Console.ReadLine();
        Plant plantToDelist = plants.Find(plant => plant.Species == speciesToDelist && plant.Sold == false);
        if (plantToDelist != null)
        {
            plants.Remove(plantToDelist);
            Console.WriteLine("Plant delisted successfully!");
        }
        else
        {
            Console.WriteLine("Plant not found or already adopted.");
        }
        break;
    default:
        Console.WriteLine("Invalid selection. Please try again.");
        break;
}