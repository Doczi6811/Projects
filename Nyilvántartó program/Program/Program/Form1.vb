Imports System.ComponentModel
Imports Program.SerialKiolvasas
Imports System.Drawing.Printing
Imports System.Management
Imports System.IO
Imports System.Security.Cryptography
Imports System.Globalization

Public Class Form1
    Public kilep As Boolean
    Public serial = GetHDSerialNo("C") + vbCrLf

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.AdatokTableAdapter.Fill(Me.AdatokDataSet1.Adatok)
        DataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect
        If AdatokBindingSource.Count >= 2 Then
            Me.AdatokTableAdapter.Fill(Me.AdatokDataSet1.Adatok)
            DataGridView1.DataSource = AdatokBindingSource
        End If
        DataGridView1.AllowUserToAddRows = False
        DataGridView1.Refresh()
        DataGridView1.Select()
        AdatokBindingSource.MoveFirst()
        TextBox1.Text = serial
        Dim key As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
        Dim IV As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}

        Try
            Dim DecryptStream As New FileStream("C:\Nyilvantarto\Serial.txt", FileMode.OpenOrCreate)
            Dim RMCrypto As New RijndaelManaged()
            Dim CryptStream As New CryptoStream(DecryptStream, RMCrypto.CreateDecryptor(key, IV), CryptoStreamMode.Read)
            Dim sRead As New StreamReader(CryptStream)
            TextBox2.Text = String.Format(sRead.ReadToEnd)
            Dim num = String.Format(TextBox2.Text)

            If TextBox1.Text = num Then
                Me.Show()
            ElseIf TextBox1.Text <> num Then
                kilep = True
                Me.Close()
            End If
            sRead.Close()
            DecryptStream.Close()
        Catch ex As Exception
            MsgBox(ex.Message, MsgBoxStyle.Critical, "Kódolási hiba")
            kilep = True
            Close()
        End Try
        DataGridView1.Sort(DataGridView1.Columns("NévDataGridViewTextBoxColumn"), System.ComponentModel.ListSortDirection.Ascending)
        DataGridView1.Columns("NévDataGridViewTextBoxColumn").SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns("AnyjaNeveDataGridViewTextBoxColumn").SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns("IrányítószámDataGridViewTextBoxColumn").SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns("HelységDataGridViewTextBoxColumn").SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns("ÚtutcaDataGridViewTextBoxColumn").SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns("HázszámDataGridViewTextBoxColumn").SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns("SzületésiIdőDataGridViewTextBoxColumn").SortMode = DataGridViewColumnSortMode.NotSortable
        DataGridView1.Columns("UtoljáraMódosítvaDataGridViewTextBoxColumn").SortMode = DataGridViewColumnSortMode.NotSortable
        'Timer2.Start()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs)
        Me.AdatokBindingSource.MovePrevious()
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs)
        Me.AdatokBindingSource.MoveNext()
    End Sub

    Private Sub TB_Ado_TextChanged(sender As Object, e As EventArgs) Handles TB_Ado.TextChanged
        TB_Ado.MaxLength = 13
    End Sub

    Private Sub TB_Banksz_TextChanged(sender As Object, e As EventArgs) Handles TB_Banksz.TextChanged
        TB_Banksz.MaxLength = 26
    End Sub

    Private Sub TB_Taj_TextChanged(sender As Object, e As EventArgs) Handles TB_Taj.TextChanged
        Dim V = "-"
        TB_Taj.MaxLength = 11
        If TB_Taj.TextLength = 3 Then
            TB_Taj.Text = TB_Taj.Text & V
            TB_Taj.SelectionStart = TB_Taj.TextLength + 1
        End If
        If TB_Taj.TextLength = 7 Then
            TB_Taj.Text = TB_Taj.Text & V
            TB_Taj.SelectionStart = TB_Taj.TextLength + 1
        End If
    End Sub

    Private Sub TB_Adoazon_TextChanged(sender As Object, e As EventArgs) Handles TB_Adoazon.TextChanged
        TB_Adoazon.MaxLength = 10
    End Sub

    Private Sub TB_Szulhely_TextChanged(sender As Object, e As EventArgs) Handles TB_Szulhely.TextChanged
        TB_Szulhely.MaxLength = 23
    End Sub

    Private Sub TB_Irsz_TextChanged(sender As Object, e As EventArgs) Handles TB_Irsz.TextChanged
        TB_Irsz.MaxLength = 4
    End Sub

    Private Sub TS_Legelore_Click(sender As Object, e As EventArgs)
        Me.AdatokBindingSource.MoveFirst()
    End Sub

    Private Sub ToolStripButton1_Click(sender As Object, e As EventArgs)
        Me.AdatokBindingSource.MoveLast()
    End Sub

    Private Sub ToolStripButton2_Click(sender As Object, e As EventArgs)
        Me.AdatokBindingSource.MoveNext()
    End Sub

    Private Sub ToolStripButton3_Click(sender As Object, e As EventArgs)
        Me.AdatokBindingSource.MoveLast()
    End Sub

    Friend Sub Mentes() 'Adatok lementése
        If TB_Ado.Text = Nothing Or TB_Adoazon.Text = Nothing Or TB_Anyja.Text = Nothing Or TB_Banksz.Text = Nothing Or TB_Hely.Text = Nothing Or TB_Hsz.Text = Nothing Or TB_Irsz.Text = Nothing Or TB_Nev.Text = Nothing Or TB_Osterm.Text = Nothing Or TB_Regsz.Text = Nothing Or TB_Szulhely.Text = Nothing Or TB_Taj.Text = Nothing Or TB_Tel.Text = Nothing Or TB_Ut.Text = Nothing Then
            MsgBox("Valamelyik mező nincs kitöltve!", MsgBoxStyle.Critical, "HIBA")
        Else
            'Dim datum As DateTime = DateTime.ParseExact(Date.Now, "yyyy/MM/dd", CultureInfo.InvariantCulture)
            TB_Mod.Text = Date.Today
            Me.AdatokBindingSource.EndEdit()
            Me.AdatokTableAdapter.Update(Me.AdatokDataSet1)
            Me.AdatokTableAdapter.Fill(AdatokDataSet1.Adatok)
            DataGridView1.Sort(DataGridView1.Columns("NévDataGridViewTextBoxColumn"), System.ComponentModel.ListSortDirection.Ascending)
            ' TB_Ado.Text <> Nothing And TB_Adoazon.Text <> Nothing And TB_Anyja.Text <> Nothing And TB_Banksz.Text <> Nothing And TB_Csaladig.Text <> Nothing And TB_Felir.Text <> Nothing And TB_Hely.Text <> Nothing And TB_Hsz.Text <> Nothing And TB_Irsz.Text <> Nothing And TB_Lanykori.Text <> Nothing And TB_Nev.Text <> Nothing And TB_Osterm.Text <> Nothing And TB_Regsz.Text <> Nothing And TB_Szulhely.Text <> Nothing And TB_Taj.Text <> Nothing And TB_Tel.Text <> Nothing And TB_Ut.Text <> Nothing And TB_Vallal.Text = Nothing
            B_Hozzaad.Enabled = True
            B_Nyomtat.Enabled = True
            TS_Hozzad.Enabled = True
            TS_Nyomtat.Enabled = True
            DataGridView1.Select()
            MsgBox("Adatok elmentése sikeres!", MsgBoxStyle.Information, "Információ")
        End If
    End Sub

    Private Sub TS_MentesAs_Click(sender As Object, e As EventArgs) Handles TS_MentesAs.Click
        Dim mentesneve = System.DateTime.Now.ToString("yyyyMMdd")
        SaveFileDialog1 = New SaveFileDialog()
        SaveFileDialog1.Filter = "Adatbázis | *.accdb"
        SaveFileDialog1.Title = "Adatbázis elmentése"
        SaveFileDialog1.FileName = "Adatok" & mentesneve
        SaveFileDialog1.DefaultExt = "accdb"
        Dim saveing = SaveFileDialog1.ShowDialog()
        If saveing = DialogResult.OK Then
            Mentes()
            Dim path As String = IO.Path.GetDirectoryName(SaveFileDialog1.FileName)
            FileSystem.FileCopy("C:\Nyilvantarto\Adatok.accdb", path & "\Adatok" & mentesneve & ".accdb")
        End If
    End Sub

    Private Sub TS_Torles_Click(sender As Object, e As EventArgs) Handles TS_Torles.Click
        Dim Kerd As String
        Kerd = MsgBox("Biztos kiakarja törölni?", MsgBoxStyle.YesNo, "Információ")
        If Kerd = MsgBoxResult.Yes Then
            Me.AdatokBindingSource.RemoveCurrent()
            Me.AdatokBindingSource.EndEdit()
            Me.AdatokTableAdapter.Update(AdatokDataSet1)
            DataGridView1.Select()
            B_Hozzaad.Enabled = True
            B_Nyomtat.Enabled = True
            TS_Hozzad.Enabled = True
            TS_Nyomtat.Enabled = True
            DataGridView1.DataSource = AdatokBindingSource
            AdatokTableAdapter.Fill(AdatokDataSet1.Adatok)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub ToolStripButton6_Click(sender As Object, e As EventArgs) Handles TS_Kilep.Click
        If TB_Ado.Text = Nothing Or TB_Adoazon.Text = Nothing Or TB_Anyja.Text = Nothing Or TB_Banksz.Text = Nothing Or TB_Hely.Text = Nothing Or TB_Hsz.Text = Nothing Or TB_Irsz.Text = Nothing Or TB_Nev.Text = Nothing Or TB_Osterm.Text = Nothing Or TB_Regsz.Text = Nothing Or TB_Szulhely.Text = Nothing Or TB_Taj.Text = Nothing Or TB_Tel.Text = Nothing Or TB_Ut.Text = Nothing Then
            MsgBox("Valamelyik mező nincs kitöltve!", MsgBoxStyle.Critical, "HIBA")
        Else
            Me.AdatokBindingSource.EndEdit()
            Close()
        End If
    End Sub

    Private Sub TS_Hozzad_Click(sender As Object, e As EventArgs) Handles TS_Hozzad.Click
        If TB_Ado.Text = Nothing Or TB_Adoazon.Text = Nothing Or TB_Anyja.Text = Nothing Or TB_Banksz.Text = Nothing Or TB_Hely.Text = Nothing Or TB_Hsz.Text = Nothing Or TB_Irsz.Text = Nothing Or TB_Nev.Text = Nothing Or TB_Osterm.Text = Nothing Or TB_Regsz.Text = Nothing Or TB_Szulhely.Text = Nothing Or TB_Taj.Text = Nothing Or TB_Tel.Text = Nothing Or TB_Ut.Text = Nothing Then
            MsgBox("Valamelyik mező nincs kitöltve!", MsgBoxStyle.Critical, "HIBA")
        Else
            ' TB_Ado.Text <> Nothing And TB_Adoazon.Text <> Nothing And TB_Anyja.Text <> Nothing And TB_Banksz.Text <> Nothing And TB_Csaladig.Text <> Nothing And TB_Felir.Text <> Nothing And TB_Hely.Text <> Nothing And TB_Hsz.Text <> Nothing And TB_Irsz.Text <> Nothing And TB_Lanykori.Text <> Nothing And TB_Nev.Text <> Nothing And TB_Osterm.Text <> Nothing And TB_Regsz.Text <> Nothing And TB_Szulhely.Text <> Nothing And TB_Taj.Text <> Nothing And TB_Tel.Text <> Nothing And TB_Ut.Text <> Nothing And TB_Vallal.Text = Nothing
            Me.AdatokBindingSource.MoveLast()
            B_Hozzaad.Enabled = False
            B_Nyomtat.Enabled = False
            TS_Hozzad.Enabled = False
            TS_Nyomtat.Enabled = False
            Me.AdatokBindingSource.AddNew()
            TB_Mod.Text = Date.Today
            Me.AdatokBindingSource.MoveFirst()
            Me.AdatokBindingSource.EndEdit()
            DataGridView1.DataSource = AdatokBindingSource
        End If
    End Sub

    Private Sub TB_Nev_TextChanged(sender As Object, e As EventArgs) Handles TB_Nev.TextChanged
        TB_Nev.MaxLength = 52
    End Sub

    Private Sub TB_Anyja_TextChanged(sender As Object, e As EventArgs) Handles TB_Anyja.TextChanged
        TB_Anyja.MaxLength = 52
    End Sub

    Private Sub TB_Lanykori_TextChanged(sender As Object, e As EventArgs) Handles TB_Lanykori.TextChanged
        TB_Lanykori.MaxLength = 52
    End Sub

    Private Sub TS_ID_TextChanged(sender As Object, e As EventArgs) Handles TS_ID.TextChanged
        Me.AdatokBindingSource.Filter = "Név Like '%" & TS_ID.Text & "%'"
        If AdatokBindingSource.Count <> 0 Then
            DataGridView1.DataSource = AdatokBindingSource
        End If
        If TS_ID.Text = "" Then
            'DataGridView1.AllowUserToAddRows = True
            AdatokBindingSource.RemoveFilter()
            AdatokBindingSource.AllowNew = True
        End If
    End Sub

    Private Sub PrintDocument1_PrintPage(sender As Object, e As Printing.PrintPageEventArgs) Handles PrintDocument1.PrintPage
        Dim font As New Font("Time New Roman", 16, FontStyle.Regular)
        Dim font1 As New Font("Arial", 16, FontStyle.Bold)
        Dim font2 As New Font("Arial", 11, FontStyle.Bold)
        'e.Graphics.DrawString("ADATLAP", font, Brushes.Black, 350, 20)
        'e.Graphics.DrawString("AGRO-TEREM Szövetkezet", font, Brushes.Black, 260, 40)
        e.Graphics.DrawString("ADATLAP", font1, Brushes.Black, 350, 60)
        e.Graphics.DrawString("Név: ", font, Brushes.Black, 50, 100)
        e.Graphics.DrawString(TB_Nev.Text, font1, Brushes.Black, 100, 103)
        e.Graphics.DrawString("Születési hely, idő: ", font, Brushes.Black, 50, 150)
        e.Graphics.DrawString(TB_Szulhely.Text & ", " & TB_Szulido.Text, font1, Brushes.Black, 240, 152)
        e.Graphics.DrawString("Anyja neve: ", font, Brushes.Black, 50, 200)
        e.Graphics.DrawString(TB_Anyja.Text, font1, Brushes.Black, 170, 202)
        e.Graphics.DrawString("Születési, leánykori neve:", font, Brushes.Black, 50, 249)
        e.Graphics.DrawString(TB_Lanykori.Text, font1, Brushes.Black, 310, 251)
        e.Graphics.DrawString("Lakcím:", font, Brushes.Black, 50, 300)
        e.Graphics.DrawString(TB_Irsz.Text & ", " & TB_Hely.Text, font1, Brushes.Black, 135, 302)
        e.Graphics.DrawString("Út, utca: ", font, Brushes.Black, 50, 350)
        e.Graphics.DrawString(TB_Ut.Text, font1, Brushes.Black, 140, 352)
        e.Graphics.DrawString(", Házszám: ", font, Brushes.Black, 477, 351)
        e.Graphics.DrawString(TB_Hsz.Text, font1, Brushes.Black, 593, 353)
        e.Graphics.DrawString("Telefonszám: ", font, Brushes.Black, 50, 400)
        e.Graphics.DrawString(TB_Tel.Text, font1, Brushes.Black, 190, 402)
        e.Graphics.DrawString("Regisztrációs szám: ", font, Brushes.Black, 50, 450)
        e.Graphics.DrawString(TB_Regsz.Text, font1, Brushes.Black, 255, 452)
        e.Graphics.DrawString(", Adószám: ", font, Brushes.Black, 380, 451)
        e.Graphics.DrawString(TB_Ado.Text, font1, Brushes.Black, 498, 452)
        e.Graphics.DrawString("Adóazonosító szám: ", font, Brushes.Black, 50, 500)
        e.Graphics.DrawString(TB_Adoazon.Text, font1, Brushes.Black, 260, 502)
        e.Graphics.DrawString(", Tajszám: ", font, Brushes.Black, 370, 501)
        e.Graphics.DrawString(TB_Taj.Text, font1, Brushes.Black, 478, 502)
        e.Graphics.DrawString("Őstermelői igazolvány száma: ", font, Brushes.Black, 50, 550)
        e.Graphics.DrawString(TB_Osterm.Text, font1, Brushes.Black, 355, 552)
        e.Graphics.DrawString("Vállakozói igazolványszáma: ", font, Brushes.Black, 50, 600)
        e.Graphics.DrawString(TB_Vallal.Text, font1, Brushes.Black, 345, 602)
        e.Graphics.DrawString("Családi gazdálkodói hazározat szám: ", font, Brushes.Black, 50, 650)
        e.Graphics.DrawString(TB_Csaladig.Text, font1, Brushes.Black, 427, 652)
        e.Graphics.DrawString("Bankszámlaszám: ", font, Brushes.Black, 50, 700)
        e.Graphics.DrawString(TB_Banksz.Text, font1, Brushes.Black, 240, 702)
        e.Graphics.DrawString("FELIR (NÉBIH) azonosító: ", font, Brushes.Black, 50, 750)
        e.Graphics.DrawString(TB_Felir.Text, font1, Brushes.Black, 315, 752)
        'e.Graphics.DrawString("Termelő jelen adatlap aláírásával hozzájárul, hogy a fent szereplő adatait az Agro Terem Szövetkezet a" & vbCrLf & "GDRP rendeletnek megfelelő adatkezelési szabályzata, előírási szerint kezelje. Termelő az Agro Terem" & vbCrLf & "Szövetkezet honlapján közzétett Adatkezelési Szabályzatot elolvasta, megértette és az abban foglaltakat" & vbCrLf & "elfogadja.", font2, Brushes.Black, 50, 800)
        e.Graphics.DrawString("Büntetőjogi felelőségem tudatában kijelentem, hogy az itt közölt adatok a valóságnak " & vbCrLf & " megfelelnek, a leadott termény saját termelésből származik.", font2, Brushes.Black, 50, 800)
        e.Graphics.DrawString("Mátészalka, Dátum:__________év__________hó__________nap", font1, Brushes.Black, 50, 920)
        e.Graphics.DrawString("_____________________", font1, Brushes.Black, 450, 1000)
        e.Graphics.DrawString("a termelő aláírása", font, Brushes.Black, 500, 1030)
    End Sub

    Private Sub TS_Nyomtat_Click_1(sender As Object, e As EventArgs) Handles TS_Nyomtat.Click
        If TB_Ado.Text = Nothing Or TB_Adoazon.Text = Nothing Or TB_Anyja.Text = Nothing Or TB_Banksz.Text = Nothing Or TB_Hely.Text = Nothing Or TB_Hsz.Text = Nothing Or TB_Irsz.Text = Nothing Or TB_Nev.Text = Nothing Or TB_Osterm.Text = Nothing Or TB_Regsz.Text = Nothing Or TB_Szulhely.Text = Nothing Or TB_Taj.Text = Nothing Or TB_Tel.Text = Nothing Or TB_Ut.Text = Nothing Then
            MsgBox("Valamelyik mező nincs kitöltve!", MsgBoxStyle.Critical, "HIBA")
        Else
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
        End If
    End Sub

    Private Sub B_Hozzaad_Click(sender As Object, e As EventArgs) Handles B_Hozzaad.Click
        If TB_Ado.Text = Nothing Or TB_Adoazon.Text = Nothing Or TB_Anyja.Text = Nothing Or TB_Banksz.Text = Nothing Or TB_Hely.Text = Nothing Or TB_Hsz.Text = Nothing Or TB_Irsz.Text = Nothing Or TB_Nev.Text = Nothing Or TB_Osterm.Text = Nothing Or TB_Regsz.Text = Nothing Or TB_Szulhely.Text = Nothing Or TB_Taj.Text = Nothing Or TB_Tel.Text = Nothing Or TB_Ut.Text = Nothing Then
            MsgBox("Valamelyik mező nincs kitöltve!", MsgBoxStyle.Critical, "HIBA")
        Else
            ' TB_Ado.Text <> Nothing And TB_Adoazon.Text <> Nothing And TB_Anyja.Text <> Nothing And TB_Banksz.Text <> Nothing And TB_Csaladig.Text <> Nothing And TB_Felir.Text <> Nothing And TB_Hely.Text <> Nothing And TB_Hsz.Text <> Nothing And TB_Irsz.Text <> Nothing And TB_Lanykori.Text <> Nothing And TB_Nev.Text <> Nothing And TB_Osterm.Text <> Nothing And TB_Regsz.Text <> Nothing And TB_Szulhely.Text <> Nothing And TB_Taj.Text <> Nothing And TB_Tel.Text <> Nothing And TB_Ut.Text <> Nothing And TB_Vallal.Text = Nothing
            Me.AdatokBindingSource.MoveLast()
            B_Hozzaad.Enabled = False
            B_Nyomtat.Enabled = False
            TS_Hozzad.Enabled = False
            TS_Nyomtat.Enabled = False
            Me.AdatokBindingSource.AddNew()
            TB_Mod.Text = Date.Today
            Me.AdatokBindingSource.MoveFirst()
            Me.AdatokBindingSource.EndEdit()
            DataGridView1.DataSource = AdatokBindingSource
        End If
    End Sub

    Private Sub B_Mentes_Click(sender As Object, e As EventArgs) Handles B_Mentes.Click
        Mentes()
    End Sub

    Private Sub B_Torol_Click(sender As Object, e As EventArgs) Handles B_Torol.Click
        Dim Kerd As String
        Kerd = MsgBox("Biztos kiakarja törölni?", MsgBoxStyle.YesNo, "Információ")
        If Kerd = MsgBoxResult.Yes Then
            Me.AdatokBindingSource.RemoveCurrent()
            Me.AdatokBindingSource.EndEdit()
            Me.AdatokTableAdapter.Update(AdatokDataSet1)
            DataGridView1.Select()
            B_Hozzaad.Enabled = True
            B_Nyomtat.Enabled = True
            TS_Hozzad.Enabled = True
            TS_Nyomtat.Enabled = True
            DataGridView1.DataSource = AdatokBindingSource
            AdatokTableAdapter.Fill(AdatokDataSet1.Adatok)
        Else
            Exit Sub
        End If
    End Sub

    Private Sub B_Nyomtat_Click(sender As Object, e As EventArgs) Handles B_Nyomtat.Click
        If TB_Ado.Text = Nothing Or TB_Adoazon.Text = Nothing Or TB_Anyja.Text = Nothing Or TB_Banksz.Text = Nothing Or TB_Hely.Text = Nothing Or TB_Hsz.Text = Nothing Or TB_Irsz.Text = Nothing Or TB_Nev.Text = Nothing Or TB_Osterm.Text = Nothing Or TB_Regsz.Text = Nothing Or TB_Szulhely.Text = Nothing Or TB_Taj.Text = Nothing Or TB_Tel.Text = Nothing Or TB_Ut.Text = Nothing Then
            MsgBox("Valamelyik mező nincs kitöltve!", MsgBoxStyle.Critical, "HIBA")
        Else
            PrintPreviewDialog1.Document = PrintDocument1
            PrintPreviewDialog1.ShowDialog()
        End If
    End Sub

    Private Sub B_Kilep_Click(sender As Object, e As EventArgs) Handles B_Kilep.Click
        If TB_Ado.Text = Nothing Or TB_Adoazon.Text = Nothing Or TB_Anyja.Text = Nothing Or TB_Banksz.Text = Nothing Or TB_Hely.Text = Nothing Or TB_Hsz.Text = Nothing Or TB_Irsz.Text = Nothing Or TB_Nev.Text = Nothing Or TB_Osterm.Text = Nothing Or TB_Regsz.Text = Nothing Or TB_Szulhely.Text = Nothing Or TB_Taj.Text = Nothing Or TB_Tel.Text = Nothing Or TB_Ut.Text = Nothing Then
            MsgBox("Valamelyik mező nincs kitöltve!", MsgBoxStyle.Critical, "HIBA")
        Else
            Me.AdatokBindingSource.EndEdit()
            Close()
        End If
    End Sub

    Private Sub TS_Info_Click(sender As Object, e As EventArgs) Handles TS_Info.Click
        MsgBox("Jogos felhasználó: ÁTI DEPO Zrt." & vbCrLf & "V2.1 - 2021.10.29", MsgBoxStyle.OkOnly, "Információ")
    End Sub

    Private Sub TS_Mentes_Click_1(sender As Object, e As EventArgs) Handles TS_Mentes.Click
        Mentes()
    End Sub
    Public Sub Form1_Closing(sender As Object, e As CancelEventArgs) Handles Me.Closing
        If kilep Then
            If kilep = True Then
                MsgBox("Te nem jelentkezhetsz be!", MsgBoxStyle.Critical, "HIBA")
                e.Cancel = False
                Exit Sub
            End If
        End If
        Dim kerd = MsgBox("Biztos kiakar lépni? Kilépéskor az adatok automatikusan lementődnek!", MsgBoxStyle.YesNo, "Információ")
        If kerd = MsgBoxResult.Yes Then
            Me.AdatokBindingSource.EndEdit()
            Me.AdatokTableAdapter.Update(Me.AdatokDataSet1)
        ElseIf kerd = MsgBoxResult.No Then
            e.Cancel = True
        End If
    End Sub

    Public Function GetHDSerialNo(ByVal strDrive As String) As String 'Get HD Serial Number

        'Ensure Valid Drive Letter Entered, Else, Default To C
        If strDrive = "" OrElse strDrive Is Nothing Then
            strDrive = "C"
        End If
        Dim moHD As New ManagementObject("Win32_LogicalDisk.DeviceID=""" + strDrive + ":""")
        'Get Info
        moHD.[Get]()
        Return moHD("VolumeSerialNumber").ToString()

    End Function

    Private Sub TB_Tel_TextChanged(sender As Object, e As EventArgs) Handles TB_Tel.TextChanged
        TB_Tel.MaxLength = 15
    End Sub

    Private Sub TB_Vallal_TextChanged(sender As Object, e As EventArgs) Handles TB_Vallal.TextChanged
        TB_Vallal.MaxLength = 10
    End Sub

    Private Sub TB_Osterm_TextChanged(sender As Object, e As EventArgs) Handles TB_Osterm.TextChanged
        TB_Osterm.MaxLength = 15
    End Sub

    Private Sub TB_Csaladig_TextChanged(sender As Object, e As EventArgs) Handles TB_Csaladig.TextChanged
        TB_Csaladig.MaxLength = 12
    End Sub

    Private Sub DataGridView1_RowEnter(sender As Object, e As DataGridViewCellEventArgs) Handles DataGridView1.RowEnter
    End Sub

    Private Sub TB_Felir_TextChanged(sender As Object, e As EventArgs) Handles TB_Felir.TextChanged
        TB_Felir.MaxLength = 13
    End Sub

    Private Sub Form1_KeyPress(sender As Object, e As KeyPressEventArgs) Handles Me.KeyPress
        If Keys.Up Then
            If DataGridView1.FirstDisplayedScrollingRowIndex > 1 Then
                DataGridView1.FirstDisplayedScrollingRowIndex = _DataGridView1.FirstDisplayedScrollingRowIndex - 1
                DataGridView1.DataSource = AdatokBindingSource
                DataGridView1.Select()
            End If
        End If
        If Keys.Down Then
            If DataGridView1.FirstDisplayedScrollingRowIndex < (AdatokBindingSource.Count - 1) And DataGridView1.FirstDisplayedScrollingRowIndex = AdatokBindingSource.Count - 1 Then
                DataGridView1.FirstDisplayedScrollingRowIndex = DataGridView1.FirstDisplayedScrollingRowIndex + 1
                DataGridView1.DataSource = AdatokBindingSource
                DataGridView1.Select()
            End If
        End If
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        DataGridView1.Sort(DataGridView1.Columns("NévDataGridViewTextBoxColumn"), System.ComponentModel.ListSortDirection.Ascending)
    End Sub
End Class

