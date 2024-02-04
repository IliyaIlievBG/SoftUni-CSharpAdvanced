Dictionary<string, Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();

int queriesToAddCount = int.Parse(Console.ReadLine());

for (int i = 0; i < queriesToAddCount; i++)
{
    string[] nextCityInfo = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries);

    string continent = nextCityInfo[0];
    string country = nextCityInfo[1];
    string city = nextCityInfo[2];

    if (!continents.ContainsKey(continent))
    {
        continents.Add(continent, new Dictionary<string, List<string>>());
    }

    if (!continents[continent].ContainsKey(country))
    {
        continents[continent].Add(country, new List<string>());
    }

    continents[continent][country].Add(city);
}

foreach (var (continent, countriesWithCities) in continents)
{
    Console.Write($"{continent}:\n");

    foreach (var (country, cities) in countriesWithCities)
    {
        Console.WriteLine($"  {country} -> {String.Join(", ", cities)}");
    }
}