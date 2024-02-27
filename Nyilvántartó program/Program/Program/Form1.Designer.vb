<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
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
        Dim NévLabel As System.Windows.Forms.Label
        Dim Születési_helyLabel As System.Windows.Forms.Label
        Dim Anyja_neveLabel As System.Windows.Forms.Label
        Dim Leánykori_születési_neveLabel As System.Windows.Forms.Label
        Dim IrányítószámLabel As System.Windows.Forms.Label
        Dim Születési_időLabel As System.Windows.Forms.Label
        Dim TelefonszámLabel As System.Windows.Forms.Label
        Dim Regisztrációs_számLabel As System.Windows.Forms.Label
        Dim AdószámLabel As System.Windows.Forms.Label
        Dim Adóazonosító_számLabel As System.Windows.Forms.Label
        Dim Taj_számLabel As System.Windows.Forms.Label
        Dim Őstermelői_igazolványszámLabel As System.Windows.Forms.Label
        Dim Vállakozói_igazolványszámLabel As System.Windows.Forms.Label
        Dim Család_gazdálkodói_igazolványszámLabel As System.Windows.Forms.Label
        Dim FELIR_azonosítóLabel As System.Windows.Forms.Label
        Dim Utoljára_módosítvaLabel As System.Windows.Forms.Label
        Dim Label1 As System.Windows.Forms.Label
        Dim BankszámlaszámLabel As System.Windows.Forms.Label
        Dim DataGridViewCellStyle1 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle2 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim DataGridViewCellStyle3 As System.Windows.Forms.DataGridViewCellStyle = New System.Windows.Forms.DataGridViewCellStyle()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.DataGridView1 = New System.Windows.Forms.DataGridView()
        Me.AzonosítóDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.NévDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SzületésiHelyDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AnyjaNeveDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.LeánykoriszületésiNeveDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.IrányítószámDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HelységDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ÚtutcaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.HázszámDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.SzületésiIdőDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.FELIRAzonosítóDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.UtoljáraMódosítvaDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TelefonszámDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.RegisztrációsSzámDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdószámDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdóazonosítóSzámDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.TajszámDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.ŐstermelőiIgazolványszámDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.VállakozóiIgazolványszámDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.CsaládGazdálkodóiIgazolványszámDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.BankszámlaszámDataGridViewTextBoxColumn = New System.Windows.Forms.DataGridViewTextBoxColumn()
        Me.AdatokBindingSource1 = New System.Windows.Forms.BindingSource(Me.components)
        Me.AdatokDataSet1BindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.AdatokDataSet1 = New Program.AdatokDataSet1()
        Me.TB_Nev = New System.Windows.Forms.TextBox()
        Me.AdatokBindingSource = New System.Windows.Forms.BindingSource(Me.components)
        Me.TB_Szulhely = New System.Windows.Forms.TextBox()
        Me.TB_Anyja = New System.Windows.Forms.TextBox()
        Me.TB_Lanykori = New System.Windows.Forms.TextBox()
        Me.TB_Irsz = New System.Windows.Forms.TextBox()
        Me.TB_Hely = New System.Windows.Forms.TextBox()
        Me.TB_Ut = New System.Windows.Forms.TextBox()
        Me.TB_Hsz = New System.Windows.Forms.TextBox()
        Me.TB_Tel = New System.Windows.Forms.TextBox()
        Me.TB_Regsz = New System.Windows.Forms.TextBox()
        Me.TB_Osterm = New System.Windows.Forms.TextBox()
        Me.TB_Vallal = New System.Windows.Forms.TextBox()
        Me.TB_Csaladig = New System.Windows.Forms.TextBox()
        Me.TB_Felir = New System.Windows.Forms.TextBox()
        Me.TB_Ado = New System.Windows.Forms.TextBox()
        Me.TB_Adoazon = New System.Windows.Forms.TextBox()
        Me.TB_Taj = New System.Windows.Forms.TextBox()
        Me.GroupBox1 = New System.Windows.Forms.GroupBox()
        Me.TB_Mod = New System.Windows.Forms.TextBox()
        Me.B_Kilep = New System.Windows.Forms.Button()
        Me.B_Nyomtat = New System.Windows.Forms.Button()
        Me.TB_Banksz = New System.Windows.Forms.TextBox()
        Me.B_Torol = New System.Windows.Forms.Button()
        Me.DateTimePicker1 = New System.Windows.Forms.DateTimePicker()
        Me.GroupBox2 = New System.Windows.Forms.GroupBox()
        Me.TB_Szulido = New System.Windows.Forms.TextBox()
        Me.B_Mentes = New System.Windows.Forms.Button()
        Me.B_Hozzaad = New System.Windows.Forms.Button()
        Me.BindingNavigator1 = New System.Windows.Forms.BindingNavigator(Me.components)
        Me.ToolStripSeparator3 = New System.Windows.Forms.ToolStripSeparator()
        Me.TS_ID = New System.Windows.Forms.ToolStripTextBox()
        Me.ToolStripSeparator2 = New System.Windows.Forms.ToolStripSeparator()
        Me.TS_Hozzad = New System.Windows.Forms.ToolStripButton()
        Me.TS_Mentes = New System.Windows.Forms.ToolStripButton()
        Me.TS_MentesAs = New System.Windows.Forms.ToolStripButton()
        Me.TS_Torles = New System.Windows.Forms.ToolStripButton()
        Me.TS_Nyomtat = New System.Windows.Forms.ToolStripButton()
        Me.TS_Kilep = New System.Windows.Forms.ToolStripButton()
        Me.TS_Info = New System.Windows.Forms.ToolStripButton()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.SaveFileDialog1 = New System.Windows.Forms.SaveFileDialog()
        Me.PrintDocument1 = New System.Drawing.Printing.PrintDocument()
        Me.PrintPreviewDialog1 = New System.Windows.Forms.PrintPreviewDialog()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TextBox2 = New System.Windows.Forms.TextBox()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.AdatokTableAdapter = New Program.AdatokDataSet1TableAdapters.AdatokTableAdapter()
        Me.TableAdapterManager = New Program.AdatokDataSet1TableAdapters.TableAdapterManager()
        NévLabel = New System.Windows.Forms.Label()
        Születési_helyLabel = New System.Windows.Forms.Label()
        Anyja_neveLabel = New System.Windows.Forms.Label()
        Leánykori_születési_neveLabel = New System.Windows.Forms.Label()
        IrányítószámLabel = New System.Windows.Forms.Label()
        Születési_időLabel = New System.Windows.Forms.Label()
        TelefonszámLabel = New System.Windows.Forms.Label()
        Regisztrációs_számLabel = New System.Windows.Forms.Label()
        AdószámLabel = New System.Windows.Forms.Label()
        Adóazonosító_számLabel = New System.Windows.Forms.Label()
        Taj_számLabel = New System.Windows.Forms.Label()
        Őstermelői_igazolványszámLabel = New System.Windows.Forms.Label()
        Vállakozói_igazolványszámLabel = New System.Windows.Forms.Label()
        Család_gazdálkodói_igazolványszámLabel = New System.Windows.Forms.Label()
        FELIR_azonosítóLabel = New System.Windows.Forms.Label()
        Utoljára_módosítvaLabel = New System.Windows.Forms.Label()
        Label1 = New System.Windows.Forms.Label()
        BankszámlaszámLabel = New System.Windows.Forms.Label()
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdatokBindingSource1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdatokDataSet1BindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdatokDataSet1, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.AdatokBindingSource, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox1.SuspendLayout()
        Me.GroupBox2.SuspendLayout()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.BindingNavigator1.SuspendLayout()
        Me.SuspendLayout()
        '
        'NévLabel
        '
        NévLabel.AutoSize = True
        NévLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        NévLabel.Location = New System.Drawing.Point(12, 315)
        NévLabel.Name = "NévLabel"
        NévLabel.Size = New System.Drawing.Size(49, 24)
        NévLabel.TabIndex = 3
        NévLabel.Text = "Név:"
        '
        'Születési_helyLabel
        '
        Születési_helyLabel.AutoSize = True
        Születési_helyLabel.BackColor = System.Drawing.Color.White
        Születési_helyLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Születési_helyLabel.Location = New System.Drawing.Point(12, 97)
        Születési_helyLabel.Name = "Születési_helyLabel"
        Születési_helyLabel.Size = New System.Drawing.Size(130, 24)
        Születési_helyLabel.TabIndex = 5
        Születési_helyLabel.Text = "Születési hely:"
        '
        'Anyja_neveLabel
        '
        Anyja_neveLabel.AutoSize = True
        Anyja_neveLabel.BackColor = System.Drawing.Color.White
        Anyja_neveLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Anyja_neveLabel.Location = New System.Drawing.Point(356, 14)
        Anyja_neveLabel.Name = "Anyja_neveLabel"
        Anyja_neveLabel.Size = New System.Drawing.Size(109, 24)
        Anyja_neveLabel.TabIndex = 7
        Anyja_neveLabel.Text = "Anyja neve:"
        '
        'Leánykori_születési_neveLabel
        '
        Leánykori_születési_neveLabel.AutoSize = True
        Leánykori_születési_neveLabel.BackColor = System.Drawing.Color.White
        Leánykori_születési_neveLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Leánykori_születési_neveLabel.Location = New System.Drawing.Point(12, 53)
        Leánykori_születési_neveLabel.Name = "Leánykori_születési_neveLabel"
        Leánykori_születési_neveLabel.Size = New System.Drawing.Size(220, 24)
        Leánykori_születési_neveLabel.TabIndex = 9
        Leánykori_születési_neveLabel.Text = "Leánykori/születési neve:"
        '
        'IrányítószámLabel
        '
        IrányítószámLabel.AutoSize = True
        IrányítószámLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        IrányítószámLabel.Location = New System.Drawing.Point(12, 443)
        IrányítószámLabel.Name = "IrányítószámLabel"
        IrányítószámLabel.Size = New System.Drawing.Size(79, 24)
        IrányítószámLabel.TabIndex = 11
        IrányítószámLabel.Text = "Lakcím :" & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10)
        '
        'Születési_időLabel
        '
        Születési_időLabel.AutoSize = True
        Születési_időLabel.BackColor = System.Drawing.Color.White
        Születési_időLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Születési_időLabel.Location = New System.Drawing.Point(434, 94)
        Születési_időLabel.Name = "Születési_időLabel"
        Születési_időLabel.Size = New System.Drawing.Size(121, 24)
        Születési_időLabel.TabIndex = 19
        Születési_időLabel.Text = "Születési idő:"
        '
        'TelefonszámLabel
        '
        TelefonszámLabel.AutoSize = True
        TelefonszámLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        TelefonszámLabel.Location = New System.Drawing.Point(19, 495)
        TelefonszámLabel.Name = "TelefonszámLabel"
        TelefonszámLabel.Size = New System.Drawing.Size(42, 24)
        TelefonszámLabel.TabIndex = 21
        TelefonszámLabel.Text = "Tel:"
        '
        'Regisztrációs_számLabel
        '
        Regisztrációs_számLabel.AutoSize = True
        Regisztrációs_számLabel.BackColor = System.Drawing.Color.White
        Regisztrációs_számLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Regisztrációs_számLabel.Location = New System.Drawing.Point(557, 110)
        Regisztrációs_számLabel.Name = "Regisztrációs_számLabel"
        Regisztrációs_számLabel.Size = New System.Drawing.Size(175, 24)
        Regisztrációs_számLabel.TabIndex = 23
        Regisztrációs_számLabel.Text = "Regisztrációs szám:"
        '
        'AdószámLabel
        '
        AdószámLabel.AutoSize = True
        AdószámLabel.BackColor = System.Drawing.Color.White
        AdószámLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        AdószámLabel.Location = New System.Drawing.Point(513, 53)
        AdószámLabel.Name = "AdószámLabel"
        AdószámLabel.Size = New System.Drawing.Size(94, 24)
        AdószámLabel.TabIndex = 25
        AdószámLabel.Text = "Adószám:"
        '
        'Adóazonosító_számLabel
        '
        Adóazonosító_számLabel.AutoSize = True
        Adóazonosító_számLabel.BackColor = System.Drawing.Color.White
        Adóazonosító_számLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Adóazonosító_számLabel.Location = New System.Drawing.Point(434, 13)
        Adóazonosító_számLabel.Name = "Adóazonosító_számLabel"
        Adóazonosító_számLabel.Size = New System.Drawing.Size(179, 24)
        Adóazonosító_számLabel.TabIndex = 27
        Adóazonosító_számLabel.Text = "Adóazonosító szám:"
        '
        'Taj_számLabel
        '
        Taj_számLabel.AutoSize = True
        Taj_számLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Taj_számLabel.Location = New System.Drawing.Point(215, 495)
        Taj_számLabel.Name = "Taj_számLabel"
        Taj_számLabel.Size = New System.Drawing.Size(90, 24)
        Taj_számLabel.TabIndex = 29
        Taj_számLabel.Text = "Taj szám:"
        '
        'Őstermelői_igazolványszámLabel
        '
        Őstermelői_igazolványszámLabel.AutoSize = True
        Őstermelői_igazolványszámLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Őstermelői_igazolványszámLabel.Location = New System.Drawing.Point(19, 546)
        Őstermelői_igazolványszámLabel.Name = "Őstermelői_igazolványszámLabel"
        Őstermelői_igazolványszámLabel.Size = New System.Drawing.Size(266, 24)
        Őstermelői_igazolványszámLabel.TabIndex = 31
        Őstermelői_igazolványszámLabel.Text = "Nébih tevékenységi azonosító:"
        '
        'Vállakozói_igazolványszámLabel
        '
        Vállakozói_igazolványszámLabel.AutoSize = True
        Vállakozói_igazolványszámLabel.BackColor = System.Drawing.Color.White
        Vállakozói_igazolványszámLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Vállakozói_igazolványszámLabel.Location = New System.Drawing.Point(450, 64)
        Vállakozói_igazolványszámLabel.Name = "Vállakozói_igazolványszámLabel"
        Vállakozói_igazolványszámLabel.Size = New System.Drawing.Size(237, 24)
        Vállakozói_igazolványszámLabel.TabIndex = 33
        Vállakozói_igazolványszámLabel.Text = "Vállakozói igazolványszám:"
        '
        'Család_gazdálkodói_igazolványszámLabel
        '
        Család_gazdálkodói_igazolványszámLabel.AutoSize = True
        Család_gazdálkodói_igazolványszámLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Család_gazdálkodói_igazolványszámLabel.Location = New System.Drawing.Point(12, 593)
        Család_gazdálkodói_igazolványszámLabel.Name = "Család_gazdálkodói_igazolványszámLabel"
        Család_gazdálkodói_igazolványszámLabel.Size = New System.Drawing.Size(390, 24)
        Család_gazdálkodói_igazolványszámLabel.TabIndex = 35
        Család_gazdálkodói_igazolványszámLabel.Text = "Őstermelő családi gazsdaság száma: (ÖCSG)"
        '
        'FELIR_azonosítóLabel
        '
        FELIR_azonosítóLabel.AutoSize = True
        FELIR_azonosítóLabel.BackColor = System.Drawing.Color.White
        FELIR_azonosítóLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        FELIR_azonosítóLabel.Location = New System.Drawing.Point(215, 152)
        FELIR_azonosítóLabel.Name = "FELIR_azonosítóLabel"
        FELIR_azonosítóLabel.Size = New System.Drawing.Size(152, 24)
        FELIR_azonosítóLabel.TabIndex = 39
        FELIR_azonosítóLabel.Text = "FELIR azonosító:"
        '
        'Utoljára_módosítvaLabel
        '
        Utoljára_módosítvaLabel.AutoSize = True
        Utoljára_módosítvaLabel.BackColor = System.Drawing.Color.White
        Utoljára_módosítvaLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Utoljára_módosítvaLabel.Location = New System.Drawing.Point(471, 193)
        Utoljára_módosítvaLabel.Name = "Utoljára_módosítvaLabel"
        Utoljára_módosítvaLabel.Size = New System.Drawing.Size(167, 24)
        Utoljára_módosítvaLabel.TabIndex = 41
        Utoljára_módosítvaLabel.Text = "Utoljára módosítva:"
        '
        'Label1
        '
        Label1.AutoSize = True
        Label1.BackColor = System.Drawing.Color.White
        Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Label1.Location = New System.Drawing.Point(12, 273)
        Label1.Name = "Label1"
        Label1.Size = New System.Drawing.Size(167, 24)
        Label1.TabIndex = 41
        Label1.Text = "Utoljára módosítva:"
        '
        'BankszámlaszámLabel
        '
        BankszámlaszámLabel.AutoSize = True
        BankszámlaszámLabel.BackColor = System.Drawing.Color.White
        BankszámlaszámLabel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        BankszámlaszámLabel.Location = New System.Drawing.Point(12, 193)
        BankszámlaszámLabel.Name = "BankszámlaszámLabel"
        BankszámlaszámLabel.Size = New System.Drawing.Size(159, 24)
        BankszámlaszámLabel.TabIndex = 37
        BankszámlaszámLabel.Text = "Bankszámlaszám:"
        '
        'DataGridView1
        '
        Me.DataGridView1.AllowUserToAddRows = False
        Me.DataGridView1.AutoGenerateColumns = False
        Me.DataGridView1.BackgroundColor = System.Drawing.SystemColors.ButtonShadow
        DataGridViewCellStyle1.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle1.BackColor = System.Drawing.SystemColors.Control
        DataGridViewCellStyle1.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle1.ForeColor = System.Drawing.SystemColors.WindowText
        DataGridViewCellStyle1.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle1.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle1.WrapMode = System.Windows.Forms.DataGridViewTriState.[True]
        Me.DataGridView1.ColumnHeadersDefaultCellStyle = DataGridViewCellStyle1
        Me.DataGridView1.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DataGridView1.Columns.AddRange(New System.Windows.Forms.DataGridViewColumn() {Me.AzonosítóDataGridViewTextBoxColumn, Me.NévDataGridViewTextBoxColumn, Me.SzületésiHelyDataGridViewTextBoxColumn, Me.AnyjaNeveDataGridViewTextBoxColumn, Me.LeánykoriszületésiNeveDataGridViewTextBoxColumn, Me.IrányítószámDataGridViewTextBoxColumn, Me.HelységDataGridViewTextBoxColumn, Me.ÚtutcaDataGridViewTextBoxColumn, Me.HázszámDataGridViewTextBoxColumn, Me.SzületésiIdőDataGridViewTextBoxColumn, Me.FELIRAzonosítóDataGridViewTextBoxColumn, Me.UtoljáraMódosítvaDataGridViewTextBoxColumn, Me.TelefonszámDataGridViewTextBoxColumn, Me.RegisztrációsSzámDataGridViewTextBoxColumn, Me.AdószámDataGridViewTextBoxColumn, Me.AdóazonosítóSzámDataGridViewTextBoxColumn, Me.TajszámDataGridViewTextBoxColumn, Me.ŐstermelőiIgazolványszámDataGridViewTextBoxColumn, Me.VállakozóiIgazolványszámDataGridViewTextBoxColumn, Me.CsaládGazdálkodóiIgazolványszámDataGridViewTextBoxColumn, Me.BankszámlaszámDataGridViewTextBoxColumn})
        Me.DataGridView1.DataSource = Me.AdatokBindingSource1
        DataGridViewCellStyle2.Alignment = System.Windows.Forms.DataGridViewContentAlignment.MiddleLeft
        DataGridViewCellStyle2.BackColor = System.Drawing.SystemColors.Window
        DataGridViewCellStyle2.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.25!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        DataGridViewCellStyle2.ForeColor = System.Drawing.SystemColors.ControlText
        DataGridViewCellStyle2.SelectionBackColor = System.Drawing.SystemColors.Highlight
        DataGridViewCellStyle2.SelectionForeColor = System.Drawing.SystemColors.HighlightText
        DataGridViewCellStyle2.WrapMode = System.Windows.Forms.DataGridViewTriState.[False]
        Me.DataGridView1.DefaultCellStyle = DataGridViewCellStyle2
        Me.DataGridView1.Location = New System.Drawing.Point(0, 28)
        Me.DataGridView1.Name = "DataGridView1"
        Me.DataGridView1.ReadOnly = True
        Me.DataGridView1.RowHeadersVisible = False
        Me.DataGridView1.RowHeadersWidthSizeMode = System.Windows.Forms.DataGridViewRowHeadersWidthSizeMode.DisableResizing
        DataGridViewCellStyle3.Font = New System.Drawing.Font("Microsoft Sans Serif", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.DataGridView1.RowsDefaultCellStyle = DataGridViewCellStyle3
        Me.DataGridView1.Size = New System.Drawing.Size(1008, 275)
        Me.DataGridView1.TabIndex = 0
        '
        'AzonosítóDataGridViewTextBoxColumn
        '
        Me.AzonosítóDataGridViewTextBoxColumn.DataPropertyName = "Azonosító"
        Me.AzonosítóDataGridViewTextBoxColumn.HeaderText = "Azonosító"
        Me.AzonosítóDataGridViewTextBoxColumn.Name = "AzonosítóDataGridViewTextBoxColumn"
        Me.AzonosítóDataGridViewTextBoxColumn.ReadOnly = True
        Me.AzonosítóDataGridViewTextBoxColumn.Visible = False
        Me.AzonosítóDataGridViewTextBoxColumn.Width = 20
        '
        'NévDataGridViewTextBoxColumn
        '
        Me.NévDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.NévDataGridViewTextBoxColumn.DataPropertyName = "Név"
        Me.NévDataGridViewTextBoxColumn.HeaderText = "Név"
        Me.NévDataGridViewTextBoxColumn.Name = "NévDataGridViewTextBoxColumn"
        Me.NévDataGridViewTextBoxColumn.ReadOnly = True
        Me.NévDataGridViewTextBoxColumn.Width = 205
        '
        'SzületésiHelyDataGridViewTextBoxColumn
        '
        Me.SzületésiHelyDataGridViewTextBoxColumn.DataPropertyName = "Születési hely"
        Me.SzületésiHelyDataGridViewTextBoxColumn.HeaderText = "Születési hely"
        Me.SzületésiHelyDataGridViewTextBoxColumn.Name = "SzületésiHelyDataGridViewTextBoxColumn"
        Me.SzületésiHelyDataGridViewTextBoxColumn.ReadOnly = True
        Me.SzületésiHelyDataGridViewTextBoxColumn.Visible = False
        '
        'AnyjaNeveDataGridViewTextBoxColumn
        '
        Me.AnyjaNeveDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.AnyjaNeveDataGridViewTextBoxColumn.DataPropertyName = "Anyja neve"
        Me.AnyjaNeveDataGridViewTextBoxColumn.HeaderText = "Anyja neve"
        Me.AnyjaNeveDataGridViewTextBoxColumn.Name = "AnyjaNeveDataGridViewTextBoxColumn"
        Me.AnyjaNeveDataGridViewTextBoxColumn.ReadOnly = True
        Me.AnyjaNeveDataGridViewTextBoxColumn.Width = 130
        '
        'LeánykoriszületésiNeveDataGridViewTextBoxColumn
        '
        Me.LeánykoriszületésiNeveDataGridViewTextBoxColumn.DataPropertyName = "Leánykori/születési neve"
        Me.LeánykoriszületésiNeveDataGridViewTextBoxColumn.HeaderText = "Leánykori/születési neve"
        Me.LeánykoriszületésiNeveDataGridViewTextBoxColumn.Name = "LeánykoriszületésiNeveDataGridViewTextBoxColumn"
        Me.LeánykoriszületésiNeveDataGridViewTextBoxColumn.ReadOnly = True
        Me.LeánykoriszületésiNeveDataGridViewTextBoxColumn.Visible = False
        '
        'IrányítószámDataGridViewTextBoxColumn
        '
        Me.IrányítószámDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.IrányítószámDataGridViewTextBoxColumn.DataPropertyName = "Irányítószám"
        Me.IrányítószámDataGridViewTextBoxColumn.HeaderText = "Irsz"
        Me.IrányítószámDataGridViewTextBoxColumn.Name = "IrányítószámDataGridViewTextBoxColumn"
        Me.IrányítószámDataGridViewTextBoxColumn.ReadOnly = True
        Me.IrányítószámDataGridViewTextBoxColumn.Width = 45
        '
        'HelységDataGridViewTextBoxColumn
        '
        Me.HelységDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.HelységDataGridViewTextBoxColumn.DataPropertyName = "Helység"
        Me.HelységDataGridViewTextBoxColumn.HeaderText = "Helység"
        Me.HelységDataGridViewTextBoxColumn.Name = "HelységDataGridViewTextBoxColumn"
        Me.HelységDataGridViewTextBoxColumn.ReadOnly = True
        Me.HelységDataGridViewTextBoxColumn.Width = 180
        '
        'ÚtutcaDataGridViewTextBoxColumn
        '
        Me.ÚtutcaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.ÚtutcaDataGridViewTextBoxColumn.DataPropertyName = "Út,utca"
        Me.ÚtutcaDataGridViewTextBoxColumn.HeaderText = "Út,utca"
        Me.ÚtutcaDataGridViewTextBoxColumn.Name = "ÚtutcaDataGridViewTextBoxColumn"
        Me.ÚtutcaDataGridViewTextBoxColumn.ReadOnly = True
        Me.ÚtutcaDataGridViewTextBoxColumn.Width = 200
        '
        'HázszámDataGridViewTextBoxColumn
        '
        Me.HázszámDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.HázszámDataGridViewTextBoxColumn.DataPropertyName = "Házszám"
        Me.HázszámDataGridViewTextBoxColumn.HeaderText = "Házszám"
        Me.HázszámDataGridViewTextBoxColumn.Name = "HázszámDataGridViewTextBoxColumn"
        Me.HázszámDataGridViewTextBoxColumn.ReadOnly = True
        Me.HázszámDataGridViewTextBoxColumn.Width = 80
        '
        'SzületésiIdőDataGridViewTextBoxColumn
        '
        Me.SzületésiIdőDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.SzületésiIdőDataGridViewTextBoxColumn.DataPropertyName = "Születési idő"
        Me.SzületésiIdőDataGridViewTextBoxColumn.HeaderText = "Születési idő"
        Me.SzületésiIdőDataGridViewTextBoxColumn.Name = "SzületésiIdőDataGridViewTextBoxColumn"
        Me.SzületésiIdőDataGridViewTextBoxColumn.ReadOnly = True
        Me.SzületésiIdőDataGridViewTextBoxColumn.Width = 80
        '
        'FELIRAzonosítóDataGridViewTextBoxColumn
        '
        Me.FELIRAzonosítóDataGridViewTextBoxColumn.DataPropertyName = "FELIR azonosító"
        Me.FELIRAzonosítóDataGridViewTextBoxColumn.HeaderText = "FELIR azonosító"
        Me.FELIRAzonosítóDataGridViewTextBoxColumn.Name = "FELIRAzonosítóDataGridViewTextBoxColumn"
        Me.FELIRAzonosítóDataGridViewTextBoxColumn.ReadOnly = True
        Me.FELIRAzonosítóDataGridViewTextBoxColumn.Visible = False
        '
        'UtoljáraMódosítvaDataGridViewTextBoxColumn
        '
        Me.UtoljáraMódosítvaDataGridViewTextBoxColumn.AutoSizeMode = System.Windows.Forms.DataGridViewAutoSizeColumnMode.None
        Me.UtoljáraMódosítvaDataGridViewTextBoxColumn.DataPropertyName = "Utoljára módosítva"
        Me.UtoljáraMódosítvaDataGridViewTextBoxColumn.HeaderText = "Utoljára módosítva"
        Me.UtoljáraMódosítvaDataGridViewTextBoxColumn.Name = "UtoljáraMódosítvaDataGridViewTextBoxColumn"
        Me.UtoljáraMódosítvaDataGridViewTextBoxColumn.ReadOnly = True
        Me.UtoljáraMódosítvaDataGridViewTextBoxColumn.Width = 80
        '
        'TelefonszámDataGridViewTextBoxColumn
        '
        Me.TelefonszámDataGridViewTextBoxColumn.DataPropertyName = "Telefonszám"
        Me.TelefonszámDataGridViewTextBoxColumn.HeaderText = "Telefonszám"
        Me.TelefonszámDataGridViewTextBoxColumn.Name = "TelefonszámDataGridViewTextBoxColumn"
        Me.TelefonszámDataGridViewTextBoxColumn.ReadOnly = True
        Me.TelefonszámDataGridViewTextBoxColumn.Visible = False
        '
        'RegisztrációsSzámDataGridViewTextBoxColumn
        '
        Me.RegisztrációsSzámDataGridViewTextBoxColumn.DataPropertyName = "Regisztrációs szám"
        Me.RegisztrációsSzámDataGridViewTextBoxColumn.HeaderText = "Regisztrációs szám"
        Me.RegisztrációsSzámDataGridViewTextBoxColumn.Name = "RegisztrációsSzámDataGridViewTextBoxColumn"
        Me.RegisztrációsSzámDataGridViewTextBoxColumn.ReadOnly = True
        Me.RegisztrációsSzámDataGridViewTextBoxColumn.Visible = False
        '
        'AdószámDataGridViewTextBoxColumn
        '
        Me.AdószámDataGridViewTextBoxColumn.DataPropertyName = "Adószám"
        Me.AdószámDataGridViewTextBoxColumn.HeaderText = "Adószám"
        Me.AdószámDataGridViewTextBoxColumn.Name = "AdószámDataGridViewTextBoxColumn"
        Me.AdószámDataGridViewTextBoxColumn.ReadOnly = True
        Me.AdószámDataGridViewTextBoxColumn.Visible = False
        '
        'AdóazonosítóSzámDataGridViewTextBoxColumn
        '
        Me.AdóazonosítóSzámDataGridViewTextBoxColumn.DataPropertyName = "Adóazonosító szám"
        Me.AdóazonosítóSzámDataGridViewTextBoxColumn.HeaderText = "Adóazonosító szám"
        Me.AdóazonosítóSzámDataGridViewTextBoxColumn.Name = "AdóazonosítóSzámDataGridViewTextBoxColumn"
        Me.AdóazonosítóSzámDataGridViewTextBoxColumn.ReadOnly = True
        Me.AdóazonosítóSzámDataGridViewTextBoxColumn.Visible = False
        '
        'TajszámDataGridViewTextBoxColumn
        '
        Me.TajszámDataGridViewTextBoxColumn.DataPropertyName = "Tajszám"
        Me.TajszámDataGridViewTextBoxColumn.HeaderText = "Tajszám"
        Me.TajszámDataGridViewTextBoxColumn.Name = "TajszámDataGridViewTextBoxColumn"
        Me.TajszámDataGridViewTextBoxColumn.ReadOnly = True
        Me.TajszámDataGridViewTextBoxColumn.Visible = False
        '
        'ŐstermelőiIgazolványszámDataGridViewTextBoxColumn
        '
        Me.ŐstermelőiIgazolványszámDataGridViewTextBoxColumn.DataPropertyName = "Őstermelői igazolványszám"
        Me.ŐstermelőiIgazolványszámDataGridViewTextBoxColumn.HeaderText = "Őstermelői igazolványszám"
        Me.ŐstermelőiIgazolványszámDataGridViewTextBoxColumn.Name = "ŐstermelőiIgazolványszámDataGridViewTextBoxColumn"
        Me.ŐstermelőiIgazolványszámDataGridViewTextBoxColumn.ReadOnly = True
        Me.ŐstermelőiIgazolványszámDataGridViewTextBoxColumn.Visible = False
        '
        'VállakozóiIgazolványszámDataGridViewTextBoxColumn
        '
        Me.VállakozóiIgazolványszámDataGridViewTextBoxColumn.DataPropertyName = "Vállakozói igazolványszám"
        Me.VállakozóiIgazolványszámDataGridViewTextBoxColumn.HeaderText = "Vállakozói igazolványszám"
        Me.VállakozóiIgazolványszámDataGridViewTextBoxColumn.Name = "VállakozóiIgazolványszámDataGridViewTextBoxColumn"
        Me.VállakozóiIgazolványszámDataGridViewTextBoxColumn.ReadOnly = True
        Me.VállakozóiIgazolványszámDataGridViewTextBoxColumn.Visible = False
        '
        'CsaládGazdálkodóiIgazolványszámDataGridViewTextBoxColumn
        '
        Me.CsaládGazdálkodóiIgazolványszámDataGridViewTextBoxColumn.DataPropertyName = "Család gazdálkodói igazolványszám"
        Me.CsaládGazdálkodóiIgazolványszámDataGridViewTextBoxColumn.HeaderText = "Család gazdálkodói igazolványszám"
        Me.CsaládGazdálkodóiIgazolványszámDataGridViewTextBoxColumn.Name = "CsaládGazdálkodóiIgazolványszámDataGridViewTextBoxColumn"
        Me.CsaládGazdálkodóiIgazolványszámDataGridViewTextBoxColumn.ReadOnly = True
        Me.CsaládGazdálkodóiIgazolványszámDataGridViewTextBoxColumn.Visible = False
        '
        'BankszámlaszámDataGridViewTextBoxColumn
        '
        Me.BankszámlaszámDataGridViewTextBoxColumn.DataPropertyName = "Bankszámlaszám"
        Me.BankszámlaszámDataGridViewTextBoxColumn.HeaderText = "Bankszámlaszám"
        Me.BankszámlaszámDataGridViewTextBoxColumn.Name = "BankszámlaszámDataGridViewTextBoxColumn"
        Me.BankszámlaszámDataGridViewTextBoxColumn.ReadOnly = True
        Me.BankszámlaszámDataGridViewTextBoxColumn.Visible = False
        '
        'AdatokBindingSource1
        '
        Me.AdatokBindingSource1.DataMember = "Adatok"
        Me.AdatokBindingSource1.DataSource = Me.AdatokDataSet1BindingSource
        '
        'AdatokDataSet1BindingSource
        '
        Me.AdatokDataSet1BindingSource.DataSource = Me.AdatokDataSet1
        Me.AdatokDataSet1BindingSource.Position = 0
        '
        'AdatokDataSet1
        '
        Me.AdatokDataSet1.DataSetName = "AdatokDataSet1"
        Me.AdatokDataSet1.SchemaSerializationMode = System.Data.SchemaSerializationMode.IncludeSchema
        '
        'TB_Nev
        '
        Me.TB_Nev.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Név", True))
        Me.TB_Nev.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Nev.Location = New System.Drawing.Point(67, 14)
        Me.TB_Nev.MaxLength = 20
        Me.TB_Nev.Name = "TB_Nev"
        Me.TB_Nev.RightToLeft = System.Windows.Forms.RightToLeft.No
        Me.TB_Nev.Size = New System.Drawing.Size(267, 29)
        Me.TB_Nev.TabIndex = 1
        '
        'AdatokBindingSource
        '
        Me.AdatokBindingSource.DataMember = "Adatok"
        Me.AdatokBindingSource.DataSource = Me.AdatokDataSet1
        '
        'TB_Szulhely
        '
        Me.TB_Szulhely.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Születési hely", True))
        Me.TB_Szulhely.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Szulhely.Location = New System.Drawing.Point(148, 94)
        Me.TB_Szulhely.Name = "TB_Szulhely"
        Me.TB_Szulhely.Size = New System.Drawing.Size(275, 29)
        Me.TB_Szulhely.TabIndex = 5
        '
        'TB_Anyja
        '
        Me.TB_Anyja.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Anyja neve", True))
        Me.TB_Anyja.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Anyja.Location = New System.Drawing.Point(471, 14)
        Me.TB_Anyja.Name = "TB_Anyja"
        Me.TB_Anyja.Size = New System.Drawing.Size(269, 29)
        Me.TB_Anyja.TabIndex = 2
        '
        'TB_Lanykori
        '
        Me.TB_Lanykori.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Leánykori/születési neve", True))
        Me.TB_Lanykori.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Lanykori.Location = New System.Drawing.Point(238, 50)
        Me.TB_Lanykori.Name = "TB_Lanykori"
        Me.TB_Lanykori.Size = New System.Drawing.Size(269, 29)
        Me.TB_Lanykori.TabIndex = 3
        '
        'TB_Irsz
        '
        Me.TB_Irsz.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Irányítószám", True))
        Me.TB_Irsz.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Irsz.Location = New System.Drawing.Point(97, 139)
        Me.TB_Irsz.Name = "TB_Irsz"
        Me.TB_Irsz.Size = New System.Drawing.Size(51, 29)
        Me.TB_Irsz.TabIndex = 7
        '
        'TB_Hely
        '
        Me.TB_Hely.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Helység", True))
        Me.TB_Hely.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Hely.Location = New System.Drawing.Point(154, 139)
        Me.TB_Hely.Name = "TB_Hely"
        Me.TB_Hely.Size = New System.Drawing.Size(269, 29)
        Me.TB_Hely.TabIndex = 8
        '
        'TB_Ut
        '
        Me.TB_Ut.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Út,utca", True))
        Me.TB_Ut.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Ut.Location = New System.Drawing.Point(429, 139)
        Me.TB_Ut.Name = "TB_Ut"
        Me.TB_Ut.Size = New System.Drawing.Size(269, 29)
        Me.TB_Ut.TabIndex = 9
        '
        'TB_Hsz
        '
        Me.TB_Hsz.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Házszám", True))
        Me.TB_Hsz.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Hsz.Location = New System.Drawing.Point(704, 139)
        Me.TB_Hsz.Name = "TB_Hsz"
        Me.TB_Hsz.Size = New System.Drawing.Size(92, 29)
        Me.TB_Hsz.TabIndex = 10
        '
        'TB_Tel
        '
        Me.TB_Tel.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Telefonszám", True))
        Me.TB_Tel.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Tel.Location = New System.Drawing.Point(67, 13)
        Me.TB_Tel.Name = "TB_Tel"
        Me.TB_Tel.Size = New System.Drawing.Size(142, 29)
        Me.TB_Tel.TabIndex = 10
        '
        'TB_Regsz
        '
        Me.TB_Regsz.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Regisztrációs szám", True))
        Me.TB_Regsz.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Regsz.Location = New System.Drawing.Point(738, 110)
        Me.TB_Regsz.Name = "TB_Regsz"
        Me.TB_Regsz.Size = New System.Drawing.Size(109, 29)
        Me.TB_Regsz.TabIndex = 16
        '
        'TB_Osterm
        '
        Me.TB_Osterm.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Őstermelői igazolványszám", True))
        Me.TB_Osterm.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Osterm.Location = New System.Drawing.Point(291, 64)
        Me.TB_Osterm.Name = "TB_Osterm"
        Me.TB_Osterm.Size = New System.Drawing.Size(153, 29)
        Me.TB_Osterm.TabIndex = 13
        '
        'TB_Vallal
        '
        Me.TB_Vallal.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Vállakozói igazolványszám", True))
        Me.TB_Vallal.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Vallal.Location = New System.Drawing.Point(693, 64)
        Me.TB_Vallal.Name = "TB_Vallal"
        Me.TB_Vallal.Size = New System.Drawing.Size(110, 29)
        Me.TB_Vallal.TabIndex = 14
        '
        'TB_Csaladig
        '
        Me.TB_Csaladig.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Család gazdálkodói igazolványszám", True))
        Me.TB_Csaladig.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Csaladig.Location = New System.Drawing.Point(408, 110)
        Me.TB_Csaladig.Name = "TB_Csaladig"
        Me.TB_Csaladig.Size = New System.Drawing.Size(142, 29)
        Me.TB_Csaladig.TabIndex = 15
        '
        'TB_Felir
        '
        Me.TB_Felir.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "FELIR azonosító", True))
        Me.TB_Felir.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Felir.Location = New System.Drawing.Point(373, 152)
        Me.TB_Felir.Name = "TB_Felir"
        Me.TB_Felir.Size = New System.Drawing.Size(269, 29)
        Me.TB_Felir.TabIndex = 17
        '
        'TB_Ado
        '
        Me.TB_Ado.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Adószám", True))
        Me.TB_Ado.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Ado.Location = New System.Drawing.Point(613, 50)
        Me.TB_Ado.Name = "TB_Ado"
        Me.TB_Ado.Size = New System.Drawing.Size(154, 29)
        Me.TB_Ado.TabIndex = 4
        '
        'TB_Adoazon
        '
        Me.TB_Adoazon.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Adóazonosító szám", True))
        Me.TB_Adoazon.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Adoazon.Location = New System.Drawing.Point(619, 13)
        Me.TB_Adoazon.Name = "TB_Adoazon"
        Me.TB_Adoazon.Size = New System.Drawing.Size(121, 29)
        Me.TB_Adoazon.TabIndex = 12
        '
        'TB_Taj
        '
        Me.TB_Taj.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Tajszám", True))
        Me.TB_Taj.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Taj.Location = New System.Drawing.Point(311, 13)
        Me.TB_Taj.Name = "TB_Taj"
        Me.TB_Taj.Size = New System.Drawing.Size(117, 29)
        Me.TB_Taj.TabIndex = 11
        '
        'GroupBox1
        '
        Me.GroupBox1.BackColor = System.Drawing.Color.Gray
        Me.GroupBox1.Controls.Add(Me.TB_Mod)
        Me.GroupBox1.Controls.Add(Me.B_Kilep)
        Me.GroupBox1.Controls.Add(Me.B_Nyomtat)
        Me.GroupBox1.Controls.Add(Me.TB_Banksz)
        Me.GroupBox1.Controls.Add(Me.TB_Felir)
        Me.GroupBox1.Controls.Add(Me.TB_Regsz)
        Me.GroupBox1.Controls.Add(Me.TB_Tel)
        Me.GroupBox1.Controls.Add(Me.TB_Adoazon)
        Me.GroupBox1.Controls.Add(Me.TB_Csaladig)
        Me.GroupBox1.Controls.Add(Me.TB_Taj)
        Me.GroupBox1.Controls.Add(Me.TB_Vallal)
        Me.GroupBox1.Controls.Add(Adóazonosító_számLabel)
        Me.GroupBox1.Controls.Add(Me.TB_Osterm)
        Me.GroupBox1.Controls.Add(Vállakozói_igazolványszámLabel)
        Me.GroupBox1.Controls.Add(Me.B_Torol)
        Me.GroupBox1.Controls.Add(Regisztrációs_számLabel)
        Me.GroupBox1.Controls.Add(BankszámlaszámLabel)
        Me.GroupBox1.Controls.Add(Label1)
        Me.GroupBox1.Controls.Add(FELIR_azonosítóLabel)
        Me.GroupBox1.Controls.Add(Me.DateTimePicker1)
        Me.GroupBox1.Controls.Add(Utoljára_módosítvaLabel)
        Me.GroupBox1.Location = New System.Drawing.Point(0, 482)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(1008, 247)
        Me.GroupBox1.TabIndex = 1
        Me.GroupBox1.TabStop = False
        '
        'TB_Mod
        '
        Me.TB_Mod.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Utoljára módosítva", True))
        Me.TB_Mod.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Mod.Location = New System.Drawing.Point(644, 190)
        Me.TB_Mod.Name = "TB_Mod"
        Me.TB_Mod.ReadOnly = True
        Me.TB_Mod.Size = New System.Drawing.Size(142, 29)
        Me.TB_Mod.TabIndex = 19
        '
        'B_Kilep
        '
        Me.B_Kilep.BackColor = System.Drawing.Color.White
        Me.B_Kilep.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.B_Kilep.Location = New System.Drawing.Point(863, 140)
        Me.B_Kilep.Name = "B_Kilep"
        Me.B_Kilep.Size = New System.Drawing.Size(133, 60)
        Me.B_Kilep.TabIndex = 20
        Me.B_Kilep.Text = "Kilépés"
        Me.B_Kilep.UseVisualStyleBackColor = False
        '
        'B_Nyomtat
        '
        Me.B_Nyomtat.BackColor = System.Drawing.Color.White
        Me.B_Nyomtat.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.B_Nyomtat.Location = New System.Drawing.Point(863, 74)
        Me.B_Nyomtat.Name = "B_Nyomtat"
        Me.B_Nyomtat.Size = New System.Drawing.Size(133, 60)
        Me.B_Nyomtat.TabIndex = 20
        Me.B_Nyomtat.Text = "Nyomtatás"
        Me.B_Nyomtat.UseVisualStyleBackColor = False
        '
        'TB_Banksz
        '
        Me.TB_Banksz.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Bankszámlaszám", True))
        Me.TB_Banksz.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Banksz.Location = New System.Drawing.Point(177, 190)
        Me.TB_Banksz.Name = "TB_Banksz"
        Me.TB_Banksz.Size = New System.Drawing.Size(288, 29)
        Me.TB_Banksz.TabIndex = 18
        '
        'B_Torol
        '
        Me.B_Torol.BackColor = System.Drawing.Color.White
        Me.B_Torol.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.B_Torol.Location = New System.Drawing.Point(863, 8)
        Me.B_Torol.Name = "B_Torol"
        Me.B_Torol.Size = New System.Drawing.Size(133, 60)
        Me.B_Torol.TabIndex = 20
        Me.B_Torol.Text = "Termelő törlése"
        Me.B_Torol.UseVisualStyleBackColor = False
        '
        'DateTimePicker1
        '
        Me.DateTimePicker1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.5!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.DateTimePicker1.Format = System.Windows.Forms.DateTimePickerFormat.[Short]
        Me.DateTimePicker1.Location = New System.Drawing.Point(185, 273)
        Me.DateTimePicker1.Name = "DateTimePicker1"
        Me.DateTimePicker1.Size = New System.Drawing.Size(129, 25)
        Me.DateTimePicker1.TabIndex = 200
        '
        'GroupBox2
        '
        Me.GroupBox2.BackColor = System.Drawing.Color.Gray
        Me.GroupBox2.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None
        Me.GroupBox2.Controls.Add(Me.TB_Szulhely)
        Me.GroupBox2.Controls.Add(Me.TB_Ut)
        Me.GroupBox2.Controls.Add(Me.TB_Irsz)
        Me.GroupBox2.Controls.Add(Me.TB_Szulido)
        Me.GroupBox2.Controls.Add(Me.B_Mentes)
        Me.GroupBox2.Controls.Add(Me.B_Hozzaad)
        Me.GroupBox2.Controls.Add(Születési_helyLabel)
        Me.GroupBox2.Controls.Add(Me.TB_Nev)
        Me.GroupBox2.Controls.Add(Me.TB_Ado)
        Me.GroupBox2.Controls.Add(Me.TB_Lanykori)
        Me.GroupBox2.Controls.Add(Me.TB_Anyja)
        Me.GroupBox2.Controls.Add(AdószámLabel)
        Me.GroupBox2.Controls.Add(Születési_időLabel)
        Me.GroupBox2.Controls.Add(Me.TB_Hely)
        Me.GroupBox2.Controls.Add(Me.TB_Hsz)
        Me.GroupBox2.Controls.Add(Leánykori_születési_neveLabel)
        Me.GroupBox2.Controls.Add(Anyja_neveLabel)
        Me.GroupBox2.Location = New System.Drawing.Point(0, 301)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(1008, 191)
        Me.GroupBox2.TabIndex = 0
        Me.GroupBox2.TabStop = False
        '
        'TB_Szulido
        '
        Me.TB_Szulido.DataBindings.Add(New System.Windows.Forms.Binding("Text", Me.AdatokBindingSource, "Születési idő", True))
        Me.TB_Szulido.Font = New System.Drawing.Font("Microsoft Sans Serif", 14.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.TB_Szulido.Location = New System.Drawing.Point(561, 94)
        Me.TB_Szulido.Name = "TB_Szulido"
        Me.TB_Szulido.Size = New System.Drawing.Size(154, 29)
        Me.TB_Szulido.TabIndex = 6
        '
        'B_Mentes
        '
        Me.B_Mentes.BackColor = System.Drawing.Color.White
        Me.B_Mentes.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.B_Mentes.Location = New System.Drawing.Point(863, 80)
        Me.B_Mentes.Name = "B_Mentes"
        Me.B_Mentes.Size = New System.Drawing.Size(133, 60)
        Me.B_Mentes.TabIndex = 0
        Me.B_Mentes.Text = "Adatok mentése"
        Me.B_Mentes.UseVisualStyleBackColor = False
        '
        'B_Hozzaad
        '
        Me.B_Hozzaad.BackColor = System.Drawing.Color.White
        Me.B_Hozzaad.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(238, Byte))
        Me.B_Hozzaad.Location = New System.Drawing.Point(863, 14)
        Me.B_Hozzaad.Name = "B_Hozzaad"
        Me.B_Hozzaad.Size = New System.Drawing.Size(133, 60)
        Me.B_Hozzaad.TabIndex = 0
        Me.B_Hozzaad.Text = "Új termelő hozzáadása"
        Me.B_Hozzaad.UseVisualStyleBackColor = False
        '
        'BindingNavigator1
        '
        Me.BindingNavigator1.AddNewItem = Nothing
        Me.BindingNavigator1.CountItem = Nothing
        Me.BindingNavigator1.CountItemFormat = "Adatok száma:"
        Me.BindingNavigator1.DeleteItem = Nothing
        Me.BindingNavigator1.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.BindingNavigator1.ImageScalingSize = New System.Drawing.Size(20, 20)
        Me.BindingNavigator1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.ToolStripSeparator3, Me.TS_ID, Me.ToolStripSeparator2, Me.TS_Hozzad, Me.TS_Mentes, Me.TS_MentesAs, Me.TS_Torles, Me.TS_Nyomtat, Me.TS_Kilep, Me.TS_Info})
        Me.BindingNavigator1.Location = New System.Drawing.Point(0, 0)
        Me.BindingNavigator1.MoveFirstItem = Nothing
        Me.BindingNavigator1.MoveLastItem = Nothing
        Me.BindingNavigator1.MoveNextItem = Nothing
        Me.BindingNavigator1.MovePreviousItem = Nothing
        Me.BindingNavigator1.Name = "BindingNavigator1"
        Me.BindingNavigator1.PositionItem = Nothing
        Me.BindingNavigator1.Size = New System.Drawing.Size(1008, 27)
        Me.BindingNavigator1.TabIndex = 84
        Me.BindingNavigator1.Text = "BindingNavigator1"
        '
        'ToolStripSeparator3
        '
        Me.ToolStripSeparator3.Name = "ToolStripSeparator3"
        Me.ToolStripSeparator3.Size = New System.Drawing.Size(6, 27)
        '
        'TS_ID
        '
        Me.TS_ID.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TS_ID.Name = "TS_ID"
        Me.TS_ID.Size = New System.Drawing.Size(100, 27)
        '
        'ToolStripSeparator2
        '
        Me.ToolStripSeparator2.Name = "ToolStripSeparator2"
        Me.ToolStripSeparator2.Size = New System.Drawing.Size(6, 27)
        '
        'TS_Hozzad
        '
        Me.TS_Hozzad.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TS_Hozzad.Image = CType(resources.GetObject("TS_Hozzad.Image"), System.Drawing.Image)
        Me.TS_Hozzad.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TS_Hozzad.Name = "TS_Hozzad"
        Me.TS_Hozzad.Size = New System.Drawing.Size(24, 24)
        Me.TS_Hozzad.Text = "ToolStripButton1"
        Me.TS_Hozzad.ToolTipText = "Hozzáadás"
        '
        'TS_Mentes
        '
        Me.TS_Mentes.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TS_Mentes.Image = CType(resources.GetObject("TS_Mentes.Image"), System.Drawing.Image)
        Me.TS_Mentes.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TS_Mentes.Name = "TS_Mentes"
        Me.TS_Mentes.Size = New System.Drawing.Size(24, 24)
        Me.TS_Mentes.Text = "ToolStripButton1"
        Me.TS_Mentes.ToolTipText = "Mentés"
        '
        'TS_MentesAs
        '
        Me.TS_MentesAs.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TS_MentesAs.Image = CType(resources.GetObject("TS_MentesAs.Image"), System.Drawing.Image)
        Me.TS_MentesAs.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TS_MentesAs.Name = "TS_MentesAs"
        Me.TS_MentesAs.Size = New System.Drawing.Size(24, 24)
        Me.TS_MentesAs.Text = "ToolStripButton4"
        Me.TS_MentesAs.ToolTipText = "Mentés Másként"
        '
        'TS_Torles
        '
        Me.TS_Torles.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TS_Torles.Image = CType(resources.GetObject("TS_Torles.Image"), System.Drawing.Image)
        Me.TS_Torles.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TS_Torles.Name = "TS_Torles"
        Me.TS_Torles.Size = New System.Drawing.Size(24, 24)
        Me.TS_Torles.Text = "ToolStripButton5"
        Me.TS_Torles.ToolTipText = "Törlés"
        '
        'TS_Nyomtat
        '
        Me.TS_Nyomtat.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TS_Nyomtat.Image = CType(resources.GetObject("TS_Nyomtat.Image"), System.Drawing.Image)
        Me.TS_Nyomtat.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TS_Nyomtat.Name = "TS_Nyomtat"
        Me.TS_Nyomtat.Size = New System.Drawing.Size(24, 24)
        Me.TS_Nyomtat.Text = "ToolStripButton1"
        Me.TS_Nyomtat.ToolTipText = "Nyomtatás"
        '
        'TS_Kilep
        '
        Me.TS_Kilep.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TS_Kilep.Font = New System.Drawing.Font("Segoe UI", 9.0!)
        Me.TS_Kilep.Image = CType(resources.GetObject("TS_Kilep.Image"), System.Drawing.Image)
        Me.TS_Kilep.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TS_Kilep.Name = "TS_Kilep"
        Me.TS_Kilep.Size = New System.Drawing.Size(24, 24)
        Me.TS_Kilep.Text = "ToolStripButton6"
        Me.TS_Kilep.ToolTipText = "Kilépés"
        '
        'TS_Info
        '
        Me.TS_Info.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.TS_Info.Image = CType(resources.GetObject("TS_Info.Image"), System.Drawing.Image)
        Me.TS_Info.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.TS_Info.Name = "TS_Info"
        Me.TS_Info.Size = New System.Drawing.Size(24, 24)
        Me.TS_Info.Text = "ToolStripButton1"
        Me.TS_Info.ToolTipText = "Rólunk"
        '
        'PrintDocument1
        '
        '
        'PrintPreviewDialog1
        '
        Me.PrintPreviewDialog1.AutoScrollMargin = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.AutoScrollMinSize = New System.Drawing.Size(0, 0)
        Me.PrintPreviewDialog1.ClientSize = New System.Drawing.Size(400, 300)
        Me.PrintPreviewDialog1.Enabled = True
        Me.PrintPreviewDialog1.Icon = CType(resources.GetObject("PrintPreviewDialog1.Icon"), System.Drawing.Icon)
        Me.PrintPreviewDialog1.Name = "PrintPreviewDialog1"
        Me.PrintPreviewDialog1.Visible = False
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(896, 2)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.ReadOnly = True
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 191
        Me.TextBox1.Visible = False
        '
        'TextBox2
        '
        Me.TextBox2.Location = New System.Drawing.Point(790, 2)
        Me.TextBox2.Name = "TextBox2"
        Me.TextBox2.ReadOnly = True
        Me.TextBox2.Size = New System.Drawing.Size(100, 20)
        Me.TextBox2.TabIndex = 192
        Me.TextBox2.Visible = False
        '
        'Timer2
        '
        '
        'AdatokTableAdapter
        '
        Me.AdatokTableAdapter.ClearBeforeFill = True
        '
        'TableAdapterManager
        '
        Me.TableAdapterManager.AdatokTableAdapter = Me.AdatokTableAdapter
        Me.TableAdapterManager.BackupDataSetBeforeUpdate = False
        Me.TableAdapterManager.UpdateOrder = Program.AdatokDataSet1TableAdapters.TableAdapterManager.UpdateOrderOption.InsertUpdateDelete
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoScroll = True
        Me.BackColor = System.Drawing.Color.White
        Me.ClientSize = New System.Drawing.Size(1008, 729)
        Me.Controls.Add(Me.TextBox2)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.BindingNavigator1)
        Me.Controls.Add(NévLabel)
        Me.Controls.Add(IrányítószámLabel)
        Me.Controls.Add(TelefonszámLabel)
        Me.Controls.Add(Taj_számLabel)
        Me.Controls.Add(Őstermelői_igazolványszámLabel)
        Me.Controls.Add(Család_gazdálkodói_igazolványszámLabel)
        Me.Controls.Add(Me.DataGridView1)
        Me.Controls.Add(Me.GroupBox1)
        Me.Controls.Add(Me.GroupBox2)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "Form1"
        Me.Text = "Nyílvántartó program"
        CType(Me.DataGridView1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdatokBindingSource1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdatokDataSet1BindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdatokDataSet1, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.AdatokBindingSource, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.BindingNavigator1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.BindingNavigator1.ResumeLayout(False)
        Me.BindingNavigator1.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents DataGridView1 As DataGridView
    Friend WithEvents TB_Nev As TextBox
    Friend WithEvents TB_Szulhely As TextBox
    Friend WithEvents TB_Anyja As TextBox
    Friend WithEvents TB_Lanykori As TextBox
    Friend WithEvents TB_Irsz As TextBox
    Friend WithEvents TB_Hely As TextBox
    Friend WithEvents TB_Ut As TextBox
    Friend WithEvents TB_Hsz As TextBox
    Friend WithEvents TB_Tel As TextBox
    Friend WithEvents TB_Regsz As TextBox
    Friend WithEvents TB_Osterm As TextBox
    Friend WithEvents TB_Vallal As TextBox
    Friend WithEvents TB_Csaladig As TextBox
    Friend WithEvents TB_Felir As TextBox
    Friend WithEvents TB_Ado As TextBox
    Friend WithEvents TB_Adoazon As TextBox
    Friend WithEvents TB_Taj As TextBox
    Friend WithEvents AdatokDataSet1 As AdatokDataSet1
    Friend WithEvents AdatokTableAdapter As AdatokDataSet1TableAdapters.AdatokTableAdapter
    Friend WithEvents TableAdapterManager As AdatokDataSet1TableAdapters.TableAdapterManager
    Friend WithEvents AdatokDataSet1BindingSource As BindingSource
    Friend WithEvents AdatokBindingSource As BindingSource
    Friend WithEvents AdatokBindingSource1 As BindingSource
    Friend WithEvents GroupBox1 As GroupBox
    Friend WithEvents GroupBox2 As GroupBox
    Friend WithEvents BindingNavigator1 As BindingNavigator
    Friend WithEvents TS_ID As ToolStripTextBox
    Friend WithEvents ToolStripSeparator2 As ToolStripSeparator
    Friend WithEvents ToolStripSeparator3 As ToolStripSeparator
    Friend WithEvents TS_MentesAs As ToolStripButton
    Friend WithEvents TS_Torles As ToolStripButton
    Friend WithEvents TS_Kilep As ToolStripButton
    Friend WithEvents Timer1 As Timer
    Friend WithEvents TS_Hozzad As ToolStripButton
    Friend WithEvents TS_Nyomtat As ToolStripButton
    Friend WithEvents SaveFileDialog1 As SaveFileDialog
    Friend WithEvents PrintDocument1 As Printing.PrintDocument
    Friend WithEvents PrintPreviewDialog1 As PrintPreviewDialog
    Friend WithEvents B_Mentes As Button
    Friend WithEvents B_Hozzaad As Button
    Friend WithEvents B_Torol As Button
    Friend WithEvents B_Kilep As Button
    Friend WithEvents B_Nyomtat As Button
    Friend WithEvents TS_Info As ToolStripButton
    Friend WithEvents TS_Mentes As ToolStripButton
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TextBox2 As TextBox
    Friend WithEvents TB_Banksz As TextBox
    Friend WithEvents DateTimePicker1 As DateTimePicker
    Friend WithEvents TB_Szulido As TextBox
    Friend WithEvents Timer2 As Timer
    Friend WithEvents TB_Mod As TextBox
    Friend WithEvents AzonosítóDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents NévDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SzületésiHelyDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AnyjaNeveDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents LeánykoriszületésiNeveDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents IrányítószámDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HelységDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ÚtutcaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents HázszámDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents SzületésiIdőDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents FELIRAzonosítóDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents UtoljáraMódosítvaDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TelefonszámDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents RegisztrációsSzámDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AdószámDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents AdóazonosítóSzámDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents TajszámDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents ŐstermelőiIgazolványszámDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents VállakozóiIgazolványszámDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents CsaládGazdálkodóiIgazolványszámDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
    Friend WithEvents BankszámlaszámDataGridViewTextBoxColumn As DataGridViewTextBoxColumn
End Class
