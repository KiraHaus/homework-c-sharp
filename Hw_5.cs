
//Разделение строки по словам

static string[] SplitString(string stroka)
{
    char[] separators = new char[] { ' ', '.', ',', '!', '?' };
    string[] words = stroka.Split(separators, StringSplitOptions.RemoveEmptyEntries);

    return words;
}

static void WordsArray(string stroka)
{
    string[] array = SplitString(stroka);
    foreach (string word in array)
    {
        Console.WriteLine(word);
    }
}

Console.WriteLine("Введи строку");
string userString = Console.ReadLine();
WordsArray(userString);


// Миксование слов в предложении

static string[] SplitStringSimple (string stroka)
{
    string[] words = stroka.Split(' ');
    return words;
}

static void MixWords (string stroka)
{
    string newSentence = string.Empty;
    string [] sentence = SplitStringSimple (stroka);
    for (int i = sentence.Length - 1; i >= 0; i--)
    {
        newSentence += sentence[i];
    }
    Console.WriteLine (newSentence);
}

Console.WriteLine ("Введи строку");
string mixUserString = Console.ReadLine ();
MixWords (mixUserString);
