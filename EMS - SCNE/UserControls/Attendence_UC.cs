using System.Windows.Forms;
using Bunifu.UI.WinForms;
using System.Drawing;
using Bunifu.Framework.UI;
using System.Data;
using System.Data.OleDb;
using System.Data.SqlClient;
using System.IO;
using ExcelDataReader;



namespace EMS___SCNE
{
    public partial class Attendence_UC : UserControl
    {
        public Attendence_UC()
        {
            InitializeComponent();
        }

        private void bunifuLabel1_Click(object sender, System.EventArgs e)
        {

        }

        private void bunifuDataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // create a Panel control
            var panel = new Panel();

            // set the panel's size and location
            panel.Size = new Size(400, 300);
            panel.Location = new Point(10, 10);

            // create a BunifuDataGridView control
            var dgv = new BunifuDataGridView();

            // set the DataGridView's size and location
            dgv.Size = new Size(390, 290);
            dgv.Location = new Point(5, 5);

            // add the DataGridView to the panel
            panel.Controls.Add(dgv);

            // set the panel's BorderStyle and BorderRadius
            panel.BorderStyle = BorderStyle.FixedSingle;
            //panel.BorderRadius = 10;

            // add the panel to the form
            Controls.Add(panel);

        }

        private void openFileDialog1_FileOk(object sender, System.ComponentModel.CancelEventArgs e)
        {
            openFileDialog1.Filter = "Excel files (*.xls;*.xlsx)|*.xls;*.xlsx|All files (*.*)|*.*";

        }

        private void bunifuButton1_Click(object sender, System.EventArgs e)
        {
            // Create a new instance of the OpenFileDialog component
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            openFileDialog1.Filter = "Excel Files|*.xlsx;*.xls;*.xlsm";
            openFileDialog1.Title = "Select an Excel File";

            // Show the OpenFileDialog box and wait for the user to select a file
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                // Get the file path and name
                string filePath = openFileDialog1.FileName;

                // Set up the connection string to the SQL Server database
                string connectionString = "Server=yourServerName;Database=yourDatabaseName;Trusted_Connection=True;";

                // Set up the SQL INSERT statement
                string insertSql = "INSERT INTO YourTableName (Column1, Column2, Column3) VALUES (@Value1, @Value2, @Value3);";

                // Create a new instance of the ExcelDataReader component to read the data from the Excel file
                using (var stream = File.Open(filePath, FileMode.Open, FileAccess.Read))
                {
                    using (var reader = ExcelReaderFactory.CreateReader(stream))
                    {
                        // Read the data from the Excel file
                        var dataSet = reader.AsDataSet();
                        var dataTable = dataSet.Tables[0];

                        // Open a connection to the SQL Server database
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Loop through each row in the DataTable and insert it into the database
                            foreach (DataRow row in dataTable.Rows)
                            {
                                using (SqlCommand command = new SqlCommand(insertSql, connection))
                                {
                                    // Set the parameter values for the SQL INSERT statement
                                    command.Parameters.AddWithValue("@Value1", row[0].ToString());
                                    command.Parameters.AddWithValue("@Value2", row[1].ToString());
                                    command.Parameters.AddWithValue("@Value3", row[2].ToString());

                                    // Execute the SQL INSERT statement
                                    command.ExecuteNonQuery();
                                }
                            }
                        }
                    }
                }

                // Display a message to the user indicating that the import was successful
                MessageBox.Show("Import complete.");
            }
        }

        private void Attendence_UC_Load(object sender, System.EventArgs e)
        {

        }

        private void fileSystemWatcher1_Changed(object sender, FileSystemEventArgs e)
        {

        }

        private void timer1_Tick(object sender, System.EventArgs e)
        {

        }
    }
}
