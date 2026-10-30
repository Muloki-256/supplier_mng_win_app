Imports System.Drawing.Drawing2D

Public Module UiBranding
    Public Sub ApplyModuleHeader(targetForm As Form, moduleName As String)
        If targetForm.Controls.ContainsKey("pnlBrandHeader") Then
            Return
        End If

        Dim header As New Panel With {
            .Name = "pnlBrandHeader",
            .Height = 55,
            .Dock = DockStyle.Top,
            .BackColor = Color.FromArgb(40, 167, 69)
        }

        Dim lblModule As New Label With {
            .AutoSize = True,
            .Location = New Point(20, 18),
            .ForeColor = Color.White,
            .Font = New Font("Segoe UI", 12.0F, FontStyle.Bold),
            .Text = moduleName
        }

        header.Controls.Add(lblModule)
        targetForm.Controls.Add(header)
        header.BringToFront()

        For Each ctrl As Control In targetForm.Controls
            If ctrl Is header Then
                Continue For
            End If

            If ctrl.Dock = DockStyle.None Then
                ctrl.Top += header.Height
            End If
        Next
    End Sub

    Public Function GetLogoImage() As Bitmap
        ' Try to load from file first
        Dim logoPath As String = Application.StartupPath & "\logo_small.png"
        If System.IO.File.Exists(logoPath) Then
            Return New Bitmap(logoPath)
        End If

        ' Fallback - create simple logo
        Dim bmp As New Bitmap(44, 44)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.SmoothingMode = SmoothingMode.AntiAlias
            g.Clear(Color.Transparent)
            Using bg As New SolidBrush(Color.FromArgb(40, 167, 69))
                g.FillEllipse(bg, 0, 0, 44, 44)
            End Using
            Using font As New Font("Segoe UI", 8, FontStyle.Bold)
                g.DrawString("MA", font, Brushes.White, New PointF(12, 15))
            End Using
        End Using
        Return bmp
    End Function
End Module