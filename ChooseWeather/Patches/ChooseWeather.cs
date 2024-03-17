using BepInEx.Logging;
using GameNetcodeStuff;
using HarmonyLib;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace ChooseWeather.Patches
{

    [HarmonyPatch(typeof(StartOfRound))]
    internal class ChooseWeather
    {
        private static string actualWeather = null;

        [HarmonyPatch("SetPlanetsWeather")]
        [HarmonyPostfix]
        static void UpdateWeather(ref SelectableLevel[] ___levels)
        {
            if (actualWeather == null) {  return; }

            for (int i = 0; i < ___levels.Length; i++) {
                ___levels[i].currentWeather = (LevelWeatherType) Weather.WeatherStringToEnum(actualWeather);
            }        

        }

        public static void ChangeWeather(string newWeather) {
            actualWeather = newWeather;
        }

    }







}

