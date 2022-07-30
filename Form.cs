namespace BlockWars_Fabric_Installer
{
    public partial class Form : System.Windows.Forms.Form
    {
        public Form()
        {
            InitializeComponent();
            prepareComponent();
        }

        private void prepareComponent()
        {
            BackColor = System.Drawing.Color.FromArgb(23, 23, 23);
            Text = "BlockWars Modpack Installer";
            textBox1.ReadOnly = true;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if(Info.vars.minecraftDirectory == null)
            {
                System.Windows.Forms.MessageBox.Show("Please select your minecraft directory before installing!");
                return;
            }

            if (LauncherProfileCreator.isLauncherRunning())
            {
                System.Windows.Forms.MessageBox.Show("Please close the minecraft launcher before\ninstalling the blockwars modpack!");
                return;
            }

            FabricInstaller.InstallFabric();
            ModInstaller.InstallMods();
            LauncherProfileCreator.createNewProfile();
            System.Windows.Forms.MessageBox.Show("BlockWars modpack has been installed!\nYou can now open the Minecraft launcher!");
            System.Environment.Exit(0x00);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            using (var fbd = new FolderBrowserDialog())
            {
                DialogResult result = fbd.ShowDialog();

                if (result == DialogResult.OK && !string.IsNullOrWhiteSpace(fbd.SelectedPath))
                {
                    Info.vars.minecraftDirectory = fbd.SelectedPath;
                    textBox1.Text = fbd.SelectedPath;
                }
            }
        }
    }
}
