int carsToGoOnGreen = int.Parse(Console.ReadLine());

string car = Console.ReadLine();

Queue<string> carsAtTheTrafficLight = new Queue<string>();
int passedCars = 0;

while (car != "end")
{
    if (car == "green")
    {
        for (int i = 0; i < carsToGoOnGreen; i++)
        {
            if (carsAtTheTrafficLight.Count > 0)
            {
                Console.WriteLine($"{carsAtTheTrafficLight.Dequeue()} passed!");
                passedCars++;
            }
        }
    }
    else
    {
        carsAtTheTrafficLight.Enqueue(car);
    }
    car = Console.ReadLine();
}

Console.WriteLine($"{passedCars} cars passed the crossroads.");
