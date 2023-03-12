using System;
using System.Windows.Forms;

namespace EMS___SCNE
{
    public partial class Dashboard : KryptonForm
    {
        public Dashboard()
        {
            InitializeComponent();
            timer1.Enabled = true;
        }

        private void Form1_Load(object sender, EventArgs e)
        {
           
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void kryptonPalette1_PalettePaint(object sender, PaletteLayoutEventArgs e)
        {

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            labletime.Text = DateTime.Now.ToString("hh:mm:ss tt");
            labledate.Text = DateTime.Now.ToString("MM/dd/yyyy");

            // Get the current time
            DateTime currentTime = DateTime.Now;

            // Check the time of day and set the label text accordingly
            if (currentTime.Hour >= 5 && currentTime.Hour < 12)
            {
                // Good morning
              //greatingslable.Text = "Good morning";
            }
            else if (currentTime.Hour >= 12 && currentTime.Hour < 18)
            {
                // Good afternoon
              //greatingslable.Text = "Good afternoon";
            }
            else
            {
                // Good evening
               //greatingslable.Text = "Good evening";
            }

        }

        private void bunifuLabel1_Click_1(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void bunifuLabel1_Click_2(object sender, EventArgs e)
        {

        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel5_Click(object sender, EventArgs e)
        {

        }

        private void kryptonPanel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
           

        }


        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {

        }

        private void bunifuButton5_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void greatingslable_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void bunifuPanel2_Click_1(object sender, EventArgs e)
        {

        }

        private void bunifuButton4_Click(object sender, EventArgs e)
        {
            
        }

        private void dashboard_UC1_Load(object sender, EventArgs e)
        {

        }

        private void dashboard_UC1_Load_1(object sender, EventArgs e)
        {

        }

        private void bunifuPanel7_Click(object sender, EventArgs e)
        {

        }
    }
}
