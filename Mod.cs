namespace BlockWars_Fabric_Installer;

public class Mod
{
    public readonly string url;
    public readonly string name;

    public Mod(string url, string name)
    {
        this.url = url;
        this.name = name;
    }
}