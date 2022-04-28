using Hw_7;

Worker Ivan = new Worker()
{
    Name = "Ivan",
    Id = 1,
    Date = DateTime.Now,
    Birth = new DateOnly(1994, 08, 23),
    Age = 23,
    Place = "Moscow"
};
Worker Ivan2 = new Worker(1, "Ivan", 23, 176, new DateOnly(1994, 08, 23), "Moscow");
Console.WriteLine(Ivan2.ShowInfo());
Console.WriteLine(Ivan.ShowInfo());
