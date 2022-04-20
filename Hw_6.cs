using System.IO;

/// <summary>
/// Показывает файл
/// </summary>
static void ShowFile(string path)
{
    using (StreamReader info = new StreamReader($@"{path}"))
    {
        string line = null;
        while ((line = info.ReadLine()) != null)
        {
            string user = line.Replace("#", "; ");
            Console.WriteLine(user);
        }
    }
}

/// <summary>
/// Определяет наличие файла
/// </summary>
static bool FileCheck(string name)
{
    bool f = File.Exists(name);
    if (f == true)
    {
        return true;
    }
    else
    {
        return false;
    }
}


/// <summary>
/// Добавляет данные в файл
/// </summary>
static void AddData(string info, string path)
{
    int id = File.ReadAllLines($@"{path}").Length;//При новом файле почему-то выдает ошибку в этой строке
    if (id == 0)
    {
        id = 1;
    }
    else
    {
        id += 1;
    }
    DateTime date = DateTime.Now;
    using (StreamWriter add = new StreamWriter($@"{path}", true))
    {
        string part = Convert.ToString(id) + ";" + Convert.ToString(date) + ";";
        string data = part + info;
        string dataAll = data.Replace(";", "#");
        add.WriteLine(dataAll);
    }
}

Console.WriteLine("Программа запущена!\nВведите путь к вашему файлу. Если файла нет - мы его создадим");
string path = Console.ReadLine();

if (FileCheck(path) == true)
{
    Console.WriteLine("Файл найден!");
}
else
{
    File.Create(path);
    Console.WriteLine("Файл создан!");
}

Console.WriteLine("Выберите, просмотреть записи в файле (1) или ввести данные о новом сотруднике (2)");
int choice = int.Parse(Console.ReadLine());

if (choice == 1)
{
    ShowFile(path);
}
else if (choice == 2)
{
    Console.WriteLine("Введите Ф.И.О, возраст, рост, дату рождения, место рождения через ';'");
    string info = Console.ReadLine();
    AddData(info, path);
    Console.WriteLine("Сотрудник добавлен");


}
else
{
    Console.WriteLine("Неверная команда! Приложение закрыто.");
}
