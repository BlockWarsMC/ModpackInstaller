using System.Diagnostics;
using System.Text.Json;

namespace BlockWars_Fabric_Installer
{
    public static class LauncherProfileCreator
    {
        private static readonly string ProfileFile = $"{Info.Vars.minecraftDirectory}\\launcher_profiles.json";
        private static readonly string OptionsFile = $"{Info.Vars.minecraftDirectory}\\options.txt";
        private static readonly string ServersDat = $"{Info.Vars.minecraftDirectory}\\servers.dat";
        private static readonly string HotbarNbt = $"{Info.Vars.minecraftDirectory}\\hotbar.nbt";

        public static void CreateNewProfile()
        {
            var prof = File.ReadAllText(ProfileFile);
            var json = JsonSerializer.Deserialize<LauncherProfiles>(prof)!;
            var profiles = json.profiles;
            var newProfile = new Profile
            {
                gameDir = Info.BlockwarsDirectory,
                icon = Info.ProfileImageBase64,
                lastVersionId = FabricInstaller.LoaderName,
                name = "BlockWars Modpack",
                type = "custom"
            };
            
            if (profiles.ContainsKey("blockwars")) profiles.Remove("blockwars");
            
            profiles.Add("blockwars", newProfile);
            json.profiles = profiles;
            File.WriteAllBytes(ProfileFile, JsonSerializer.SerializeToUtf8Bytes(json));
            if(File.Exists(ServersDat))
            {
                File.Delete($"{Info.BlockwarsDirectory}\\servers.dat");
                File.Copy(ServersDat, $"{Info.BlockwarsDirectory}\\servers.dat");

            }
            if(File.Exists(HotbarNbt))
            {
                File.Delete($"{Info.BlockwarsDirectory}\\hotbar.nbt");
                File.Copy(HotbarNbt, $"{Info.BlockwarsDirectory}\\hotbar.nbt");
            }
            if (File.Exists(OptionsFile))
            {
                File.Delete($"{Info.BlockwarsDirectory}\\options.txt");
                File.Copy(OptionsFile, $"{Info.BlockwarsDirectory}\\options.txt");
            }
        }

        public static bool IsLauncherRunning()
        {
            bool isRunning;
            var launcherProcessOld = Process.GetProcessesByName("MinecraftLauncher");
            var launcherProcessNew = Process.GetProcessesByName("Minecraft");
            if (launcherProcessNew.Length == 0 && launcherProcessOld.Length == 0) isRunning = false; else isRunning = true;
            return isRunning;
        }
    }
}
