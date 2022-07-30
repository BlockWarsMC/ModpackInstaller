using RestSharp;

namespace BlockWars_Fabric_Installer
{
    public class ModDownloader
    {
        public byte[] downloadMod(string url)
        {
            var client = new RestClient();
            var req = new RestRequest(url);

            var response = client.ExecuteAsync(req);
            return response.Result.RawBytes;
        }

        public string[] getModList()
        {
            var lines = getString("https://lukynka.cz/ppy.puush.selfHosted/blockwarsModList.txt").Split("\n");
            return lines;
        }

        public string getString(string url)
        {
            var client = new RestClient();
            var req = new RestRequest(url);

            var response = client.ExecuteAsync(req);
            return response.Result.Content;
        }
    }
}
