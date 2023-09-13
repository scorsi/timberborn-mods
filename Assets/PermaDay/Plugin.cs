using HarmonyLib;
using TimberApi.ConsoleSystem;
using TimberApi.ModSystem;

namespace Scorsi.PermaDay
{
    public class Plugin : IModEntrypoint
    {
        public const string PluginGuid = "scorsi.perma-day";
        public const string PluginName = "PermaDay";
        public const string PluginVersion = "1.0.0";

        private static Harmony _harmony;
        private static IMod _mod;
        public static IConsoleWriter Log;

        public void Entry(IMod mod, IConsoleWriter consoleWriter)
        {
            Log = consoleWriter;
            _mod = mod;
            _harmony = new Harmony(PluginGuid);
            _harmony.PatchAll();
        }
    }
}