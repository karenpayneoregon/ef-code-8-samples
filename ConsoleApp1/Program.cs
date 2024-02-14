namespace ConsoleApp1;

internal class Program
{
    static void Main(string[] args)
    {

        var country = Country.Mexico;

        var (capital, fact) = Operations.GetDetailsForCountry(country);


        Console.WriteLine($"Country: '{country}' capital '{capital}' fact '{fact}'");
        Console.ReadLine();
    }
}

public enum Country
{
    USA,
    Canada,
    Mexico,
    Japan
}
class Operations
{
    public static (string Capital, string Fact) GetDetailsForCountry(Country value) => value switch
    {
        Country.Canada => ("Ottawa", "Is home to 26 Sons of Norway lodges."),
        Country.Mexico => ("Mexico City", "Is home to the world's largest pyramid."),
        Country.USA => ("Washington", " Has The 4th Longest River System In The World."),
        Country.Japan => ("Tokyo", " Japanese trains are some of the most punctual in the world."),
        _ => ("capital ???", "fact ??? ")
    };

    public static (string Capital, string Fact) GetDetailsForCountry1(Country value)
    {
        (string capital, string fact) = value switch
        {
            Country.Canada => ("Ottawa", "Is home to 26 Sons of Norway lodges."),
            Country.Mexico => ("Mexico City", "Is home to the world's largest pyramid."),
            Country.USA => ("Washington", " Has The 4th Longest River System In The World."),
            Country.Japan => ("Tokyo", " Japanese trains are some of the most punctual in the world."),
            _ => ("capital ???", "fact ??? ")
        };

        return (capital, fact);
    }

    public static (string Capital, string Fact) GetDetailsForCountry2(Country value)
    {
        string capital;
        string fact;
        switch (value)
        {
            case Country.Canada:
                (capital, fact) = ("Ottawa", "Is home to 26 Sons of Norway lodges.");
                break;
            case Country.Mexico:
                (capital, fact) = ("Mexico City", "Is home to the world's largest pyramid.");
                break;
            case Country.USA:
                (capital, fact) = ("Washington", " Has The 4th Longest River System In The World.");
                break;
            case Country.Japan:
                (capital, fact) = ("Tokyo", " Japanese trains are some of the most punctual in the world.");
                break;
            default:
                (capital, fact) = ("capital ???", "fact ??? ");
                break;
        }

        return (capital, fact);
    }

    public List<string> GetCountries1(string continent) => continent switch
        {
            "North America" => Continents.Get(1),
            "Africa"        => Africa,
            "Asia"          => Asia,
            "Europe"        => Europe,
            _               => []
        };

    public List<string> GetCountries2(string continent)
    {
        switch (continent)
        {
            case "North America": 
                return Continents.Get(1);
            case "Africa":        
                return Africa;
            case "Asia":          
                return Asia;
            case "Europe":
                return Europe;
            default:              
                return [];
        }
    }
    public static List<string> NorthAmerica => ["Canada", "Mexico", "United States"];
    public static List<string> Africa => ["Nigeria", "Egypt", "Ethiopia", "Botswana", "Mozambique", "Lesotho"];
    public static List<string> Asia => ["China", "Japan", "India", "Nepal", "Thailand", "Pakistan", "Mongolia"];
    public static List<string> Europe => ["Great Britain", "Germany", "Poland", "Czechia", "Italy", "Serbia"];
    public static List<string> SouthAmerica => ["Argentina", "Brazil", "Chile", "Ecuador", "Peru", "Venezuela"];

}

public static class Continents
{
    public static List<string> Get(int id)
    {
        return new List<string>();
    }
}
