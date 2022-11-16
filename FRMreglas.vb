Imports MySql.Data.MySqlClient
Imports System.ComponentModel
Imports System.Data
Imports System.IOPublic
Class FRMreglas
    Private Sub FRMreglas_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Dim Sql As String
        Dim cndb As New MySqlConnection("server=127.0.0.1; port=3306; userid=rednel; password=expres2021*; database=erp; SslMode=none")
        Dim dt As New DataTable()
        Sql = "select * from tablas"
        Dim cmd As New MySqlCommand(Sql, cndb)
        Try
            Dim da As New MySqlDataAdapter(cmd)
            da.Fill(dt)
            'DGVcampos.DataSource = dt
        Catch ex As Exception
            MsgBox(ex.Message)
            Exit Sub
        End Try
        DGVcampos.ColumnCount = 18
        DGVcampos.Columns(0).Name = "tabla"
        DGVcampos.Columns(1).Name = "Orden"
        DGVcampos.Columns(2).Name = "Campo"
        DGVcampos.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        'DGVcampos.Columns(1).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(3).Name = "Clave"
        DGVcampos.Columns(4).Name = "Tipo"
        DGVcampos.Columns(4).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        DGVcampos.Columns(5).Name = "Tamaño"
        DGVcampos.Columns(5).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(6).Name = "Valida"
        DGVcampos.Columns(7).Name = "Tabla Combo"
        DGVcampos.Columns(8).Name = "Clave combo"
        DGVcampos.Columns(9).Name = "Campo muestra Combo"
        DGVcampos.Columns(10).Name = "Formato"
        'DGVcampos.Columns(8).HeaderCell.Style.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(10).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(11).Name = "Enteros"
        DGVcampos.Columns(11).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(12).Name = "Decimales"
        DGVcampos.Columns(12).DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleRight
        DGVcampos.Columns(13).Name = "Muestra"
        DGVcampos.Columns(14).Name = "descripcion"
        DGVcampos.Columns(15).Name = "Label"
        DGVcampos.Columns(16).Name = "minimo"
        DGVcampos.Columns(17).Name = "maximo"
        For i = 0 To dt.Rows.Count - 1
            DGVcampos.Rows.Add(dt.Rows(i)(0).ToString, dt.Rows(i)(1).ToString, dt.Rows(i)(2).ToString, dt.Rows(i)(3).ToString, dt.Rows(i)(4).ToString, dt.Rows(i)(5).ToString, dt.Rows(i)(6).ToString, dt.Rows(i)(7).ToString, dt.Rows(i)(8).ToString, dt.Rows(i)(9).ToString, dt.Rows(i)(10).ToString, dt.Rows(i)(11).ToString, dt.Rows(i)(12).ToString, dt.Rows(i)(13).ToString, dt.Rows(i)(14).ToString, dt.Rows(i)(15).ToString, dt.Rows(i)(16).ToString, dt.Rows(i)(17).ToString)
        Next
    End Sub

    Private Sub BTNactualiza_Click(sender As Object, e As EventArgs) Handles BTNactualiza.Click
        Dim Sql As String
        Dim cndb As New MySqlConnection("server=127.0.0.1; port=3306; userid=rednel; password=expres2021*; database=erp; SslMode=none")
        Sql = "delete from tablas"
        Try
            cndb.Open()
            Dim cmd As New MySqlCommand(Sql, cndb)
            cmd.ExecuteNonQuery()
            cndb.Close()
        Catch ex As Exception
            MsgBox(ex.Message)
        End Try
        For i = 0 To DGVcampos.Rows.Count - 2
            Sql = "insert into tablas (tabla, orden, campo, clave, tipo, tamano, valida, tabla_combo, clave_combo, muestra_combo, formato, enteros, decimales, muestra, descripcion, label, minimo, maximo) "
            'Sql = Sql & " values ('" & DGVcampos.Rows.Item(i).Cells(0).Value.trim & "', " & i & ", '" & DGVcampos.Rows.Item(i).Cells(1).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(2).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(3).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(4).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(5).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(6).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(7).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(8).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(9).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(10).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(11).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(12).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(13).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(14).Value.trim & "', '" & DGVcampos.Rows.Item(i).Cells(15).Value.trim & "')"
            Sql = Sql & " values ('" & DGVcampos.Rows.Item(i).Cells(0).Value & "', " & DGVcampos.Rows.Item(i).Cells(1).Value & ", '" & DGVcampos.Rows.Item(i).Cells(2).Value & "', '" & DGVcampos.Rows.Item(i).Cells(3).Value & "', '" & DGVcampos.Rows.Item(i).Cells(4).Value & "', '" & DGVcampos.Rows.Item(i).Cells(5).Value & "', '" & DGVcampos.Rows.Item(i).Cells(6).Value & "', '" & DGVcampos.Rows.Item(i).Cells(7).Value & "', '" & DGVcampos.Rows.Item(i).Cells(8).Value & "', '" & DGVcampos.Rows.Item(i).Cells(9).Value & "', '" & DGVcampos.Rows.Item(i).Cells(10).Value & "', '" & DGVcampos.Rows.Item(i).Cells(11).Value & "', '" & DGVcampos.Rows.Item(i).Cells(12).Value & "', '" & DGVcampos.Rows.Item(i).Cells(13).Value & "', '" & DGVcampos.Rows.Item(i).Cells(14).Value & "', '" & DGVcampos.Rows.Item(i).Cells(15).Value & "', '" & DGVcampos.Rows.Item(i).Cells(16).Value & "', '" & DGVcampos.Rows.Item(i).Cells(17).Value & "')"

            Dim cmd As New MySqlCommand(Sql, cndb)
            Try
                cndb.Open()
                cmd.ExecuteNonQuery()
                cndb.Close()
            Catch ex As Exception
                MsgBox(ex.Message)
            End Try
        Next
        MsgBox("termino ")

    End Sub
End Class