namespace BlockWars_Fabric_Installer
{
    public static class FabricInstaller
    {
        public static string loaderName = $"fabric-loader-{Info.fabricVersion}-{Info.gameVersion}";
        public static string versionPath = $"{Info.vars.minecraftDirectory}\\versions\\{loaderName}";
        
        public static void InstallFabric()
        {
            if (Directory.Exists(versionPath))
            {
                return;
            }
            Directory.CreateDirectory(versionPath);
            File.Create($"{versionPath}\\{loaderName}.jar");

            var data = new ModDownloader().getString(
                $"https://meta.fabricmc.net/v2/versions/loader/{Info.gameVersion}/{Info.fabricVersion}/profile/json");
            File.WriteAllText($"{versionPath}\\{loaderName}.json", data);
        }
    }
}
