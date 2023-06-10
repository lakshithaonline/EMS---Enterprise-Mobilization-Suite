﻿
// This file was auto-generated by ML.NET Model Builder. 

using MLModel2_LeaveReason;

// Create single instance of sample data from first line of dataset for model input
MLModel2.ModelInput sampleData = new MLModel2.ModelInput()
{
    Col1 = @"Traveling for a vacation",
};

// Make a single prediction on the sample data and print results
var predictionResult = MLModel2.Predict(sampleData);

Console.WriteLine("Using model to make single prediction -- Comparing actual Col0 with predicted Col0 from sample data...\n\n");


Console.WriteLine($"Col0: {@"Positive"}");
Console.WriteLine($"Col1: {@"Traveling for a vacation"}");


Console.WriteLine($"\n\nPredicted Col0: {predictionResult.PredictedLabel}\n\n");
Console.WriteLine("=============== End of process, hit any key to finish ===============");
Console.ReadKey();
