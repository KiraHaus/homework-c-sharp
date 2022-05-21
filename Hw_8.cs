using System.Collections.Generic;
using System.Xml.Serialization;
using System.Xml.Linq;
using Hw_8;

/// РАБОТА СО СПИСКОМ   
/// <summary>
/// Заполнение списка
/// </summary>
static void WriteIn(List<int> list)
{
    Random numbers = new Random();

    for (int i = 0; i < 100; i++)
    {
        list.Add(numbers.Next(1, 100));
    }
}

/// <summary>
/// Вывод списка на экран
/// </summary>
static void Print(List<int> list)
{
    foreach (int i in list)
    {
        Console.WriteLine(i);
    }
}

static void Del(List<int> list, int i, int j)
{
    List<int> numbs = new List<int>();

    for (int n = 0; n < list.Count; n++)
    {

        if (list[n] > i & list[n] < j)
        {
            continue;
        }
        else
        {
            numbs.Add(list[n]);
        }
    }

    list.Clear();
    list.AddRange(numbs);
}


List<int> NumbList = new List<int>();
WriteIn(NumbList);
Print(NumbList);
Del(NumbList, 25, 50);
Print(NumbList);

///РАБОТА СО СЛОВАРЕМ
static void Add(Dictionary<string, string> notebook)
{
    while (true)
    {
        Console.WriteLine("Введите ФИО");
        string name = Console.ReadLine();
        if (name == "") break;
        Console.WriteLine("Введите номер");
        string numb = Console.ReadLine();
        if (numb == "") break;
        notebook.Add(numb, name);
    }
}

static void Search(Dictionary<string, string> notebook, string numb)
{
    if (notebook.ContainsKey(numb)) Console.WriteLine(notebook[$"{numb}"]);
    else Console.WriteLine("Абонент не найден");
}

Dictionary<string, string> Contacts = new Dictionary<string, string>();
Add(Contacts);
Search(Contacts, "89521109088");

/// РАБОТА С ХЭШЕМ
HashSet<int> numbs = new HashSet<int>();
for (int j = 0; j < 10; j++)
{
    Console.WriteLine("Введите число");
    int n = Convert.ToInt32(Console.ReadLine());
    if (numbs.Contains(n))
    {
        Console.WriteLine("Число уже есть в коллекции");
    }
    else if (!numbs.Contains(n))
    {
        numbs.Add(n);
        Console.WriteLine("Число добавлено");
    }
}

///РАБОТА С XML
static XElement Create(string name, string street, int house, int appartment, string phone, string homePhone)
{
    XElement human = new XElement("Person", name,
    new XElement("Address",
        new XElement("Street", street),
        new XElement("HouseNumber", house),
        new XElement("FlatNumber", appartment)),
    new XElement("Phones",
        new XElement("MobilePhone", phone),
        new XElement("FlatPhone", homePhone))
    );
    return human;
}


static void Serialization(XElement human, string path)
{
    XmlSerializer serializer = new XmlSerializer(typeof(XElement));
    Stream stream = new FileStream(path, FileMode.Create, FileAccess.Write);
    serializer.Serialize(stream, human);
    stream.Close();
}

static void Deserialize(XElement human,string path)
{
    XmlSerializer serializer = new XmlSerializer(typeof(XElement));
    Stream stream = new FileStream(path, FileMode.Open, FileAccess.Read);
    human = XElement.Load(stream);
    stream.Close();
}

string path = "_human.xml";

XElement contact1 = Create("Kirill", "Nemansky st", 1, 369, "89521109088", "7572515");
Serialization(contact1, path);
Deserialize(contact1, path);
