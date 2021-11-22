using System;
using System.Threading.Tasks;
using Telegram.Bot;

namespace TelegrammBot
{
    class Program
    {
        private const string Token = "2124891882:AAFFnt3BrOvHK9FudKqzwHMvLvVW7etCVhs";

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
            Console.ReadLine();
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
                        offset = update.Id + 1;
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
