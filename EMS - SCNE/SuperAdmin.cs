using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using ComponentFactory.Krypton.Toolkit;
using EMS___SCNE.UserControls___SuperAdmin;

namespace EMS___SCNE
{
    public partial class SuperAdmin : KryptonForm
    {
        public SuperAdmin()
        {
            InitializeComponent();

        }

        private void SuperAdmin_Load(object sender, EventArgs e)
        {   

        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuImageButton1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuShadowPanel1_ControlAdded(object sender, ControlEventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel4_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton3_Click(object sender, EventArgs e)
        {
            EMSAccess_Superadmin attendenceUC = new EMSAccess_Superadmin(); 
            attendenceUC.Dock = DockStyle.Fill; 
            bunifuPanel10.Controls.Clear();
            bunifuPanel10.Controls.Add(attendenceUC);
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            Dashboard_superadmin attendenceUC = new Dashboard_superadmin(); 
            attendenceUC.Dock = DockStyle.Fill;
            bunifuPanel10.Controls.Clear();
            bunifuPanel10.Controls.Add(attendenceUC); 
        }

        private void bunifuPanel1_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuPanel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Employee_superadmin attendenceUC = new Employee_superadmin();
            attendenceUC.Dock = DockStyle.Fill;
            bunifuPanel10.Controls.Clear();
            bunifuPanel10.Controls.Add(attendenceUC);
        }

        private void bunifuPanel10_Click(object sender, EventArgs e)
        {
            
        }

        private void dashboard_superadmin1_Load(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click_1(object sender, EventArgs e)
        {
            this.Hide(); 
            Login Login = new Login();
            Login.ShowDialog();
            this.Close();
        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            LeaveHistory_superadmin attendenceUC = new LeaveHistory_superadmin();
            attendenceUC.Dock = DockStyle.Fill;
            bunifuPanel10.Controls.Clear();
            bunifuPanel10.Controls.Add(attendenceUC);
        }
    }
}
