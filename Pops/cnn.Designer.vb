<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class cnn
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container()
        Me.lblDegree = New System.Windows.Forms.Label()
        Me.btnShot = New System.Windows.Forms.Button()
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.Label1 = New System.Windows.Forms.Label()
        Me.lblTime = New System.Windows.Forms.Label()
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.SuspendLayout()
        '
        'lblDegree
        '
        Me.lblDegree.AutoSize = True
        Me.lblDegree.Location = New System.Drawing.Point(420, 443)
        Me.lblDegree.Name = "lblDegree"
        Me.lblDegree.Size = New System.Drawing.Size(13, 13)
        Me.lblDegree.TabIndex = 0
        Me.lblDegree.Text = "0"
        '
        'btnShot
        '
        Me.btnShot.Enabled = False
        Me.btnShot.Location = New System.Drawing.Point(420, 433)
        Me.btnShot.Name = "btnShot"
        Me.btnShot.Size = New System.Drawing.Size(10, 10)
        Me.btnShot.TabIndex = 1
        Me.btnShot.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Interval = 35
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(13, 9)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(35, 13)
        Me.Label1.TabIndex = 2
        Me.Label1.Text = "Wind:"
        '
        'lblTime
        '
        Me.lblTime.AutoSize = True
        Me.lblTime.Location = New System.Drawing.Point(13, 31)
        Me.lblTime.Name = "lblTime"
        Me.lblTime.Size = New System.Drawing.Size(48, 13)
        Me.lblTime.TabIndex = 3
        Me.lblTime.Text = "Time: 60"
        '
        'Timer2
        '
        Me.Timer2.Enabled = True
        Me.Timer2.Interval = 1000
        '
        'cnn
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(824, 468)
        Me.Controls.Add(Me.lblTime)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnShot)
        Me.Controls.Add(Me.lblDegree)
        Me.Name = "cnn"
        Me.Text = "cnn"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lblDegree As System.Windows.Forms.Label
    Friend WithEvents btnShot As System.Windows.Forms.Button
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents lblTime As System.Windows.Forms.Label
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
End Class
