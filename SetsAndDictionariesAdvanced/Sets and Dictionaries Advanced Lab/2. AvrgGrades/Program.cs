int studentsCount = int.Parse(Console.ReadLine());

Dictionary<string, List<decimal>> students = new Dictionary<string, List<decimal>>();

for (int i = 0; i < studentsCount; i++)
{
    string[] currentStudent = Console.ReadLine().Split(' ', StringSplitOptions.RemoveEmptyEntries).ToArray();

    string studentName = currentStudent[0];
    decimal grade = decimal.Parse(currentStudent[1]); //maybe we should round up the grade here

    if (!students.ContainsKey(studentName))
    {
        students.Add(studentName, new List<decimal>());
    }

    students[studentName].Add(grade);
}

foreach (var student in students)
{
    Console.Write($"{student.Key} -> ");

    foreach (var grade in student.Value)
    {
        Console.Write($"{grade:F2} ");
    }

    Console.WriteLine($"(avg: {student.Value.Average():F2})");
}