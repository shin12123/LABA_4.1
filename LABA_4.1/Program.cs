class Program
//Створити об'єкт класу Держава, використовуючи класи Область, Район, Місто.
//Методи: вивести на консоль столицю, кількість областей, площу, обласні центри.

{
    static void Main()
    {
        
        var ukraine = new Country("Украина", new City("Киев"), 603628);

       
        ukraine.AddRegion(new Region("Киев")); 
        ukraine.AddRegion(new Region("Харьков"));
        ukraine.AddRegion(new Region("Львов"));

        
        ukraine.DisplayCountryInfo();
    }
}
// класс для всех локаций
abstract class Location
{
    public string Name { get; set; }

    public Location(string name)
    {
        Name = name;
    }

    public override string ToString() => Name;
}

// Класс для города
class City : Location
{
    public override bool Equals(object obj)
    {
        return obj is City city && Name == city.Name;
    }

    public override int GetHashCode()
    {
        return HashCode.Combine(Name);
    }

    public City(string name) : base(name) { }
}

// Класс для области
class Region : Location
{
    public Region(string name) : base(name) { }
}

// Класс для страны
class Country : Location
{
    public void AddRegion(Region region)
    {
        Regions.Add(region);
        Console.WriteLine($"Область {region.Name} добавлена в страну {Name}");
    }

    public City Capital { get; set; }
    public double Area { get; set; } // Площадь страны
    public List<Region> Regions { get; set; } = new List<Region>();

    public Country(string name, City capital, int area) : base(name)
    {
        Capital = capital;
        Area = area;
    }

   
    public void DisplayCountryInfo()
    {
        Console.WriteLine($"Страна: {Name}");
        Console.WriteLine($"Столица: {Capital}");
        Console.WriteLine($"Количество областей(к прмеру): {Regions.Count}");
        Console.WriteLine($"Площадь: {Area} км^2");
        Console.Write("Областные центры: ");
        foreach (var region in Regions)
        {
            Console.Write($"{region.Name} ");
        }
        Console.WriteLine("\n");
    }
}
