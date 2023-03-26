using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Bunifu.Framework.UI;
using Bunifu.UI.WinForms;
using ComponentFactory.Krypton.Toolkit;

namespace EMS___SCNE.UserControls___SuperAdmin
{
    public partial class Login : KryptonForm
    {
        public Login()
        {
            InitializeComponent();
        }

        private void Preloader_Load(object sender, EventArgs e)
        {
            bunifuTextBox2.UseSystemPasswordChar = true;
            bunifuTextBox2.UseSystemPasswordChar = !bunifuCheckBox1.Checked;


            // Add items to the dropdown list
            bunifuDropdown1.Items.Add("SuperAdmin");
            bunifuDropdown1.Items.Add("EMS");


        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            string username = bunifuTextBox1.Text;
            string password = bunifuTextBox2.Text;

            if (bunifuDropdown1.SelectedIndex == 0 && username == "superadmin" && password == "123456") // SuperAdmin selected in dropdown and hardcoded username and password for SuperAdmin
            {
                SuperAdmin superAdminForm = new SuperAdmin();
                this.Hide();
                superAdminForm.ShowDialog();
                this.Close();
            }
            else if (bunifuDropdown1.SelectedIndex == 1 && username == "ems" && password == "123456") // EMS selected in dropdown and hardcoded username and password for EMS
            {
                Dashboard emsForm = new Dashboard();
                this.Hide();
                emsForm.ShowDialog();
                this.Close();
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }

        }

        private void bunifuTextBox2_TextChanged(object sender, EventArgs e)
        {
           
        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }
    }
}
