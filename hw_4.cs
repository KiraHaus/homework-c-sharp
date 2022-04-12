//Матрица от пользователя

Console.WriteLine("Введите число столбцов");
int a = int.Parse(Console.ReadLine());

Console.WriteLine("Введите число строк");
int b = int.Parse(Console.ReadLine());

int[,] matrix2d = new int[a, b];
int summ = 0;

Random rand = new Random();

for (int i = 0; i < a; i++)
{
    for (int j = 0; j < b; j++)
    {
        matrix2d[i, j] = rand.Next(20);
        summ += matrix2d[i, j];
        Console.WriteLine(matrix2d[i, j]);
    }
}
Console.WriteLine($"Сумма чисел матрицы: {summ}");


// Наименьший элемент

Console.WriteLine("Введите длину последовательности: ");
int lenght = int.Parse(Console.ReadLine());

int[] array = new int[lenght];
int start = int.MaxValue;
int lessNum = 0;

for (int i = 0; i < lenght; i++)
{
    Console.WriteLine("Ведите число в последовательность");
    int num = int.Parse(Console.ReadLine());
    array[i] = num;
    if (num < lessNum)
    {
        lessNum = num;
    }
    else
    {
        continue;
    }

}
Console.WriteLine("Последовательность заполнена");
Console.WriteLine($"Наименьшее число: {lessNum}");


Угадай число

Console.WriteLine("Введи максимальное число для диапазона:");
int lenght = int.Parse(Console.ReadLine());
Random rand = new Random ();
int numb = rand.Next (lenght);
Console.WriteLine("Случайное число создано! А теперь попробуй его угадать =) Если устал - введи '-1'");

while (true)
{
    int numPerson = int.Parse(Console.ReadLine());
    if (numPerson == -1)
    {
        Console.WriteLine("Игра закончена!");
        break;
    }
    else if ( numPerson != numb)
    {
        Console.WriteLine("Неверно! Попробуй снова");
        continue;
    }
    else
    {
        Console.WriteLine($"Верно! Это число {numb}");
        break;
    }
}
