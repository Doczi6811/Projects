Imports System.Management
Public Class SerialKiolvasas
    Public Shared Function GetHDSerialNo(ByVal strDrive As String) As String

        If strDrive = "" OrElse strDrive Is Nothing Then
            strDrive = "C"
        End If
        Dim moHD As New ManagementObject("Win32_LogicalDisk.DeviceID=""" + strDrive + ":""")

        moHD.[Get]()
        Return moHD("VolumeSerialNumber").ToString()

    End Function
End Class
