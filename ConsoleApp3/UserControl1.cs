using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ConsoleApp3
{
    public partial class UserControl1 : UserControl
    {
        public UserControl1()
        {
            InitializeComponent();
            bridge.boxid_bridge = Properties.Settings.Default.boxid;
            boxid_1.Text= Properties.Settings.Default.boxid;
          

        }

    

        private void Boxid_1_TextChanged(object sender, EventArgs e)
        {
            bridge.boxid_bridge = boxid_1.Text;
            Properties.Settings.Default.boxid = bridge.boxid_bridge;
            Properties.Settings.Default.Save();
        }
    }
}
