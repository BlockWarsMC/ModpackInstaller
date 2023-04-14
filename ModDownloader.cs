using RestSharp;

namespace BlockWars_Fabric_Installer;

public class ModDownloader
{

    private readonly Mod[] _modList = { 
        new("https://cdn.modrinth.com/data/Kw7Sm3Xf/versions/5QKzTtlI/noxesium-0.1.8.jar", "Noxesium"),
        new("https://cdn.modrinth.com/data/P7dR8mSH/versions/unERf4ZJ/fabric-api-0.78.0%2B1.19.4.jar", "Fabric API"),
        new("https://cdn.modrinth.com/data/AANobbMI/versions/b4hTi3mo/sodium-fabric-mc1.19.4-0.4.10%2Bbuild.24.jar", "Sodium"),
        new("https://cdn.modrinth.com/data/gvQqBUqZ/versions/14hWYkog/lithium-fabric-mc1.19.4-0.11.1.jar", "Lithium"),
        new("https://cdn.modrinth.com/data/mOgUt4GM/versions/5e62j63G/modmenu-6.1.0-rc.4.jar", "Mod Menu"),
        new("https://cdn.modrinth.com/data/H8CaAYZC/versions/1.1.1%2B1.19/starlight-1.1.1%2Bfabric.ae22326.jar", "Starlight "),
        new("https://cdn.modrinth.com/data/PtjYWJkn/versions/YknbqkHe/sodium-extra-0.4.18%2Bmc1.19.4-build.100.jar", "Sodium Extra"),
        new("https://cdn.modrinth.com/data/Ha28R6CL/versions/MkcO8aQ0/fabric-language-kotlin-1.9.3%2Bkotlin.1.8.20.jar", "Fabric Language Kotlin"),
        new("https://cdn.modrinth.com/data/Bh37bMuy/versions/aO0hSGlL/reeses_sodium_options-1.5.0%2Bmc1.19.4-build.72.jar", "Reese's Sodium Options"),
        new("https://cdn.modrinth.com/data/FWumhS4T/versions/I9TkHxLI/smoothboot-fabric-1.19.4-1.7.0.jar", "Smooth Boot"),
        new("https://mediafilez.forgecdn.net/files/4184/889/Zoomify-2.9.2.jar", "Optifine Zoom"),
        new("https://cdn.modrinth.com/data/89Wsn8GD/versions/kXfWiNN7/capes-1.5.2%2B1.19.3-fabric.jar", "Capes"),
        new("https://cdn.modrinth.com/data/1eAoo2KR/versions/RLTQViRg/YetAnotherConfigLib-2.4.0.jar", "YetAnotherConfigLib")
    };
        
    public static byte[]? DownloadMod(string url)
    {
        var client = new RestClient();
        var req = new RestRequest(url);

        var response = client.ExecuteAsync(req);
        return response.Result.RawBytes;
    }

    public IEnumerable<Mod> GetModList()
    {
        return _modList;
    }

    public static string? GetString(string url)
    {
        var client = new RestClient();
        var req = new RestRequest(url);

        var response = client.ExecuteAsync(req);
        return response.Result.Content;
    }
}