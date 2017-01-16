Public Class DrawingSystem
    Private TEST As Boolean = False
    Private _MainForm As Main
    Public ag As Integer
    Public hide As Boolean
    Public stopAI As New HashSet(Of Point)

    Public Sub New(isTest As Boolean, mainForm As Main)
        TEST = isTest
        _MainForm = mainForm
    End Sub

    Public Sub DrawScreen(direction As Char, x As Integer, y As Integer)

        Using bmp As Bitmap = New Bitmap(Main.FORMWIDTH, Main.FORMHEIGHT)

            Using g As Graphics = Graphics.FromImage(bmp)

                With g

                    'Draw Background
                    .Clear(Color.Black)

                    DrawPointCollection(CalculationSystem.CalculateSemiCircle(x, y, ag), g)
                    g.DrawRectangle(New Pen(Brushes.DarkGray, 4), x - 2, y - 2, 4, 4)
                    'g.DrawRectangle(New Pen(Brushes.White, 1), x, y, 0, 0)

                    If Main.TEST Then
                        drawAI(g, _MainForm.AIList)
                    End If

                    g.DrawString(_MainForm.survTime, New Font("Tahoma", 11), Brushes.White, New Point(0, 0))


                    _MainForm.BackgroundImage = bmp.Clone

                    _MainForm.Invalidate()

                End With

            End Using

        End Using

    End Sub

    Public Sub drawAI(ByVal g As Graphics, PointsToDraw As HashSet(Of Point))
        For Each p As Point In PointsToDraw
            g.DrawArc(Pens.Green, p.X, p.Y, 5, 5, 0, 360)
        Next
    End Sub

    Private Sub DrawPointCollection(PointsToDraw As hashset(Of Point), ByVal g As Graphics)
        Dim count As Integer = 0
        Dim col As Color = Color.Gray
        stopAI.Clear()
        For Each Point As Point In PointsToDraw
            For Each p As Point In _MainForm.AIList
                If p.X < Point.X + 3 And p.X > Point.X - 3 And p.Y < Point.Y + 3 And p.Y > Point.Y - 3 Then
                    g.DrawArc(New Pen(Brushes.Green, 3), p.X, p.Y, 5, 5, 0, 360)
                    stopAI.Add(p)
                End If
            Next

            count += 1
            If col.R - 1 <= 10 Or col.G - 1 <= 10 Or col.B - 1 <= 10 Then
                col = Color.FromArgb(col.A, 5, 5, 5)
            ElseIf count = 60 Then
                count = 1
                col = Color.FromArgb(col.A, col.R - count, col.G - count, col.B - count)
                count = 0
            Else
                col = Color.FromArgb(col.A, col.R, col.G, col.B)
            End If

            g.DrawRectangle(New Pen(col), Point.X, Point.Y, 2, 2)
        Next
    End Sub

End Class
