namespace Classes;


// build public plant class
public class Plant
{
    public string Species { get; set; }
    public int LightNeeds { get; set; }
    public decimal AskingPrice { get; set; }
    public string City { get; set; }
    public string ZIP { get; set; }
    public bool Sold { get; set; }
    public DateTime AvailableUntil { get; set; }

    //public Plant()
    //{

    //    Console.WriteLine("This is a new plant instance!");
    //}
}
