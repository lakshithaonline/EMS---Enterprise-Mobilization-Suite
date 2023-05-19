namespace EMS___SCNE
{
    partial class OverviewPanel_superadmin
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea11 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend11 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series11 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(OverviewPanel_superadmin));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea12 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend12 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series12 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuPanel2 = new Bunifu.UI.WinForms.BunifuPanel();
            this.bunifuLabel5 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel4 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel3 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel2 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuCircleProgress4 = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.bunifuCircleProgress3 = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.bunifuCircleProgress2 = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.bunifuCircleProgress1 = new Bunifu.UI.WinForms.BunifuCircleProgress();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.bunifuPanel3 = new Bunifu.UI.WinForms.BunifuPanel();
            this.chart2 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.bunifuLabel6 = new Bunifu.UI.WinForms.BunifuLabel();
            this.bunifuLabel7 = new Bunifu.UI.WinForms.BunifuLabel();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.bunifuPanel1.SuspendLayout();
            this.bunifuPanel2.SuspendLayout();
            this.bunifuPanel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).BeginInit();
            this.SuspendLayout();
            // 
            // chart1
            // 
            this.chart1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.chart1.BorderlineColor = System.Drawing.Color.Empty;
            chartArea11.Name = "ChartArea1";
            this.chart1.ChartAreas.Add(chartArea11);
            legend11.Name = "Legend1";
            this.chart1.Legends.Add(legend11);
            this.chart1.Location = new System.Drawing.Point(3, 27);
            this.chart1.Name = "chart1";
            this.chart1.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart1.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black,
        System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(128)))), ((int)(((byte)(0))))),
        System.Drawing.Color.Red};
            series11.ChartArea = "ChartArea1";
            series11.Legend = "Legend1";
            series11.Name = "Series1";
            this.chart1.Series.Add(series11);
            this.chart1.Size = new System.Drawing.Size(778, 256);
            this.chart1.TabIndex = 0;
            this.chart1.Text = "chart1";
            this.chart1.Click += new System.EventHandler(this.chart1_Click);
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Black;
            this.bunifuPanel1.BorderRadius = 10;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.bunifuLabel1);
            this.bunifuPanel1.Controls.Add(this.chart1);
            this.bunifuPanel1.Location = new System.Drawing.Point(3, 19);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(784, 286);
            this.bunifuPanel1.TabIndex = 1;
            this.bunifuPanel1.Click += new System.EventHandler(this.bunifuPanel1_Click);
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel1.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel1.Location = new System.Drawing.Point(16, 10);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(165, 23);
            this.bunifuLabel1.TabIndex = 3;
            this.bunifuLabel1.Text = "Monthly Attendance";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.bunifuLabel1.Click += new System.EventHandler(this.bunifuLabel1_Click);
            // 
            // bunifuPanel2
            // 
            this.bunifuPanel2.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuPanel2.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel2.BackgroundImage")));
            this.bunifuPanel2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel2.BorderColor = System.Drawing.Color.Black;
            this.bunifuPanel2.BorderRadius = 10;
            this.bunifuPanel2.BorderThickness = 1;
            this.bunifuPanel2.Controls.Add(this.bunifuLabel6);
            this.bunifuPanel2.Controls.Add(this.bunifuLabel5);
            this.bunifuPanel2.Controls.Add(this.bunifuLabel4);
            this.bunifuPanel2.Controls.Add(this.bunifuLabel3);
            this.bunifuPanel2.Controls.Add(this.bunifuLabel2);
            this.bunifuPanel2.Controls.Add(this.bunifuCircleProgress4);
            this.bunifuPanel2.Controls.Add(this.bunifuCircleProgress3);
            this.bunifuPanel2.Controls.Add(this.bunifuCircleProgress2);
            this.bunifuPanel2.Controls.Add(this.bunifuCircleProgress1);
            this.bunifuPanel2.Location = new System.Drawing.Point(3, 325);
            this.bunifuPanel2.Name = "bunifuPanel2";
            this.bunifuPanel2.ShowBorders = true;
            this.bunifuPanel2.Size = new System.Drawing.Size(784, 208);
            this.bunifuPanel2.TabIndex = 2;
            // 
            // bunifuLabel5
            // 
            this.bunifuLabel5.AllowParentOverrides = false;
            this.bunifuLabel5.AutoEllipsis = false;
            this.bunifuLabel5.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel5.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel5.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel5.Location = new System.Drawing.Point(419, 181);
            this.bunifuLabel5.Name = "bunifuLabel5";
            this.bunifuLabel5.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel5.Size = new System.Drawing.Size(121, 19);
            this.bunifuLabel5.TabIndex = 22;
            this.bunifuLabel5.Text = "THAMBURU VILLA";
            this.bunifuLabel5.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel5.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.bunifuLabel5.Click += new System.EventHandler(this.bunifuLabel5_Click);
            // 
            // bunifuLabel4
            // 
            this.bunifuLabel4.AllowParentOverrides = false;
            this.bunifuLabel4.AutoEllipsis = false;
            this.bunifuLabel4.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel4.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel4.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel4.Location = new System.Drawing.Point(643, 181);
            this.bunifuLabel4.Name = "bunifuLabel4";
            this.bunifuLabel4.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel4.Size = new System.Drawing.Size(50, 19);
            this.bunifuLabel4.TabIndex = 21;
            this.bunifuLabel4.Text = "The SIX";
            this.bunifuLabel4.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel4.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel3
            // 
            this.bunifuLabel3.AllowParentOverrides = false;
            this.bunifuLabel3.AutoEllipsis = false;
            this.bunifuLabel3.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel3.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel3.Location = new System.Drawing.Point(249, 181);
            this.bunifuLabel3.Name = "bunifuLabel3";
            this.bunifuLabel3.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel3.Size = new System.Drawing.Size(71, 19);
            this.bunifuLabel3.TabIndex = 20;
            this.bunifuLabel3.Text = "KAMATHA";
            this.bunifuLabel3.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel3.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel2
            // 
            this.bunifuLabel2.AllowParentOverrides = false;
            this.bunifuLabel2.AutoEllipsis = false;
            this.bunifuLabel2.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel2.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel2.Font = new System.Drawing.Font("Calibri", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuLabel2.Location = new System.Drawing.Point(64, 181);
            this.bunifuLabel2.Name = "bunifuLabel2";
            this.bunifuLabel2.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel2.Size = new System.Drawing.Size(69, 19);
            this.bunifuLabel2.TabIndex = 4;
            this.bunifuLabel2.Text = "Villa Anna";
            this.bunifuLabel2.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel2.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.bunifuLabel2.Click += new System.EventHandler(this.bunifuLabel2_Click);
            // 
            // bunifuCircleProgress4
            // 
            this.bunifuCircleProgress4.Animated = true;
            this.bunifuCircleProgress4.AnimationInterval = 1;
            this.bunifuCircleProgress4.AnimationSpeed = 1;
            this.bunifuCircleProgress4.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCircleProgress4.CircleMargin = 10;
            this.bunifuCircleProgress4.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.bunifuCircleProgress4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgress4.IsPercentage = true;
            this.bunifuCircleProgress4.LineProgressThickness = 10;
            this.bunifuCircleProgress4.LineThickness = 10;
            this.bunifuCircleProgress4.Location = new System.Drawing.Point(408, 37);
            this.bunifuCircleProgress4.Name = "bunifuCircleProgress4";
            this.bunifuCircleProgress4.ProgressAnimationSpeed = 200;
            this.bunifuCircleProgress4.ProgressBackColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuCircleProgress4.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(55)))));
            this.bunifuCircleProgress4.ProgressColor2 = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuCircleProgress4.ProgressEndCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Triangle;
            this.bunifuCircleProgress4.ProgressFillStyle = Bunifu.UI.WinForms.BunifuCircleProgress.FillStyles.Solid;
            this.bunifuCircleProgress4.ProgressStartCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Flat;
            this.bunifuCircleProgress4.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.bunifuCircleProgress4.Size = new System.Drawing.Size(141, 141);
            this.bunifuCircleProgress4.SubScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgress4.SubScriptMargin = new System.Windows.Forms.Padding(5, -20, 0, 0);
            this.bunifuCircleProgress4.SubScriptText = "";
            this.bunifuCircleProgress4.SuperScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgress4.SuperScriptMargin = new System.Windows.Forms.Padding(5, 50, 0, 0);
            this.bunifuCircleProgress4.SuperScriptText = "%";
            this.bunifuCircleProgress4.TabIndex = 19;
            this.bunifuCircleProgress4.Text = "30";
            this.bunifuCircleProgress4.TextMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.bunifuCircleProgress4.Value = 30;
            this.bunifuCircleProgress4.ValueByTransition = 30;
            this.bunifuCircleProgress4.ValueMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            // 
            // bunifuCircleProgress3
            // 
            this.bunifuCircleProgress3.Animated = true;
            this.bunifuCircleProgress3.AnimationInterval = 1;
            this.bunifuCircleProgress3.AnimationSpeed = 1;
            this.bunifuCircleProgress3.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCircleProgress3.CircleMargin = 10;
            this.bunifuCircleProgress3.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.bunifuCircleProgress3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgress3.IsPercentage = true;
            this.bunifuCircleProgress3.LineProgressThickness = 10;
            this.bunifuCircleProgress3.LineThickness = 10;
            this.bunifuCircleProgress3.Location = new System.Drawing.Point(217, 37);
            this.bunifuCircleProgress3.Name = "bunifuCircleProgress3";
            this.bunifuCircleProgress3.ProgressAnimationSpeed = 200;
            this.bunifuCircleProgress3.ProgressBackColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuCircleProgress3.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(55)))));
            this.bunifuCircleProgress3.ProgressColor2 = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuCircleProgress3.ProgressEndCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Triangle;
            this.bunifuCircleProgress3.ProgressFillStyle = Bunifu.UI.WinForms.BunifuCircleProgress.FillStyles.Solid;
            this.bunifuCircleProgress3.ProgressStartCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Flat;
            this.bunifuCircleProgress3.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.bunifuCircleProgress3.Size = new System.Drawing.Size(141, 141);
            this.bunifuCircleProgress3.SubScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgress3.SubScriptMargin = new System.Windows.Forms.Padding(5, -20, 0, 0);
            this.bunifuCircleProgress3.SubScriptText = "";
            this.bunifuCircleProgress3.SuperScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgress3.SuperScriptMargin = new System.Windows.Forms.Padding(5, 50, 0, 0);
            this.bunifuCircleProgress3.SuperScriptText = "%";
            this.bunifuCircleProgress3.TabIndex = 18;
            this.bunifuCircleProgress3.Text = "30";
            this.bunifuCircleProgress3.TextMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.bunifuCircleProgress3.Value = 30;
            this.bunifuCircleProgress3.ValueByTransition = 30;
            this.bunifuCircleProgress3.ValueMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            // 
            // bunifuCircleProgress2
            // 
            this.bunifuCircleProgress2.Animated = true;
            this.bunifuCircleProgress2.AnimationInterval = 1;
            this.bunifuCircleProgress2.AnimationSpeed = 1;
            this.bunifuCircleProgress2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCircleProgress2.CircleMargin = 10;
            this.bunifuCircleProgress2.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.bunifuCircleProgress2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgress2.IsPercentage = true;
            this.bunifuCircleProgress2.LineProgressThickness = 10;
            this.bunifuCircleProgress2.LineThickness = 10;
            this.bunifuCircleProgress2.Location = new System.Drawing.Point(594, 37);
            this.bunifuCircleProgress2.Name = "bunifuCircleProgress2";
            this.bunifuCircleProgress2.ProgressAnimationSpeed = 200;
            this.bunifuCircleProgress2.ProgressBackColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuCircleProgress2.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(55)))));
            this.bunifuCircleProgress2.ProgressColor2 = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuCircleProgress2.ProgressEndCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Triangle;
            this.bunifuCircleProgress2.ProgressFillStyle = Bunifu.UI.WinForms.BunifuCircleProgress.FillStyles.Solid;
            this.bunifuCircleProgress2.ProgressStartCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Flat;
            this.bunifuCircleProgress2.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.bunifuCircleProgress2.Size = new System.Drawing.Size(141, 141);
            this.bunifuCircleProgress2.SubScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgress2.SubScriptMargin = new System.Windows.Forms.Padding(5, -20, 0, 0);
            this.bunifuCircleProgress2.SubScriptText = "";
            this.bunifuCircleProgress2.SuperScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgress2.SuperScriptMargin = new System.Windows.Forms.Padding(5, 50, 0, 0);
            this.bunifuCircleProgress2.SuperScriptText = "%";
            this.bunifuCircleProgress2.TabIndex = 17;
            this.bunifuCircleProgress2.Text = "30";
            this.bunifuCircleProgress2.TextMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.bunifuCircleProgress2.Value = 30;
            this.bunifuCircleProgress2.ValueByTransition = 30;
            this.bunifuCircleProgress2.ValueMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.bunifuCircleProgress2.ProgressChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCircleProgress.ProgressChangedEventArgs>(this.bunifuCircleProgress2_ProgressChanged);
            // 
            // bunifuCircleProgress1
            // 
            this.bunifuCircleProgress1.Animated = true;
            this.bunifuCircleProgress1.AnimationInterval = 1;
            this.bunifuCircleProgress1.AnimationSpeed = 1;
            this.bunifuCircleProgress1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuCircleProgress1.CircleMargin = 10;
            this.bunifuCircleProgress1.Font = new System.Drawing.Font("Microsoft Sans Serif", 40F, System.Drawing.FontStyle.Bold);
            this.bunifuCircleProgress1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgress1.IsPercentage = false;
            this.bunifuCircleProgress1.LineProgressThickness = 10;
            this.bunifuCircleProgress1.LineThickness = 10;
            this.bunifuCircleProgress1.Location = new System.Drawing.Point(31, 37);
            this.bunifuCircleProgress1.Name = "bunifuCircleProgress1";
            this.bunifuCircleProgress1.ProgressAnimationSpeed = 200;
            this.bunifuCircleProgress1.ProgressBackColor = System.Drawing.Color.WhiteSmoke;
            this.bunifuCircleProgress1.ProgressColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(170)))), ((int)(((byte)(55)))));
            this.bunifuCircleProgress1.ProgressColor2 = System.Drawing.SystemColors.ActiveCaptionText;
            this.bunifuCircleProgress1.ProgressEndCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Triangle;
            this.bunifuCircleProgress1.ProgressFillStyle = Bunifu.UI.WinForms.BunifuCircleProgress.FillStyles.Solid;
            this.bunifuCircleProgress1.ProgressStartCap = Bunifu.UI.WinForms.BunifuCircleProgress.CapStyles.Flat;
            this.bunifuCircleProgress1.SecondaryFont = new System.Drawing.Font("Microsoft Sans Serif", 16F);
            this.bunifuCircleProgress1.Size = new System.Drawing.Size(141, 141);
            this.bunifuCircleProgress1.SubScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(64)))), ((int)(((byte)(64)))), ((int)(((byte)(64)))));
            this.bunifuCircleProgress1.SubScriptMargin = new System.Windows.Forms.Padding(5, -20, 0, 0);
            this.bunifuCircleProgress1.SubScriptText = "%";
            this.bunifuCircleProgress1.SuperScriptColor = System.Drawing.Color.FromArgb(((int)(((byte)(166)))), ((int)(((byte)(166)))), ((int)(((byte)(166)))));
            this.bunifuCircleProgress1.SuperScriptMargin = new System.Windows.Forms.Padding(5, 20, 0, 0);
            this.bunifuCircleProgress1.SuperScriptText = "";
            this.bunifuCircleProgress1.TabIndex = 16;
            this.bunifuCircleProgress1.Text = "30";
            this.bunifuCircleProgress1.TextMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.bunifuCircleProgress1.Value = 30;
            this.bunifuCircleProgress1.ValueByTransition = 30;
            this.bunifuCircleProgress1.ValueMargin = new System.Windows.Forms.Padding(0, 5, 0, 0);
            this.bunifuCircleProgress1.ProgressChanged += new System.EventHandler<Bunifu.UI.WinForms.BunifuCircleProgress.ProgressChangedEventArgs>(this.bunifuCircleProgress1_ProgressChanged);
            // 
            // timer1
            // 
            this.timer1.Interval = 1000;
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // bunifuPanel3
            // 
            this.bunifuPanel3.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuPanel3.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel3.BackgroundImage")));
            this.bunifuPanel3.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel3.BorderColor = System.Drawing.Color.Black;
            this.bunifuPanel3.BorderRadius = 10;
            this.bunifuPanel3.BorderThickness = 1;
            this.bunifuPanel3.Controls.Add(this.bunifuLabel7);
            this.bunifuPanel3.Controls.Add(this.chart2);
            this.bunifuPanel3.Location = new System.Drawing.Point(808, 19);
            this.bunifuPanel3.Name = "bunifuPanel3";
            this.bunifuPanel3.ShowBorders = true;
            this.bunifuPanel3.Size = new System.Drawing.Size(362, 514);
            this.bunifuPanel3.TabIndex = 23;
            this.bunifuPanel3.Click += new System.EventHandler(this.bunifuPanel3_Click);
            // 
            // chart2
            // 
            this.chart2.BackColor = System.Drawing.Color.Transparent;
            this.chart2.BorderlineColor = System.Drawing.Color.Black;
            chartArea12.Name = "ChartArea1";
            this.chart2.ChartAreas.Add(chartArea12);
            legend12.Name = "Legend1";
            this.chart2.Legends.Add(legend12);
            this.chart2.Location = new System.Drawing.Point(3, 27);
            this.chart2.Name = "chart2";
            this.chart2.Palette = System.Windows.Forms.DataVisualization.Charting.ChartColorPalette.None;
            this.chart2.PaletteCustomColors = new System.Drawing.Color[] {
        System.Drawing.Color.Black};
            series12.ChartArea = "ChartArea1";
            series12.Legend = "Legend1";
            series12.Name = "Series1";
            this.chart2.Series.Add(series12);
            this.chart2.Size = new System.Drawing.Size(356, 484);
            this.chart2.TabIndex = 1;
            this.chart2.Text = "chart3";
            // 
            // bunifuLabel6
            // 
            this.bunifuLabel6.AllowParentOverrides = false;
            this.bunifuLabel6.AutoEllipsis = false;
            this.bunifuLabel6.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel6.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel6.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel6.Location = new System.Drawing.Point(16, 11);
            this.bunifuLabel6.Name = "bunifuLabel6";
            this.bunifuLabel6.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel6.Size = new System.Drawing.Size(128, 23);
            this.bunifuLabel6.TabIndex = 4;
            this.bunifuLabel6.Text = "Site Attendance";
            this.bunifuLabel6.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel6.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // bunifuLabel7
            // 
            this.bunifuLabel7.AllowParentOverrides = false;
            this.bunifuLabel7.AutoEllipsis = false;
            this.bunifuLabel7.Cursor = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel7.CursorType = System.Windows.Forms.Cursors.Default;
            this.bunifuLabel7.Font = new System.Drawing.Font("Calibri", 14.25F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel7.Location = new System.Drawing.Point(13, 11);
            this.bunifuLabel7.Name = "bunifuLabel7";
            this.bunifuLabel7.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel7.Size = new System.Drawing.Size(172, 23);
            this.bunifuLabel7.TabIndex = 23;
            this.bunifuLabel7.Text = "Monthly Leave States";
            this.bunifuLabel7.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel7.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            // 
            // OverviewPanel_superadmin
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.AutoValidate = System.Windows.Forms.AutoValidate.EnableAllowFocusChange;
            this.Controls.Add(this.bunifuPanel3);
            this.Controls.Add(this.bunifuPanel2);
            this.Controls.Add(this.bunifuPanel1);
            this.Font = new System.Drawing.Font("Calibri", 8.25F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.ImeMode = System.Windows.Forms.ImeMode.NoControl;
            this.Name = "OverviewPanel_superadmin";
            this.Size = new System.Drawing.Size(1173, 548);
            this.Load += new System.EventHandler(this.OverviewPanel_superadmin_Load);
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.bunifuPanel1.ResumeLayout(false);
            this.bunifuPanel1.PerformLayout();
            this.bunifuPanel2.ResumeLayout(false);
            this.bunifuPanel2.PerformLayout();
            this.bunifuPanel3.ResumeLayout(false);
            this.bunifuPanel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.chart2)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel2;
        private Bunifu.UI.WinForms.BunifuCircleProgress bunifuCircleProgress2;
        private Bunifu.UI.WinForms.BunifuCircleProgress bunifuCircleProgress1;
        private Bunifu.UI.WinForms.BunifuCircleProgress bunifuCircleProgress4;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private System.Windows.Forms.Timer timer1;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel2;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel5;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel4;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel3;
        private Bunifu.UI.WinForms.BunifuCircleProgress bunifuCircleProgress3;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel3;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart2;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel6;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel7;
    }
}
