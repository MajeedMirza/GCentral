Public Class Main

    Private WithEvents Timer1 As New System.Windows.Forms.Timer With {.Interval = 1}
    Public Const TEST As Boolean = True
    Private _DrawingSystem As DrawingSystem
    Dim direction As String
    Dim x As Integer
    Dim y As Integer
    Dim speed As Integer = 5
    Dim aiSpeed As Integer = 4
    Dim AG As Double = 0
    Dim checkhide As Boolean
    Public Const FORMWIDTH As Integer = 1000
    Public Const FORMHEIGHT As Integer = 1000
    Public AIList As New HashSet(Of Point)
    Dim AIfixed As New HashSet(Of Point)
    Dim Up1 As Boolean = False
    Dim Down1 As Boolean = False
    Dim Right1 As Boolean = False
    Dim Left1 As Boolean = False
     Dim randg As New Random
    'Dim cUp1 As Boolean = False
    'Dim cDown1 As Boolean = False
    'Dim cRight1 As Boolean = False
    'Dim cLeft1 As Boolean = False


    Dim starttime As New Date
    Dim tick As Integer = 0
    Dim REtick As Integer = 500
    Public survTime As Double = 0

    ''' <summary>
    ''' Starts Everything Up
    ''' </summary>
    ''' <param name="sender"></param>
    ''' <param name="e"></param>
    ''' <remarks></remarks>
    Private Sub MainLoad_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Me.Location = New Point(0, 0)
        Dim sizePoint As Point
        sizePoint.X = FORMWIDTH
        sizePoint.Y = FORMHEIGHT
        x = FORMWIDTH / 2
        y = FORMHEIGHT / 2
        Me.MinimumSize = sizePoint
        Me.MaximumSize = sizePoint
        Me.BackgroundImageLayout = ImageLayout.None
        Me.DoubleBuffered = True
        AIList.Add(New Point(0, 0))
        AIList.Add(New Point(FORMWIDTH, 0))
        AIList.Add(New Point(x, 0))
        AIList.Add(New Point(FORMWIDTH, y))
        AIList.Add(New Point(0, FORMHEIGHT))
        AIList.Add(New Point(0, y))
        AIList.Add(New Point(x, FORMHEIGHT))
        AIList.Add(New Point(FORMWIDTH, FORMHEIGHT))
        AIfixed.UnionWith(AIList)
        _DrawingSystem = New DrawingSystem(TEST, Me)
        starttime = DateAndTime.Now

        Timer1.Start()
    End Sub

    Private Sub cursorAngle()
        direction = ""
        Dim p2 As Point = Me.PointToClient(Cursor.Position)
        Dim ax As Integer = p2.X - x
        Dim ay As Integer = y - p2.Y
        Dim angle As Double = Math.Atan2(ay, ax)
        AG = angle
        angle = (angle * 180) / Math.PI
        angle = Math.Round(angle, 0)
        angle += 90
        _DrawingSystem.ag = angle
        'followMouse()

        useArrows()
    End Sub

    Private Sub followMouse()
        Dim p As Point = Me.PointToClient(Cursor.Position)
        Dim limit As Integer = 25
        If Not (p.X < x + limit And p.X > x - limit And p.Y < y + limit And p.Y > y - limit) Then
            x += speed * Math.Cos(AG)
            y -= speed * Math.Sin(AG)
        End If
    End Sub

    Private Sub useArrows()
        If Up1 = True Then
            If Not y <= 0 Then
                y -= speed
            End If
        End If
        If Down1 = True Then
            If Not y >= FORMHEIGHT - 40 Then
                y += speed
            End If
        End If
        If Left1 = True Then
            If Not x < 0 + 5s Then
                x -= speed
            End If
        End If
        If Right1 = True Then
            If Not x > FORMWIDTH - 23 Then
                x += speed
            End If
        End If
        'Console.Write(x & " " & y & vbCrLf)

        'If cUp1 = True Then
        '    Cursor.Position = New Point(Cursor.Position.X, Cursor.Position.Y - 10)
        'End If
        'If cDown1 = True Then
        '    Cursor.Position = New Point(Cursor.Position.X, Cursor.Position.Y + 10)
        'End If
        'If cLeft1 = True Then
        '    Cursor.Position = New Point(Cursor.Position.X - 10, Cursor.Position.Y)
        'End If
        'If cRight1 = True Then
        '    Cursor.Position = New Point(Cursor.Position.X + 10, Cursor.Position.Y)
        'End If
    End Sub

    Private Sub AIfollow()
        If tick > REtick And aiSpeed < 10 Then
            aiSpeed += 1
            tick = 0
            Console.Write(aiSpeed & vbCrLf)
        End If
        Dim tempAIList As New HashSet(Of Point)
        Dim ax As Integer
        Dim ay As Integer
        For Each p As Point In AIList
            ax = p.X
            ay = p.Y

            Dim p2 As Point = Me.PointToClient(Cursor.Position)
            Dim ax2 As Integer = x - ax
            Dim ay2 As Integer = ay - y
            Dim angle As Double = Math.Atan2(ay2, ax2)
            AG = angle

            Dim aitempspeed As Integer
            If Not _DrawingSystem.stopAI.Contains(p) Then
                aitempspeed = aiSpeed
            Else
                aitempspeed = aiSpeed * 0.5
            End If

            ax += aitempspeed * Math.Cos(AG)
            ay -= aitempspeed * Math.Sin(AG)

            tempAIList.Add(New Point(ax, ay))
        Next
        AIList.Clear()
        AIList = tempAIList
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        tick += 1
        'If tick > REtick Then
        '    tick = 0
        'End If
        cursorAngle()
        AIfollow()
        _DrawingSystem.DrawScreen(direction, x, y)
        survTime = Math.Round((DateAndTime.Now - starttime).TotalSeconds, 3)
        checkAIlist()
        checkhide = _DrawingSystem.hide

    End Sub

    Private Sub checkAIlist()
        Dim limit = 5
        Dim tempAIlist As New HashSet(Of Point)
        tempAIlist.UnionWith(AIList)
        For Each p As Point In tempAIlist
            If p.X < x + limit And p.X > x - limit And p.Y < y + limit And p.Y > y - limit Then
                'AIList.Remove(p)w
                Timer1.Enabled = False
                'Dim Survived As New TimeSpan
                'Survived = DateAndTime.Now - starttime
                If survTime > My.Settings.HiScore Then
                    My.Settings.HiScore = survTime
                    My.Settings.Save()
                End If
                If MessageBox.Show("You survived for " & survTime & " seconds. Current high score: " & My.Settings.HiScore & vbCrLf & vbCrLf & "Restart?", "Zmbi", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                    restart()
                Else
                    Me.Close()
                End If
                Exit Sub
            End If
        Next

        While AIList.Count < AIfixed.Count
            AIList.Add(AIfixed(randg.Next(0, AIfixed.Count + 1)))
        End While
    End Sub

    Private Sub togglecursor(ch As String)
        If ch = "s" Then
            Cursor.Show()
        ElseIf ch = "h" Then
            Cursor.Hide()
        End If

    End Sub

    Private Sub restart()
        x = FORMWIDTH / 2
        y = FORMHEIGHT / 2
        AIList.Clear()
        AIList.UnionWith(AIfixed)

        Up1 = False
        Down1 = False
        Right1 = False
        Left1 = False

        tick = 0
        aiSpeed = 4

        starttime = DateAndTime.Now

        Timer1.Enabled = True
    End Sub

    Private Sub Main_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyCode
            Case Keys.W
                Up1 = True
                direction = "U"
                e.Handled = True
            Case Keys.S
                Down1 = True
                direction = "D"
                e.Handled = True
            Case Keys.D
                Right1 = True
                direction = "R"
                e.Handled = True
            Case Keys.A
                Left1 = True
                direction = "L"
                e.Handled = True
                'Case Keys.Up
                '    cUp1 = True
                '    e.Handled = True
                'Case Keys.Down
                '    cDown1 = True
                '    e.Handled = True
                'Case Keys.Right
                '    cRight1 = True
                '    e.Handled = True
                'Case Keys.Left
                '    cLeft1 = True
                '    e.Handled = True
            Case Keys.Space
                'Dim p As Point = Me.PointToClient(Cursor.Position)
                'If Not (p.X < x + speed And p.X > x - speed And p.Y < y + speed And p.Y > y - speed) Then
                '    x += speed * Math.Cos(AG)
                '    y -= speed * Math.Sin(AG)
                '    Console.Write(x & ", " & y & " " & AG & vbCrLf)
                'End If
                Me.Close()
                Cursor.Show()
                e.Handled = True
            Case (Keys.Escape)
                    Me.Close()
        End Select
    End Sub

    Private Sub Main_KeyUp(sender As Object, e As System.Windows.Forms.KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyCode
            Case Keys.W
                Up1 = False
                e.Handled = True
            Case Keys.S
                Down1 = False
                e.Handled = True
            Case Keys.D
                Right1 = False
                e.Handled = True
            Case Keys.A
                Left1 = False
                e.Handled = True
                'Case Keys.Up
                '    cUp1 = False
                '    e.Handled = True
                'Case Keys.Down
                '    cDown1 = False
                '    e.Handled = True
                'Case Keys.Right
                '    cRight1 = False
                '    e.Handled = True
                'Case Keys.Left
                '    cLeft1 = False
                '    e.Handled = True
        End Select
    End Sub

End Class