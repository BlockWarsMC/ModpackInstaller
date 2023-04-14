namespace BlockWars_Fabric_Installer;

public abstract class ModInstaller
{
    private static readonly string ModsFolder = $"{Info.BlockwarsDirectory}\\mods";

    public static void InstallMods()
    {
        if (!Directory.Exists(Info.BlockwarsDirectory))
        {
            Directory.CreateDirectory(Info.BlockwarsDirectory);
        }

        if (Directory.Exists(ModsFolder))
        {   foreach (var file in new DirectoryInfo(ModsFolder).GetFiles())
            {
                file.Delete();
            }
            Directory.Delete(ModsFolder);
            Directory.CreateDirectory(ModsFolder);
        } else
        {
            Directory.CreateDirectory(ModsFolder);
        }

        var downloader = new ModDownloader();
        var modList = downloader.GetModList();

        foreach (var mod in modList)
        {
            var name = mod.name;
            var url = mod.url;
            var modjar = ModDownloader.DownloadMod(url);
            File.WriteAllBytes($"{ModsFolder}\\{name}.jar", modjar);
        }
    }
}