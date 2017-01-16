Public Class CalculationSystem

    Private Const VISIONMAXANGLE As Integer = 30
    Private Const VISIONLENGTH As Integer = 150

    ''' <summary>
    ''' (X,Y)
    ''' </summary>

    Public Shared Function CalculateArc(ByVal startX As Integer, ByVal startY As Integer, ByVal direction As Integer, ByVal currentVisionLength As Integer) As HashSet(Of Point)

        Dim DirectionOffset As Integer = direction

        Dim VisionAngle As Double = -VISIONMAXANGLE + DirectionOffset
        Dim VisionAngleRads As Double
        Dim PointsToDraw As HashSet(Of Point) = New HashSet(Of Point)
        Dim DrawX As Integer
        Dim DrawY As Integer

        While VisionAngle < VISIONMAXANGLE + DirectionOffset
            VisionAngleRads = (Math.PI * (VisionAngle)) / 180
            DrawX = startX + currentVisionLength * Math.Sin(VisionAngleRads)
            DrawY = startY + currentVisionLength * Math.Cos(VisionAngleRads)
            PointsToDraw.Add(New Point(DrawX, DrawY))
            VisionAngle += 1
        End While

        Return PointsToDraw

    End Function

    ''' <summary>
    ''' (X,Y)
    ''' </summary>


    Public Shared Function CalculateSemiCircle(ByVal startX As Integer, ByVal startY As Integer, ByVal direction As Integer) As HashSet(Of Point)

        Dim PointsToDraw As HashSet(Of Point) = New HashSet(Of Point)

        For i As Integer = 0 To VISIONLENGTH
            PointsToDraw.UnionWith(CalculationSystem.CalculateArc(startX, startY, direction, i))
        Next
        'Console.Write(PointsToDraw(0).X & ", " & PointsToDraw(0).Y & vbCrLf)
        Return PointsToDraw

    End Function

End Class

