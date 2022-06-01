using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;

ITelegramBotClient bot = new TelegramBotClient("token");
string path = @"Great Vault";
async Task HandleUpdateAsync(ITelegramBotClient botClient, Update update, CancellationToken cancellationToken)
{
    Console.WriteLine(JsonConvert.SerializeObject(update));
    if (update.Type == Telegram.Bot.Types.Enums.UpdateType.Message)
    {
        string name = "";
        var message = update.Message;
        if (message.Text == "/start")
        {
            await botClient.SendTextMessageAsync(message.Chat, "Приветствую, мешок с мясом!");
            return;
        }
        else if(System.IO.File.Exists(@$"{path}\{message.Text}"))
        {
            var id = message.From.Id;
            LoadDoc(id, message.Text);
        }
        else if (message.Text == "/command")
        {
            await botClient.SendTextMessageAsync(message.Chat, "/start - Запуск бота\r\n/list - Список файлов\r\n");
        }
        else if (message.Text == "/list")
        {
            await FileList(botClient, message);
        }
        else if (message.Type == Telegram.Bot.Types.Enums.MessageType.Text)
        {
            await botClient.SendTextMessageAsync(message.Chat, "Bite my shiny metal ass!");
        }

        else if (message.Type == Telegram.Bot.Types.Enums.MessageType.Document)
        {
            Download(message.Document.FileId, message.Document.FileName);
            await botClient.SendTextMessageAsync(message.Chat, "Все, я богат! Пока, неудачники! Я вас всегда ненавидел!");
        }

        else if (message.Type == Telegram.Bot.Types.Enums.MessageType.Photo)
        {
            DownloadPhoto(message.Photo[0].FileId, message.Photo[0].FileId);
            await botClient.SendTextMessageAsync(message.Chat, "Все, я богат! Пока, неудачники! Я вас всегда ненавидел!");
        }

        else if (message.Text == null)
        {
            await botClient.SendTextMessageAsync(message.Chat, "Дорогая, хочешь убить всех людей?");
        }

        else
        {
            await botClient.SendTextMessageAsync(message.Chat, "Я Бендер. Пожалуйста, дайте мне прут");
        }
    }
}
///Отображение доументов хранилища
async Task FileList (ITelegramBotClient botClient, Message? message)
{
    DirectoryInfo vault = new DirectoryInfo(path);
    var list = new List<KeyboardButton>();
    foreach (FileInfo file in vault.GetFiles())
    {
        list.Add(new KeyboardButton(file.Name));
    }
    var markup = new ReplyKeyboardMarkup(list);
    await botClient.SendTextMessageAsync(message.Chat, "All files in the Great Vault", replyMarkup: markup);
}
///Скачивание документа
async void Download (string id, string name)
{
    var file = await bot.GetFileAsync(id);
    FileStream stream = new FileStream($@"{path}\{name}", FileMode.Create);
    await bot.DownloadFileAsync(file.FilePath, stream);
    stream.Close();
    stream.Dispose();
}
///Скачивание фото
async void DownloadPhoto(string id, string name)
{
    var file = await bot.GetFileAsync(id);
    FileStream stream = new FileStream($@"{path}\{name}.jpg", FileMode.Create);
    await bot.DownloadFileAsync(file.FilePath, stream);
    stream.Close();
    stream.Dispose();
}
///Загрузка документов из хранилища
async void LoadDoc(long id, string name)
{
    Stream fs = System.IO.File.OpenRead($@"{path}\{name}");
    var document = new Telegram.Bot.Types.InputFiles.InputOnlineFile(fs);
    document.FileName = name;
    await bot.SendDocumentAsync(id, document);
    fs.Close();
    fs.Dispose();
}
///Исключения
static async Task HandleErrorAsync(ITelegramBotClient botClient, Exception exception, CancellationToken cancellationToken)
{
    Console.WriteLine(JsonConvert.SerializeObject(exception));
}


Console.WriteLine("Бендер 'Хранитель' Родригес здесь! " + bot.GetMeAsync().Result.FirstName);

var cts = new CancellationTokenSource();
var cancellationToken = cts.Token;
var receiverOptions = new ReceiverOptions
{
    AllowedUpdates = { },
};
bot.StartReceiving(
    HandleUpdateAsync,
    HandleErrorAsync,
    receiverOptions,
    cancellationToken
);
Console.ReadLine();
