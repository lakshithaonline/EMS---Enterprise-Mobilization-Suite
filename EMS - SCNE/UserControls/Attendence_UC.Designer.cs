namespace EMS___SCNE
{
    partial class Attendence_UC
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Attendence_UC));
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle4 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle5 = new System.Windows.Forms.DataGridViewCellStyle();
            System.Windows.Forms.DataGridViewCellStyle dataGridViewCellStyle6 = new System.Windows.Forms.DataGridViewCellStyle();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges3 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges borderEdges4 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderEdges();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties5 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties6 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties7 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            Bunifu.UI.WinForms.BunifuTextBox.StateProperties stateProperties8 = new Bunifu.UI.WinForms.BunifuTextBox.StateProperties();
            this.eMSSCNEDataSetBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this._EMS_SCNEDataSet = new EMS___SCNE._EMS_SCNEDataSet();
            this.bunifuLabel1 = new Bunifu.UI.WinForms.BunifuLabel();
            this.openFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.fileSystemWatcher1 = new System.IO.FileSystemWatcher();
            this.bunifuPanel1 = new Bunifu.UI.WinForms.BunifuPanel();
            this.bunifuDataGridView1 = new Bunifu.UI.WinForms.BunifuDataGridView();
            this.userIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.nameDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.departmentDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.dateDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkInTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.checkOutTimeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.totalHoursWorkedDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.enrollIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.deviceIDDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.placeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.verifyModeDataGridViewTextBoxColumn = new System.Windows.Forms.DataGridViewTextBoxColumn();
            this.attendanceBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.bunifuButton1 = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.import_file = new Bunifu.UI.WinForms.BunifuButton.BunifuButton();
            this.bunifuTextBox1 = new Bunifu.UI.WinForms.BunifuTextBox();
            this.attendanceTableAdapter = new EMS___SCNE._EMS_SCNEDataSetTableAdapters.AttendanceTableAdapter();
            this.bunifuDatePicker2 = new Bunifu.UI.WinForms.BunifuDatePicker();
            this.bunifuDropdown2 = new Bunifu.UI.WinForms.BunifuDropdown();
            this.bunifuDatePicker1 = new Bunifu.UI.WinForms.BunifuDatePicker();
            ((System.ComponentModel.ISupportInitialize)(this.eMSSCNEDataSetBindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this._EMS_SCNEDataSet)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).BeginInit();
            this.bunifuPanel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.bunifuDataGridView1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // eMSSCNEDataSetBindingSource
            // 
            this.eMSSCNEDataSetBindingSource.DataSource = this._EMS_SCNEDataSet;
            this.eMSSCNEDataSetBindingSource.Position = 0;
            // 
            // _EMS_SCNEDataSet
            // 
            this._EMS_SCNEDataSet.DataSetName = "_EMS_SCNEDataSet";
            this._EMS_SCNEDataSet.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema;
            // 
            // bunifuLabel1
            // 
            this.bunifuLabel1.AllowParentOverrides = false;
            this.bunifuLabel1.AutoEllipsis = false;
            this.bunifuLabel1.CursorType = null;
            this.bunifuLabel1.Font = new System.Drawing.Font("Calibri", 15.75F, System.Drawing.FontStyle.Bold);
            this.bunifuLabel1.Location = new System.Drawing.Point(17, 22);
            this.bunifuLabel1.Name = "bunifuLabel1";
            this.bunifuLabel1.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.bunifuLabel1.Size = new System.Drawing.Size(190, 26);
            this.bunifuLabel1.TabIndex = 25;
            this.bunifuLabel1.Text = "Attendence Summery";
            this.bunifuLabel1.TextAlignment = System.Drawing.ContentAlignment.TopLeft;
            this.bunifuLabel1.TextFormat = Bunifu.UI.WinForms.BunifuLabel.TextFormattingOptions.Default;
            this.bunifuLabel1.Click += new System.EventHandler(this.bunifuLabel1_Click_1);
            // 
            // openFileDialog1
            // 
            this.openFileDialog1.FileName = "openFileDialog1";
            this.openFileDialog1.FileOk += new System.ComponentModel.CancelEventHandler(this.openFileDialog1_FileOk);
            // 
            // fileSystemWatcher1
            // 
            this.fileSystemWatcher1.EnableRaisingEvents = true;
            this.fileSystemWatcher1.SynchronizingObject = this;
            this.fileSystemWatcher1.Changed += new System.IO.FileSystemEventHandler(this.fileSystemWatcher1_Changed);
            // 
            // bunifuPanel1
            // 
            this.bunifuPanel1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuPanel1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuPanel1.BackgroundImage")));
            this.bunifuPanel1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.bunifuPanel1.BorderColor = System.Drawing.Color.Black;
            this.bunifuPanel1.BorderRadius = 10;
            this.bunifuPanel1.BorderThickness = 1;
            this.bunifuPanel1.Controls.Add(this.bunifuDataGridView1);
            this.bunifuPanel1.Location = new System.Drawing.Point(35, 175);
            this.bunifuPanel1.Name = "bunifuPanel1";
            this.bunifuPanel1.ShowBorders = true;
            this.bunifuPanel1.Size = new System.Drawing.Size(978, 358);
            this.bunifuPanel1.TabIndex = 29;
            // 
            // bunifuDataGridView1
            // 
            this.bunifuDataGridView1.AllowCustomTheming = false;
            this.bunifuDataGridView1.AllowUserToOrderColumns = true;
            dataGridViewCellStyle4.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(191)))));
            dataGridViewCellStyle4.ForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.AlternatingRowsDefaultCellStyle = dataGridViewCellStyle4;
            this.bunifuDataGridView1.AutoGenerateColumns = false;
            this.bunifuDataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.ColumnHeader;
            this.bunifuDataGridView1.BackgroundColor = System.Drawing.Color.FromArgb(((int)(((byte)(224)))), ((int)(((byte)(224)))), ((int)(((byte)(224)))));
            this.bunifuDataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None;
            this.bunifuDataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SingleHorizontal;
            this.bunifuDataGridView1.ColumnHeadersBorderStyle = System.Windows.Forms.DataGridViewHeaderBorderStyle.None;
            dataGridViewCellStyle5.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle5.BackColor = System.Drawing.Color.Orange;
            dataGridViewCellStyle5.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle5.ForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            dataGridViewCellStyle5.SelectionForeColor = System.Drawing.Color.White;
            dataGridViewCellStyle5.WrapMode = System.Windows.Forms.DataGridViewTriState.True;
            this.bunifuDataGridView1.ColumnHeadersDefaultCellStyle = dataGridViewCellStyle5;
            this.bunifuDataGridView1.ColumnHeadersHeight = 40;
            this.bunifuDataGridView1.Columns.AddRange(new System.Windows.Forms.DataGridViewColumn[] {
            this.userIDDataGridViewTextBoxColumn,
            this.nameDataGridViewTextBoxColumn,
            this.departmentDataGridViewTextBoxColumn,
            this.dateDataGridViewTextBoxColumn,
            this.checkInTimeDataGridViewTextBoxColumn,
            this.checkOutTimeDataGridViewTextBoxColumn,
            this.totalHoursWorkedDataGridViewTextBoxColumn,
            this.enrollIDDataGridViewTextBoxColumn,
            this.deviceIDDataGridViewTextBoxColumn,
            this.placeDataGridViewTextBoxColumn,
            this.verifyModeDataGridViewTextBoxColumn});
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(232)))), ((int)(((byte)(191)))));
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(102)))));
            this.bunifuDataGridView1.CurrentTheme.AlternatingRowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.CurrentTheme.BackColor = System.Drawing.Color.Orange;
            this.bunifuDataGridView1.CurrentTheme.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(226)))), ((int)(((byte)(173)))));
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.BackColor = System.Drawing.Color.Orange;
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 11.75F, System.Drawing.FontStyle.Bold);
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.ForeColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(132)))), ((int)(((byte)(0)))));
            this.bunifuDataGridView1.CurrentTheme.HeaderStyle.SelectionForeColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.CurrentTheme.Name = null;
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(204)))));
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.ForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(102)))));
            this.bunifuDataGridView1.CurrentTheme.RowsStyle.SelectionForeColor = System.Drawing.Color.Black;
            this.bunifuDataGridView1.DataSource = this.attendanceBindingSource;
            dataGridViewCellStyle6.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft;
            dataGridViewCellStyle6.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(237)))), ((int)(((byte)(204)))));
            dataGridViewCellStyle6.Font = new System.Drawing.Font("Segoe UI Semibold", 9.75F, System.Drawing.FontStyle.Bold);
            dataGridViewCellStyle6.ForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.SelectionBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(201)))), ((int)(((byte)(102)))));
            dataGridViewCellStyle6.SelectionForeColor = System.Drawing.Color.Black;
            dataGridViewCellStyle6.WrapMode = System.Windows.Forms.DataGridViewTriState.False;
            this.bunifuDataGridView1.DefaultCellStyle = dataGridViewCellStyle6;
            this.bunifuDataGridView1.EnableHeadersVisualStyles = false;
            this.bunifuDataGridView1.GridColor = System.Drawing.Color.FromArgb(((int)(((byte)(255)))), ((int)(((byte)(226)))), ((int)(((byte)(173)))));
            this.bunifuDataGridView1.HeaderBackColor = System.Drawing.Color.Orange;
            this.bunifuDataGridView1.HeaderBgColor = System.Drawing.Color.Empty;
            this.bunifuDataGridView1.HeaderForeColor = System.Drawing.Color.White;
            this.bunifuDataGridView1.Location = new System.Drawing.Point(8, 2);
            this.bunifuDataGridView1.Name = "bunifuDataGridView1";
            this.bunifuDataGridView1.RowHeadersVisible = false;
            this.bunifuDataGridView1.RowTemplate.Height = 40;
            this.bunifuDataGridView1.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
            this.bunifuDataGridView1.Size = new System.Drawing.Size(961, 353);
            this.bunifuDataGridView1.TabIndex = 2;
            this.bunifuDataGridView1.Theme = Bunifu.UI.WinForms.BunifuDataGridView.PresetThemes.Orange;
            this.bunifuDataGridView1.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.bunifuDataGridView1_CellContentClick);
            // 
            // userIDDataGridViewTextBoxColumn
            // 
            this.userIDDataGridViewTextBoxColumn.DataPropertyName = "UserID";
            this.userIDDataGridViewTextBoxColumn.HeaderText = "User ID";
            this.userIDDataGridViewTextBoxColumn.Name = "userIDDataGridViewTextBoxColumn";
            this.userIDDataGridViewTextBoxColumn.Width = 86;
            // 
            // nameDataGridViewTextBoxColumn
            // 
            this.nameDataGridViewTextBoxColumn.DataPropertyName = "Name";
            this.nameDataGridViewTextBoxColumn.HeaderText = "Name";
            this.nameDataGridViewTextBoxColumn.Name = "nameDataGridViewTextBoxColumn";
            this.nameDataGridViewTextBoxColumn.Width = 76;
            // 
            // departmentDataGridViewTextBoxColumn
            // 
            this.departmentDataGridViewTextBoxColumn.DataPropertyName = "Department";
            this.departmentDataGridViewTextBoxColumn.HeaderText = "Department";
            this.departmentDataGridViewTextBoxColumn.Name = "departmentDataGridViewTextBoxColumn";
            this.departmentDataGridViewTextBoxColumn.Width = 121;
            // 
            // dateDataGridViewTextBoxColumn
            // 
            this.dateDataGridViewTextBoxColumn.DataPropertyName = "Date";
            this.dateDataGridViewTextBoxColumn.HeaderText = "Date";
            this.dateDataGridViewTextBoxColumn.Name = "dateDataGridViewTextBoxColumn";
            this.dateDataGridViewTextBoxColumn.Width = 67;
            // 
            // checkInTimeDataGridViewTextBoxColumn
            // 
            this.checkInTimeDataGridViewTextBoxColumn.DataPropertyName = "Check_In_Time";
            this.checkInTimeDataGridViewTextBoxColumn.HeaderText = "Check In";
            this.checkInTimeDataGridViewTextBoxColumn.Name = "checkInTimeDataGridViewTextBoxColumn";
            this.checkInTimeDataGridViewTextBoxColumn.Width = 95;
            // 
            // checkOutTimeDataGridViewTextBoxColumn
            // 
            this.checkOutTimeDataGridViewTextBoxColumn.DataPropertyName = "Check_Out_Time";
            this.checkOutTimeDataGridViewTextBoxColumn.HeaderText = "Check Out";
            this.checkOutTimeDataGridViewTextBoxColumn.Name = "checkOutTimeDataGridViewTextBoxColumn";
            this.checkOutTimeDataGridViewTextBoxColumn.Width = 108;
            // 
            // totalHoursWorkedDataGridViewTextBoxColumn
            // 
            this.totalHoursWorkedDataGridViewTextBoxColumn.DataPropertyName = "Total_Hours_Worked";
            this.totalHoursWorkedDataGridViewTextBoxColumn.HeaderText = "Total Hours";
            this.totalHoursWorkedDataGridViewTextBoxColumn.Name = "totalHoursWorkedDataGridViewTextBoxColumn";
            this.totalHoursWorkedDataGridViewTextBoxColumn.Width = 116;
            // 
            // enrollIDDataGridViewTextBoxColumn
            // 
            this.enrollIDDataGridViewTextBoxColumn.DataPropertyName = "EnrollID";
            this.enrollIDDataGridViewTextBoxColumn.HeaderText = "Enroll ID";
            this.enrollIDDataGridViewTextBoxColumn.Name = "enrollIDDataGridViewTextBoxColumn";
            this.enrollIDDataGridViewTextBoxColumn.Width = 94;
            // 
            // deviceIDDataGridViewTextBoxColumn
            // 
            this.deviceIDDataGridViewTextBoxColumn.DataPropertyName = "DeviceID";
            this.deviceIDDataGridViewTextBoxColumn.HeaderText = "Device ID";
            this.deviceIDDataGridViewTextBoxColumn.Name = "deviceIDDataGridViewTextBoxColumn";
            this.deviceIDDataGridViewTextBoxColumn.Width = 102;
            // 
            // placeDataGridViewTextBoxColumn
            // 
            this.placeDataGridViewTextBoxColumn.DataPropertyName = "Place";
            this.placeDataGridViewTextBoxColumn.HeaderText = "Place";
            this.placeDataGridViewTextBoxColumn.Name = "placeDataGridViewTextBoxColumn";
            this.placeDataGridViewTextBoxColumn.Width = 71;
            // 
            // verifyModeDataGridViewTextBoxColumn
            // 
            this.verifyModeDataGridViewTextBoxColumn.DataPropertyName = "VerifyMode";
            this.verifyModeDataGridViewTextBoxColumn.HeaderText = "Verify Mode";
            this.verifyModeDataGridViewTextBoxColumn.Name = "verifyModeDataGridViewTextBoxColumn";
            this.verifyModeDataGridViewTextBoxColumn.Visible = false;
            this.verifyModeDataGridViewTextBoxColumn.Width = 123;
            // 
            // attendanceBindingSource
            // 
            this.attendanceBindingSource.DataMember = "Attendance";
            this.attendanceBindingSource.DataSource = this.eMSSCNEDataSetBindingSource;
            // 
            // bunifuButton1
            // 
            this.bunifuButton1.AllowAnimations = true;
            this.bunifuButton1.AllowMouseEffects = true;
            this.bunifuButton1.AllowToggling = false;
            this.bunifuButton1.AnimationSpeed = 200;
            this.bunifuButton1.AutoGenerateColors = false;
            this.bunifuButton1.AutoRoundBorders = false;
            this.bunifuButton1.AutoSizeLeftIcon = true;
            this.bunifuButton1.AutoSizeRightIcon = true;
            this.bunifuButton1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuButton1.BackColor1 = System.Drawing.Color.White;
            this.bunifuButton1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuButton1.BackgroundImage")));
            this.bunifuButton1.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.ButtonText = "Search";
            this.bunifuButton1.ButtonTextMarginLeft = 0;
            this.bunifuButton1.ColorContrastOnClick = 45;
            this.bunifuButton1.ColorContrastOnHover = 45;
            this.bunifuButton1.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges3.BottomLeft = true;
            borderEdges3.BottomRight = true;
            borderEdges3.TopLeft = true;
            borderEdges3.TopRight = true;
            this.bunifuButton1.CustomizableEdges = borderEdges3;
            this.bunifuButton1.DialogResult = System.Windows.Forms.DialogResult.None;
            this.bunifuButton1.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton1.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton1.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton1.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.bunifuButton1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuButton1.ForeColor = System.Drawing.Color.Black;
            this.bunifuButton1.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.bunifuButton1.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton1.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.bunifuButton1.IconMarginLeft = 11;
            this.bunifuButton1.IconPadding = 10;
            this.bunifuButton1.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.bunifuButton1.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.bunifuButton1.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.bunifuButton1.IconSize = 25;
            this.bunifuButton1.IdleBorderColor = System.Drawing.Color.Black;
            this.bunifuButton1.IdleBorderRadius = 10;
            this.bunifuButton1.IdleBorderThickness = 1;
            this.bunifuButton1.IdleFillColor = System.Drawing.Color.White;
            this.bunifuButton1.IdleIconLeftImage = null;
            this.bunifuButton1.IdleIconRightImage = null;
            this.bunifuButton1.IndicateFocus = false;
            this.bunifuButton1.Location = new System.Drawing.Point(348, 85);
            this.bunifuButton1.Name = "bunifuButton1";
            this.bunifuButton1.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.bunifuButton1.OnDisabledState.BorderRadius = 10;
            this.bunifuButton1.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.OnDisabledState.BorderThickness = 1;
            this.bunifuButton1.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuButton1.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.bunifuButton1.OnDisabledState.IconLeftImage = null;
            this.bunifuButton1.OnDisabledState.IconRightImage = null;
            this.bunifuButton1.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuButton1.onHoverState.BorderRadius = 10;
            this.bunifuButton1.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.onHoverState.BorderThickness = 1;
            this.bunifuButton1.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.bunifuButton1.onHoverState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton1.onHoverState.IconLeftImage = null;
            this.bunifuButton1.onHoverState.IconRightImage = null;
            this.bunifuButton1.OnIdleState.BorderColor = System.Drawing.Color.Black;
            this.bunifuButton1.OnIdleState.BorderRadius = 10;
            this.bunifuButton1.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.OnIdleState.BorderThickness = 1;
            this.bunifuButton1.OnIdleState.FillColor = System.Drawing.Color.White;
            this.bunifuButton1.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.bunifuButton1.OnIdleState.IconLeftImage = null;
            this.bunifuButton1.OnIdleState.IconRightImage = null;
            this.bunifuButton1.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton1.OnPressedState.BorderRadius = 10;
            this.bunifuButton1.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.bunifuButton1.OnPressedState.BorderThickness = 1;
            this.bunifuButton1.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.bunifuButton1.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.bunifuButton1.OnPressedState.IconLeftImage = null;
            this.bunifuButton1.OnPressedState.IconRightImage = null;
            this.bunifuButton1.Size = new System.Drawing.Size(79, 32);
            this.bunifuButton1.TabIndex = 28;
            this.bunifuButton1.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.bunifuButton1.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.bunifuButton1.TextMarginLeft = 0;
            this.bunifuButton1.TextPadding = new System.Windows.Forms.Padding(0);
            this.bunifuButton1.UseDefaultRadiusAndThickness = true;
            this.bunifuButton1.Click += new System.EventHandler(this.bunifuButton1_Click_1);
            // 
            // import_file
            // 
            this.import_file.AllowAnimations = true;
            this.import_file.AllowMouseEffects = true;
            this.import_file.AllowToggling = false;
            this.import_file.AnimationSpeed = 200;
            this.import_file.AutoGenerateColors = false;
            this.import_file.AutoRoundBorders = false;
            this.import_file.AutoSizeLeftIcon = true;
            this.import_file.AutoSizeRightIcon = true;
            this.import_file.BackColor = System.Drawing.Color.Transparent;
            this.import_file.BackColor1 = System.Drawing.Color.White;
            this.import_file.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("import_file.BackgroundImage")));
            this.import_file.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.import_file.ButtonText = "Import Attendence";
            this.import_file.ButtonTextMarginLeft = 0;
            this.import_file.ColorContrastOnClick = 45;
            this.import_file.ColorContrastOnHover = 45;
            this.import_file.Cursor = System.Windows.Forms.Cursors.Default;
            borderEdges4.BottomLeft = true;
            borderEdges4.BottomRight = true;
            borderEdges4.TopLeft = true;
            borderEdges4.TopRight = true;
            this.import_file.CustomizableEdges = borderEdges4;
            this.import_file.DialogResult = System.Windows.Forms.DialogResult.None;
            this.import_file.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.import_file.DisabledFillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.import_file.DisabledForecolor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.import_file.FocusState = Bunifu.UI.WinForms.BunifuButton.BunifuButton.ButtonStates.Pressed;
            this.import_file.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.import_file.ForeColor = System.Drawing.Color.Black;
            this.import_file.IconLeftAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.import_file.IconLeftCursor = System.Windows.Forms.Cursors.Default;
            this.import_file.IconLeftPadding = new System.Windows.Forms.Padding(11, 3, 3, 3);
            this.import_file.IconMarginLeft = 11;
            this.import_file.IconPadding = 10;
            this.import_file.IconRightAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.import_file.IconRightCursor = System.Windows.Forms.Cursors.Default;
            this.import_file.IconRightPadding = new System.Windows.Forms.Padding(3, 3, 7, 3);
            this.import_file.IconSize = 25;
            this.import_file.IdleBorderColor = System.Drawing.Color.Black;
            this.import_file.IdleBorderRadius = 10;
            this.import_file.IdleBorderThickness = 1;
            this.import_file.IdleFillColor = System.Drawing.Color.White;
            this.import_file.IdleIconLeftImage = null;
            this.import_file.IdleIconRightImage = null;
            this.import_file.IndicateFocus = false;
            this.import_file.Location = new System.Drawing.Point(863, 85);
            this.import_file.Name = "import_file";
            this.import_file.OnDisabledState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(191)))), ((int)(((byte)(191)))));
            this.import_file.OnDisabledState.BorderRadius = 10;
            this.import_file.OnDisabledState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.import_file.OnDisabledState.BorderThickness = 1;
            this.import_file.OnDisabledState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.import_file.OnDisabledState.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(168)))), ((int)(((byte)(160)))), ((int)(((byte)(168)))));
            this.import_file.OnDisabledState.IconLeftImage = null;
            this.import_file.OnDisabledState.IconRightImage = null;
            this.import_file.onHoverState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.import_file.onHoverState.BorderRadius = 10;
            this.import_file.onHoverState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.import_file.onHoverState.BorderThickness = 1;
            this.import_file.onHoverState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(105)))), ((int)(((byte)(181)))), ((int)(((byte)(255)))));
            this.import_file.onHoverState.ForeColor = System.Drawing.Color.White;
            this.import_file.onHoverState.IconLeftImage = null;
            this.import_file.onHoverState.IconRightImage = null;
            this.import_file.OnIdleState.BorderColor = System.Drawing.Color.Black;
            this.import_file.OnIdleState.BorderRadius = 10;
            this.import_file.OnIdleState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.import_file.OnIdleState.BorderThickness = 1;
            this.import_file.OnIdleState.FillColor = System.Drawing.Color.White;
            this.import_file.OnIdleState.ForeColor = System.Drawing.Color.Black;
            this.import_file.OnIdleState.IconLeftImage = null;
            this.import_file.OnIdleState.IconRightImage = null;
            this.import_file.OnPressedState.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.import_file.OnPressedState.BorderRadius = 10;
            this.import_file.OnPressedState.BorderStyle = Bunifu.UI.WinForms.BunifuButton.BunifuButton.BorderStyles.Solid;
            this.import_file.OnPressedState.BorderThickness = 1;
            this.import_file.OnPressedState.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(40)))), ((int)(((byte)(96)))), ((int)(((byte)(144)))));
            this.import_file.OnPressedState.ForeColor = System.Drawing.Color.White;
            this.import_file.OnPressedState.IconLeftImage = null;
            this.import_file.OnPressedState.IconRightImage = null;
            this.import_file.Size = new System.Drawing.Size(150, 37);
            this.import_file.TabIndex = 27;
            this.import_file.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            this.import_file.TextAlignment = System.Windows.Forms.HorizontalAlignment.Center;
            this.import_file.TextMarginLeft = 0;
            this.import_file.TextPadding = new System.Windows.Forms.Padding(0);
            this.import_file.UseDefaultRadiusAndThickness = true;
            this.import_file.Click += new System.EventHandler(this.bunifuButton1_Click);
            // 
            // bunifuTextBox1
            // 
            this.bunifuTextBox1.AcceptsReturn = false;
            this.bunifuTextBox1.AcceptsTab = false;
            this.bunifuTextBox1.AnimationSpeed = 200;
            this.bunifuTextBox1.AutoCompleteMode = System.Windows.Forms.AutoCompleteMode.None;
            this.bunifuTextBox1.AutoCompleteSource = System.Windows.Forms.AutoCompleteSource.None;
            this.bunifuTextBox1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuTextBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("bunifuTextBox1.BackgroundImage")));
            this.bunifuTextBox1.BorderColorActive = System.Drawing.Color.Black;
            this.bunifuTextBox1.BorderColorDisabled = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuTextBox1.BorderColorHover = System.Drawing.Color.Black;
            this.bunifuTextBox1.BorderColorIdle = System.Drawing.Color.Black;
            this.bunifuTextBox1.BorderRadius = 10;
            this.bunifuTextBox1.BorderThickness = 0;
            this.bunifuTextBox1.CharacterCasing = System.Windows.Forms.CharacterCasing.Normal;
            this.bunifuTextBox1.Cursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBox1.DefaultFont = new System.Drawing.Font("Segoe UI", 9.25F);
            this.bunifuTextBox1.DefaultText = "";
            this.bunifuTextBox1.FillColor = System.Drawing.Color.White;
            this.bunifuTextBox1.HideSelection = true;
            this.bunifuTextBox1.IconLeft = null;
            this.bunifuTextBox1.IconLeftCursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBox1.IconPadding = 10;
            this.bunifuTextBox1.IconRight = null;
            this.bunifuTextBox1.IconRightCursor = System.Windows.Forms.Cursors.IBeam;
            this.bunifuTextBox1.Lines = new string[0];
            this.bunifuTextBox1.Location = new System.Drawing.Point(35, 85);
            this.bunifuTextBox1.MaxLength = 32767;
            this.bunifuTextBox1.MinimumSize = new System.Drawing.Size(1, 1);
            this.bunifuTextBox1.Modified = false;
            this.bunifuTextBox1.Multiline = false;
            this.bunifuTextBox1.Name = "bunifuTextBox1";
            stateProperties5.BorderColor = System.Drawing.Color.Black;
            stateProperties5.FillColor = System.Drawing.Color.Empty;
            stateProperties5.ForeColor = System.Drawing.Color.Empty;
            stateProperties5.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBox1.OnActiveState = stateProperties5;
            stateProperties6.BorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            stateProperties6.FillColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            stateProperties6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            stateProperties6.PlaceholderForeColor = System.Drawing.Color.DarkGray;
            this.bunifuTextBox1.OnDisabledState = stateProperties6;
            stateProperties7.BorderColor = System.Drawing.Color.Black;
            stateProperties7.FillColor = System.Drawing.Color.Empty;
            stateProperties7.ForeColor = System.Drawing.Color.Empty;
            stateProperties7.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBox1.OnHoverState = stateProperties7;
            stateProperties8.BorderColor = System.Drawing.Color.Black;
            stateProperties8.FillColor = System.Drawing.Color.White;
            stateProperties8.ForeColor = System.Drawing.Color.Empty;
            stateProperties8.PlaceholderForeColor = System.Drawing.Color.Empty;
            this.bunifuTextBox1.OnIdleState = stateProperties8;
            this.bunifuTextBox1.Padding = new System.Windows.Forms.Padding(3);
            this.bunifuTextBox1.PasswordChar = '\0';
            this.bunifuTextBox1.PlaceholderForeColor = System.Drawing.Color.Silver;
            this.bunifuTextBox1.PlaceholderText = "Enter ID";
            this.bunifuTextBox1.ReadOnly = false;
            this.bunifuTextBox1.ScrollBars = System.Windows.Forms.ScrollBars.None;
            this.bunifuTextBox1.SelectedText = "";
            this.bunifuTextBox1.SelectionLength = 0;
            this.bunifuTextBox1.SelectionStart = 0;
            this.bunifuTextBox1.ShortcutsEnabled = true;
            this.bunifuTextBox1.Size = new System.Drawing.Size(151, 32);
            this.bunifuTextBox1.Style = Bunifu.UI.WinForms.BunifuTextBox._Style.Bunifu;
            this.bunifuTextBox1.TabIndex = 28;
            this.bunifuTextBox1.TextAlign = System.Windows.Forms.HorizontalAlignment.Left;
            this.bunifuTextBox1.TextMarginBottom = 0;
            this.bunifuTextBox1.TextMarginLeft = 3;
            this.bunifuTextBox1.TextMarginTop = 0;
            this.bunifuTextBox1.TextPlaceholder = "Enter ID";
            this.bunifuTextBox1.UseSystemPasswordChar = false;
            this.bunifuTextBox1.WordWrap = true;
            this.bunifuTextBox1.TextChanged += new System.EventHandler(this.bunifuTextBox1_TextChanged);
            // 
            // attendanceTableAdapter
            // 
            this.attendanceTableAdapter.ClearBeforeFill = true;
            // 
            // bunifuDatePicker2
            // 
            this.bunifuDatePicker2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDatePicker2.BorderRadius = 7;
            this.bunifuDatePicker2.Color = System.Drawing.Color.Black;
            this.bunifuDatePicker2.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.bunifuDatePicker2.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuDatePicker2.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker2.DisplayWeekNumbers = false;
            this.bunifuDatePicker2.DPHeight = 0;
            this.bunifuDatePicker2.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.bunifuDatePicker2.FillDatePicker = false;
            this.bunifuDatePicker2.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDatePicker2.ForeColor = System.Drawing.Color.Black;
            this.bunifuDatePicker2.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuDatePicker2.Icon")));
            this.bunifuDatePicker2.IconColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker2.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.bunifuDatePicker2.LeftTextMargin = 5;
            this.bunifuDatePicker2.Location = new System.Drawing.Point(35, 123);
            this.bunifuDatePicker2.MinimumSize = new System.Drawing.Size(4, 32);
            this.bunifuDatePicker2.Name = "bunifuDatePicker2";
            this.bunifuDatePicker2.Size = new System.Drawing.Size(193, 32);
            this.bunifuDatePicker2.TabIndex = 32;
            this.bunifuDatePicker2.Value = new System.DateTime(2023, 3, 18, 12, 9, 0, 0);
            this.bunifuDatePicker2.ValueChanged += new System.EventHandler(this.bunifuDatePicker2_ValueChanged);
            // 
            // bunifuDropdown2
            // 
            this.bunifuDropdown2.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDropdown2.BackgroundColor = System.Drawing.Color.White;
            this.bunifuDropdown2.BorderColor = System.Drawing.Color.Black;
            this.bunifuDropdown2.BorderRadius = 6;
            this.bunifuDropdown2.Color = System.Drawing.Color.Black;
            this.bunifuDropdown2.Direction = Bunifu.UI.WinForms.BunifuDropdown.Directions.Down;
            this.bunifuDropdown2.DisabledBackColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.bunifuDropdown2.DisabledBorderColor = System.Drawing.Color.FromArgb(((int)(((byte)(204)))), ((int)(((byte)(204)))), ((int)(((byte)(204)))));
            this.bunifuDropdown2.DisabledColor = System.Drawing.Color.FromArgb(((int)(((byte)(240)))), ((int)(((byte)(240)))), ((int)(((byte)(240)))));
            this.bunifuDropdown2.DisabledForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(109)))), ((int)(((byte)(109)))), ((int)(((byte)(109)))));
            this.bunifuDropdown2.DisabledIndicatorColor = System.Drawing.Color.DarkGray;
            this.bunifuDropdown2.DrawMode = System.Windows.Forms.DrawMode.OwnerDrawFixed;
            this.bunifuDropdown2.DropdownBorderThickness = Bunifu.UI.WinForms.BunifuDropdown.BorderThickness.Thin;
            this.bunifuDropdown2.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.bunifuDropdown2.DropDownTextAlign = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.bunifuDropdown2.FillDropDown = true;
            this.bunifuDropdown2.FillIndicator = false;
            this.bunifuDropdown2.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.bunifuDropdown2.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.bunifuDropdown2.ForeColor = System.Drawing.Color.Black;
            this.bunifuDropdown2.FormattingEnabled = true;
            this.bunifuDropdown2.Icon = null;
            this.bunifuDropdown2.IndicatorAlignment = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.bunifuDropdown2.IndicatorColor = System.Drawing.Color.Gray;
            this.bunifuDropdown2.IndicatorLocation = Bunifu.UI.WinForms.BunifuDropdown.Indicator.Right;
            this.bunifuDropdown2.ItemBackColor = System.Drawing.Color.White;
            this.bunifuDropdown2.ItemBorderColor = System.Drawing.Color.White;
            this.bunifuDropdown2.ItemForeColor = System.Drawing.Color.Black;
            this.bunifuDropdown2.ItemHeight = 26;
            this.bunifuDropdown2.ItemHighLightColor = System.Drawing.Color.DodgerBlue;
            this.bunifuDropdown2.ItemHighLightForeColor = System.Drawing.Color.White;
            this.bunifuDropdown2.ItemTopMargin = 3;
            this.bunifuDropdown2.Location = new System.Drawing.Point(192, 85);
            this.bunifuDropdown2.Name = "bunifuDropdown2";
            this.bunifuDropdown2.Size = new System.Drawing.Size(150, 32);
            this.bunifuDropdown2.TabIndex = 35;
            this.bunifuDropdown2.Text = "Select Type";
            this.bunifuDropdown2.TextAlignment = Bunifu.UI.WinForms.BunifuDropdown.TextAlign.Left;
            this.bunifuDropdown2.TextLeftMargin = 5;
            this.bunifuDropdown2.SelectedIndexChanged += new System.EventHandler(this.bunifuDropdown2_SelectedIndexChanged);
            // 
            // bunifuDatePicker1
            // 
            this.bunifuDatePicker1.BackColor = System.Drawing.Color.Transparent;
            this.bunifuDatePicker1.BorderRadius = 7;
            this.bunifuDatePicker1.Color = System.Drawing.Color.Black;
            this.bunifuDatePicker1.DateBorderThickness = Bunifu.UI.WinForms.BunifuDatePicker.BorderThickness.Thin;
            this.bunifuDatePicker1.DateTextAlign = Bunifu.UI.WinForms.BunifuDatePicker.TextAlign.Left;
            this.bunifuDatePicker1.DisabledColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker1.DisplayWeekNumbers = false;
            this.bunifuDatePicker1.DPHeight = 0;
            this.bunifuDatePicker1.DropDownAlign = System.Windows.Forms.LeftRightAlignment.Right;
            this.bunifuDatePicker1.FillDatePicker = false;
            this.bunifuDatePicker1.Font = new System.Drawing.Font("Calibri", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.bunifuDatePicker1.ForeColor = System.Drawing.Color.Black;
            this.bunifuDatePicker1.Icon = ((System.Drawing.Image)(resources.GetObject("bunifuDatePicker1.Icon")));
            this.bunifuDatePicker1.IconColor = System.Drawing.Color.Gray;
            this.bunifuDatePicker1.IconLocation = Bunifu.UI.WinForms.BunifuDatePicker.Indicator.Right;
            this.bunifuDatePicker1.LeftTextMargin = 5;
            this.bunifuDatePicker1.Location = new System.Drawing.Point(234, 123);
            this.bunifuDatePicker1.MinimumSize = new System.Drawing.Size(4, 32);
            this.bunifuDatePicker1.Name = "bunifuDatePicker1";
            this.bunifuDatePicker1.Size = new System.Drawing.Size(193, 32);
            this.bunifuDatePicker1.TabIndex = 36;
            this.bunifuDatePicker1.Value = new System.DateTime(2023, 3, 18, 12, 9, 0, 0);
            this.bunifuDatePicker1.ValueChanged += new System.EventHandler(this.bunifuDatePicker1_ValueChanged);
            // 
            // Attendence_UC
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.Controls.Add(this.bunifuDatePicker1);
            this.Controls.Add(this.bunifuDropdown2);
            this.Controls.Add(this.bunifuDatePicker2);
            this.Controls.Add(this.bunifuTextBox1);
            this.Controls.Add(this.bunifuPanel1);
            this.Controls.Add(this.bunifuButton1);
            this.Controls.Add(this.import_file);
            this.Controls.Add(this.bunifuLabel1);
            this.Name = "Attendence_UC";
            this.Size = new System.Drawing.Size(1035, 556);
            this.Load += new System.EventHandler(this.Attendence_UC_Load);
            ((System.ComponentModel.ISupportInitialize)(this.eMSSCNEDataSetBindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this._EMS_SCNEDataSet)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.fileSystemWatcher1)).EndInit();
            this.bunifuPanel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.bunifuDataGridView1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.attendanceBindingSource)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private Bunifu.UI.WinForms.BunifuDataGridView bunifuDataGridView1;
        private System.Windows.Forms.BindingSource eMSSCNEDataSetBindingSource;
        private _EMS_SCNEDataSet _EMS_SCNEDataSet;
        private Bunifu.UI.WinForms.BunifuLabel bunifuLabel1;
        private System.Windows.Forms.OpenFileDialog openFileDialog1;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton import_file;
        private Bunifu.UI.WinForms.BunifuButton.BunifuButton bunifuButton1;
        private System.IO.FileSystemWatcher fileSystemWatcher1;
        private Bunifu.UI.WinForms.BunifuPanel bunifuPanel1;
        private Bunifu.UI.WinForms.BunifuTextBox bunifuTextBox1;
        private System.Windows.Forms.BindingSource attendanceBindingSource;
        private _EMS_SCNEDataSetTableAdapters.AttendanceTableAdapter attendanceTableAdapter;
        private System.Windows.Forms.DataGridViewTextBoxColumn userIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn nameDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn departmentDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn dateDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkInTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn checkOutTimeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn totalHoursWorkedDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn enrollIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn deviceIDDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn placeDataGridViewTextBoxColumn;
        private System.Windows.Forms.DataGridViewTextBoxColumn verifyModeDataGridViewTextBoxColumn;
        private Bunifu.UI.WinForms.BunifuDatePicker bunifuDatePicker2;
        private Bunifu.UI.WinForms.BunifuDropdown bunifuDropdown2;
        private Bunifu.UI.WinForms.BunifuDatePicker bunifuDatePicker1;
    }
}
