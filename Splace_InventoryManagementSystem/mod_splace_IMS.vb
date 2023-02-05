Imports System.Data
Imports MySql.Data.MySqlClient
Module mod_splace_IMS
    '#############################################################Db Connection##########################################################################################
    Public dbConn As MySqlConnection ' This is used to establish connection
    Public sqlCommand As MySqlCommand ' This is used invoking SQL Command and retrieval
    Public sqlCommand2 As MySqlCommand ' This is used invoking SQL Command and retrieval
    Public strConn = "server=192.168.254.100; user id=root;password=d74r3j93527;database=" 'Connecttion String
    'Public strConn = "server=192.168.254.114; user id=raldz;password=d74r3j93527;database=" 'Connecttion String
    'Public strConn = "server=206.189.80.59;Port=22284; user id=raldz;password=d74r3j93527;database=" 'Connecttion String
    Public da As MySqlDataAdapter ' A bridge between connection and Data
    Public dt As DataTable  'opulate the records from Database
    Public dr As MySqlDataReader
    Public ds As DataSet
    Public result As Integer
    Public username As String


    '#############################################################End of Db Connection##########################################################################################

    '######################################################### Module & function class ##############################################################################
    Public Sub _dbConnection(ByVal dbName As String)
        Try
            dbConn = New MySqlConnection(strConn & dbName)
            dbConn.Open()
        Catch ex As Exception
            erromessage("error 101: Connection to database is failed. Please contact the administrator " & ex.Message)
        Finally
            dbConn.Close()
        End Try
    End Sub

    Public Sub _insertData(ByVal sql As String)
        Try
            dbConn.Open()
            sqlCommand = New MySqlCommand(sql, dbConn)
            dr = sqlCommand.ExecuteReader
        Catch ex As Exception
            erromessage("error 102: Insert Data " & ex.Message)
        Finally
            dbConn.Close()
        End Try

    End Sub

    Public Sub _insertData(ByVal sql As String)
        Try
            dbConn.Open()
            sqlCommand = New MySqlCommand(sql, dbConn)
            dr = sqlCommand.ExecuteReader
        Catch ex As Exception
            erromessage("error 102: Insert Data " & ex.Message)
        Finally
            dbConn.Close()
        End Try

    End Sub

    Public Sub _loadToCombobox(ByVal sql As String, ByVal cbo As ComboBox)
        Try
            dbConn.Open()
            da = New MySqlDataAdapter(sql, dbConn)
            dt = New DataTable
            da.Fill(dt)
            cbo.DataSource = dt
            cbo.ValueMember = dt.Columns(0).ToString 'primary key
            cbo.DisplayMember = dt.Columns(1).ToString 'display value
        Catch ex As Exception
            erromessage("error 103: loadToCombobox  " & ex.Message)
        Finally
            dbConn.Close()
        End Try
    End Sub

    Public Sub _updateData(ByVal sql As String)
        Try
            dbConn.Open()
            sqlCommand = New MySqlCommand(sql, dbConn)
            dr = sqlCommand.ExecuteReader
        Catch ex As Exception
            erromessage("error 104 Update Data " & ex.Message)
        Finally
            dbConn.Close()
        End Try
    End Sub

    Public Sub _loadToTextbox(ByVal sql As String, ByVal txtb As TextBox)
        Try
            dbConn.Open()
            sqlCommand = New MySqlCommand(sql, dbConn)
            dr = sqlCommand.ExecuteReader
            While dr.Read()

                txtb.Text = dr(0)
            End While
        Catch ex As Exception
            erromessage("error 105 loadToTextbox " & ex.Message)
        Finally
            dbConn.Close()
        End Try
    End Sub
    Public Sub _retrieveData(ByVal sql As String)
        Try
            dbConn.Open()
            sqlCommand = New MySqlCommand(sql, dbConn)
            dr = sqlCommand.ExecuteReader
            result = 0
            While dr.Read
                username = dr(0).ToString
                result += 1
            End While
        Catch ex As Exception
            erromessage("error 106: Retrieve Data " & ex.Message)
        Finally
            dbConn.Close()
        End Try
    End Sub
    Public Sub erromessage(ByVal errMsg As String)
        MessageBox.Show(errMsg)
    End Sub
End Module
