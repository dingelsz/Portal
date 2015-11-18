Imports System.Windows.Forms

Public Class Dialog1

    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        setScenery()
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub


    Private _scenery As Scenery
    Public ReadOnly Property Scenery() As Scenery
        Get
            Return _scenery
        End Get
    End Property

    Private Sub setScenery()
        _scenery = New Scenery(NumericUpDown1.Value, NumericUpDown2.Value)
        _scenery.Image = PictureBox1.Image
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Dim dialog As New OpenFileDialog()
        dialog.ShowDialog()
        PictureBox1.Image = New Bitmap(dialog.FileName)
    End Sub
End Class
