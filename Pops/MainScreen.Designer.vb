<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class MainScreen
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(MainScreen))
        Me.btnBMTron = New System.Windows.Forms.Button()
        Me.btnSudoku = New System.Windows.Forms.Button()
        Me.btnPops = New System.Windows.Forms.Button()
        Me.btnSnake = New System.Windows.Forms.Button()
        Me.btnTanks = New System.Windows.Forms.Button()
        Me.Zmbi = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'btnBMTron
        '
        Me.btnBMTron.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnBMTron.BackColor = System.Drawing.Color.Snow
        Me.btnBMTron.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnBMTron.Location = New System.Drawing.Point(12, 12)
        Me.btnBMTron.Name = "btnBMTron"
        Me.btnBMTron.Size = New System.Drawing.Size(260, 23)
        Me.btnBMTron.TabIndex = 0
        Me.btnBMTron.Text = "BMTron"
        Me.btnBMTron.UseVisualStyleBackColor = False
        '
        'btnSudoku
        '
        Me.btnSudoku.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSudoku.BackColor = System.Drawing.Color.Snow
        Me.btnSudoku.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSudoku.Location = New System.Drawing.Point(12, 128)
        Me.btnSudoku.Name = "btnSudoku"
        Me.btnSudoku.Size = New System.Drawing.Size(260, 23)
        Me.btnSudoku.TabIndex = 1
        Me.btnSudoku.Text = "Sudoku Solver"
        Me.btnSudoku.UseVisualStyleBackColor = False
        '
        'btnPops
        '
        Me.btnPops.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnPops.BackColor = System.Drawing.Color.Snow
        Me.btnPops.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnPops.Location = New System.Drawing.Point(12, 70)
        Me.btnPops.Name = "btnPops"
        Me.btnPops.Size = New System.Drawing.Size(260, 23)
        Me.btnPops.TabIndex = 2
        Me.btnPops.Text = "POPS"
        Me.btnPops.UseVisualStyleBackColor = False
        '
        'btnSnake
        '
        Me.btnSnake.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnSnake.BackColor = System.Drawing.Color.Snow
        Me.btnSnake.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnSnake.Location = New System.Drawing.Point(12, 99)
        Me.btnSnake.Name = "btnSnake"
        Me.btnSnake.Size = New System.Drawing.Size(260, 23)
        Me.btnSnake.TabIndex = 3
        Me.btnSnake.Text = "Snake"
        Me.btnSnake.UseVisualStyleBackColor = False
        '
        'btnTanks
        '
        Me.btnTanks.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.btnTanks.BackColor = System.Drawing.Color.Snow
        Me.btnTanks.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.btnTanks.Location = New System.Drawing.Point(12, 41)
        Me.btnTanks.Name = "btnTanks"
        Me.btnTanks.Size = New System.Drawing.Size(260, 23)
        Me.btnTanks.TabIndex = 4
        Me.btnTanks.Text = "Cannon"
        Me.btnTanks.UseVisualStyleBackColor = False
        '
        'Zmbi
        '
        Me.Zmbi.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.Zmbi.BackColor = System.Drawing.Color.Snow
        Me.Zmbi.FlatStyle = System.Windows.Forms.FlatStyle.Flat
        Me.Zmbi.Location = New System.Drawing.Point(12, 157)
        Me.Zmbi.Name = "Zmbi"
        Me.Zmbi.Size = New System.Drawing.Size(260, 23)
        Me.Zmbi.TabIndex = 5
        Me.Zmbi.Text = "Zmbi"
        Me.Zmbi.UseVisualStyleBackColor = False
        '
        'MainScreen
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackColor = System.Drawing.SystemColors.GradientInactiveCaption
        Me.ClientSize = New System.Drawing.Size(284, 191)
        Me.Controls.Add(Me.Zmbi)
        Me.Controls.Add(Me.btnTanks)
        Me.Controls.Add(Me.btnSnake)
        Me.Controls.Add(Me.btnPops)
        Me.Controls.Add(Me.btnSudoku)
        Me.Controls.Add(Me.btnBMTron)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "MainScreen"
        Me.Text = "Games"
        Me.ResumeLayout(False)

    End Sub
    Friend WithEvents btnBMTron As System.Windows.Forms.Button
    Friend WithEvents btnSudoku As System.Windows.Forms.Button
    Friend WithEvents btnPops As System.Windows.Forms.Button
    Friend WithEvents btnSnake As System.Windows.Forms.Button
    Friend WithEvents btnTanks As System.Windows.Forms.Button
    Friend WithEvents Zmbi As System.Windows.Forms.Button
End Class
