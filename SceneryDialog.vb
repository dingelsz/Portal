'Dialog for a scenery editor that creates new scenery inside the main window.

Imports System.Windows.Forms

Public Class SceneryDialog

    'Set the scenery variable inside the main form to the one created
    Private Sub OK_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles OK_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.OK
        setScenery()
        Me.Close()
    End Sub

    Private Sub Cancel_Button_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Cancel_Button.Click
        Me.DialogResult = System.Windows.Forms.DialogResult.Cancel
        Me.Close()
    End Sub

    Private _image As Bitmap

    'set the scenery to the current selected values
    Private Sub setScenery()
        Form1.scene = New Scenery(NumericUpDown1.Value, NumericUpDown2.Value)
        Form1.scene.Image = _image
        Form1.scene.Image.MakeTransparent()
    End Sub

    'Open an image
    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImage.Click
        Dim dialog As New OpenFileDialog()
        dialog.ShowDialog()
        _image = New Bitmap(dialog.FileName)
        _image.MakeTransparent()
        PictureBox1.Image = _image
    End Sub
End Class
