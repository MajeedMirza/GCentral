Public Class Pops
    Dim rand1 As New Random
    Dim rand2 As New Random
    Dim xsize As Integer
    Dim ysize As Integer
    Dim points As Integer
    Dim ticks As Integer
    Dim checkticks As Integer = 2
    Dim speed As Integer
    Dim speed2 As Integer
    Dim pointscheck As Integer


    Private Sub Pops_FormClosing(sender As Object, e As FormClosingEventArgs) Handles Me.FormClosing
        If Me.Name = "Pops" Then
            Clipboard.SetText(Label1.Text & " Points")
        End If
    End Sub

    Private Sub Pops_Load(sender As Object, e As EventArgs) Handles MyBase.Load 
        If Me.Name = "Pops" Then
            Label1.Visible = True
            Timer1.Enabled = True
            Dim point As Drawing.Point
            point.X = 0
            point.Y = 0
            Me.Location = point
        Else
            xsize = rand1.Next(50, 300)
            ysize = rand1.Next(280, 400)
            Me.Width = xsize
            Me.Height = ysize
            Me.FormBorderStyle = Windows.Forms.FormBorderStyle.None
            Dim point As Drawing.Point
            point.X = 1920 * 2
            point.Y = Cursor.Position.Y - 150
            speed = rand2.Next(15, 18)
            speed2 = rand2.Next(0, 4)
            Me.Location = point
            Timer2.Enabled = True
        End If


    End Sub

    Private Sub Pops_MouseEnter(sender As Object, e As EventArgs) Handles Me.MouseEnter
        If Me.Name <> "Pops" Then
            Application.Exit()
        End If
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        points += 1
        pointscheck += 1
        ticks += 1
        If ticks > checkticks Then
            If Timer1.Interval > 105 Then
                Timer1.Interval = Timer1.Interval - 50
                'Console.Write(Timer1.Interval.ToString & vbCrLf)
            ElseIf pointscheck > 250 And Timer1.Interval > 50 Then
                Timer1.Interval = Timer1.Interval - 10
                pointscheck = 0
                'Console.Write(Timer1.Interval.ToString & vbCrLf)
            End If
            ticks = 0
            Dim newpops As New Pops
            newpops.Name = "new"
            Dim ncol As New Color
            newpops.TopMost = True
            ncol = Color.FromArgb(rand1.Next(0, 256), rand1.Next(0, 256), rand1.Next(0, 256))
            newpops.BackColor = ncol
            newpops.Show()
        End If
        Label1.Text = points
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        If Me.Location.X < -300 Or Me.Location.Y > 1480 Then
            Me.Close()
        End If
        Dim point As Drawing.Point
        point.X = Me.Location.X - speed
        
        If speed2 = 3 Then
            Me.BackColor = Color.Red
            If Me.Location.Y < Cursor.Position.Y - 150 Then
                point.Y = Me.Location.Y + speed2
            Else
                point.Y = Me.Location.Y - speed2
            End If
        Else
            If Me.Location.Y < 0 And speed2 < 0 And Location.X < 1910 * 2 Then
                speed2 = speed2 * -1
            End If
            If Me.Location.Y > 1080 - Me.Height And speed2 > 0 And Location.X < 1910 * 2 Then
                speed2 = speed2 * -1
            End If
            point.Y = Me.Location.Y + speed2
        End If
        Me.Location = point
    End Sub
End Class