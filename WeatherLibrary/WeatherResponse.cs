using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLibrary
{
    /// <summary>
    /// Общий класс погоды.
    /// </summary>
    internal class WeatherResponse
    {
        /// <summary>
        /// Город для определения погоды в нем.
        /// </summary>
        public string? Name { get; set; }
        /// <summary>
        /// Общая информация о погоде.
        /// </summary>
        public WeatherInfo? Main { get; set; }
        /// <summary>
        /// Информация о ветре.
        /// </summary>
        public Wind? Wind { get; set; }
        /// <summary>
        /// Информация об облачности.
        /// </summary>
        public Clouds? Clouds { get; set; }
    }
}