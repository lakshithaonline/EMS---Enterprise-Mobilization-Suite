using System.Windows.Forms;
using Bunifu.UI.WinForms;
using System.Drawing;
using Bunifu.Framework.UI;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using ExcelDataReader;
using System.Collections.Generic;
using System.Linq;
using System;
using System.Drawing.Printing;




namespace EMS___SCNE
{
    public partial class Attendence_UC : UserControl
    {

        private string dbConnectionString = @"Server=.\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";
        private SqlConnection connection;
        private object printDocument1;

        public Attendence_UC()
        {
            InitializeComponent();

            connection = new SqlConnection(dbConnectionString);
            connection.Open();

            // Set up combobox options
            bunifuDropdown2.Items.Add("Late Check In");
            bunifuDropdown2.Items.Add("Early Check-Out");
            bunifuDropdown2.Items.Add("Absent");
            bunifuDropdown2.Items.Add("Normal Attendence");
            bunifuDropdown2.Items.Add("Must be monitored");

        }

        private void bunifuLabel1_Click(object sender, System.EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            openFileDialog1.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";

        }

        public void bunifuButton1_Click(object sender, System.EventArgs e)
        {
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV Files|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string csvFilePath = openFileDialog1.FileName;

                DataTable dataTable = new DataTable();
                using (StreamReader reader = new StreamReader(csvFilePath))
                {
                    string[] headers = reader.ReadLine().Split(',');
                    foreach (string header in headers)
                    {
                        dataTable.Columns.Add(header);
                    }
                    while (!reader.EndOfStream)
                    {
                        string[] fields = reader.ReadLine().Split(',');
                        DataRow dataRow = dataTable.NewRow();
                        for (int i = 0; i < headers.Length; i++)
                        {
                            dataRow[i] = fields[i];
                        }
                        dataTable.Rows.Add(dataRow);
                    }
                }

                string dbConnectionString = @"Server=.\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";
                using (SqlConnection dbConnection = new SqlConnection(dbConnectionString))
                {
                    dbConnection.Open();

                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = dbConnection;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "INSERT INTO Attendance (UserID, Name, Department, Date, [Check_In_Time], [Check_Out_Time], [Total_Hours_Worked], EnrollID, DeviceID, Place, VerifyMode) " +
                            "VALUES (@UserID, @Name, @Department, @Date, @Check_In_Time, @Check_Out_Time, @Total_Hours_Worked, @EnrollID, @DeviceID, @Place, @VerifyMode)";

                        sqlCommand.Parameters.AddWithValue("@UserID", dataRow["UserID"]);
                        sqlCommand.Parameters.AddWithValue("@Name", dataRow["Name"]);
                        sqlCommand.Parameters.AddWithValue("@Department", dataRow["Department"]);
                        sqlCommand.Parameters.AddWithValue("@Date", dataRow["Date"]);
                        sqlCommand.Parameters.AddWithValue("@Check_In_Time", dataRow["Check_In_Time"]);
                        sqlCommand.Parameters.AddWithValue("@Check_Out_Time", dataRow["Check_Out_Time"]);
                        sqlCommand.Parameters.AddWithValue("@Total_Hours_Worked", dataRow["Total_Hours_Worked"]);
                        sqlCommand.Parameters.AddWithValue("@EnrollID", dataRow["EnrollID"]);
                        sqlCommand.Parameters.AddWithValue("@DeviceID", dataRow["DeviceID"]);
                        sqlCommand.Parameters.AddWithValue("@Place", dataRow["Place"]);
                        sqlCommand.Parameters.AddWithValue("@VerifyMode", dataRow["VerifyMode"]);

                        sqlCommand.ExecuteNonQuery();
                    }
                }
                MessageBox.Show("Import complete!");
            }
        }

        private void Attendence_UC_Load(object sender, System.EventArgs e)
        {
            string connectionString = @"Server=.\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";
            SqlConnection connection = new SqlConnection(connectionString);

            SqlDataAdapter adapter = new SqlDataAdapter("SELECT * FROM Attendance", connection);

            DataTable dataTable = new DataTable();
            adapter.Fill(dataTable);

            bunifuDataGridView1.DataSource = dataTable;
        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {

        }

        private void bunifuLabel1_Click_1(object sender, System.EventArgs e)
        {

        }

        private void bunifuTextBox1_TextChanged(object sender, System.EventArgs e)
        {

        }

        private void bunifuButton1_Click_1(object sender, System.EventArgs e)
        {
            try
            {
                string attendanceType = bunifuDropdown2.SelectedItem?.ToString();
                DateTime startDate = bunifuDatePicker2.Value.Date;
                DateTime endDate = bunifuDatePicker1.Value.Date;
                string employeeID = bunifuTextBox1.Text.Trim();

                if (string.IsNullOrEmpty(attendanceType))
                {
                    throw new ArgumentException("Please select an attendance type.", nameof(attendanceType));
                }

                string sqlQuery = "";
                switch (attendanceType)
                {
                    case "Late Check In":
                        sqlQuery = "SELECT UserID, Name, Department, Date, Check_In_Time FROM Attendance_View_Late_Attendance WHERE Date BETWEEN @StartDate AND @EndDate";
                        break;
                    case "Early Check-Out":
                        sqlQuery = "SELECT UserID, Name, Department, Date, Check_Out_Time, Total_Hours_Worked FROM Attendance_View_EarlyCheckOut_Attendance WHERE Date BETWEEN @StartDate AND @EndDate";
                        break;
                    case "Absent":
                        sqlQuery = "SELECT UserID, Name, Department, Date, Position FROM Attendance_View_Absent_Attendance WHERE Date BETWEEN @StartDate AND @EndDate ";
                        break;
                    case "Normal Attendence":
                        sqlQuery = "SELECT UserID, Name, Department, Date, Total_Hours_Worked FROM Attendance_View_Normal_Attendance WHERE Date BETWEEN @StartDate AND @EndDate";
                        break;
                    case "Must be monitored":
                        sqlQuery = "SELECT UserID, Name, Department, Date, Check_In_Time, Check_Out_Time, Total_Hours_Worked FROM Attendance_View_MustBeMonitored_Attendance WHERE Date BETWEEN @StartDate AND @EndDate";
                        break;
                    default:
                        sqlQuery = "";
                        break;
                }

              
                if (!string.IsNullOrEmpty(employeeID))
                {
                    sqlQuery += " AND UserID = @UserID";
                }

          
                using (SqlCommand command = new SqlCommand(sqlQuery, connection))
                {
                    command.Parameters.AddWithValue("@StartDate", startDate);
                    command.Parameters.AddWithValue("@EndDate", endDate);
                    if (!string.IsNullOrEmpty(employeeID))
                    {
                        command.Parameters.AddWithValue("@UserID", employeeID);
                    }

                    using (SqlDataAdapter adapter = new SqlDataAdapter(command))
                    {
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        bunifuDataGridView1.DataSource = dataTable;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);

                using (SqlConnection conn = new SqlConnection(dbConnectionString))
                {
                    conn.Open();
                    using (SqlCommand cmd = new SqlCommand("INSERT INTO ErrorLog (ErrorMessage, ErrorDate, ErrorType) VALUES (@ErrorMessage, @ErrorDate, @ErrorType); SELECT SCOPE_IDENTITY();", conn))
                    {
                        cmd.Parameters.AddWithValue("@ErrorMessage", ex.Message);
                        cmd.Parameters.AddWithValue("@ErrorDate", DateTime.Now);
                        cmd.Parameters.AddWithValue("@ErrorType", ex.GetType().ToString());
                        int errorId = Convert.ToInt32(cmd.ExecuteScalar());
                    }
                }
            }
        }



        private void kryptonComboBox2_SelectedIndexChanged(object sender, System.EventArgs e)
        {
                    
        }


        private void guna2ComboBox1_SelectedIndexChanged(object sender, System.EventArgs e)
        {

        }

        private void bunifuDatePicker2_ValueChanged(object sender, System.EventArgs e)
        {

        }

        private void bunifuDropdown2_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void printDocument1_PrintPage(object sender, System.Drawing.Printing.PrintPageEventArgs e)
        {
            
            Bitmap bm = new Bitmap(this.bunifuDataGridView1.Width, this.bunifuDataGridView1.Height);

           
            this.bunifuDataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.bunifuDataGridView1.Width, this.bunifuDataGridView1.Height));

            
            Point origin = new Point(100, 100);

           
            e.Graphics.DrawImage(bm, origin);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
          
            PrintDocument pd = new PrintDocument();
            PrintPreviewDialog ppd = new PrintPreviewDialog();

            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

        
            ppd.Document = pd;

          
            ppd.ShowDialog();
        }

        private void bunifuPanel1_Click(object sender, EventArgs e)
        {

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }
    }
}
