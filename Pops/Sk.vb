Public Class Sk
    Dim right1 As Boolean = False
    Dim left1 As Boolean = False
    Dim up1 As Boolean = False
    Dim down1 As Boolean = False
    Dim head As String = "o"
    Dim lengthcount As Integer = 1
    Dim snakelist As New ArrayList
    Dim horiz As Integer = 4
    Dim vert As Integer = 4

    Private Sub Sk_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        dgv.Rows.Add(10)
        dgvimg.Rows.Add(10)
        For Each row As DataGridViewRow In dgv.Rows
            row.Height = 50
        Next
        For Each row As DataGridViewRow In dgvimg.Rows
            row.Height = 50
        Next
        setimage()
        dgv.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter
        dgv.Rows(4).Cells(4).Value = head
        Me.Focus()
        dgv.ClearSelection()
        randx()
    End Sub

    Private Sub Sk_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.Right
                right1 = True
                left1 = False
                up1 = False
                down1 = False
                e.Handled = True
            Case Keys.Left
                left1 = True
                right1 = False
                up1 = False
                down1 = False
                e.Handled = True
            Case Keys.Up
                up1 = True
                left1 = False
                right1 = False
                down1 = False
                e.Handled = True
            Case Keys.Down
                down1 = True
                right1 = False
                left1 = False
                up1 = False
                e.Handled = True
            Case Keys.Escape
                Me.Close()
                e.Handled = True
            Case Keys.Space
                Me.Close()
                e.Handled = True
        End Select
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        ' setimage()
        If right1 Or left1 Or down1 Or up1 Then
            Dim horiz1 As Integer = 0
            Dim vert1 As Integer = 0
            Dim point As New Drawing.Point
            point.X = horiz
            point.Y = vert
            snakelist.Insert(0, point)
            If right1 = True Then
                vert += 1
            End If
            If left1 = True Then
                vert -= 1
            End If
            If up1 = True Then
                horiz -= 1
            End If
            If down1 = True Then
                horiz += 1
            End If
            Try
                If dgv.Rows(horiz).Cells(vert).Value = "" Then
                    horiz1 = snakelist(snakelist.Count - 1).x
                    vert1 = snakelist(snakelist.Count - 1).y
                    dgv.Rows(horiz1).Cells(vert1).Value = ""
                    snakelist.RemoveAt(snakelist.Count - 1)
                    dgv.Rows(horiz).Cells(vert).Value = "o"
                ElseIf dgv.Rows(horiz).Cells(vert).Value.ToString.Contains("o") Or dgv.Rows(horiz).Cells(vert).Value.ToString.Contains("O") Then
                    horiz1 = snakelist(snakelist.Count - 1).x
                    vert1 = snakelist(snakelist.Count - 1).y
                    dgv.Rows(horiz1).Cells(vert1).Value = ""
                    snakelist.RemoveAt(snakelist.Count - 1)
                    If dgv.Rows(horiz).Cells(vert).Value.ToString.Contains("o") Or lengthcount = 2 Or dgv.Rows(horiz).Cells(vert).Value.ToString.Contains("O") Then
                        dgv.Rows(horiz).Cells(vert).Value = "O"
                        Timer1.Enabled = False
                        restart()
                    Else
                        dgv.Rows(horiz).Cells(vert).Value = "o"
                    End If
                End If
                If dgv.Rows(horiz).Cells(vert).Value = "x" Then
                    lengthcount += 1
                    dgv.Rows(horiz).Cells(vert).Value = "O"
                    randx()
                End If
            Catch ex As Exception
                Timer1.Enabled = False
                restart()
            End Try

        End If
        setimage()
    End Sub

    Private Sub restart()
        If MessageBox.Show("Your score was: " & lengthcount & vbCrLf & "Restart?", "Snake", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            For Each row As DataGridViewRow In dgv.Rows
                For Each cell As DataGridViewCell In row.Cells
                    cell.Value = ""
                Next
            Next
            dgv.Rows(4).Cells(4).Value = head
            randx()
            lengthcount = 1
            snakelist.Clear()
            left1 = False
            right1 = False
            up1 = False
            down1 = False
            horiz = 4
            vert = 4
            Timer1.Enabled = True
        Else
            'Me.Close()
            Application.Exit()
        End If
    End Sub

    Private Sub setHead()
        Dim horiz1 As Integer
        Dim vert1 As Integer
        For i As Integer = 0 To snakelist.Count - 1
            horiz1 = snakelist(i).x
            vert1 = snakelist(i).y
            dgv.Rows(horiz).Cells(vert).Value = "o"
        Next
    End Sub

    Private Sub randx()
        Dim horiz1 As Integer
        Dim vert1 As Integer
        Dim rand1 As Integer
        Dim emptylist As New ArrayList
        Dim point As New Drawing.Point
        Dim rand As New Random
        For i As Integer = 0 To dgv.RowCount - 1
            For j As Integer = 0 To dgv.ColumnCount - 1
                If dgv.Rows(i).Cells(j).Value = "" Then
                    point.X = i
                    point.Y = j
                    emptylist.Insert(0, point)
                End If
            Next
        Next
        rand1 = rand.Next(0, emptylist.Count)
        horiz1 = emptylist(rand1).x
        vert1 = emptylist(rand1).y
        dgv.Rows(horiz1).Cells(vert1).Value = "x"
    End Sub

    Private Sub setimage()
        For i As Integer = 0 To dgv.RowCount - 1
            For j As Integer = 0 To dgv.ColumnCount - 1
                If dgv.Rows(i).Cells(j).Value = "" Then
                    dgvimg.Rows(i).Cells(j).Value = picb.Image
                ElseIf dgv.Rows(i).Cells(j).Value = "o" Or dgv.Rows(i).Cells(j).Value = "O" Then
                    dgvimg.Rows(i).Cells(j).Value = picam.Image
                Else
                    dgvimg.Rows(i).Cells(j).Value = picbm.Image
                End If
            Next
        Next
    End Sub


    'Private Sub Sk_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
    '    MsgBox(Me.Size.ToString)
    'End Sub

End Class