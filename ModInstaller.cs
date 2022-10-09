
namespace BlockWars_Fabric_Installer
{
    public class ModInstaller
    {
        private readonly static string modsFolder = $"{Info.blockwarsDirectory}\\mods";

        public static void InstallMods()
        {
            if (!Directory.Exists(Info.blockwarsDirectory))
            {
                Directory.CreateDirectory(Info.blockwarsDirectory);
            }

            if (Directory.Exists(modsFolder))
            {   foreach (FileInfo file in new DirectoryInfo(modsFolder).GetFiles())
                {
                    file.Delete();
                }
                Directory.Delete(modsFolder);
                Directory.CreateDirectory(modsFolder);
            } else
            {
                Directory.CreateDirectory(modsFolder);
            }

            ModDownloader downloader = new ModDownloader();
            string[] modList = downloader.getModList();

            for (var i = 0; i < modList.Length; i++)
            {
                string[] v = modList[i].Split(",");
                string name = v[1].Trim();
                string url = v[0];
                byte[] modjar = downloader.downloadMod(url);
                File.WriteAllBytes($"{modsFolder}\\{name}.jar", modjar);
            }
        }
    }
}
