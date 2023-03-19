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

            // Set up database connection
            connection = new SqlConnection(dbConnectionString);
            connection.Open();

            // Set up combobox options
            bunifuDropdown2.Items.Add("Late Check In");
            bunifuDropdown2.Items.Add("Early Check-Out");
            bunifuDropdown2.Items.Add("Absent");

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
            // Show the Open File dialog
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "CSV Files|*.csv";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the path to the selected file
                string csvFilePath = openFileDialog1.FileName;

                // Read the data from the CSV file
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

                // Set up the connection to the database and insert the data
                string dbConnectionString = @"Server=.\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";
                using (SqlConnection dbConnection = new SqlConnection(dbConnectionString))
                {
                    dbConnection.Open();

                    // Loop through the rows of the DataTable and insert each row into the database
                    foreach (DataRow dataRow in dataTable.Rows)
                    {
                        SqlCommand sqlCommand = new SqlCommand();
                        sqlCommand.Connection = dbConnection;
                        sqlCommand.CommandType = CommandType.Text;
                        sqlCommand.CommandText = "INSERT INTO Attendance (UserID, Name, Department, Date, [Check_In_Time], [Check_Out_Time], [Total_Hours_Worked], EnrollID, DeviceID, Place, VerifyMode) " +
                            "VALUES (@UserID, @Name, @Department, @Date, @Check_In_Time, @Check_Out_Time, @Total_Hours_Worked, @EnrollID, @DeviceID, @Place, @VerifyMode)";

                        // Add parameters for the values to insert
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

                // Display a message box to indicate that the import was successful
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
         

            // Get selected filter values
            string attendanceType = bunifuDropdown2.SelectedItem.ToString();
            DateTime startDate = bunifuDatePicker2.Value.Date;
            DateTime endDate = bunifuDatePicker1.Value.Date;
            string employeeID = bunifuTextBox1.Text.Trim();

            // Set up SQL query based on selected filter values
            string sqlQuery = "";
            switch (attendanceType)
            {
                case "Late Check In":
                    sqlQuery = "SELECT UserID, Name, Department, Date, Check_In_Time FROM Attendance WHERE Date BETWEEN @StartDate AND @EndDate AND Check_In_Time > '09:00:00'";
                    break;
                case "Early Check-Out":
                    sqlQuery = "SELECT UserID, Name, Department, Date, Check_Out_Time, Total_Hours_Worked FROM Attendance WHERE Date BETWEEN @StartDate AND @EndDate AND Total_Hours_Worked < 8";
                    break;
                case "Absent":
                    sqlQuery = "SELECT UserID, Name, Department, Date, Position FROM Absent_emp WHERE Date BETWEEN @StartDate AND @EndDate ";
                    break;


            }

            // Add employee ID filter if specified
            if (!string.IsNullOrEmpty(employeeID))
            {
                sqlQuery += " AND UserID = @UserID";
            }

            // Execute query and display results
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
            // Create a Bitmap object for the DataGridView control
            Bitmap bm = new Bitmap(this.bunifuDataGridView1.Width, this.bunifuDataGridView1.Height);

            // Draw the DataGridView control to the Bitmap object
            this.bunifuDataGridView1.DrawToBitmap(bm, new Rectangle(0, 0, this.bunifuDataGridView1.Width, this.bunifuDataGridView1.Height));

            // Set the origin of the printing area
            Point origin = new Point(100, 100);

            // Draw the Bitmap object to the printing area
            e.Graphics.DrawImage(bm, origin);
        }

        private void bunifuButton2_Click(object sender, EventArgs e)
        {
            // Create the PrintDocument and PrintPreviewDialog objects
            PrintDocument pd = new PrintDocument();
            PrintPreviewDialog ppd = new PrintPreviewDialog();

            // Set the PrintPage event handler for the PrintDocument
            pd.PrintPage += new PrintPageEventHandler(printDocument1_PrintPage);

            // Set the document to print
            ppd.Document = pd;

            // Display the Print Preview Dialog
            ppd.ShowDialog();
        }
    }
}
