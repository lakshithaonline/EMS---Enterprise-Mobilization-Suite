using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS___SCNE.UserControls___SuperAdmin
{
    public partial class Dashboard_superadmin : UserControl
    {
        public Dashboard_superadmin()
        {
            InitializeComponent();


        }

        private void bunifuPanel7_Click(object sender, EventArgs e)
        {

        }

        private void Dashboard_superadmin_Load(object sender, EventArgs e)
        {
            Login form1 = new Login();
            string count = form1.logincount;

            bunifuLabel1.Text = count;

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }
    }
}
