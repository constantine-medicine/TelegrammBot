using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using Telegram.Bot;
using Telegram.Bot.Types.ReplyMarkups;
using Telegram.Bot.Types.Enums;
using System.Net;
using WeatherLibrary;

namespace TelegrammBot
{
    class Program
    {
        private const string Token = "2124891882:AAFFnt3BrOvHK9FudKqzwHMvLvVW7etCVhs";

        public static SQLiteConnection connection;

        static void Main(string[] args)
        {            
            while (true)
            {
                try
                {
                    GetMessage().Wait();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        static async Task GetMessage()
        {
            TelegramBotClient bot = new TelegramBotClient(Token);
            int offset = 0;
            int timeout = 0;

            try
            {
                await bot.SetWebhookAsync(string.Empty);
                while (true)
                {
                    var updates = await bot.GetUpdatesAsync(offset, timeout);

                    foreach (var update in updates)
                    {
                        var message = update.Message;
                        
                        if (message != null)
                        {
                        }
                        if (message != null && message.Text == "/start")
                        {
                            Console.WriteLine($"Привет {message.Chat.Username}");
                            await bot.SendTextMessageAsync(message.Chat.Id, $"Привет, {message.Chat.Username}.");
                            await bot.SendTextMessageAsync(message.Chat.Id, "Напишите город, чтобы узнать погоду.");

                        }
                        if (message != null && WeatherController.GetWeather($"{message.Text}") != string.Empty)
                        {
                            await bot.SendTextMessageAsync(message.Chat.Id, WeatherController.GetWeather($"{ message.Text}"));
                        }
                        offset = update.Id + 1;
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }

        private static void Registration(string chatId, string username)
        {
            try
            {
                using (connection = new SQLiteConnection(@"Data source = C:\Users\rakin\source\repos\TelegrammBot\TelegrammBot\bin\Db.db;"))
                {
                    using (var command = new SQLiteCommand(connection))
                    {
                        connection.Open();
                        command.CommandText = "INSERT INTO Users VALUES(@chatId, @username)";
                        command.Parameters.AddWithValue("@chatId", chatId);
                        command.Parameters.AddWithValue("@username", username);
                        command.ExecuteNonQuery();
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }

        }

        private static void BoardButtons()
        {
            var board = new KeyboardButton("");
            var keyboard = new ReplyKeyboardMarkup(board)
            {
                Keyboard = new[]
                {
                    new[]
                    {
                        new KeyboardButton("Регистрация"),
                        new KeyboardButton("Погода за окном")
                    }
                }
            };
        }
    }
}
