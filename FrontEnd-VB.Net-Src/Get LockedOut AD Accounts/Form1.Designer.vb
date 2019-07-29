<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class GetLockedOutADForm
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(GetLockedOutADForm))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.Time = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Username = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.Hostname = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.EnterUsername = New System.Windows.Forms.TextBox()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.PictureBox1 = New System.Windows.Forms.PictureBox()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.Label2 = New System.Windows.Forms.Label()
        Me.Label3 = New System.Windows.Forms.Label()
        Me.Label4 = New System.Windows.Forms.Label()
        Me.CurrentFile = New System.Windows.Forms.TextBox()
        Me.ProgressBar1 = New System.Windows.Forms.ProgressBar()
        Me.Label5 = New System.Windows.Forms.Label()
        Me.Search = New System.Windows.Forms.Button()
        Me.lblVersion = New System.Windows.Forms.Label()
        Me.CheckBox1 = New System.Windows.Forms.CheckBox()
        Me.ContextMenuStrip1 = New System.Windows.Forms.ContextMenuStrip(Me.components)
        Me.LogoffToolStripMenuItem = New System.Windows.Forms.ToolStripMenuItem()
        Me.lable6 = New System.Windows.Forms.Label()
        Me.SharePath = New System.Windows.Forms.TextBox()
        Me.AskUsername = New System.Windows.Forms.Label()
        Me.Timer = New System.Windows.Forms.Timer(Me.components)
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.ContextMenuStrip1.SuspendLayout()
        Me.SuspendLayout()
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AllowUserToDeleteRows = False
        Me.DataGridView1.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.DataGridView1.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells
        Me.DataGridView1.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.Control
        Me.DataGridView1.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DataGridView1.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.SunkenHorizontal
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.Format = "N0"
        DataGridViewCellStyle1.NullValue = Nothing
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.Time, Me.Username, Me.Hostname})
        Me.DataGridView1.Location = New System.Drawing.Point(24, 235)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        DataGridViewCellStyle3.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleRight
        DataGridViewCellStyle3.BackColor = System.Drawing.SystemColors.ActiveCaption
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        DataGridViewCellStyle3.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle3.Format = "N0"
        DataGridViewCellStyle3.NullValue = Nothing
        DataGridViewCellStyle3.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle3.SelectionForeColor = System.Drawing.SystemColors.GradientInactiveCaption
        DataGridViewCellStyle3.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.RowHeadersDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.RowHeadersWidth = 50
        Me.DataGridView1.RowTemplate.Height = 24
        Me.DataGridView1.RowTemplate.Resizable = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.Size = New System.Drawing.Size(501, 460)
        Me.DataGridView1.TabIndex = 3
        '
        'Time
        '
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.Format = "G"
        DataGridViewCellStyle2.NullValue = Nothing
        Me.Time.DefaultCellStyle = DataGridViewCellStyle2
        Me.Time.HeaderText = "Time"
        Me.Time.MinimumWidth = 8
        Me.Time.Name = "Time"
        Me.Time.ReadOnly = True
        Me.Time.Width = 79
        '
        'Username
        '
        Me.Username.HeaderText = "Username"
        Me.Username.MinimumWidth = 8
        Me.Username.Name = "Username"
        Me.Username.ReadOnly = True
        Me.Username.Width = 119
        '
        'Hostname
        '
        Me.Hostname.HeaderText = "Hostname"
        Me.Hostname.MinimumWidth = 8
        Me.Hostname.Name = "Hostname"
        Me.Hostname.ReadOnly = True
        Me.Hostname.Width = 119
        '
        'EnterUsername
        '
        Me.EnterUsername.AcceptsReturn = True
        Me.EnterUsername.Location = New System.Drawing.Point(282, 186)
        Me.EnterUsername.Name = "EnterUsername"
        Me.EnterUsername.Size = New System.Drawing.Size(140, 26)
        Me.EnterUsername.TabIndex = 0
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle
        Me.Label1.Font = New System.Drawing.Font("Microsoft YaHei", 11.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.ImageAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.Label1.Location = New System.Drawing.Point(90, 45)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(364, 32)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Search For Locked AD Accounts"
        '
        'PictureBox1
        '
        Me.PictureBox1.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.PictureBox1.Image = CType(resources.GetObject("PictureBox1.Image"), System.Drawing.Image)
        Me.PictureBox1.Location = New System.Drawing.Point(24, 138)
        Me.PictureBox1.Name = "PictureBox1"
        Me.PictureBox1.Size = New System.Drawing.Size(84, 86)
        Me.PictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.StretchImage
        Me.PictureBox1.TabIndex = 5
        Me.PictureBox1.TabStop = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Checked = False
        Me.DateTimePicker1.Cursor = System.Windows.Forms.Cursors.Hand
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.5!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(282, 140)
        Me.DateTimePicker1.MinDate = New Date(2018, 6, 1, 0, 0, 0, 0)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(243, 27)
        Me.DateTimePicker1.TabIndex = 2
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(156, 145)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(114, 20)
        Me.Label2.TabIndex = 7
        Me.Label2.Text = "Select Date :"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D
        Me.Label3.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label3.ForeColor = System.Drawing.SystemColors.ControlDarkDark
        Me.Label3.Location = New System.Drawing.Point(310, 114)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(179, 22)
        Me.Label3.TabIndex = 8
        Me.Label3.Text = "Default Date (Today)"
        '
        'Label4
        '
        Me.Label4.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label4.AutoSize = True
        Me.Label4.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label4.Location = New System.Drawing.Point(34, 766)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(137, 20)
        Me.Label4.TabIndex = 9
        Me.Label4.Text = "File Processed :"
        '
        'CurrentFile
        '
        Me.CurrentFile.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CurrentFile.BackColor = System.Drawing.Color.DodgerBlue
        Me.CurrentFile.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.CurrentFile.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CurrentFile.ForeColor = System.Drawing.Color.Silver
        Me.CurrentFile.Location = New System.Drawing.Point(188, 765)
        Me.CurrentFile.Name = "CurrentFile"
        Me.CurrentFile.Size = New System.Drawing.Size(338, 23)
        Me.CurrentFile.TabIndex = 10
        Me.CurrentFile.Text = "Current File Being Processed"
        Me.CurrentFile.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'ProgressBar1
        '
        Me.ProgressBar1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.ProgressBar1.Location = New System.Drawing.Point(188, 726)
        Me.ProgressBar1.MarqueeAnimationSpeed = 1000
        Me.ProgressBar1.Name = "ProgressBar1"
        Me.ProgressBar1.Size = New System.Drawing.Size(338, 25)
        Me.ProgressBar1.TabIndex = 11
        Me.ProgressBar1.UseWaitCursor = True
        Me.ProgressBar1.Value = 1
        '
        'Label5
        '
        Me.Label5.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.Label5.AutoSize = True
        Me.Label5.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label5.Location = New System.Drawing.Point(86, 728)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(90, 20)
        Me.Label5.TabIndex = 12
        Me.Label5.Text = "Progress :"
        '
        'Search
        '
        Me.Search.BackColor = System.Drawing.Color.Green
        Me.Search.Cursor = System.Windows.Forms.Cursors.Hand
        Me.Search.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Search.ForeColor = System.Drawing.Color.White
        Me.Search.Location = New System.Drawing.Point(432, 174)
        Me.Search.Name = "Search"
        Me.Search.Size = New System.Drawing.Size(93, 46)
        Me.Search.TabIndex = 1
        Me.Search.Text = "Search"
        Me.Search.UseVisualStyleBackColor = False
        '
        'lblVersion
        '
        Me.lblVersion.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblVersion.AutoSize = True
        Me.lblVersion.Location = New System.Drawing.Point(426, 846)
        Me.lblVersion.Name = "lblVersion"
        Me.lblVersion.Size = New System.Drawing.Size(120, 20)
        Me.lblVersion.TabIndex = 14
        Me.lblVersion.Text = "Current Version"
        '
        'CheckBox1
        '
        Me.CheckBox1.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.CheckBox1.AutoSize = True
        Me.CheckBox1.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.CheckBox1.ForeColor = System.Drawing.Color.DarkGreen
        Me.CheckBox1.Location = New System.Drawing.Point(24, 840)
        Me.CheckBox1.Name = "CheckBox1"
        Me.CheckBox1.Size = New System.Drawing.Size(325, 24)
        Me.CheckBox1.TabIndex = 15
        Me.CheckBox1.Text = "Search all records for this username"
        Me.CheckBox1.UseVisualStyleBackColor = True
        '
        'ContextMenuStrip1
        '
        Me.ContextMenuStrip1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.ContextMenuStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.LogoffToolStripMenuItem})
        Me.ContextMenuStrip1.Name = "ContextMenuStrip1"
        Me.ContextMenuStrip1.Size = New System.Drawing.Size(138, 36)
        '
        'LogoffToolStripMenuItem
        '
        Me.LogoffToolStripMenuItem.Name = "LogoffToolStripMenuItem"
        Me.LogoffToolStripMenuItem.Size = New System.Drawing.Size(137, 32)
        Me.LogoffToolStripMenuItem.Text = "Logoff"
        '
        'lable6
        '
        Me.lable6.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.lable6.AutoSize = True
        Me.lable6.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lable6.ForeColor = System.Drawing.SystemColors.ActiveCaptionText
        Me.lable6.Location = New System.Drawing.Point(64, 805)
        Me.lable6.Name = "lable6"
        Me.lable6.Size = New System.Drawing.Size(109, 20)
        Me.lable6.TabIndex = 17
        Me.lable6.Text = "Share Path :"
        '
        'SharePath
        '
        Me.SharePath.Anchor = CType((System.Windows.Forms.AnchorStyles.Bottom Or System.Windows.Forms.AnchorStyles.Left), System.Windows.Forms.AnchorStyles)
        Me.SharePath.BackColor = System.Drawing.Color.DodgerBlue
        Me.SharePath.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.SharePath.Font = New System.Drawing.Font("Microsoft Sans Serif", 10.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.SharePath.ForeColor = System.Drawing.Color.Silver
        Me.SharePath.Location = New System.Drawing.Point(188, 803)
        Me.SharePath.Name = "SharePath"
        Me.SharePath.Size = New System.Drawing.Size(338, 23)
        Me.SharePath.TabIndex = 18
        Me.SharePath.Text = "\\ServerName\ShareName\"
        Me.SharePath.TextAlign = System.Windows.Forms.HorizontalAlignment.Center
        '
        'AskUsername
        '
        Me.AskUsername.AutoSize = True
        Me.AskUsername.Font = New System.Drawing.Font("Microsoft Sans Serif", 7.8!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.AskUsername.Location = New System.Drawing.Point(120, 191)
        Me.AskUsername.Name = "AskUsername"
        Me.AskUsername.Size = New System.Drawing.Size(155, 20)
        Me.AskUsername.TabIndex = 2
        Me.AskUsername.Text = "Enter Username : "
        '
        'Timer
        '
        Me.Timer.Enabled = True
        Me.Timer.Interval = 500
        '
        'GetLockedOutADForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(9.0!, 20.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(555, 871)
        Me.Controls.Add(Me.SharePath)
        Me.Controls.Add(Me.lable6)
        Me.Controls.Add(Me.CheckBox1)
        Me.Controls.Add(Me.lblVersion)
        Me.Controls.Add(Me.Search)
        Me.Controls.Add(Me.Label5)
        Me.Controls.Add(Me.ProgressBar1)
        Me.Controls.Add(Me.CurrentFile)
        Me.Controls.Add(Me.Label4)
        Me.Controls.Add(Me.Label3)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.DateTimePicker1)
        Me.Controls.Add(Me.PictureBox1)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.EnterUsername)
        Me.Controls.Add(Me.AskUsername)
        Me.Controls.Add(Me.DataGridView1)
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MinimumSize = New System.Drawing.Size(560, 796)
        Me.Name = "GetLockedOutADForm"
        Me.Text = "Get Locked Out AD User Accounts"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.PictureBox1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ContextMenuStrip1.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents EnterUsername As TextBox
    Friend WithEvents Label1 As Label
    Friend WithEvents PictureBox1 As PictureBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents Label2 As Label
    Friend WithEvents Label3 As Label
    Friend WithEvents Label4 As Label
    Friend WithEvents CurrentFile As TextBox
    Friend WithEvents ProgressBar1 As ProgressBar
    Friend WithEvents Label5 As Label
    Friend WithEvents Search As Button
    Friend WithEvents lblVersion As Label
    Friend WithEvents CheckBox1 As CheckBox
    Friend WithEvents ContextMenuStrip1 As ContextMenuStrip
    Friend WithEvents LogoffToolStripMenuItem As ToolStripMenuItem
    Friend WithEvents lable6 As Label
    Friend WithEvents SharePath As TextBox
    Friend WithEvents AskUsername As Label
    Friend WithEvents Time As DataGridViewTextBoxColumn
    Friend WithEvents Username As DataGridViewTextBoxColumn
    Friend WithEvents Hostname As DataGridViewTextBoxColumn
    Friend WithEvents Timer As Timer
End Class
