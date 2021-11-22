using System;
using System.Data.SQLite;
using System.Threading.Tasks;
using Telegram.Bot;

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
                    Console.WriteLine("Check");
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

                        if (message.Text == "Привет")
                        {
                            Console.WriteLine("Привет дорогой");
                            await bot.SendTextMessageAsync(message.Chat.Id, $"Привет дорогой, {message.Chat.Username}");
                        }
                        if (message.Text == "/reg")
                        {
                            Registration(message.Chat.Id.ToString(), message.Chat.Username);
                            await bot.SendTextMessageAsync(message.Chat.Id, $"Пользователь {message.Chat.Username} зарегестрирован");
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
    }
}
