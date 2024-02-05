SortedDictionary<string, Dictionary<string, double>> shopList =
    new SortedDictionary<string, Dictionary<string, double>>();

string command = Console.ReadLine();

while (command != "Revision")
{
    string[] currentProductInfo = command.Split(", ");

    string shop = currentProductInfo[0];
    string product = currentProductInfo[1];
    double price = double.Parse(currentProductInfo[2]);

    if (!shopList.ContainsKey(shop))
    {
        shopList.Add(shop, new Dictionary<string, double>());
    }

    if (!shopList[shop].ContainsKey(product))
    {
        shopList[shop].Add(product, price);
    }

    shopList[shop][product] = price;

    command = Console.ReadLine();
}

foreach (var (shop, productCollection) in shopList)
{
    Console.WriteLine($"{shop}->");

    foreach (var (product,price) in productCollection)
    {
        Console.WriteLine($"Product: {product}, Price: {price}");
    }
}