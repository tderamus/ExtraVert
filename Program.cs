using Classes;
using static System.Runtime.InteropServices.JavaScript.JSType;
using System.Xml.Linq;


internal class Program
{
    private static void Main(string[] args)
    {
        bool exit = false;

        List<Plant> plants = new List<Plant>
{
    new Plant { Species = "Dafodil", LightNeeds = 3, AskingPrice = 30, City = "Seattle", ZIP = "98101", Sold = true, AvailableUntil = new DateTime(2025, 12, 31) },
    new Plant { Species = "Cactus", LightNeeds = 2, AskingPrice = 20, City = "Baltimore", ZIP = "98101", Sold = false , AvailableUntil = new DateTime(2025, 12, 31)},
    new Plant { Species = "Trefold", LightNeeds = 3, AskingPrice = 40, City = "Erlanger", ZIP = "98101", Sold = false, AvailableUntil = new DateTime(2025, 12, 31) },
    new Plant { Species = "Hosta Plant", LightNeeds = 2, AskingPrice = 15, City = "Atlanta", ZIP = "98101", Sold = false, AvailableUntil = new DateTime(2025, 12, 31) },
    new Plant { Species = "Spider Plant", LightNeeds = 2, AskingPrice = 40, City = "Birmingham", ZIP = "98101", Sold = false, AvailableUntil = new DateTime(2025, 12, 31) },
    new Plant { Species = "Peace Lilly", LightNeeds = 2, AskingPrice = 30, City = "Mobile", ZIP = "35801", Sold = false, AvailableUntil = new DateTime(2025, 12, 31) },
    new Plant { Species = "Orchid", LightNeeds = 2, AskingPrice = 25, City = "Seattle", ZIP = "49208", Sold = false, AvailableUntil = new DateTime(2025, 12, 31) },
    new Plant { Species = "Jade Plant", LightNeeds = 2, AskingPrice = 35, City = "Seattle", ZIP = "81309", Sold = false, AvailableUntil = new DateTime(2025, 12, 31) }
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
            Console.WriteLine("\th - View plant statistics");

            Console.WriteLine("\nEnter your selection:");

            string selection = Console.ReadLine().ToLower();

            switch (selection)
            {
                case "a":
                    Console.WriteLine("Here are all the plants available for adoption:");
                    for (int i = 0; i < plants.Count; i++)
                    {
                        Plant plant = plants[i];
                        Console.WriteLine($"{i + 1}. {PlantDetails(plant)}");
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

                    DateTime availableUntil;
                    while (true)
                    {
                        try
                        {
                            Console.WriteLine("Enter the date until the plant is available (yyyy-MM-dd):");
                            string dateInput = Console.ReadLine();
                            if (DateTime.TryParse(dateInput, out availableUntil))
                            {
                                break;
                            }
                            else
                            {
                                Console.WriteLine("Invalid date format. Please try again.");
                            }
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"An error occurred: {ex.Message}");
                        }
                    }
                   
                    Console.WriteLine("Enter the ZIP code where the plant is located:");
                    string zip = Console.ReadLine();

                    plants.Add(new Plant { Species = species, LightNeeds = lightNeeds, AskingPrice = askingPrice, City = city, ZIP = zip, Sold = false, AvailableUntil = availableUntil });
                    Console.WriteLine("Plant posted successfully!");
                    break;
                case "c":
                    Console.WriteLine("Enter the species of the plant you would like to adopt:");
                    string speciesToAdopt = Console.ReadLine();
                    Plant plantToAdopt = plants.Find(plant => plant.Species == speciesToAdopt && !plant.Sold && plant.AvailableUntil > DateTime.Now);
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
                        Console.WriteLine($"The plant of the day is {PlantDetails(plantOfTheDay)}");
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
                            Console.WriteLine($"The plant of the day is {PlantDetails(plant)}");
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
                case "h":
                    // Initialize variables
                    string lowestPricePlantName = null;
                    decimal lowestPrice = decimal.MaxValue;
                    int numberOfPlantsAvailable = 0;
                    string highestLightNeedsPlantName = null;
                    int highestLightNeeds = int.MinValue;
                    int totalLightNeeds = 0;
                    int totalPlants = plants.Count;
                    int totalSoldPlants = 0;

                    // Loop through the list of plants
                    foreach (var plant in plants)
                    {
                        // Check for the lowest price plant
                        if (plant.AskingPrice < lowestPrice)
                        {
                            lowestPrice = plant.AskingPrice;
                            lowestPricePlantName = plant.Species;
                        }

                        // Count available plants
                        if (!plant.Sold)
                        {
                            numberOfPlantsAvailable++;
                        }

                        // Check for the highest light needs
                        if (plant.LightNeeds > highestLightNeeds)
                        {
                            highestLightNeeds = plant.LightNeeds;
                            highestLightNeedsPlantName = plant.Species;
                        }

                        // Sum up light needs
                        totalLightNeeds += plant.LightNeeds;

                        // Count sold plants
                        if (plant.Sold)
                        {
                            totalSoldPlants++;
                        }
                    }

                    // Calculate the average light needs
                    double averageLightNeeds = totalPlants > 0 ? (double)totalLightNeeds / totalPlants : 0;

                    // Calculate the percentage of plants adopted (sold)
                    double percentageAdopted = totalPlants > 0 ? (double)totalSoldPlants / totalPlants * 100 : 0;

                    // Print the results
                    Console.WriteLine($"Lowest price plant name: {lowestPricePlantName}");
                    Console.WriteLine($"Number of Plants Available: {numberOfPlantsAvailable}");
                    Console.WriteLine($"Name of plant with highest light needs: {highestLightNeedsPlantName}");
                    Console.WriteLine($"Average light needs: {averageLightNeeds:F2}");
                    Console.WriteLine($"Percentage of plants adopted: {percentageAdopted:F2}%");
                    break;

                default:
                    Console.WriteLine("Invalid selection. Please try again.");
                    break;
            }
            Console.WriteLine(" ");
            Console.WriteLine(" ");
            Console.WriteLine(" ");
        }
        string PlantDetails(Plant plant)
        {
            return $"The plant of the day is {plant.Species} in {plant.City}, with light needs of {plant.LightNeeds} and the price of ${plant.AskingPrice} dollars";
        }
    }
}