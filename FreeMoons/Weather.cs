using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChooseWeather.Patches
{
    internal class Weather
    {

        public const string dustClouds = "DUST_CLOUDS"; 
        public const string rainy = "RAINY";
        public const string stormy = "STORMY";
        public const string foggy = "FOGGY";
        public const string flooded = "FLOODED";
        public const string eclipsed = "ECLIPSED";
        public const string clear = "CLEAR";

        // Game code has a Enum called LevelWeatherType.
        public static int WeatherStringToEnum(string weather) { 
            switch (weather)
            {
                case dustClouds:
                    return 0;
                case rainy:
                    return 1;
                case stormy:
                    return 2;
                case foggy:
                    return 3;
                case flooded:
                    return 4;
                case eclipsed:
                    return 5;
                default:
                    return -1;
            }

        }



    }
}
