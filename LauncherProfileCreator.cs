using System.Diagnostics;
using System.Text.Json;

namespace BlockWars_Fabric_Installer
{
    public static class LauncherProfileCreator
    {
        public static string profileFile = $"{Info.vars.minecraftDirectory}\\launcher_profiles.json";
        public static string optionsFile = $"{Info.vars.minecraftDirectory}\\options.txt";
        public static string serverDat = $"{Info.vars.minecraftDirectory}\\servers.dat";

        public static void createNewProfile()
        {
            string prof = File.ReadAllText(profileFile);
            var json = JsonSerializer.Deserialize<LauncherProfiles>(prof)!;
            Dictionary<string, Profile> profiles = json.profiles;
            Profile newProfile = new Profile();
            newProfile.created = DateTime.Now;
            newProfile.gameDir = Info.blockwarsDirectory;
            newProfile.icon = Info.profileImageBase64;
            newProfile.lastUsed = DateTime.Now;
            newProfile.lastVersionId = FabricInstaller.loaderName;
            newProfile.name = "BlockWars Modpack";
            newProfile.type = "custom";
            if (profiles.ContainsKey("blockwars"))
            {
                profiles.Remove("blockwars");
            }
            profiles.Add("blockwars", newProfile);
            json.profiles = profiles;
            File.WriteAllBytes(profileFile, JsonSerializer.SerializeToUtf8Bytes(json));
            if (File.Exists(optionsFile))
            {
                File.Delete($"{Info.blockwarsDirectory}\\options.txt");
                File.Copy(optionsFile, $"{Info.blockwarsDirectory}\\options.txt");
            }
        }

        public static bool isLauncherRunning()
        {
            bool isRunning = false;
            Process[] processes = Process.GetProcessesByName("MinecraftLauncher");
            if (processes.Length == 0)
            {
                isRunning = false;

            } else
            {
                isRunning = true;
            }
            return isRunning;
        }
    }
}
