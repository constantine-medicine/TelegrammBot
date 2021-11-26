using Telegram.Bot;
using WeatherLibrary;

namespace TelegramLibrary
{
    public class TelegramController
    {
        public static string Token { get; set; }

        public static async Task GetMessage()
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
    }
}
