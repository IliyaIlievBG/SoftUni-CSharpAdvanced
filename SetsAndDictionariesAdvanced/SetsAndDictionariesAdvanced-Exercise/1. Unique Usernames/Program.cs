HashSet<string> names = new HashSet<string>();

int namesCount = int.Parse(Console.ReadLine());

for (int i = 0; i < namesCount; i++)
{
    names.Add(Console.ReadLine());
}

foreach (var name in names)
{
    Console.WriteLine(name);
}