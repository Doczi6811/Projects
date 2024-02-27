Imports System.Management
Imports System.IO
Imports System.Security.Cryptography
Public Class Form1
    Public serial = GetHDSerialNo("C")
    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ProgressBar1.Increment(2)
        Label1.Visible = True
        If ProgressBar1.Value = 1 Then
            Label1.Text = "Folyamat megkezdése"
        End If
        If ProgressBar1.Value = 20 Then
            While ProgressBar1.Value = 20
                Label1.Text = "Fájlok létrehozása"
                If My.Computer.FileSystem.DirectoryExists("C:\Nyilvantarto\") Then
                    Timer1.Stop()
                    MsgBox("A nyilvantarto mappa létezik. Ezért a program leáll!", MsgBoxStyle.Critical, "HIBA")
                    Close()
                Else
                    My.Computer.FileSystem.CreateDirectory("C:\Nyilvantarto\")
                End If
                System.IO.File.Create("C:\Nyilvantarto\Serial.txt").Dispose()
                Exit While
            End While
        End If
        If ProgressBar1.Value = 50 Then
            Label1.Text = "Szériaszám hozzáadása"
        End If
        If ProgressBar1.Value = 80 Then
            Label1.Text = "Szériaszám kódolása"
            While ProgressBar1.Value = 80
                Try
                    Dim encryptstream As FileStream
                    encryptstream = New FileStream("C:\Nyilvantarto\Serial.txt", FileMode.Open)
                    Dim RMCrypto As New RijndaelManaged()
                    Dim key As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
                    Dim IV As Byte() = {&H1, &H2, &H3, &H4, &H5, &H6, &H7, &H8, &H9, &H10, &H11, &H12, &H13, &H14, &H15, &H16}
                    Dim CryptStream As New CryptoStream(encryptstream, RMCrypto.CreateEncryptor(key, IV), CryptoStreamMode.Write)
                    Dim sWriter As New StreamWriter(CryptStream)
                    sWriter.WriteLine(serial)
                    sWriter.Close()
                    CryptStream.Close()
                    encryptstream.Close()
                    Exit While
                Catch ex As Exception
                    MsgBox(ex.Message, MsgBoxStyle.Critical, "Kódolási hiba")
                End Try
            End While
        End If
        If ProgressBar1.Value = 90 Then
            Label1.Text = "Véglegesítés"
        End If
        If ProgressBar1.Value = 100 Then
            Label1.Text = "Aktiválás sikeresen megtörtént!"
            Timer1.Stop()
            Label1.Text = Nothing
        End If
    End Sub

    Public Function GetHDSerialNo(ByVal strDrive As String) As String

        If strDrive = "" OrElse strDrive Is Nothing Then
            strDrive = "C"
        End If
        Dim moHD As New ManagementObject("Win32_LogicalDisk.DeviceID=""" + strDrive + ":""")
        moHD.[Get]()
        Return moHD("VolumeSerialNumber").ToString()

    End Function

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Start()
    End Sub

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Label1.Text = Nothing
    End Sub
End Class
