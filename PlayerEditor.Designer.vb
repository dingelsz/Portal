<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class PlayerEditor
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
        Me.LabelTitle = New System.Windows.Forms.Label
        Me.LabelSpeed = New System.Windows.Forms.Label
        Me.LabelJump = New System.Windows.Forms.Label
        Me.LabelJumps = New System.Windows.Forms.Label
        Me.PictureBoxImage = New System.Windows.Forms.PictureBox
        Me.ButtonOk = New System.Windows.Forms.Button
        Me.ButtonCancel = New System.Windows.Forms.Button
        Me.ButtonImage = New System.Windows.Forms.Button
        Me.LabelMass = New System.Windows.Forms.Label
        Me.LabelHeight = New System.Windows.Forms.Label
        Me.LabelWidth = New System.Windows.Forms.Label
        Me.NumericUpDownMass = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDownJumps = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDownSpeed = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDownPower = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDownY = New System.Windows.Forms.NumericUpDown
        Me.NumericUpDownX = New System.Windows.Forms.NumericUpDown
        Me.Label1 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Button1 = New System.Windows.Forms.Button
        CType(Me.PictureBoxImage, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownMass, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownJumps, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownPower, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownY, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.NumericUpDownX, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'LabelTitle
        '
        Me.LabelTitle.AutoSize = True
        Me.LabelTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 24.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelTitle.Location = New System.Drawing.Point(99, 9)
        Me.LabelTitle.Name = "LabelTitle"
        Me.LabelTitle.Size = New System.Drawing.Size(212, 37)
        Me.LabelTitle.TabIndex = 2
        Me.LabelTitle.Text = "Player Editor"
        '
        'LabelSpeed
        '
        Me.LabelSpeed.AutoSize = True
        Me.LabelSpeed.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelSpeed.Location = New System.Drawing.Point(163, 60)
        Me.LabelSpeed.Name = "LabelSpeed"
        Me.LabelSpeed.Size = New System.Drawing.Size(64, 20)
        Me.LabelSpeed.TabIndex = 3
        Me.LabelSpeed.Text = "Speed: "
        '
        'LabelJump
        '
        Me.LabelJump.AutoSize = True
        Me.LabelJump.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelJump.Location = New System.Drawing.Point(163, 86)
        Me.LabelJump.Name = "LabelJump"
        Me.LabelJump.Size = New System.Drawing.Size(100, 20)
        Me.LabelJump.TabIndex = 4
        Me.LabelJump.Text = "Jump Power:"
        '
        'LabelJumps
        '
        Me.LabelJumps.AutoSize = True
        Me.LabelJumps.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelJumps.Location = New System.Drawing.Point(163, 112)
        Me.LabelJumps.Name = "LabelJumps"
        Me.LabelJumps.Size = New System.Drawing.Size(60, 20)
        Me.LabelJumps.TabIndex = 6
        Me.LabelJumps.Text = "Jumps:"
        '
        'PictureBoxImage
        '
        Me.PictureBoxImage.Location = New System.Drawing.Point(126, 152)
        Me.PictureBoxImage.Name = "PictureBoxImage"
        Me.PictureBoxImage.Size = New System.Drawing.Size(136, 96)
        Me.PictureBoxImage.TabIndex = 7
        Me.PictureBoxImage.TabStop = False
        '
        'ButtonOk
        '
        Me.ButtonOk.Location = New System.Drawing.Point(144, 302)
        Me.ButtonOk.Name = "ButtonOk"
        Me.ButtonOk.Size = New System.Drawing.Size(75, 23)
        Me.ButtonOk.TabIndex = 8
        Me.ButtonOk.Text = "Ok"
        Me.ButtonOk.UseVisualStyleBackColor = True
        '
        'ButtonCancel
        '
        Me.ButtonCancel.Location = New System.Drawing.Point(63, 302)
        Me.ButtonCancel.Name = "ButtonCancel"
        Me.ButtonCancel.Size = New System.Drawing.Size(75, 23)
        Me.ButtonCancel.TabIndex = 9
        Me.ButtonCancel.Text = "Cancel"
        Me.ButtonCancel.UseVisualStyleBackColor = True
        '
        'ButtonImage
        '
        Me.ButtonImage.Location = New System.Drawing.Point(16, 225)
        Me.ButtonImage.Name = "ButtonImage"
        Me.ButtonImage.Size = New System.Drawing.Size(89, 23)
        Me.ButtonImage.TabIndex = 10
        Me.ButtonImage.Text = "Open Image..."
        Me.ButtonImage.UseVisualStyleBackColor = True
        '
        'LabelMass
        '
        Me.LabelMass.AutoSize = True
        Me.LabelMass.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelMass.Location = New System.Drawing.Point(12, 112)
        Me.LabelMass.Name = "LabelMass"
        Me.LabelMass.Size = New System.Drawing.Size(55, 20)
        Me.LabelMass.TabIndex = 16
        Me.LabelMass.Text = "Mass: "
        '
        'LabelHeight
        '
        Me.LabelHeight.AutoSize = True
        Me.LabelHeight.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelHeight.Location = New System.Drawing.Point(12, 86)
        Me.LabelHeight.Name = "LabelHeight"
        Me.LabelHeight.Size = New System.Drawing.Size(160, 20)
        Me.LabelHeight.TabIndex = 14
        Me.LabelHeight.Text = "Height: Image Height"
        '
        'LabelWidth
        '
        Me.LabelWidth.AutoSize = True
        Me.LabelWidth.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.LabelWidth.Location = New System.Drawing.Point(12, 60)
        Me.LabelWidth.Name = "LabelWidth"
        Me.LabelWidth.Size = New System.Drawing.Size(148, 20)
        Me.LabelWidth.TabIndex = 13
        Me.LabelWidth.Text = "Width: Image Width"
        '
        'NumericUpDownMass
        '
        Me.NumericUpDownMass.Location = New System.Drawing.Point(73, 115)
        Me.NumericUpDownMass.Name = "NumericUpDownMass"
        Me.NumericUpDownMass.Size = New System.Drawing.Size(67, 20)
        Me.NumericUpDownMass.TabIndex = 19
        '
        'NumericUpDownJumps
        '
        Me.NumericUpDownJumps.Location = New System.Drawing.Point(258, 115)
        Me.NumericUpDownJumps.Name = "NumericUpDownJumps"
        Me.NumericUpDownJumps.Size = New System.Drawing.Size(67, 20)
        Me.NumericUpDownJumps.TabIndex = 22
        '
        'NumericUpDownSpeed
        '
        Me.NumericUpDownSpeed.Location = New System.Drawing.Point(258, 59)
        Me.NumericUpDownSpeed.Name = "NumericUpDownSpeed"
        Me.NumericUpDownSpeed.Size = New System.Drawing.Size(67, 20)
        Me.NumericUpDownSpeed.TabIndex = 21
        '
        'NumericUpDownPower
        '
        Me.NumericUpDownPower.Location = New System.Drawing.Point(258, 85)
        Me.NumericUpDownPower.Name = "NumericUpDownPower"
        Me.NumericUpDownPower.Size = New System.Drawing.Size(67, 20)
        Me.NumericUpDownPower.TabIndex = 20
        '
        'NumericUpDownY
        '
        Me.NumericUpDownY.Location = New System.Drawing.Point(219, 266)
        Me.NumericUpDownY.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDownY.Minimum = New Decimal(New Integer() {10000, 0, 0, -2147483648})
        Me.NumericUpDownY.Name = "NumericUpDownY"
        Me.NumericUpDownY.Size = New System.Drawing.Size(43, 20)
        Me.NumericUpDownY.TabIndex = 23
        '
        'NumericUpDownX
        '
        Me.NumericUpDownX.Location = New System.Drawing.Point(130, 266)
        Me.NumericUpDownX.Maximum = New Decimal(New Integer() {100000, 0, 0, 0})
        Me.NumericUpDownX.Minimum = New Decimal(New Integer() {10000, 0, 0, -2147483648})
        Me.NumericUpDownX.Name = "NumericUpDownX"
        Me.NumericUpDownX.Size = New System.Drawing.Size(43, 20)
        Me.NumericUpDownX.TabIndex = 24
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(102, 263)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(24, 20)
        Me.Label1.TabIndex = 25
        Me.Label1.Text = "X:"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label2.Location = New System.Drawing.Point(191, 263)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(24, 20)
        Me.Label2.TabIndex = 26
        Me.Label2.Text = "Y:"
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(225, 302)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 27
        Me.Button1.Text = "New Player"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'PlayerEditor
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(378, 337)
        Me.Controls.Add(Me.Button1)
        Me.Controls.Add(Me.Label2)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.NumericUpDownX)
        Me.Controls.Add(Me.NumericUpDownY)
        Me.Controls.Add(Me.NumericUpDownJumps)
        Me.Controls.Add(Me.NumericUpDownSpeed)
        Me.Controls.Add(Me.NumericUpDownPower)
        Me.Controls.Add(Me.NumericUpDownMass)
        Me.Controls.Add(Me.LabelMass)
        Me.Controls.Add(Me.LabelHeight)
        Me.Controls.Add(Me.LabelWidth)
        Me.Controls.Add(Me.ButtonImage)
        Me.Controls.Add(Me.ButtonCancel)
        Me.Controls.Add(Me.ButtonOk)
        Me.Controls.Add(Me.PictureBoxImage)
        Me.Controls.Add(Me.LabelJumps)
        Me.Controls.Add(Me.LabelJump)
        Me.Controls.Add(Me.LabelSpeed)
        Me.Controls.Add(Me.LabelTitle)
        Me.Name = "PlayerEditor"
        Me.Text = "PlayerEditor"
        CType(Me.PictureBoxImage, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownMass, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownJumps, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownPower, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownY, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.NumericUpDownX, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents LabelTitle As System.Windows.Forms.Label
    Friend WithEvents LabelSpeed As System.Windows.Forms.Label
    Friend WithEvents LabelJump As System.Windows.Forms.Label
    Friend WithEvents LabelJumps As System.Windows.Forms.Label
    Friend WithEvents PictureBoxImage As System.Windows.Forms.PictureBox
    Friend WithEvents ButtonOk As System.Windows.Forms.Button
    Friend WithEvents ButtonCancel As System.Windows.Forms.Button
    Friend WithEvents ButtonImage As System.Windows.Forms.Button
    Friend WithEvents LabelMass As System.Windows.Forms.Label
    Friend WithEvents LabelHeight As System.Windows.Forms.Label
    Friend WithEvents LabelWidth As System.Windows.Forms.Label
    Friend WithEvents NumericUpDownMass As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownJumps As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownSpeed As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownPower As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownY As System.Windows.Forms.NumericUpDown
    Friend WithEvents NumericUpDownX As System.Windows.Forms.NumericUpDown
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Button1 As System.Windows.Forms.Button
End Class
