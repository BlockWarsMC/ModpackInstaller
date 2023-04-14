namespace BlockWars_Fabric_Installer;

internal static class Program
{

    [STAThread]
    public static void Main()
    {
        ApplicationConfiguration.Initialize();
        Application.Run(new Form());
    }
}