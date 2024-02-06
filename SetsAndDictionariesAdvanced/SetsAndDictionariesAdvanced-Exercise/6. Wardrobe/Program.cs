int inputLines = int.Parse(Console.ReadLine());

Dictionary<string, Dictionary<string, int>> wardrobe = new Dictionary<string, Dictionary<string, int>>();


for (int i = 0; i < inputLines; i++)
{
    string[] nextSetOfClothes = Console.ReadLine()
        .Split(new string[] { " -> ", "," }, StringSplitOptions.RemoveEmptyEntries);

    string color = nextSetOfClothes[0];

    if (!wardrobe.ContainsKey(color))
    {
        wardrobe.Add(color, new Dictionary<string, int>());
    }

    for (int j = 1; j < nextSetOfClothes.Length; j++)
    {
        if (!wardrobe[color].ContainsKey(nextSetOfClothes[j]))
        {
            wardrobe[color].Add(nextSetOfClothes[j], 0);
        }

        wardrobe[color][nextSetOfClothes[j]]++;
    }

}

string[] itemToSearch = Console.ReadLine()
    .Split(' ', StringSplitOptions.RemoveEmptyEntries);

foreach (var (color, clothes) in wardrobe)
{
    Console.WriteLine($"{color} clothes:");

    foreach (var (wear, count) in clothes)
    {
        bool foundWeaer = itemToSearch[0] == color && itemToSearch[1] == wear;
        string foundItem = foundWeaer ? " (found!)" : String.Empty;

        Console.WriteLine($"* {wear} - {count}{foundItem}");
    }
}