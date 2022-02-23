using System.IO;
using Newtonsoft.Json;

namespace XIVLauncher.Common
{
    class DalamudSettings
    {
        public string? DalamudBetaKey { get; set; } = null;
        public bool DoDalamudRuntime { get; set; } = false;
        public string DalamudBetaKind { get; set; }
        public bool? OptOutMbCollection { get; set; }


        public static readonly string CONFIG_PATH = Path.Combine(Paths.RoamingPath, "dalamudConfig.json");

        public static DalamudSettings GetSettings()
        {
            var deserialized = File.Exists(CONFIG_PATH) ? JsonConvert.DeserializeObject<DalamudSettings>(File.ReadAllText(CONFIG_PATH)) : new DalamudSettings();
            deserialized ??= new DalamudSettings(); // In case the .json is corrupted
            return deserialized;
        }
    }
}