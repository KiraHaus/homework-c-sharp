using Newtonsoft.Json;
using Telegram.Bot;
using Telegram.Bot.Extensions.Polling;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types;


ITelegramBotClient bot = new TelegramBotClient("token");
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
        else if (message.Text == "/list")
        {
            DirectoryInfo vault = new DirectoryInfo(@"C:\Users\paladich\Desktop\Skillbox\C sharp\9\Great Vault");
            foreach (FileInfo file in vault.GetFiles())
            {
                var inlineSelect = new InlineKeyboardMarkup(new[]
                            {
                                new[] {InlineKeyboardButton.WithCallbackData(file.Name)}
                            });
                await botClient.SendTextMessageAsync(message.Chat, "Файл", replyMarkup: inlineSelect);
            }
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

async void Download (string id, string name)
{
    var file = await bot.GetFileAsync(id);
    FileStream stream = new FileStream($@"C:\Users\paladich\Desktop\Skillbox\C sharp\9\Great Vault\{name}", FileMode.Create);
    await bot.DownloadFileAsync(file.FilePath, stream);
    stream.Close();
    stream.Dispose();
}

async void DownloadPhoto(string id, string name)
{
    var file = await bot.GetFileAsync(id);
    FileStream stream = new FileStream($@"C:\Users\paladich\Desktop\Skillbox\C sharp\9\Great Vault\{name}.jpg", FileMode.Create);
    await bot.DownloadFileAsync(file.FilePath, stream);
    stream.Close();
    stream.Dispose();
}

async void LoadDoc(string name)
{
    FileStream stream = new FileStream($@"C:\Users\paladich\Desktop\Skillbox\C sharp\9\Great Vault\{name}", FileMode.Open);
    await bot.SendDocumentAsync(name, stream);
    stream.Close();
    stream.Dispose();
}

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
