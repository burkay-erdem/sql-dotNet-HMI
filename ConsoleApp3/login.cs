using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Reflection;
using System.Resources;
using System.Globalization;
namespace ConsoleApp3
{
    public partial class login : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;

        ResourceManager res_man;
        CultureInfo cul;
        public login()
        {
           
            InitializeComponent();

            res_man = new ResourceManager("ConsoleApp3.lang.language", typeof(login).Assembly);

            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            user.Text = Properties.Settings.Default.username;
            password.Text = Properties.Settings.Default.password;
            bridge.boxid = Properties.Settings.Default.boxid;
            password.UseSystemPasswordChar = true;
            hide.Visible = false;
            show.Visible = true;
            settings_pnl.Visible = false;
           



        }
        private void MaterialRaisedButton1_Click(object sender, EventArgs e)
        {
            log();
        }
        private void Login_FormClosing(object sender, FormClosingEventArgs e)
        {
            if (Properties.Settings.Default.language == "en")
            {
                Properties.Settings.Default.language = "tr";
                Properties.Settings.Default.Save();
            }
            else if (Properties.Settings.Default.language == "tr")
            {
                Properties.Settings.Default.language = "en";
                Properties.Settings.Default.Save();
            }
            Environment.Exit(0);
        }
        private int singin()
        {
            Properties.Settings.Default.username = user.Text;
            Properties.Settings.Default.password = password.Text;
            if (checkBox1.Checked)
            {
                Properties.Settings.Default.Save();
            }
            bridge.Connect = true;
            bridge.Userconnecterror = false;
            while (bridge.Connect == true)
            {
                if (bridge.Userconnecterror == true)
                    break;
            }
            if (bridge.Userconnecterror == false)
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    this.Hide();
                    datamonitor login = new datamonitor();
                    login.Show();
                });
            }
            else
            {
                this.Invoke((MethodInvoker)delegate ()
                {
                    circularProgressBar5.Style = ProgressBarStyle.Blocks;
                    circularProgressBar5.Text = "AL-BA Elektronik";
                    circularProgressBar5.Value = 75;
                    this.circularProgressBar5.InnerMargin = 0;
                    this.circularProgressBar5.InnerWidth = 0;
                    this.circularProgressBar5.StartAngle = 270;
                });
            }
            return 0;
        }
        private async void log()
        {
            Task<int> task = new Task<int>(singin);
            task.Start();
            circularProgressBar5.Style = ProgressBarStyle.Marquee;
            circularProgressBar5.Text = "Please Wait...";
        }
        private void Login_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                log();
            }
        }
        private void User_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                log();
            }
        }
        private void Password_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                log();
            }
        }

        private void Hide_Click(object sender, EventArgs e)
        {
            hide.Visible = false;
            show.Visible = true;
            password.UseSystemPasswordChar = true;
        }

        private void Show_Click(object sender, EventArgs e)
        {
            hide.Visible = true;
            show.Visible = false;
            password.UseSystemPasswordChar = false;
        }

        private void Button12_Click(object sender, EventArgs e)
        {
            if (settings_pnl.Visible == true)
            {
                settings_pnl.Visible = false;
            }
            else
                settings_pnl.Visible = true;
        }

        private void Turk_Click(object sender, EventArgs e)
        {


            cul = CultureInfo.CreateSpecificCulture(Properties.Settings.Default.language);
            label1.Text = res_man.GetString("user", cul);
            label2.Text = res_man.GetString("password", cul);
            materialRaisedButton1.Text = res_man.GetString("login", cul);
            checkBox1.Text = res_man.GetString("r_me", cul);
            eng.BringToFront();
            Properties.Settings.Default.language = "en";
            Properties.Settings.Default.Save();

        }

        private void Eng_Click(object sender, EventArgs e)
        {


            cul = CultureInfo.CreateSpecificCulture(Properties.Settings.Default.language);
            label1.Text = res_man.GetString("user", cul);
            label2.Text = res_man.GetString("password", cul);
            materialRaisedButton1.Text = res_man.GetString("login", cul);
            checkBox1.Text = res_man.GetString("r_me", cul);
            turk.BringToFront();

            Properties.Settings.Default.language = "tr";
            Properties.Settings.Default.Save();

        }

        private void Login_Load(object sender, EventArgs e)
        {
            
            if (Properties.Settings.Default.language != "")
            {
                cul = CultureInfo.CreateSpecificCulture(Properties.Settings.Default.language);
                label1.Text = res_man.GetString("user", cul);
                label2.Text = res_man.GetString("password", cul);
                materialRaisedButton1.Text = res_man.GetString("login", cul);
                checkBox1.Text = res_man.GetString("r_me", cul);
                if (Properties.Settings.Default.language == "en")
                    turk.BringToFront();
                if (Properties.Settings.Default.language == "tr")
                    eng.BringToFront();
            }
            if (Properties.Settings.Default.language == "tr")
            {
                Properties.Settings.Default.language = "en";
                Properties.Settings.Default.Save();
            }
            else if (Properties.Settings.Default.language == "en")
            {
                Properties.Settings.Default.language = "tr";
                Properties.Settings.Default.Save();
            }
            else
            {
                Properties.Settings.Default.language = "tr";
                Properties.Settings.Default.Save();
            }

        }
    }
}
