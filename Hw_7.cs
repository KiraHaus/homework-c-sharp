string path = @"C:\Users\paladich\Desktop\Skillbox\C sharp\7\Hw 7\database.xml";

Base database = new Base(path);

database.Load();

//database.AddWorker(new Worker(database.Count + 1, "Паладич Кирилл Максимович", 27, 178, new DateTime(1994, 08, 23), "Москва"));

database.Print();
database.WriteData();

database.Sort();
