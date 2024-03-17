using BepInEx;
using BepInEx.Logging;
using ChooseWeather.Patches;
using HarmonyLib;
using TerminalApi;
using TerminalApi.Classes;
using static TerminalApi.TerminalApi;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using System.Runtime.InteropServices.WindowsRuntime;


namespace ChooseWeather
{
    [BepInPlugin(modGUIID, modName, modVersion)]
    public class ChooseWeatherBase : BaseUnityPlugin
    {
        private const string modGUIID = "digjohnsons.ChooseWeather";
        private const string modName = "Choose Weather";
        private const string modVersion = "1.0.0.0";

        private readonly Harmony harmony = new Harmony(modGUIID);

        private static ChooseWeatherBase instance;

        internal ManualLogSource mls;      

        void Awake() 
        {
            if (instance == null) 
            {
                instance = this;
            }

            mls = BepInEx.Logging.Logger.CreateLogSource(modGUIID);
            mls.LogInfo("The mod Choose Weather has awaken.");

            AddDisableModCommand();
            //AddWeatherCommand(Weather.dustClouds);  // This is in the game code, but it's not used.
            AddWeatherCommand(Weather.clear);
            AddWeatherCommand(Weather.eclipsed);
            AddWeatherCommand(Weather.flooded);
            AddWeatherCommand(Weather.foggy);
            AddWeatherCommand(Weather.rainy);
            AddWeatherCommand(Weather.stormy);

            harmony.PatchAll(typeof(Patches.ChooseWeather));
        }

        private void AddWeatherCommand(string weather) {
            AddCommand(weather, new CommandInfo
                        {
                            Category = "other",
                            Description = "From now on all moon's weather will be " + weather + ".",
                            DisplayTextSupplier = () => {
                                return ChangeWeather(weather);
                            }
                        },
                        "weather");
        }
        
        private void AddDisableModCommand() {
            AddCommand("disable", new CommandInfo
            {
                Category = "other",
                Description = "Turns off the ChooseWeatherMod's effects.",
                DisplayTextSupplier = DisableWeatherChanging
            },
            "weather");
        }

        private string ChangeWeather(string newWeather) {
            ChooseWeather.Patches.ChooseWeather.ChangeWeather(newWeather);
            return "Weather will be changed to " + newWeather + ".\n(Starting tomorrow)\n";
        }

        private string DisableWeatherChanging() {
            ChooseWeather.Patches.ChooseWeather.ChangeWeather(null);
            return "Weather changing is now disable.\n(Starting tomorrow)\n";
        }
        
    }

}

