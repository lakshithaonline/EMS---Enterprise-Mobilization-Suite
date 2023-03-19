using System;
using System.Drawing;
using Bunifu.UI.WinForms;
using System.Reflection.Emit;
using System.Windows.Forms;
using static Bunifu.UI.WinForms.BunifuLabel;
using System.Data.SqlClient;
using System.Data;

namespace EMS___SCNE.UserControls
{
    public partial class Dashboard_UC : UserControl
    {

        public Dashboard_UC()
        {
            InitializeComponent();
            this.Region = new System.Drawing.Region(
            new System.Drawing.RectangleF(
                this.ClientRectangle.X,
                this.ClientRectangle.Y,
                this.ClientRectangle.Width,
                this.ClientRectangle.Height
                )
            );
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            using (var brush = new System.Drawing.SolidBrush(this.BackColor))
            {
                e.Graphics.FillRegion(brush, this.Region);
            }
        }

        private void Dashboard_Load(object sender, EventArgs e)
        {
            //display absent employees
            string connectionString = @"Server=.\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Absent_emp", connection);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            bunifuDataGridView2.DataSource = dataTable;


            //display the best employee in month
            {
                SqlCommand cmd = new SqlCommand("sp_GetTopEmployees", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);

                bunifuDataGridView1.DataSource = dt;
            }

            //display employee count
            {
                SqlCommand cmd = new SqlCommand("SELECT COUNT(*) FROM Employees", connection);
                connection.Open();
                int employeeCount = (int)cmd.ExecuteScalar();
                connection.Close();

                bunifuLabel2.Text = employeeCount.ToString();
            }

            //display monthly attendence (without absents)
            {
                SqlCommand cmd = new SqlCommand("sp_GetMonthlyAttendanceCount", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                int monthlyAttendanceCount = (int)cmd.ExecuteScalar();

                bunifuLabel8.Text = monthlyAttendanceCount.ToString();

                connection.Close();
            }

            //display the monthly late attendence
            {
                SqlCommand cmd = new SqlCommand("sp_GetLateAttendanceCount", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();

                int lateAttendanceCount = (int)cmd.ExecuteScalar();

                bunifuLabel10.Text = lateAttendanceCount.ToString();

                connection.Close();
            }
            //display the monthly absent employees 
            {
                SqlCommand cmd = new SqlCommand("sp_GetAbsentEmployeeCountMonthly", connection);
                cmd.CommandType = CommandType.StoredProcedure;

                connection.Open();
                int absentEmployeeCount = (int)cmd.ExecuteScalar();
                

                bunifuLabel12.Text = absentEmployeeCount.ToString();

                connection.Close();
            }


        }

        private void bunifuSeparator1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel3_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel5_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            
        }

        private void bunifuCircleProgress1_ProgressChanged(object sender, Bunifu.UI.WinForms.BunifuCircleProgress.ProgressChangedEventArgs e)
        {

        }

        private void greatingslable_Click(object sender, EventArgs e)
        {
            timer1.Start();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            
            DateTime currentTime = DateTime.Now;

            // Check the time of day and set the label text accordingly
            if (currentTime.Hour >= 5 && currentTime.Hour < 12)
            {
                // Good morning
                greatingslable.Text = "Good Morning";
            }
            else if (currentTime.Hour >= 12 && currentTime.Hour < 18)
            {
                // Good afternoon
                greatingslable.Text = "Good Afternoon";
            }
            else
            {
                // Good evening
                greatingslable.Text = "Good Evening";
            }
        }

        private void bunifuLabel8_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel15_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel7_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel17_Load(object sender, EventArgs e)
        {
            
            
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuDataGridView2_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
           
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {
           
        }

        private void bunifuLabel10_Click(object sender, EventArgs e)
        {

        }

        private void bunifuLabel12_Click(object sender, EventArgs e)
        {

        }
    }
}
