using MaterialSkin;
using MaterialSkin.Controls;
using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.IO;
using System.Security;
using System.Threading.Tasks;
using System.Threading;
using System.Resources;
using System.Globalization;
namespace ConsoleApp3
{
    public partial class datamonitor : MaterialForm
    {
        private readonly MaterialSkinManager materialSkinManager;
        private int colorSchemeIndex;
        ToolTip information = new ToolTip();
        ResourceManager res_man;
        CultureInfo cul;
        public datamonitor()
        {
            InitializeComponent();
            res_man = new ResourceManager("ConsoleApp3.lang.language", typeof(datamonitor).Assembly);
            materialSkinManager = MaterialSkinManager.Instance;
            materialSkinManager.AddFormToManage(this);
            materialSkinManager.Theme = MaterialSkinManager.Themes.LIGHT;
            materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
            serveruser.Text = Properties.Settings.Default.serverusername;
            serverpassword.Text = Properties.Settings.Default.serverpassword;
            servername.Text = Properties.Settings.Default.servername;
            serverdb.Text = Properties.Settings.Default.serverdb;
            servertb.Text = Properties.Settings.Default.servertb;
            comboBox1.Text = Properties.Settings.Default.Database;
            boxid_1.Text = Properties.Settings.Default.boxid;
            bridge.boxid_bridge = boxid_1.Text;
            bridge.databasename = comboBox1.Text;
            bridge.serverusername = serveruser.Text;
            bridge.serveruserpassword = serverpassword.Text;
            bridge.serverdbname = serverdb.Text;
            bridge.servertbname = servertb.Text;
            bridge.servername = servername.Text;
            string[] databases = { "MSSQL", "MICROSOFT OFFICE ACCESS", "MYSQL", "MONGO.DB", "ORACLE" };
            comboBox1.Items.AddRange(databases);
            dissconnect.BringToFront();
            if (comboBox1.Text == "MSSQL")
                sql.BringToFront();
            else if (comboBox1.Text == "MYSQL")
                mysql.BringToFront();
            else
                oddb.BringToFront();

            this.materialTabControl1.Controls.Remove(this.tabPage5);
        }
        private void MaterialRaisedButton2_Click(object sender, EventArgs e)
        {
            colorSchemeIndex++;
            if (colorSchemeIndex > 2) colorSchemeIndex = 0;
            switch (colorSchemeIndex)
            {
                case 0:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.BlueGrey800, Primary.BlueGrey900, Primary.BlueGrey500, Accent.LightBlue200, TextShade.WHITE);
                    break;
                case 1:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Indigo500, Primary.Indigo700, Primary.Indigo100, Accent.Pink200, TextShade.WHITE);
                    break;
                case 2:
                    materialSkinManager.ColorScheme = new ColorScheme(Primary.Green600, Primary.Green700, Primary.Green200, Accent.Red100, TextShade.WHITE);
                    break;
            }
        }
        private void Form1_FormClosing(object sender, FormClosingEventArgs e)
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
        private void MaterialRaisedButton4_Click(object sender, EventArgs e)
        {
            materialSkinManager.Theme = materialSkinManager.Theme == MaterialSkinManager.Themes.DARK ? MaterialSkinManager.Themes.LIGHT : MaterialSkinManager.Themes.DARK;
        }
        private void MaterialRaisedButton3_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.serverusername = serveruser.Text;
            Properties.Settings.Default.serverpassword = serverpassword.Text;
            Properties.Settings.Default.servername = servername.Text;
            Properties.Settings.Default.serverdb = serverdb.Text;
            Properties.Settings.Default.servertb = servertb.Text;
            Properties.Settings.Default.Database = comboBox1.Text;
            Properties.Settings.Default.boxid = boxid_1.Text;
            Properties.Settings.Default.Save();
            bridge.databasename = comboBox1.Text;
            bridge.serverusername = serveruser.Text;
            bridge.serveruserpassword = serverpassword.Text;
            bridge.serverdbname = serverdb.Text;
            bridge.servertbname = servertb.Text;
            bridge.servername = servername.Text;
            bridge.boxid_bridge = boxid_1.Text;
            MessageBox.Show("işlem tamamlandı", "info", MessageBoxButtons.OK, MessageBoxIcon.Information);
            materialTabSelector1.TabIndex = materialTabControl1.TabPages.IndexOf(tabPage1);
            if (comboBox1.Text == "MSSQL")
                sql.BringToFront();
            else if (comboBox1.Text == "MYSQL")
                mysql.BringToFront();
            else
                oddb.BringToFront();
        }
        private void BackgroundWorker1_DoWork_1(object sender, DoWorkEventArgs e)
        {


            while (true)
            {

                if (bridge.datachanged)
                {
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        ListViewItem item = new ListViewItem(new[] { bridge.uid, bridge.value, DateTime.Now.ToString() });
                        listView1.Items.Add(item);
                        bridge.datachanged = false;
                    });
                }
                this.Invoke((MethodInvoker)delegate ()
                {

                    boxid.Text = bridge.boxno;
                    boxstat.Text = bridge.status;
                    sqlstat.Text = bridge.sqlstatus;
                });
            }
        }
        private void CheckBox1_CheckedChanged(object sender, EventArgs e)
        {
            if (checkBox1.Checked)
            {
                bridge.sqloffline = true;
            }
            else
            {
                bridge.sqloffline = false;
            }
        }
        private void ComboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (comboBox1.Text == "MICROSOFT OFFICE ACCESS")
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "Access Dosyası |*.accdb";
                // dosya filtresi için bu kodu kullanıyoruz. Şuan sadece xlsx dosyalarını görecektir.
                var thread = new Thread(new ParameterizedThreadStart(param =>
                {
                    file.ShowDialog();
                    this.Invoke((MethodInvoker)delegate ()
                    {
                        servername.Text = file.FileName;
                        serverdb.Text = file.SafeFileName;
                        bridge.servername = file.FileName;
                    });
                }));
                thread.SetApartmentState(ApartmentState.STA);
                thread.Start();
            }
        }
        private void Serveruser_MouseHover(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "MSSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serveruser, "SQL server user name");
                    break;
                case "MYSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serveruser, "MYSQL server user name");
                    break;
                case "MICROSOFT OFFICE ACCESS":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serveruser, "MICROSOFT OFFICE ACCESS user name");
                    break;
                default:
                    break;
            }
        }
        private void Serverpassword_MouseHover(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "MSSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serverpassword, "SQL server password");
                    break;
                case "MYSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serverpassword, "MYSQL server password");
                    break;
                case "MICROSOFT OFFICE ACCESS":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serverpassword, "MICROSOFT OFFICE ACCESS server password");
                    break;
                default:
                    break;
            }
        }

        private void Servername_MouseHover(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "MSSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(servername, "SQL server name");
                    break;
                case "MYSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(servername, "MYSQL server name for examle: localhost/3801");
                    break;
                case "MICROSOFT OFFICE ACCESS":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(servername, ".accdb file path for example: c:\\documents and saves\\exp.accdb");
                    break;
                default:
                    break;
            }
        }
        private void Serverdb_MouseHover(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "MSSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serverdb, "SQL database name name");
                    break;
                case "MYSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serverdb, "MYSQL server database name");
                    break;
                case "MICROSOFT OFFICE ACCESS":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serverdb, "MICROSOFT OFFICE ACCESS database name");
                    break;
                default:
                    break;
            }
        }
        private void Servertb_MouseHover(object sender, EventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "MSSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(servertb, "SQL server table name");
                    break;
                case "MYSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(servertb, "MYSQL server table name");
                    break;
                case "MICROSOFT OFFICE ACCESS":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(servertb, "MICROSOFT OFFICE ACCESS table name");
                    break;
                default:
                    break;
            }
        }
        private void Serveruser_MouseUp(object sender, MouseEventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "MSSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serveruser, "SQL server user name");
                    break;
                case "MYSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serveruser, "MYSQL server user name");
                    break;
                case "MICROSOFT OFFICE ACCESS":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serveruser, "MICROSOFT OFFICE ACCESS user name");
                    break;
                default:
                    break;
            }
        }
        private void Serverpassword_MouseUp(object sender, MouseEventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "MSSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serverpassword, "SQL server password");
                    break;
                case "MYSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serverpassword, "MYSQL server password");
                    break;
                case "MICROSOFT OFFICE ACCESS":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serverpassword, "MICROSOFT OFFICE ACCESS server password");
                    break;
                default:
                    break;
            }
        }
        private void Servername_MouseUp(object sender, MouseEventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "MSSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(servername, "SQL server name");
                    break;
                case "MYSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(servername, "MYSQL server name and port for examle: localhost/3801");
                    break;
                case "MICROSOFT OFFICE ACCESS":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(servername, ".accdb file path for example: c:\\documents and saves\\exp.accdb");
                    break;
                default:
                    break;
            }
        }
        private void Serverdb_MouseUp(object sender, MouseEventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "MSSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serverdb, "SQL database name name");
                    break;
                case "MYSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serverdb, "MYSQL server database name");
                    break;
                case "MICROSOFT OFFICE ACCESS":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(serverdb, "MICROSOFT OFFICE ACCESS database name");
                    break;
                default:
                    break;
            }
        }
        private void Servertb_MouseUp(object sender, MouseEventArgs e)
        {
            switch (comboBox1.Text)
            {
                case "MSSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;

                    information.IsBalloon = true;
                    information.SetToolTip(servertb, "SQL server table name");
                    break;
                case "MYSQL":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(servertb, "MYSQL server table name");
                    break;
                case "MICROSOFT OFFICE ACCESS":
                    information.ToolTipTitle = "information...";
                    information.ToolTipIcon = ToolTipIcon.Info;
                    information.IsBalloon = true;
                    information.SetToolTip(servertb, "MICROSOFT OFFICE ACCESS table name");
                    break;
                default:
                    break;
            }
        }
        private void MaterialRaisedButton5_Click(object sender, EventArgs e)
        {
            DialogResult dialogResult = MessageBox.Show("All settings will be deleted.\nAre you sure you want to continue?", "warning", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);
            if (dialogResult == DialogResult.Yes)
            {
                comboBox1.Text = "";
                servertb.Text = "";
                serverdb.Text = "";
                servername.Text = "";
                serverpassword.Text = "";
                serveruser.Text = "";
                Properties.Settings.Default.serverusername = "";
                Properties.Settings.Default.serverpassword = "";
                Properties.Settings.Default.servername = "";
                Properties.Settings.Default.serverdb = "";
                Properties.Settings.Default.servertb = "";
                Properties.Settings.Default.Database = "";
                Properties.Settings.Default.Save();
                bridge.databasename = "";
                bridge.serverusername = "";
                bridge.serveruserpassword = "";
                bridge.serverdbname = "";
                bridge.servertbname = "";
                bridge.servername = "";
                this.materialTabControl1.SelectTab(0);


            }
        }
        private void Boxstat_TextChanged(object sender, EventArgs e)
        {
            if (boxstat.Text == "Normal")
                connected.BringToFront();
            else if (boxstat.Text == "Dissconnect")
                dissconnect.BringToFront();
        }
        private void Eng_Click(object sender, EventArgs e)
        {

            cul = CultureInfo.CreateSpecificCulture(Properties.Settings.Default.language);
            tabPage1.Text = res_man.GetString("flink", cul);
            tabPage2.Text = res_man.GetString("datamon", cul);
            tabPage3.Text = res_man.GetString("set", cul);
            tabPage4.Text = res_man.GetString("help", cul);
            label2.Text = res_man.GetString("flinkstat", cul);
            label1.Text = res_man.GetString("boxid", cul);
            label8.Text = res_man.GetString("databasestat", cul);
            checkBox1.Text = res_man.GetString("ntusdatabase", cul);
            ID.Text = res_man.GetString("id", cul);
            VALUE.Text = res_man.GetString("val", cul);
            DATETIME.Text = res_man.GetString("datetm", cul);
            groupBox1.Text = res_man.GetString("serverset", cul);
            label9.Text = res_man.GetString("server", cul);
            label3.Text = res_man.GetString("serveruser", cul);
            label4.Text = res_man.GetString("pass", cul);
            label6.Text = res_man.GetString("dbname", cul);
            label7.Text = res_man.GetString("tbname", cul);
            groupBox3.Text = res_man.GetString("flinkset", cul);
            groupBox2.Text = res_man.GetString("set", cul);
            materialRaisedButton2.Text = res_man.GetString("color", cul);
            materialRaisedButton4.Text = res_man.GetString("theme", cul);
            this.materialTabControl1.Controls.Add(this.tabPage5);
            this.materialTabControl1.Controls.Remove(this.tabPage5);
            turk.BringToFront();
            Properties.Settings.Default.language = "tr";
            Properties.Settings.Default.Save();
        }

        private void Turk_Click(object sender, EventArgs e)
        {


            cul = CultureInfo.CreateSpecificCulture(Properties.Settings.Default.language);
            tabPage1.Text = res_man.GetString("flink", cul);
            tabPage2.Text = res_man.GetString("datamon", cul);
            tabPage3.Text = res_man.GetString("set", cul);
            tabPage4.Text = res_man.GetString("help", cul);
            label2.Text = res_man.GetString("flinkstat", cul);
            label1.Text = res_man.GetString("boxid", cul);
            label8.Text = res_man.GetString("databasestat", cul);
            checkBox1.Text = res_man.GetString("ntusdatabase", cul);
            ID.Text = res_man.GetString("id", cul);
            VALUE.Text = res_man.GetString("val", cul);
            DATETIME.Text = res_man.GetString("datetm", cul);
            groupBox1.Text = res_man.GetString("serverset", cul);
            label9.Text = res_man.GetString("server", cul);
            label3.Text = res_man.GetString("serveruser", cul);
            label4.Text = res_man.GetString("pass", cul);
            label6.Text = res_man.GetString("dbname", cul);
            label7.Text = res_man.GetString("tbname", cul);
            groupBox3.Text = res_man.GetString("flinkset", cul);
            groupBox2.Text = res_man.GetString("set", cul);
            materialRaisedButton2.Text = res_man.GetString("color", cul);
            materialRaisedButton4.Text = res_man.GetString("theme", cul);

            this.materialTabControl1.Controls.Add(this.tabPage5);
            this.materialTabControl1.Controls.Remove(this.tabPage5);

            eng.BringToFront();
            Properties.Settings.Default.language = "en";
            Properties.Settings.Default.Save();
        }

        private void Datamonitor_Load(object sender, EventArgs e)
        {

            backgroundWorker1.RunWorkerAsync();
            if (Properties.Settings.Default.language != "")
            {
                cul = CultureInfo.CreateSpecificCulture(Properties.Settings.Default.language);
                if (Properties.Settings.Default.language == "en")
                    eng.BringToFront();
                if (Properties.Settings.Default.language == "tr")
                    turk.BringToFront();
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

            cul = CultureInfo.CreateSpecificCulture(Properties.Settings.Default.language);
            tabPage1.Text = res_man.GetString("flink", cul);
            tabPage2.Text = res_man.GetString("datamon", cul);
            tabPage3.Text = res_man.GetString("set", cul);
            tabPage4.Text = res_man.GetString("help", cul);
            label2.Text = res_man.GetString("flinkstat", cul);
            label1.Text = res_man.GetString("boxid", cul);
            label8.Text = res_man.GetString("databasestat", cul);
            checkBox1.Text = res_man.GetString("ntusdatabase", cul);
            ID.Text = res_man.GetString("id", cul);
            VALUE.Text = res_man.GetString("val", cul);
            DATETIME.Text = res_man.GetString("datetm", cul);
            groupBox1.Text = res_man.GetString("serverset", cul);
            label9.Text = res_man.GetString("server", cul);
            label3.Text = res_man.GetString("serveruser", cul);
            label4.Text = res_man.GetString("pass", cul);
            label6.Text = res_man.GetString("dbname", cul);
            label7.Text = res_man.GetString("tbname", cul);
            groupBox3.Text = res_man.GetString("flinkset", cul);
            groupBox2.Text = res_man.GetString("set", cul);
            materialRaisedButton2.Text = res_man.GetString("color", cul);
            materialRaisedButton4.Text = res_man.GetString("theme", cul);

            this.materialTabControl1.Controls.Add(this.tabPage5);
            this.materialTabControl1.Controls.Remove(this.tabPage5);

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

