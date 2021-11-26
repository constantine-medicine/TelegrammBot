using System;
using TelegramLibrary;

namespace TelegrammBot
{
    class Program
    {
        static void Main(string[] args)
        {
            SetConsoleSettings();

            Console.WriteLine("Введите свой токен бота.");
            string token = Console.ReadLine();
            TelegramController.Token = token;
            
            while (true)
            {
                try
                {
                    TelegramController.GetMessage().Wait();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                }
            }
        }

        private static void SetConsoleSettings()
        {
            Console.ForegroundColor = ConsoleColor.Yellow;
            Console.BackgroundColor = ConsoleColor.Blue;
            Console.Title = "Бот погоды";
            Console.SetWindowSize(75, 10);
        }       
    }
}
