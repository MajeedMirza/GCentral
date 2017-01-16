Public Class BMTron
    Dim right2 As Boolean = False
    Dim left2 As Boolean = False
    Dim up2 As Boolean = False
    Dim down2 As Boolean = False
    Dim origin2x As Integer = 12
    Dim origin2y As Integer = 11
    Dim horiz2 As Integer
    Dim vert2 As Integer

    Dim right1 As Boolean = False
    Dim left1 As Boolean = False
    Dim up1 As Boolean = False
    Dim down1 As Boolean = False
    Dim origin1x As Integer = 12
    Dim origin1y As Integer = 13
    Dim horiz1 As Integer
    Dim vert1 As Integer
    Dim wait25 As Integer = 0
    Dim dev As Boolean = False

    Dim limit As Integer = 1
    Dim test As Boolean = False
    Dim randfirst As Boolean = True
    Dim thirst As Integer = 1
    Dim multiplier As Integer = 100
    Dim bluefound As Boolean = False
    Dim rande As New Random
    Dim bluewins As Integer = 0
    Dim redwins As Integer = 0
    Dim wallreflect As Integer = 3 '3
    Dim points As Integer = 5
    Dim seeblue As Integer = 0
    Dim aggList As String = ""

    Dim ai As Boolean = True

    Private Sub BMTron_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        horiz2 = origin2x
        vert2 = origin2y
        horiz1 = origin1x
        vert1 = origin1y
        dgv.Rows.Add(25)
        For Each row As DataGridViewRow In dgv.Rows
            row.Height = 20
            For Each cell As DataGridViewCell In row.Cells
                cell.Style.BackColor = Color.White
            Next
        Next
        For Each col As DataGridViewColumn In dgv.Columns
            col.Width = 20
        Next

        Me.Focus()
        dgv.ClearSelection()
        dgv.Rows(horiz2).Cells(vert2).Style.BackColor = Color.Red
        dgv.Rows(horiz1).Cells(vert1).Style.BackColor = Color.Blue
        thirst = rande.Next(0, 4)
        getUsername()
    End Sub



    Private Sub BMTron_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
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

            Case Keys.D
                right2 = True
                left2 = False
                up2 = False
                down2 = False
                e.Handled = True
            Case Keys.A
                left2 = True
                right2 = False
                up2 = False
                down2 = False
                e.Handled = True
            Case Keys.W
                up2 = True
                left2 = False
                right2 = False
                down2 = False
                e.Handled = True
            Case Keys.S
                down2 = True
                right2 = False
                left2 = False
                up2 = False
                e.Handled = True
            Case Keys.Escape
                Me.Close()
                e.Handled = True
            Case Keys.Enter
                Me.Close()
                e.Handled = True
            Case Keys.Space
                Me.Close()
                e.Handled = True
            Case Keys.C
                If ai = True Then
                    ai = False
                Else
                    ai = True
                End If
                e.Handled = True
            Case Keys.P
                left1 = False
                right1 = False
                up1 = False
                down1 = False
                Timer1.Enabled = False
                e.Handled = True
            Case Keys.D0
                Timer1.Enabled = True
            Case Keys.T
                If dev = True Then
                    If test = True Then
                        clearText()
                        test = False
                    Else
                        test = True
                    End If
                End If
            Case Keys.V
                Me.Text = "Nov 3"
        End Select
        If (up1 Or left1 Or right1 Or down1) And ((up2 Or left2 Or right2 Or down2) Or ai = True) Then
            Timer1.Enabled = True
        End If
    End Sub

    'Private Sub BMTron_ResizeEnd(sender As Object, e As EventArgs) Handles Me.ResizeEnd
    '    MsgBox(Me.Size.ToString)
    'End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        dothis()
    End Sub

    Private Sub dothis()
        Dim bluewin As Boolean = False
        Dim redwin As Boolean = False
        wait25 += 1
        If right1 Or left1 Or down1 Or up1 Then
            If right1 = True Then
                vert1 += 1
            End If
            If left1 = True Then
                vert1 -= 1
            End If
            If up1 = True Then
                horiz1 -= 1
            End If
            If down1 = True Then
                horiz1 += 1
            End If
            Try
                If dgv.Rows(horiz1).Cells(vert1).Style.BackColor = Color.White Then
                    dgv.Rows(horiz1).Cells(vert1).Style.BackColor = Color.Blue
                Else
                    Timer1.Enabled = False
                    redwin = True
                End If

            Catch ex As Exception
                Timer1.Enabled = False
                redwin = True
            End Try
        End If

        If ai = True Then
            aiPlay2()
        End If

        If right2 Or left2 Or down2 Or up2 Then
            If right2 = True Then
                vert2 += 1
            End If
            If left2 = True Then
                vert2 -= 1
            End If
            If up2 = True Then
                horiz2 -= 1
            End If
            If down2 = True Then
                horiz2 += 1
            End If
            Try
                If dgv.Rows(horiz2).Cells(vert2).Style.BackColor = Color.White Then
                    dgv.Rows(horiz2).Cells(vert2).Style.BackColor = Color.Red
                Else
                    Timer1.Enabled = False
                    bluewin = True
                End If

            Catch ex As Exception
                Timer1.Enabled = False
                bluewin = True
            End Try
        End If
        If vert1 = vert2 And horiz1 = horiz2 Then
            dgv.Rows(horiz2).Cells(vert2).Style.BackColor = Color.Purple
            Timer1.Enabled = False
            bluewin = True
            redwin = True
        End If
        If bluewin And redwin = True Then
            'bluewins += 1
            'redwins += 1
            restart("Draw!")
        ElseIf bluewin Then
            dgv.Rows(horiz1).Cells(vert1).Style.BackColor = Color.White
            bluewins += 1
            restart("Blue wins!")
        ElseIf redwin Then
            dgv.Rows(horiz2).Cells(vert2).Style.BackColor = Color.White
            redwins += 1
            aggList += thirst.ToString
            If redwins > 10 And dev = True Then
                MsgBox(aggList)
            End If
            restart("Red wins!")
        End If
    End Sub


    Private Sub aiPlay2()
        clearText()

        Dim playmove As Integer
        Dim played As Integer
        Dim Direction As Integer

        Dim pL As Integer
        Dim pR As Integer
        Dim pU As Integer
        Dim pD As Integer

        played = MLeft(horiz2, vert2, 0)
        pL = played
        If played > playmove Then
            playmove = played
            Direction = 4
        End If

        played = MRight(horiz2, vert2, 0)
        pR = played
        If played > playmove Then
            playmove = played
            Direction = 3
        End If

        played = MDown(horiz2, vert2, 0)
        pU = played
        If played > playmove Then
            playmove = played
            Direction = 1
        End If

        played = MUp(horiz2, vert2, 0)
        pD = played
        If played > playmove Then
            playmove = played
            Direction = 2
        End If

        If seeblue = 0 And wait25 > 25 Then
            wallreflect = 3
            If test = True Then
                Console.Write("WR: ON" & vbCrLf)
            End If
        Else
            seeblue = 0
            wallreflect = 0
            If test = True Then
                Console.Write("WR: OFF " & wait25 & vbCrLf)
            End If
        End If
        If test = True Then
            Console.Write(playmove)
            If limit = 0 Then
                Console.Write("LIVE" & vbCrLf)
            Else
                Console.Write(" SMART " & thirst & vbCrLf)
            End If
        End If

        If randfirst = True Then
            Dim rand As New Random
            Direction = rand.Next(1, 5)
            randfirst = False
        End If

        If Direction = 1 Then
            '  Console.Write("DOWN")
            down2 = True
            right2 = False
            left2 = False
            up2 = False
        ElseIf Direction = 2 Then
            '  Console.Write("UP")
            down2 = False
            right2 = False
            left2 = False
            up2 = True
        ElseIf Direction = 3 Then
            ' Console.Write("RIGHT")
            down2 = False
            right2 = True
            left2 = False
            up2 = False
        ElseIf Direction = 4 Then
            ' Console.Write("LEFT")
            down2 = False
            right2 = False
            left2 = True
            up2 = False
        End If
        ' Console.Write(vbCrLf)
        'End If
    End Sub

    Private Function MLeft(hor As Integer, vert As Integer, cont As Integer)
        Dim Move As Integer = 0
        Dim hit As Integer = vert
        If vert <> 0 Then
            If dgv.Rows(hor).Cells(vert - 1).Style.BackColor = Color.White Then
                For i As Integer = vert - 1 To 0 Step -1
                    If dgv.Rows(hor).Cells(i).Style.BackColor = Color.White Then
                        If test = True Then
                            dgv.Rows(hor).Cells(i).Value = "x" '--
                        End If
                        Move += points + cont
                        If cont < limit Then
                            Dim comp As Integer = MUp(hor, i, cont + 1)
                            Dim comp2 As Integer = MDown(hor, i, cont + 1)
                            If comp > comp2 Then
                                Move += comp
                            Else
                                Move += comp2
                            End If
                            'Move += MUp(hor, i, cont + 1)
                            'Move += MDown(hor, i, cont + 1)
                        End If
                    Else
                        'If dgv.Rows(hor).Cells(i).Style.BackColor = Color.Blue Then
                        '    Move -= 2
                        'End If
                        hit = i + 1
                        Exit For
                    End If

                    If up1 = True Then
                        If hor = horiz1 - 1 And i = vert1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    ElseIf down1 = True Then
                        If hor = horiz1 + 1 And i = vert1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    ElseIf left1 = True Then
                        If hor = horiz1 And i = vert1 - 1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    ElseIf right1 = True Then
                        If hor = horiz1 And i = vert + 1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    End If
                    If hor = horiz1 - 1 And i = vert1 Then
                        Move += thirst
                        'seeblue += 1
                    End If
                    If hor = horiz1 + 1 And i = vert1 Then
                        Move += thirst
                        'seeblue += 1
                    End If
                    If hor = horiz1 And i = vert1 - 1 Then
                        Move += thirst
                        'seeblue += 1
                    End If
                    If hor = horiz1 And i = vert + 1 Then
                        Move += thirst
                        'seeblue += 1
                    End If

                    hit = i
                Next
                If cont < limit + wallreflect Then
                    Dim comp As Integer = MUp(hor, hit, cont + 1)
                    Dim comp2 As Integer = MDown(hor, hit, cont + 1)
                    If comp > comp2 Then
                        Move += comp
                    Else
                        Move += comp2
                    End If
                End If

            End If
        End If
        Return Move
    End Function

    Private Function MRight(hor As Integer, vert As Integer, cont As Integer)
        Dim Move As Integer = 0
        Dim hit As Integer = vert
        If vert <> dgv.ColumnCount - 1 Then
            If dgv.Rows(hor).Cells(vert + 1).Style.BackColor = Color.White Then
                For i As Integer = vert + 1 To dgv.ColumnCount - 1
                    If dgv.Rows(hor).Cells(i).Style.BackColor = Color.White Then
                        If test = True Then
                            dgv.Rows(hor).Cells(i).Value = "x" '--
                        End If
                        Move += points + cont
                        If cont < limit Then
                            Dim comp As Integer = MUp(hor, i, cont + 1)
                            Dim comp2 As Integer = MDown(hor, i, cont + 1)
                            If comp > comp2 Then
                                Move += comp
                            Else
                                Move += comp2
                            End If
                            'Move += MUp(hor, i, cont + 1)
                            'Move += MDown(hor, i, cont + 1)
                        End If
                    Else
                        'If dgv.Rows(hor).Cells(i).Style.BackColor = Color.Blue Then
                        '    Move -= 2
                        'End If
                        hit = i - 1
                        Exit For
                    End If

                    If up1 = True Then
                        If hor = horiz1 - 1 And i = vert1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    ElseIf down1 = True Then
                        If hor = horiz1 + 1 And i = vert1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    ElseIf left1 = True Then
                        If hor = horiz1 And i = vert1 - 1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    ElseIf right1 = True Then
                        If hor = horiz1 And i = vert + 1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    End If
                    If hor = horiz1 - 1 And i = vert1 Then
                        Move += thirst
                        'seeblue += 1
                    End If
                    If hor = horiz1 + 1 And i = vert1 Then
                        Move += thirst
                        'seeblue += 1
                    End If
                    If hor = horiz1 And i = vert1 - 1 Then
                        Move += thirst
                        'seeblue += 1
                    End If
                    If hor = horiz1 And i = vert1 + 1 Then
                        Move += thirst
                        'seeblue += 1
                    End If

                    hit = i
                Next
                If cont < limit + wallreflect Then
                    Dim comp As Integer = MUp(hor, hit, cont + 1)
                    Dim comp2 As Integer = MDown(hor, hit, cont + 1)
                    If comp > comp2 Then
                        Move += comp
                    Else
                        Move += comp2
                    End If
                End If
            End If
        End If
        Return Move
    End Function

    Private Function MUp(hor As Integer, vert As Integer, cont As Integer)
        Dim Move As Integer = 0
        Dim hit As Integer = hor
        If hor <> 0 Then
            If dgv.Rows(hor - 1).Cells(vert).Style.BackColor = Color.White Then
                For i As Integer = hor - 1 To 0 Step -1
                    If dgv.Rows(i).Cells(vert).Style.BackColor = Color.White Then
                        If test = True Then
                            dgv.Rows(i).Cells(vert).Value = "x" '--
                        End If
                        Move += points + cont
                        If cont < limit Then
                            Dim comp As Integer = MLeft(i, vert, cont + 1)
                            Dim comp2 As Integer = MRight(i, vert, cont + 1)
                            If comp > comp2 Then
                                Move += comp
                            Else
                                Move += comp2
                            End If
                            'Move += MLeft(i, vert, cont + 1)
                            'Move += MRight(i, vert, cont + 1)
                        End If
                    Else
                        'If dgv.Rows(i).Cells(vert).Style.BackColor = Color.Blue Then
                        '    Move -= 2
                        'End If
                        hit = i + 1
                        Exit For
                    End If


                    If up1 = True Then
                        If i = horiz1 - 1 And vert = vert1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    ElseIf down1 = True Then
                        If i = horiz1 + 1 And vert = vert1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    ElseIf left1 = True Then
                        If i = horiz1 And vert = vert1 - 1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    ElseIf right1 = True Then
                        If i = horiz1 And vert = vert + 1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    End If
                    If i = horiz1 - 1 And vert = vert1 Then
                        Move += thirst
                        'seeblue += 1
                    End If
                    If i = horiz1 + 1 And vert = vert1 Then
                        Move += thirst
                        'seeblue += 1
                    End If
                    If i = horiz1 And vert = vert1 - 1 Then
                        Move += thirst
                        'seeblue += 1
                    End If
                    If i = horiz1 And vert = vert + 1 Then
                        Move += thirst
                        'seeblue += 1
                    End If

                    hit = i
                Next
                If cont < limit + wallreflect Then
                    Dim comp As Integer = MLeft(hit, vert, cont + 1)
                    Dim comp2 As Integer = MRight(hit, vert, cont + 1)
                    If comp > comp2 Then
                        Move += comp
                    Else
                        Move += comp2
                    End If
                End If

            End If
        End If

        Return Move
    End Function

    Private Function MDown(hor As Integer, vert As Integer, cont As Integer)
        Dim hit As Integer = hor
        Dim Move As Integer = 0
        If hor <> dgv.RowCount - 1 Then
            If dgv.Rows(hor + 1).Cells(vert).Style.BackColor = Color.White Then
                For i As Integer = hor + 1 To dgv.RowCount - 1
                    If dgv.Rows(i).Cells(vert).Style.BackColor = Color.White Then
                        If test = True Then
                            dgv.Rows(i).Cells(vert).Value = "x" '--
                        End If
                        Move += points + cont
                        If cont < limit Then
                            Dim comp As Integer = MLeft(i, vert, cont + 1)
                            Dim comp2 As Integer = MRight(i, vert, cont + 1)
                            If comp > comp2 Then
                                Move += comp
                            Else
                                Move += comp2
                            End If
                            'Move += MLeft(i, vert, cont + 1)
                            'Move += MRight(i, vert, cont + 1)
                        End If
                    Else
                        'If dgv.Rows(i).Cells(vert).Style.BackColor = Color.Blue Then
                        '    Move -= 2
                        'End If
                        hit = i - 1
                        Exit For
                    End If

                    If up1 = True Then
                        If i = horiz1 - 1 And vert = vert1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    ElseIf down1 = True Then
                        If i = horiz1 + 1 And vert = vert1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    ElseIf left1 = True Then
                        If i = horiz1 And vert = vert1 - 1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    ElseIf right1 = True Then
                        If i = horiz1 And vert = vert + 1 Then
                            Move += thirst * multiplier
                            seeblue += 1
                        End If
                    End If
                    If i = horiz1 - 1 And vert = vert1 Then
                        Move += thirst
                        'seeblue += 1
                    End If
                    If i = horiz1 + 1 And vert = vert1 Then
                        Move += thirst
                        'seeblue += 1
                    End If
                    If i = horiz1 And vert = vert1 - 1 Then
                        Move += thirst
                        'seeblue += 1
                    End If
                    If i = horiz1 And vert = vert + 1 Then
                        Move += thirst
                        'seeblue += 1
                    End If

                    hit = i
                Next
                If cont < limit + wallreflect Then
                    Dim comp As Integer = MLeft(hit, vert, cont + 1)
                    Dim comp2 As Integer = MRight(hit, vert, cont + 1)
                    If comp > comp2 Then
                        Move += comp
                    Else
                        Move += comp2
                    End If
                End If

            End If
        End If

        Return Move
    End Function

    Private Sub clearText()
        If test = True Then
            For Each row As DataGridViewRow In dgv.Rows
                For Each cell As DataGridViewCell In row.Cells
                    cell.Value = ""
                Next
            Next
        End If
    End Sub

    Private Sub savespace()
        Dim playList As New ArrayList
        'DOWN
        If horiz2 <> dgv.RowCount - 1 Then
            If dgv.Rows(horiz2 + 1).Cells(vert2).Style.BackColor = Color.White Then
                down2 = True
                right2 = False
                left2 = False
                up2 = False
            End If
        End If
        'UP
        If horiz2 <> 0 Then
            If dgv.Rows(horiz2 - 1).Cells(vert2).Style.BackColor = Color.White Then
                down2 = False
                right2 = False
                left2 = False
                up2 = True
            End If
        End If
        'RIGHT
        If vert2 <> dgv.ColumnCount - 1 Then
            If dgv.Rows(horiz2).Cells(vert2 + 1).Style.BackColor = Color.White Then
                down2 = False
                right2 = True
                left2 = False
                up2 = False
            End If
        End If
        'LEFT
        If vert2 <> 0 Then
            If dgv.Rows(horiz2).Cells(vert2 - 1).Style.BackColor = Color.White Then
                down2 = False
                right2 = False
                left2 = True
                up2 = False
            End If
        End If
    End Sub

    'Private Sub aiPlay()
    '    Dim playList As New ArrayList
    '    'DOWN
    '    If horiz2 <> dgv.RowCount - 1 Then
    '        If dgv.Rows(horiz2 + 1).Cells(vert2).Style.BackColor = Color.White Then
    '            playList.Add(1)
    '        End If
    '    End If
    '    'UP
    '    If horiz2 <> 0 Then
    '        If dgv.Rows(horiz2 - 1).Cells(vert2).Style.BackColor = Color.White Then
    '            playList.Add(2)
    '        End If
    '    End If
    '    'RIGHT
    '    If vert2 <> dgv.ColumnCount - 1 Then
    '        If dgv.Rows(horiz2).Cells(vert2 + 1).Style.BackColor = Color.White Then
    '            playList.Add(3)
    '        End If
    '    End If
    '    'LEFT
    '    If vert2 <> 0 Then
    '        If dgv.Rows(horiz2).Cells(vert2 - 1).Style.BackColor = Color.White Then
    '            playList.Add(4)
    '        End If
    '    End If
    '    Dim rand As New Random

    '    For Each item As String In playList
    '        'Console.Write(item & " ")
    '    Next
    '    'Console.Write(vbCrLf)
    '    If playList.Count = 0 Then
    '        Exit Sub
    '    End If
    '    Dim check As Integer = rand.Next(0, playList.Count - 1)

    '    If playList(check) = 1 Then
    '        'Console.Write("Check = " & check & "DOWN")
    '        down2 = True
    '        right2 = False
    '        left2 = False
    '        up2 = False
    '    ElseIf playList(check) = 2 Then
    '        'Console.Write("Check = " & check & "UP")
    '        down2 = False
    '        right2 = False
    '        left2 = False
    '        up2 = True
    '    ElseIf playList(check) = 3 Then
    '        'Console.Write("Check = " & check & "RIGHT")
    '        down2 = False
    '        right2 = True
    '        left2 = False
    '        up2 = False
    '    ElseIf playList(check) = 4 Then
    '        'Console.Write("Check = " & check & "LEFT")
    '        down2 = False
    '        right2 = False
    '        left2 = True
    '        up2 = False
    '    End If
    '    'Console.Write(vbCrLf)

    'End Sub


    Private Sub restart(Winner As String)
        Me.Text = "BMTron B: " & bluewins & " R: " & redwins
        If MessageBox.Show(Winner & vbCrLf & "Restart?", "Snake", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
            For Each row As DataGridViewRow In dgv.Rows
                For Each cell As DataGridViewCell In row.Cells
                    cell.Style.BackColor = Color.White
                    cell.Value = ""
                Next
            Next
            horiz2 = origin2x
            vert2 = origin2y
            horiz1 = origin1x
            vert1 = origin1y
            dgv.Rows(horiz2).Cells(vert2).Style.BackColor = Color.Red
            dgv.Rows(horiz1).Cells(vert1).Style.BackColor = Color.Blue
            left1 = False
            right1 = False
            up1 = False
            down1 = False
            left2 = False
            right2 = False
            up2 = False
            down2 = False
            randfirst = True
            thirst = rande.Next(0, 4)
            wallreflect = 0
            seeblue = 0
            wait25 = 0
        Else
            'Me.Close()

            Application.Exit()
        End If
    End Sub

    Private Sub getUsername()
        Dim user As String = ""
        If TypeOf My.User.CurrentPrincipal Is Security.Principal.WindowsPrincipal Then
            Dim parts() As String = Split(My.User.Name, "\")
            Dim username As String = parts(1)
            user = username
        Else
            user = My.User.Name
        End If
        If user.Contains("mirz") Then
            dev = True
        End If
    End Sub
    


End Class