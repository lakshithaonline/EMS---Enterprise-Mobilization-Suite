using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace EMS___SCNE
{
    public partial class ML_Testing : Form
    {
        public ML_Testing()
        {
            InitializeComponent();
        }

        private void bunifuButton1_Click(object sender, EventArgs e)
        {
            // Get input values from text boxes
            float userID = float.Parse(bunifuTextBox1.Text);
            float month = float.Parse(bunifuTextBox2.Text);

            // Calculate total working days for the entered month
            int daysInMonth = DateTime.DaysInMonth(DateTime.Now.Year, (int)month);
            float totalWorkingDays = (float)daysInMonth;

            // Get days worked value from text box
            float daysWorked = float.Parse(bunifuTextBox3.Text);

            // Create model input
           /* var sampleData = new ModelInput
            {
                UserID = userID,
                Month = month,
                Days_Worked = daysWorked,
                Total_Working_Days = totalWorkingDays
            }; */

            // Load model and predict output
            //var predictionResult = MLModel1.Predict(sampleData);

            // Display prediction result in a label
           // bunifuLabel1.Text = predictionResult.Prediction.ToString();
        }
    }
}
