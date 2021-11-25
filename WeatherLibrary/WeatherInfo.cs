using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherLibrary
{
    /// <summary>
    /// Информация о погоде (температура, ощущение, влажность, давление).
    /// </summary>
    internal class WeatherInfo
    {
        /// <summary>
        /// Текущая температура.
        /// </summary>
        public float Temp { get; set; }
        /// <summary>
        /// Минимальная температура сегодня.
        /// </summary>
        public float Temp_min { get; set; }
        /// <summary>
        /// Максимальная температура сегодня.
        /// </summary>
        public float Temp_max { get; set; }
        /// <summary>
        /// Ощущение погоды человеком.
        /// </summary>
        public float Feels_like { get; set; }
        /// <summary>
        /// Давление.
        /// </summary>
        public float Pressure { get; set; }
        /// <summary>
        /// Влажность
        /// </summary>
        public float Humidity { get; set; }
    }
}
