Public Class cnn

    Dim rad As Double = 0
    Dim degree As Integer = 0
    Dim vert As Integer = 0
    Dim horiz As Integer = 0
    Dim speed As Integer = 25
    Dim gravity As Integer = 1
    Dim wind As Integer = 0
    Dim loc2 As Drawing.Point
    Dim target As New Button
    Dim points As Integer = 0
    Dim time As Integer = 60

    Private Sub cnn_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        If Timer1.Enabled = False Then
            Select Case e.KeyCode
                Case Keys.Up
                    degree += 1
                    e.Handled = True
                Case Keys.Down
                    degree -= 1
                    e.Handled = True
                Case Keys.Right
                    Dim loc1 As Drawing.Point
                    loc1.X = btnShot.Location.X + 10
                    loc1.Y = btnShot.Location.Y
                    btnShot.Location = loc1
                    loc1.Y = btnShot.Location.Y + 10
                    lblDegree.Location = loc1
                    e.Handled = True
                Case Keys.Left
                    Dim loc1 As Drawing.Point
                    loc1.X = btnShot.Location.X - 10
                    loc1.Y = btnShot.Location.Y
                    btnShot.Location = loc1
                    loc1.Y = btnShot.Location.Y + 10
                    lblDegree.Location = loc1
                    e.Handled = True
                Case Keys.Space
                    loc2.X = btnShot.Location.X
                    loc2.Y = btnShot.Location.Y
                    Timer1.Enabled = True
                Case Keys.Escape
                    Me.Close()
            End Select
            rad = (degree * Math.PI) / 180
            lblDegree.Text = degree
            vert = speed * Math.Sin(rad)
            vert = vert * -1
            horiz = speed * Math.Cos(rad)
            Console.Write(vert & " & " & horiz & vbCrLf)
        End If
    End Sub


    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        vert += gravity
        horiz += wind
        Dim loc1 As Drawing.Point
        loc1.X = btnShot.Location.X + horiz
        loc1.Y = btnShot.Location.Y + vert
        btnShot.Location = loc1
        If btnShot.Location.Y > Me.Height Then
            btnShot.Location = loc2
            Timer1.Enabled = False
        End If
        If btnShot.Location.Y > target.Location.Y - 10 And btnShot.Location.Y < target.Location.Y + target.Height And btnShot.Location.X > target.Location.X - 10 And btnShot.Location.X < target.Location.X + target.Width Then
            Dim rand As New Random
            Dim loc3 As Drawing.Point
            loc3.X = rand.Next(50, Me.Width - 49)
            loc3.Y = rand.Next(150, Me.Height - 100)
            target.Location = loc3
            wind += rand.Next(-1, 2)
            Label1.Text = "Wind: " & wind
            btnShot.Location = loc2
            Timer1.Enabled = False
            points += 1
            target.Text = points
        End If

    End Sub

    Private Sub cnn_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        loc2.X = 420
        loc2.Y = 433
        Dim rand As New Random
        wind = rand.Next(-1, 2)
        Label1.Text = "Wind: " & wind
        target.Enabled = False
        target.Height = 25
        target.Width = 25
        Dim loc1 As Drawing.Point
        loc1.X = rand.Next(50, Me.Width - 49)
        loc1.Y = rand.Next(150, Me.Height - 100)
        target.Location = loc1
        target.Text = points
        Me.Controls.Add(target)
    End Sub

    Private Sub Timer2_Tick(sender As Object, e As EventArgs) Handles Timer2.Tick
        time -= 1
        lblTime.Text = "Time: " & time
        If time = 0 Then
            Timer2.Enabled = False
            If MessageBox.Show("Score: " & points & " Restart?", "CNN", MessageBoxButtons.YesNo) = Windows.Forms.DialogResult.Yes Then
                time = 60
                lblTime.Text = "Time: " & time
                Dim rand As New Random
                wind = rand.Next(-1, 2)
                Label1.Text = "Wind: " & wind
                points = 0
                target.Text = points
                Dim loc1 As Drawing.Point
                loc1.X = 420
                loc1.Y = 433
                btnShot.Location = loc1
                loc1.Y = btnShot.Location.Y + 10
                lblDegree.Location = loc1
                Dim loc3 As Drawing.Point
                loc3.X = rand.Next(50, Me.Width - 49)
                loc3.Y = rand.Next(150, Me.Height - 100)
                target.Location = loc3
                degree = 0
                lblDegree.Text = degree
                Timer2.Enabled = True
            Else
                Me.Close()
            End If
        End If
    End Sub
End Class