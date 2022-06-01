///Приложение для определения четности числа

Console.WriteLine("Введите целое число");
int number = Convert.ToInt32(Console.ReadLine());
if (number % 2 == 0)
{
    Console.WriteLine($" {number} четное число");
}
else
{
    Console.WriteLine($" {number} нечетное число");
}



///Приложение для счета карт в blackjack

Console.WriteLine("Введите число карт");
int card_count = Convert.ToInt32(Console.ReadLine());
int summary = 0;
for (int i = 0; i < card_count; i++)
{
    Console.WriteLine("Введите номинал карты");
    string nominal = Console.ReadLine();
    switch (nominal)
    {
        case "2":
            int nom2 = Convert.ToInt32(nominal);
            summary += nom2;
            break;

        case "3":
            int nom3 = Convert.ToInt32(nominal);
            summary += nom3;
            break;

        case "4":
            int nom4 = Convert.ToInt32(nominal);
            summary += nom4;
            break;
        case "5":
            int nom5 = Convert.ToInt32(nominal);
            summary += nom5;
            break; ;

        case "6":
            int nom6 = Convert.ToInt32(nominal);
            summary += nom6;
            break;

        case "7":
            int nom7 = Convert.ToInt32(nominal);
            summary += nom7;
            break;

        case "8":
            int nom8 = Convert.ToInt32(nominal);
            summary += nom8;
            break;

        case "9":
            int nom9 = Convert.ToInt32(nominal);
            summary += nom9;
            break;

        case "10":
            int nom10 = Convert.ToInt32(nominal);
            summary += nom10;
            break;

        case "j":
            summary += 2;
            break;

        case "q":
            summary += 3;
            break;

        case "k":
            summary += 4;
            break;

        case "a":
            summary += 11;
            break;
    }
}
Console.WriteLine($"Общая сумма карт: {summary}");



/// Приложение для проверки простого числа

bool prost = true;
Console.WriteLine("Введите число\n");
int number = Convert.ToInt32(Console.ReadLine());
int count = 2;
bool answer = true;
while (count <= number/2)
{
    if (number % count == 0)
    {
        answer = false;
        break;
    }
    else
    {
        count++;
    }
}
if (answer)
{
    Console.WriteLine("Число простое");
}
else
{
    Console.WriteLine("Число не простое");
}
