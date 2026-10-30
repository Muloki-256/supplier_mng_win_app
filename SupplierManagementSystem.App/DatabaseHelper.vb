Imports MySql.Data.MySqlClient

Public Module DatabaseHelper

    Private Const DatabaseName As String = "supplier_management_system"

    Private ReadOnly ServerConnectionString As String =
        "Server=localhost;Port=3306;Uid=root;Pwd=;"

    Private ReadOnly DatabaseConnectionString As String =
        $"Server=localhost;Port=3306;Database={DatabaseName};Uid=root;Pwd=;"

    ' Initialize database connection
    Public Sub InitializeDatabase()
        Try
            ' Test if MySQL server is running
            Using conn As New MySqlConnection(ServerConnectionString)
                conn.Open()
                Console.WriteLine("MySQL server is running!")
            End Using

            ' Now try to connect to your database
            Using conn As New MySqlConnection(DatabaseConnectionString)
                conn.Open()
                Console.WriteLine("Connected to database: " & DatabaseName)
            End Using
        Catch ex As Exception
            MessageBox.Show(
                "Cannot connect to MySQL Server!" & vbCrLf & vbCrLf &
                "Error: " & ex.Message & vbCrLf & vbCrLf &
                "Please ensure:" & vbCrLf &
                "1. XAMPP Control Panel is open" & vbCrLf &
                "2. MySQL is STARTED (green color) in XAMPP" & vbCrLf &
                "3. Database '" & DatabaseName & "' exists" & vbCrLf &
                "4. Tables are created in the database",
                "Connection Error", MessageBoxButtons.OK, MessageBoxIcon.Error)
            Throw
        End Try
    End Sub

    ' Get database connection
    Public Function GetConnection() As MySqlConnection
        Dim conn As New MySqlConnection(DatabaseConnectionString)
        conn.Open()
        Return conn
    End Function

    ' Execute non-query (for INSERT, UPDATE, DELETE)
    Public Function ExecuteNonQuery(sql As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Integer
        Using conn As MySqlConnection = GetConnection()
            Using cmd As New MySqlCommand(sql, conn)
                If parameters IsNot Nothing Then
                    For Each param In parameters
                        cmd.Parameters.AddWithValue(param.Key, param.Value)
                    Next
                End If
                Return cmd.ExecuteNonQuery()
            End Using
        End Using
    End Function

    ' Execute scalar query (for single value like COUNT, SUM)
    Public Function ExecuteScalar(sql As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As Object
        Using conn As MySqlConnection = GetConnection()
            Using cmd As New MySqlCommand(sql, conn)
                If parameters IsNot Nothing Then
                    For Each param In parameters
                        cmd.Parameters.AddWithValue(param.Key, param.Value)
                    Next
                End If
                Return cmd.ExecuteScalar()
            End Using
        End Using
    End Function

    ' Execute query and return DataTable
    Public Function ExecuteQuery(sql As String, Optional parameters As Dictionary(Of String, Object) = Nothing) As DataTable
        Using conn As MySqlConnection = GetConnection()
            Using adapter As New MySqlDataAdapter(sql, conn)
                If parameters IsNot Nothing Then
                    For Each param In parameters
                        adapter.SelectCommand.Parameters.AddWithValue(param.Key, param.Value)
                    Next
                End If
                Dim dt As New DataTable()
                adapter.Fill(dt)
                Return dt
            End Using
        End Using
    End Function
End Module