using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.ML.Data;
using Microsoft.ML.Trainers.FastTree;
using Microsoft.ML.Trainers;
using Microsoft.ML;

namespace MLModel1_ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            // Create MLContext
            var mlContext = new MLContext();

            // Load model
            var model = mlContext.Model.Load("MLModel1.zip", out var modelSchema);

            // Create prediction engine
            var predictionEngine = mlContext.Model.CreatePredictionEngine<InputData, OutputData>(model);

            // Get custom input values from user
            Console.WriteLine("Enter UserID:");
            var userID = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Month:");
            var month = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Days_Worked:");
            var daysWorked = Convert.ToInt32(Console.ReadLine());

            Console.WriteLine("Enter Total_Working_Days:");
            var totalWorkingDays = Convert.ToInt32(Console.ReadLine());

            // Make prediction
            var input = new InputData()
            {
                UserID = userID,
                Month = month,
                Days_Worked = daysWorked,
                Total_Working_Days = totalWorkingDays
            };

            var output = predictionEngine.Predict(input);

            // Display results
            Console.WriteLine($"Predicted Attendance Percentage: {output.Attendance_Percentage}");
        }
    }

    class InputData
    {
        public int UserID { get; set; }

        public int Month { get; set; }

        public int Days_Worked { get; set; }

        public int Total_Working_Days { get; set; }
    }

    class OutputData
    {
        [ColumnName("Score")]
        public float Attendance_Percentage { get; set; }
    }
}
