using Classes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;


bool exit = false;

List<Plant> plants = new List<Plant>
{
    new Plant { Species = "Dafodil", LightNeeds = 3, AskingPrice = 30, City = "Seattle", ZIP = "98101", Sold = true },
    new Plant { Species = "Cactus", LightNeeds = 2, AskingPrice = 20, City = "Baltimore", ZIP = "98101", Sold = false },
    new Plant { Species = "Trefold", LightNeeds = 3, AskingPrice = 40, City = "Erlanger", ZIP = "98101", Sold = false },
    new Plant { Species = "Hosta Plant", LightNeeds = 2, AskingPrice = 15, City = "Atlanta", ZIP = "98101", Sold = false },
    new Plant { Species = "Spider Plant", LightNeeds = 2, AskingPrice = 40, City = "Birmingham", ZIP = "98101", Sold = false },
    new Plant { Species = "Peace Lilly", LightNeeds = 2, AskingPrice = 30, City = "Mobile", ZIP = "35801", Sold = false },
    new Plant { Species = "Orchid", LightNeeds = 2, AskingPrice = 25, City = "Seattle", ZIP = "49208", Sold = false },
    new Plant { Species = "Jade Plant", LightNeeds = 2, AskingPrice = 35, City = "Seattle", ZIP = "81309", Sold = false }
};



while (!exit)
{

    Random random = new Random();
    int randomIndex = random.Next(1, plants.Count);

    Console.WriteLine("Welcome to the plant adoption market. Select and option below to perform the action!");
    Console.WriteLine(" ");
    Console.WriteLine("\ta - Display all plants");
    Console.WriteLine("\tb - Post a plant to be adopted");
    Console.WriteLine("\tc - Adopt a plant");
    Console.WriteLine("\td - Delist a plant");
    Console.WriteLine("\te - Choose the plant of the day ");
    Console.WriteLine("\tf - Search plant by light needs ");
    Console.WriteLine("\tg - Exit");

    Console.WriteLine("\nEnter your selection:");

    string selection = Console.ReadLine().ToLower();

    switch (selection)
    {
        case "a":
            Console.WriteLine("Here are all the plants available for adoption:");
            for (int i = 0; i < plants.Count; i++)
            {
                Plant plant = plants[i];
                Console.WriteLine($"{i + 1}. {plant.Species} in {plant.City} {(plant.Sold ? "was sold" : "is available")} for the price of ${plant.AskingPrice} dollars");
            }
            break;
        case "b":
            Console.WriteLine("Enter the species of the plant you would like to post for adoption:");
            string species = Console.ReadLine();
            Console.WriteLine("Enter the light needs of the plant from 1 - 5:");
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
            int plantIndex = plants.FindIndex(plant => plant.Species == speciesToDelist && !plant.Sold);
            if (plantIndex != -1)
            {
                plants.RemoveAt(plantIndex);
                Console.WriteLine("Plant delisted successfully!");
            }
            else
            {
                Console.WriteLine("Plant not found or already adopted.");
            }
            break;
        case "e":
            Plant plantOfTheDay = plants[randomIndex];
            if (plantOfTheDay.Sold)
            {
                Console.WriteLine("The plant of the day is not available for adoption.");
            }
            else
            {
                Console.WriteLine($"The plant of the day is {plantOfTheDay.Species} in {plantOfTheDay.City}, with light needs of {plantOfTheDay.LightNeeds} and the price of ${plantOfTheDay.AskingPrice} dollars");
            }
            break;
        case "f":
            Console.WriteLine("Enter the light needs of the plant you would like to search between 1 and 5:");
            int lightNeedsToSearch = Convert.ToInt32(Console.ReadLine());
            List<Plant> plantsByLightNeeds = plants.FindAll(plant => plant.LightNeeds == lightNeedsToSearch);
            if (plantsByLightNeeds.Count > 0)
            {
                Console.WriteLine($"Here are all the plants with light needs of {lightNeedsToSearch}:");
                int index = 1;
                foreach (Plant plant in plantsByLightNeeds)
                {
                    Console.WriteLine($"{index}. {plant.Species} in {plant.City} {(plant.Sold ? "was sold" : "is available")} for the price of ${plant.AskingPrice} dollars");
                    index++;
                }
            }
            else
            {
                Console.WriteLine("No plants found with the specified light needs.");
            }
            break;
        case "g":
            exit = true;
            break;
        default:
            Console.WriteLine("Invalid selection. Please try again.");
            break;
    }
    Console.WriteLine(" ");
    Console.WriteLine(" ");
}