﻿// This file was auto-generated by ML.NET Model Builder. 
using Microsoft.ML;
using Microsoft.ML.Data;
using System;
using System.Linq;
using System.IO;
using System.Collections.Generic;
namespace MLModel1_ConsoleApp1
{
    public partial class MLModel1
    {
        /// <summary>
        /// model input class for MLModel1.
        /// </summary>
        #region model input class
        public class ModelInput
        {
            [ColumnName(@"UserID")]
            public float UserID { get; set; }

            [ColumnName(@"Month")]
            public float Month { get; set; }

            [ColumnName(@"Days_Worked")]
            public float Days_Worked { get; set; }

            [ColumnName(@"Total_Working_Days")]
            public float Total_Working_Days { get; set; }

            [ColumnName(@"Attendance_Percentage")]
            public float Attendance_Percentage { get; set; }

        }

        #endregion

        /// <summary>
        /// model output class for MLModel1.
        /// </summary>
        #region model output class
        public class ModelOutput
        {
            [ColumnName(@"UserID")]
            public float UserID { get; set; }

            [ColumnName(@"Month")]
            public float Month { get; set; }

            [ColumnName(@"Days_Worked")]
            public float Days_Worked { get; set; }

            [ColumnName(@"Total_Working_Days")]
            public float Total_Working_Days { get; set; }

            [ColumnName(@"Attendance_Percentage")]
            public float Attendance_Percentage { get; set; }

            [ColumnName(@"Features")]
            public float[] Features { get; set; }

            [ColumnName(@"Score")]
            public float Score { get; set; }

        }

        #endregion

        private static string MLNetModelPath = Path.GetFullPath("MLModel1.zip");

        public static readonly Lazy<PredictionEngine<ModelInput, ModelOutput>> PredictEngine = new Lazy<PredictionEngine<ModelInput, ModelOutput>>(() => CreatePredictEngine(), true);

        /// <summary>
        /// Use this method to predict on <see cref="ModelInput"/>.
        /// </summary>
        /// <param name="input">model input.</param>
        /// <returns><seealso cref=" ModelOutput"/></returns>
        public static ModelOutput Predict(ModelInput input)
        {
            var predEngine = PredictEngine.Value;
            return predEngine.Predict(input);
        }

        private static PredictionEngine<ModelInput, ModelOutput> CreatePredictEngine()
        {
            var mlContext = new MLContext();
            ITransformer mlModel = mlContext.Model.Load(MLNetModelPath, out var _);
            return mlContext.Model.CreatePredictionEngine<ModelInput, ModelOutput>(mlModel);
        }
    }
}
