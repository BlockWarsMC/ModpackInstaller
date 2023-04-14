namespace BlockWars_Fabric_Installer
{
    public static class FabricInstaller
    {
        public const string LoaderName = $"fabric-loader-{Info.FabricVersion}-{Info.GameVersion}";
        private static readonly string VersionPath = $"{Info.Vars.minecraftDirectory}\\versions\\{LoaderName}";
        
        public static void InstallFabric()
        {
            if (Directory.Exists(VersionPath))
            {
                return;
            }
            Directory.CreateDirectory(VersionPath);
            File.Create($"{VersionPath}\\{LoaderName}.jar");

            var data = ModDownloader.GetString(
                $"https://meta.fabricmc.net/v2/versions/loader/{Info.GameVersion}/{Info.FabricVersion}/profile/json");
            File.WriteAllText($"{VersionPath}\\{LoaderName}.json", data);
        }
    }
}
