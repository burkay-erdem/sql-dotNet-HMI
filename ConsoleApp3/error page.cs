using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Windows.Forms;

namespace ConsoleApp3
{
    public partial class Form1 : MaterialForm
    {

        private readonly MaterialSkinManager materialSkinManager;
        public Form1()
        {
            InitializeComponent();

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            materialLabel1.Text = bridge.errormessage;
        }

        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
        {
            Environment.Exit(0);
        }
    }
}
