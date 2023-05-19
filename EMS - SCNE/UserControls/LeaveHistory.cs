using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EMS___SCNE
{
    public partial class LeaveHistory : UserControl
    {
        string connString = "Server=.\\SQLEXPRESS;Database=EMS-SCNE;User Id=lakshitha;Password=123456;";

        public LeaveHistory()
        {
            InitializeComponent();
        }

        private void LeaveHistory_Load(object sender, EventArgs e)
        {
            //Select Leave type
            bunifuDropdown1.Items.Add("half_day");
            bunifuDropdown1.Items.Add("short_leave");
            bunifuDropdown1.Items.Add("casual_leave");
            bunifuDropdown1.Items.Add("annual_leave");

        }

        private void bunifuDatePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {

            DataTable dt = new DataTable();

            string query = "SELECT UserID, Leave_Type, From_Date, To_Date , Position, Department, Name, Reason FROM LeaveRequest_HistoryDisplay WHERE 1=1 ";

            string userID = bunifuTextBox1.Text;
            DateTime fromDate = bunifuDatePicker1.Value;
            DateTime toDate = bunifuDatePicker2.Value;
            string leaveType = bunifuDropdown1.SelectedItem?.ToString();

            if (!string.IsNullOrEmpty(userID))
            {
                query += $"AND UserID = '{userID}' ";
            }
            if (fromDate != default && toDate != default)
            {
                if (leaveType == "half_day" || leaveType == "short_leave")
                {
                    query += $"AND From_Date >= '{fromDate:yyyy-MM-dd}' AND From_Date <= '{toDate:yyyy-MM-dd}' ";
                }
                else
                {
                    query += $"AND From_Date >= '{fromDate:yyyy-MM-dd}' AND To_Date <= '{toDate:yyyy-MM-dd}' ";
                }
            }
            if (!string.IsNullOrEmpty(leaveType))
            {
                query += $"AND Leave_Type LIKE '%{leaveType}%' ";
            }

            using (SqlConnection conn = new SqlConnection(connString))
            {
                using (SqlDataAdapter adapter = new SqlDataAdapter(query, conn))
                {
                    conn.Open();
                    adapter.Fill(dt);
                }
            }

            bunifuDataGridView1.AutoGenerateColumns = true;
            bunifuDataGridView1.ColumnHeadersVisible = true;
           // bunifuDataGridView1.RowHeadersVisible = true;
            bunifuDataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            bunifuDataGridView1.ReadOnly = true;
            bunifuDataGridView1.DataSource = dt;
        }

        private void bunifuTextBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDropdown1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        private void LoadData()
        {
            // Connect to the database and retrieve data from the LeaveRequest_History table
            using (SqlConnection connection = new SqlConnection("connection string"))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("SELECT UserID, Leave_Type, Year, Month, From_Date, To_Date, Leave_Count, Reason, Deducted_Date FROM LeaveRequest_History", connection))
                {
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    DataTable table = new DataTable();
                    adapter.Fill(table);

                    // Set the data source of the data grid view to the retrieved data
                    bunifuDataGridView1.DataSource = table;
                }
            }
        }
        /*
        private void bunifuButton2_Click(object sender, EventArgs e)
        {

            if (bunifuDataGridView1.SelectedRows.Count == 1)
            {
                DataGridViewRow row = bunifuDataGridView1.SelectedRows[0];
                int userID = Convert.ToInt32(row.Cells["UserID"].Value);
                string leaveType = row.Cells["Leave_Type"].Value.ToString();

                // Prompt the user to confirm the deletion
                DialogResult result = MessageBox.Show("Are you sure you want to delete this record?",
                                                      "Confirmation",
                                                      MessageBoxButtons.YesNo,
                                                      MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Delete the record from the database
                    using (SqlConnection conn = new SqlConnection(connString))
                    {
                        conn.Open();
                        string query = $"DELETE FROM LeaveRequest_HistoryDisplay WHERE UserID = {userID} AND Leave_Type = '{leaveType}'";
                        SqlCommand cmd = new SqlCommand(query, conn);
                        int rowsAffected = cmd.ExecuteNonQuery();
                        if (rowsAffected > 0)
                        {
                            // Remove the row from the DataGridView
                            bunifuDataGridView1.Rows.Remove(row);
                            MessageBox.Show("Record deleted successfully.");
                        }
                        else
                        {
                            MessageBox.Show("Error deleting record.");
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a row to delete.");
            }

        } */

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                DataGridViewRow row = bunifuDataGridView1.Rows[e.RowIndex];

            }
        }

        private void bunifuLabel2_Click(object sender, EventArgs e)
        {

        }

        private void bunifuTextBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void bunifuDatePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void bunifuPanel2_Click(object sender, EventArgs e)
        {

        }
    }
}
