using Hw_7;

Worker Ivan = new Worker();
//Worker Ivan = new Worker(1, "Ivan", 23, 178, 23.08.1994, "Moscow");
//Здесь не работает

Ivan.Birth = DateOnly.Parse("23.08.1994");
Ivan.Name = "Ivan Ivanych";
Ivan.Age = 23;
Ivan.Place = "Moscow";
Ivan.Id = 1;
Ivan.Height = 178;

Ivan.ShowInfo(1);
