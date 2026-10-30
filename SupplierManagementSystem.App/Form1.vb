Imports MySql.Data.MySqlClient
Imports System.IO

Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        LoadLogoDirectly()
    End Sub

    Private Sub LoadLogoDirectly()
        Try

            Dim customPath As String = "C:\SupplierManagementSystem\logo.png"


            ' Check custom path
            If File.Exists(customPath) Then
                picLogo.Image = Image.FromFile(customPath)
                picLogo.SizeMode = PictureBoxSizeMode.StretchImage
                Return
            End If


            CreateTextLogo()

        Catch ex As Exception
            ' If anything fails, create text logo
            CreateTextLogo()
        End Try
    End Sub

    Private Sub CreateTextLogo()
        Dim bmp As New Bitmap(200, 160)
        Using g As Graphics = Graphics.FromImage(bmp)
            g.Clear(Color.FromArgb(40, 167, 69))

            ' Draw company initials
            Using font As New Font("Segoe UI", 24, FontStyle.Bold)
                Dim textSize As SizeF = g.MeasureString("MA", font)
                Dim x As Single = (200 - textSize.Width) / 2
                Dim y As Single = (160 - textSize.Height) / 2 - 10
                g.DrawString("MA", font, Brushes.White, x, y)
            End Using

            Using font As New Font("Segoe UI", 10, FontStyle.Bold)
                g.DrawString("SUPPLIES", font, Brushes.White, New PointF(55, 95))
            End Using
        End Using
        picLogo.Image = bmp
        picLogo.SizeMode = PictureBoxSizeMode.StretchImage
    End Sub

    Private Sub btnLogin_Click(sender As Object, e As EventArgs) Handles btnLogin.Click
        Dim username As String = txtUsername.Text.Trim()
        Dim password As String = txtPassword.Text.Trim()

        If username = "" OrElse password = "" Then
            MessageBox.Show("Please enter username and password.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning)
            Return
        End If

        Try
            Using conn As MySqlConnection = DatabaseHelper.GetConnection()
                Using cmd As New MySqlCommand("SELECT full_name, role FROM users WHERE username = @username AND password_hash = @password AND is_active = 1", conn)
                    cmd.Parameters.AddWithValue("@username", username)
                    cmd.Parameters.AddWithValue("@password", password)

                    Using reader As MySqlDataReader = cmd.ExecuteReader()
                        If reader.Read() Then
                            Dim fullName As String = reader("full_name").ToString()
                            Dim role As String = reader("role").ToString()

                            Dim dashboardForm As New DashboardForm(fullName, role)
                            AddHandler dashboardForm.FormClosed, Sub()
                                                                     txtPassword.Clear()
                                                                     Me.Show()
                                                                 End Sub
                            dashboardForm.Show()
                            Me.Hide()
                        Else
                            MessageBox.Show("Invalid username or password.", "Login Failed", MessageBoxButtons.OK, MessageBoxIcon.Error)
                        End If
                    End Using
                End Using
            End Using
        Catch ex As Exception
            MessageBox.Show($"Database connection failed: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
        End Try
    End Sub

    Private Sub btnExit_Click(sender As Object, e As EventArgs) Handles btnExit.Click
        Application.Exit()
    End Sub

    Private Sub picLogo_Click(sender As Object, e As EventArgs) Handles picLogo.Click

    End Sub

    Private Sub txtUsername_TextChanged(sender As Object, e As EventArgs) Handles txtUsername.TextChanged

    End Sub
End Class