using System.Data.Common;

int rowsCount = int.Parse(Console.ReadLine());

double[][] myJaggedArray = new double[rowsCount][];

for (int row = 0; row < myJaggedArray.GetLength(0); row++)
{
    myJaggedArray[row] = Console.ReadLine()
        .Split(' ', StringSplitOptions.RemoveEmptyEntries)
        .Select(x => double.Parse(x))
        .ToArray();
}

for (int row = 0; row < myJaggedArray.GetLength(0) - 1; row++)
{
    if (myJaggedArray[row].Length == myJaggedArray[row + 1].Length)
    {
        for (int column = 0; column < myJaggedArray[row].Length; column++)
        {
            myJaggedArray[row][column] *= 2;
            myJaggedArray[row + 1][column] *= 2;
        }
        continue;
    }

    for (int column = 0; column < myJaggedArray[row].Length; column++)
    {
        myJaggedArray[row][column] /= 2;
    }

    for (int column = 0; column < myJaggedArray[row + 1].Length; column++)
    {
        myJaggedArray[row + 1][column] /= 2;
    }
}

string command = Console.ReadLine();

while (command != "End")
{
    string[] currentCommand = command.Split(' ', StringSplitOptions.RemoveEmptyEntries);
    bool validCommand = CheckIfCommandIsValid(currentCommand, myJaggedArray);
    if (validCommand)
    {
        if (currentCommand[0] == "Add")
        {
            myJaggedArray[int.Parse(currentCommand[1])][int.Parse(currentCommand[2])] +=
                double.Parse(currentCommand[3]);
        }
        else
        {
            myJaggedArray[int.Parse(currentCommand[1])][int.Parse(currentCommand[2])] -=
                double.Parse(currentCommand[3]);
        }
    }

    command = Console.ReadLine();
}

for (int row = 0; row < myJaggedArray.GetLength(0); row++)
{
    Console.WriteLine(string.Join(' ', myJaggedArray[row]));
}

bool CheckIfCommandIsValid(string[] currentCommand, double[][] myJaggedArray)
{
    if (currentCommand.Length == 4
        && (currentCommand[0] == "Add" || currentCommand[0] == "Subtract")
        && (int.Parse(currentCommand[1]) >= 0 && int.Parse(currentCommand[1]) <= myJaggedArray.GetLength(0) - 1) //<= might be wrong; try with < only
        && (int.Parse(currentCommand[2]) >= 0 && int.Parse(currentCommand[2]) <= myJaggedArray[int.Parse(currentCommand[1])].Length - 1)) //check this -1 might be removed
    {
        return true;
    }

    return false;
}