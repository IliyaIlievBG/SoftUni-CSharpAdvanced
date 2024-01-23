int greenLightInSeconds = int.Parse(Console.ReadLine());
int freeWindowDuration = int.Parse(Console.ReadLine());

string input = Console.ReadLine();

Queue<string> carsInQueue = new Queue<string>();

int successfullyPassedCars = 0;
while (input != "END")
{
    string nextCar = input;
    if (nextCar != "green")
    {
        carsInQueue.Enqueue(nextCar);
      
    }
    else
    {
        int secondsUntilYellow = greenLightInSeconds;
        while (secondsUntilYellow > 0 && carsInQueue.Count > 0)
        {
            string nextCarPassing = carsInQueue.Dequeue();

            bool carCrash = CheckForCarCrash(secondsUntilYellow, freeWindowDuration, nextCarPassing.Length);

            if (carCrash)
            {
                Console.WriteLine("A crash happened!");
                Console.WriteLine($"{nextCarPassing} was hit at {nextCarPassing[secondsUntilYellow + freeWindowDuration]}.");
                return;
            }
            else
            {
                secondsUntilYellow -= nextCarPassing.Length;
                successfullyPassedCars++;    
            }
        }
    }

    input = Console.ReadLine();
}

Console.WriteLine("Everyone is safe.");
Console.WriteLine($"{successfullyPassedCars} total cars passed the crossroads.");

bool CheckForCarCrash(int secondsUntilYellow, int freeWindowDuration, int nextCarPassing)
{
    return secondsUntilYellow + freeWindowDuration < nextCarPassing;
}