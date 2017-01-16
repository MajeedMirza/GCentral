Imports System.Data.SqlClient

Public Class SDKU
    Dim numbList As New HashSet(Of Integer)
    Dim newFill As Boolean
    Private OpenDialog As New OpenFileDialog()

    Private Sub SDKU_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.Rows.Add(9)
        For Each row As DataGridViewRow In dgv.Rows
            row.Height = 30
        Next
        For Each col As DataGridViewColumn In dgv.Columns
            col.Width = 30
        Next
        dgv.ClearSelection()
    End Sub

    Private Sub btnSolve_Click(sender As Object, e As EventArgs) Handles btnSolve.Click
        Dim done As Boolean = False
        ' While done = False
        done = True
        For Each row In dgv.Rows
            For Each cell In row.Cells
                'cell.Style.BackColor = Color.White
                If cell.value > 10 Then
                    cell.value = Nothing
                End If
            Next
        Next
        For Each row As DataGridViewRow In dgv.Rows
            For Each cell As DataGridViewCell In row.Cells
                For i As Integer = 1 To 9
                    numbList.Add(i)
                Next
                If cell.Value = Nothing Then
                    Dim value As String = checkRows(row, cell.ColumnIndex).ToString()
                    If value <> Nothing Then
                        cell.Value = value
                    Else
                        Exit Sub
                    End If
                    If cell.Value <> Nothing Then
                        If cell.Value > 9 Then
                            If cell.Value > 1000 Then
                                cell.Style.BackColor = Color.IndianRed
                            ElseIf cell.Value > 100 Then
                                cell.Style.BackColor = Color.PaleVioletRed
                            Else
                                cell.Style.BackColor = Color.LightPink
                            End If
                        Else
                            cell.Style.BackColor = Color.LightBlue
                            done = False
                        End If

                    End If
                End If
                numbList.Clear()
            Next
        Next
        If done = True Then

            done = Not newFill
        End If

        'End While
        CheckAfter()
    End Sub

    Private Function checkRows(row As DataGridViewRow, colnumb As Integer)
        For Each cell As DataGridViewCell In row.Cells
            If cell.Value <> Nothing Then
                If numbList.Contains(cell.Value) Then
                    numbList.Remove(cell.Value)
                End If
            End If
        Next
        If numbList.Count = 1 Then
            Return numbList(0)
        Else
            Return checkColumns(row.Index, colnumb)
        End If
    End Function

    Private Function checkColumns(rownumb As Integer, colnumb As Integer)
        For j As Integer = 0 To dgv.RowCount - 1
            If dgv.Rows(j).Cells(colnumb).Value <> Nothing Then
                If numbList.Contains(dgv.Rows(j).Cells(colnumb).Value) Then
                    numbList.Remove(dgv.Rows(j).Cells(colnumb).Value)
                End If
            End If
        Next
        If numbList.Count = 1 Then
            Return numbList(0)
        Else
            Return checkBoxes(rownumb, colnumb)
        End If
    End Function

    Private Function checkBoxes(rownumb As Integer, colnumb As Integer)
        ' Dim b1, b2, b3, b4, b5, b6, b7, b8, b9 As New HashSet(Of Integer)
        Dim box As New HashSet(Of Integer)
        If rownumb <= 2 Then
            If colnumb <= 2 Then
                box = createBox(0, 0)
            ElseIf colnumb <= 5 Then
                box = createBox(0, 3)
            ElseIf colnumb <= 8 Then
                box = createBox(0, 6)
            End If
        ElseIf rownumb <= 5 Then
            If colnumb <= 2 Then
                box = createBox(3, 0)
            ElseIf colnumb <= 5 Then
                box = createBox(3, 3)
            ElseIf colnumb <= 8 Then
                box = createBox(3, 6)
            End If
        ElseIf rownumb <= 8 Then
            If colnumb <= 2 Then
                box = createBox(6, 0)
            ElseIf colnumb <= 5 Then
                box = createBox(6, 3)
            ElseIf colnumb <= 8 Then
                box = createBox(6, 6)
            End If
        End If
        'box = createBox(rownumb, colnumb)
        For Each item As Integer In box
            If numbList.Contains(item) Then
                numbList.Remove(item)
            End If
        Next

        If numbList.Count = 1 Then
            Return numbList(0)
        Else
            Dim possible As String = ""
            For Each value As Integer In numbList
                possible += value.ToString
            Next
            Return possible
        End If
    End Function

    Private Function createBox(row As Integer, col As Integer)
        Dim box As New HashSet(Of Integer)
        For i As Integer = row To row + 2
            For j As Integer = col To col + 2
                    If dgv.Rows(i).Cells(j).Value <> Nothing Then
                        box.Add(dgv.Rows(i).Cells(j).Value)
                    End If
            Next
        Next
        Return box
    End Function

    Private Sub btnClear_Click(sender As Object, e As EventArgs) Handles btnClear.Click
        For Each row As DataGridViewRow In dgv.Rows
            For Each cell As DataGridViewCell In row.Cells
                cell.Style.BackColor = Color.White
                cell.Value = Nothing
            Next
        Next
        dgv.ReadOnly = False
    End Sub

    Private Sub btnImport_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btnImport.Click
        Dim filePath As String = ""
        If OpenDialog.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
            Exit Sub
        Else
            filePath = OpenDialog.FileName
        End If
        For Each row As DataGridViewRow In dgv.Rows
            For Each cell As DataGridViewCell In row.Cells
                cell.Style.BackColor = Color.White
            Next
        Next
        
        Dim MyConnection As System.Data.OleDb.OleDbConnection
        Dim DtSet As System.Data.DataSet
        Dim dt As DataTable
        Dim MyCommand As System.Data.OleDb.OleDbDataAdapter
        MyConnection = New System.Data.OleDb.OleDbConnection("provider=Microsoft.ACE.OLEDB.12.0;Data Source='" & filePath & "';Extended Properties=Excel 12.0;")
        MyCommand = New System.Data.OleDb.OleDbDataAdapter("select * from [Sheet1$]", MyConnection)
        MyCommand.TableMappings.Add("Table", "Net-informations.com")
        DtSet = New System.Data.DataSet
        MyCommand.Fill(DtSet)
        dt = DtSet.Tables(0)
        MyConnection.Close()

        For i As Integer = 0 To dgv.RowCount - 1
            For j As Integer = 0 To dgv.ColumnCount - 1
                If IsDBNull(dt.Rows(i).Item(j)) Then
                    dgv.Rows(i).Cells(j).Value = Nothing
                Else
                    dgv.Rows(i).Cells(j).Value = dt.Rows(i).Item(j)
                    dgv.Rows(i).Cells(j).ReadOnly = True
                    Dim dgvCell As DataGridViewCell

                End If
            Next
        Next
    End Sub

    Private Sub SDKU_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown, dgv.KeyDown, btnClear.KeyDown, btnImport.KeyDown, btnSolve.KeyDown
        Select Case e.KeyCode
            Case Keys.Escape
                Me.Close()
                e.Handled = True
        End Select
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles btnCheck.Click
        'CheckAfter()
        completed()
    End Sub

    Private Sub CheckAfter()
        newFill = False
        For Each row As DataGridViewRow In dgv.Rows
            For Each cell As DataGridViewCell In row.Cells
                If cell.Value > 10 Then
                    For Each Ch As Char In cell.Value.ToString
                        checkRows2(row, cell.ColumnIndex, Val(Ch))
                    Next
                End If
            Next
        Next
        For Each row As DataGridViewRow In dgv.Rows
            For Each cell As DataGridViewCell In row.Cells
                If cell.Value > 10 Then
                    For Each Ch As Char In cell.Value.ToString
                        checkColumns2(row.Index, cell.ColumnIndex, Val(Ch))
                    Next
                End If
            Next
        Next
        For Each row As DataGridViewRow In dgv.Rows
            For Each cell As DataGridViewCell In row.Cells
                If cell.Value > 10 Then
                    For Each Ch As Char In cell.Value.ToString
                        checkBoxes2(row.Index, cell.ColumnIndex, Val(Ch))
                    Next
                End If
            Next
        Next
    End Sub

    Private Sub checkRows2(row As DataGridViewRow, colnumb As Integer, check As Integer)
        For Each cell As DataGridViewCell In row.Cells
            If cell.ColumnIndex <> colnumb Then
                For Each Ch As Char In cell.Value.ToString
                    If check = Val(Ch) Then
                        Exit Sub
                    End If
                Next
            End If
        Next
        row.Cells(colnumb).Value = check
        row.Cells(colnumb).Style.BackColor = Color.LightBlue 'Color.LightGoldenrodYellow
        newFill = True
    End Sub

    Private Sub checkColumns2(rownumb As Integer, colnumb As Integer, check As Integer)
        For j As Integer = 0 To dgv.RowCount - 1
            If j <> rownumb Then
                For Each Ch As Char In dgv.Rows(j).Cells(colnumb).Value.ToString
                    If check = Val(Ch) Then
                        Exit Sub
                    End If
                Next
            End If
        Next
        dgv.Rows(rownumb).Cells(colnumb).Value = check
        dgv.Rows(rownumb).Cells(colnumb).Style.BackColor = Color.LightBlue 'Color.LightGray
        newFill = True
    End Sub

    'TODO finish checkboxes 
    Private Sub checkBoxes2(rownumb As Integer, colnumb As Integer, check As Integer)
        If rownumb <= 2 Then
            If colnumb <= 2 Then
                createBox2(0, 0, check, rownumb, colnumb)
            ElseIf colnumb <= 5 Then
                createBox2(0, 3, check, rownumb, colnumb)
            ElseIf colnumb <= 8 Then
                createBox2(0, 6, check, rownumb, colnumb)
            End If
        ElseIf rownumb <= 5 Then
            If colnumb <= 2 Then
                createBox2(3, 0, check, rownumb, colnumb)
            ElseIf colnumb <= 5 Then
                createBox2(3, 3, check, rownumb, colnumb)
            ElseIf colnumb <= 8 Then
                createBox2(3, 6, check, rownumb, colnumb)
            End If
        ElseIf rownumb <= 8 Then
            If colnumb <= 2 Then
                createBox2(6, 0, check, rownumb, colnumb)
            ElseIf colnumb <= 5 Then
                createBox2(6, 3, check, rownumb, colnumb)
            ElseIf colnumb <= 8 Then
                createBox2(6, 6, check, rownumb, colnumb)
            End If
        End If

    End Sub

    Private Sub createBox2(row As Integer, col As Integer, check As Integer, rownumb As Integer, colnumb As Integer)
        Dim count As Integer = 0
        For i As Integer = row To row + 2
            For j As Integer = col To col + 2
                For Each Ch As Char In dgv.Rows(i).Cells(j).Value.ToString
                    If check = Val(Ch) Then
                        count += 1
                    End If
                Next
            Next
        Next
        If count = 1 Then
            dgv.Rows(rownumb).Cells(colnumb).Value = check
            dgv.Rows(rownumb).Cells(colnumb).Style.BackColor = Color.LightBlue 'Color.LightGreen
            newFill = True
        End If
    End Sub

    Private Function completed() As Boolean
        Dim checklist As New HashSet(Of Integer)
        For i As Integer = 1 To 9
            checklist.Add(i)
        Next
        If checkRows3(checklist) = False Or checkColumns3(checklist) = False Or checkBoxes3(checklist) = False Then
            MessageBox.Show("Not complete.")
            Return False
        End If
        MessageBox.Show("Complete.")
        Return True
    End Function

    Private Function checkRows3(check As HashSet(Of Integer))
        Dim rowlist As New HashSet(Of Integer)
        For Each row As DataGridViewRow In dgv.Rows
            rowlist.UnionWith(check)
            For Each cell As DataGridViewCell In row.Cells
                If cell.Value >= 10 Or cell.Value = Nothing Then
                    Return False
                End If
                rowlist.Remove(cell.Value)
            Next
            If rowlist.Count <> 0 Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function checkColumns3(check As HashSet(Of Integer))
        Dim collist As New HashSet(Of Integer)
        For j As Integer = 0 To dgv.ColumnCount - 1
            collist.UnionWith(check)
            For i As Integer = 0 To dgv.RowCount - 1
                collist.Remove(dgv.Rows(i).Cells(j).Value())
            Next
            If collist.Count <> 0 Then
                Return False
            End If
        Next
        Return True
    End Function

    Private Function checkBoxes3(check As HashSet(Of Integer))
        If createBox3(0, 0, check) = False Or createBox3(0, 3, check) = False Or createBox3(0, 6, check) = False Or createBox3(3, 0, check) = False Or createBox3(3, 3, check) = False Or createBox3(3, 6, check) = False Or createBox3(6, 0, check) = False Or createBox3(6, 3, check) = False Or createBox3(6, 6, check) = False Then
            Return False
        End If
        Return True
    End Function

    Private Function createBox3(row As Integer, col As Integer, check As HashSet(Of Integer))
        Dim boxlist As New HashSet(Of Integer)
        boxlist.UnionWith(check)
        For i As Integer = row To row + 2
            For j As Integer = col To col + 2
                boxlist.Remove(dgv.Rows(i).Cells(j).Value())
            Next
        Next
        If boxlist.Count <> 0 Then
            Return False
        End If
        Return True
    End Function
End Class