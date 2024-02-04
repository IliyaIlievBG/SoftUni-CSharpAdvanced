string command = Console.ReadLine();

HashSet<string> carsInLot = new HashSet<string>();

while (command != "END")
{
    string[] currentCommand = command.Split(", ", StringSplitOptions.RemoveEmptyEntries);
    
    string direction = currentCommand[0];
    string carNumber = currentCommand[1];

    switch (direction)
    {
        case "IN":
            carsInLot.Add(carNumber);
            break;
        case "OUT":
            carsInLot.Remove(carNumber);
            break;
    }
    command = Console.ReadLine();
}

if (carsInLot.Count>0)
{
    foreach (var carNumber in carsInLot)
    {
        Console.WriteLine(carNumber);
    }
}
else
{
    Console.WriteLine("Parking Lot is Empty");
}

