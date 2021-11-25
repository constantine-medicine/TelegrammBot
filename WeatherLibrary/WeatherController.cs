using Newtonsoft.Json;
using System.Net;

namespace WeatherLibrary
{
    public class WeatherController
    {
        /// <summary>
        /// Получает полную информацию о погоде.
        /// </summary>
        /// <param name="city"> Город. </param>
        /// <returns></returns>
        public static string GetWeather(string city)
        {
            string url = $"https://api.openweathermap.org/data/2.5/weather?q={city}&units=metric&lang=ru&appid=c4281ea7dcf9a3c0cd5cf9a247338761";
            HttpWebRequest request = (HttpWebRequest)WebRequest.Create(url);
            HttpWebResponse response;
            try
            {
                response = (HttpWebResponse)request.GetResponse();
            }
            catch (Exception)
            {
                return "Некорректное название города";
                throw;
            }

            string responseString;

            using (StreamReader stream = new StreamReader(response.GetResponseStream()))
            {
                responseString = stream.ReadToEnd();
            }

            WeatherResponse weatherResponse = JsonConvert.DeserializeObject<WeatherResponse>(responseString);
            return $"В городе {weatherResponse.Name} температура {(int)weatherResponse.Main.Temp} градуса." +
                $"\nМинимальная температура сегодня {(int)weatherResponse.Main.Temp_min}, а максимальная температура {(int)weatherResponse.Main.Temp_max} градуса." +
                $"\nОщущается как {(int)weatherResponse.Main.Feels_like} градусов. Давление {weatherResponse.Main.Pressure} мм. ртутного столба." +
                $"\nОтноcительная влажность {weatherResponse.Main.Humidity}%. Скорость ветра {weatherResponse.Wind.Speed} м/c." +
                $"\nОблачность {weatherResponse.Clouds.All}%.";
        }
    }
}
