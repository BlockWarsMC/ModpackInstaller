namespace BlockWars_Fabric_Installer
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            PrepareComponent();
        }

        private void PrepareComponent()
        {
            BackColor = Color.FromArgb(23, 23, 23);
            Text = "BlockWars Modpack Installer";
            textBox1.ReadOnly = true;
            progressText.Text = string.Empty;
            progressText.BackColor = Color.FromArgb(23, 23, 23);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Info.Vars.minecraftDirectory == null)
            {
                MessageBox.Show("Please select your minecraft directory before installing!");
                return;
            }

            if (LauncherProfileCreator.IsLauncherRunning())
            {
                MessageBox.Show("Please close the minecraft launcher/minecraft before\ninstalling the blockwars modpack!");
                return;
            }

            progressText.Text = "Installing Fabric... (1/3)";
            FabricInstaller.InstallFabric();
            progressText.Text = "Installing Mods... (2/3)";
            ModInstaller.InstallMods();
            progressText.Text = "Creating new launcher profile... (3/3)";
            LauncherProfileCreator.CreateNewProfile();
            progressText.Text = "Done! You can now close the program!";
            MessageBox.Show("BlockWars modpack has been installed!\nYou can now open the Minecraft launcher!");
            Environment.Exit(0x00);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using var fileBrowserDialog = new FolderBrowserDialog();
            var result = fileBrowserDialog.ShowDialog();

            if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fileBrowserDialog.SelectedPath))
            {
                Info.Vars.minecraftDirectory = fileBrowserDialog.SelectedPath;
                textBox1.Text = fileBrowserDialog.SelectedPath;
            }
        }
    }
}
