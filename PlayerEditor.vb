'Dialog form to edit the player. Has different options, like changing the speed, power and image of the player.

Public Class PlayerEditor
    Private playerCopy As Character
    Private _player As Character

    Private Sub ButtonImage_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonImage.Click
        Dim imageDialog As New OpenFileDialog
        imageDialog.ShowDialog()
        PictureBoxImage.Image = New Bitmap(imageDialog.FileName)
    End Sub

    Private Sub ButtonCancel_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonCancel.Click
        Me.Close()
    End Sub

    Private Sub ButtonOk_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ButtonOk.Click
        Form1.player.Speed = NumericUpDownSpeed.Value
        Form1.player.JumpPower = NumericUpDownPower.Value
        Form1.player.DoubleJump = NumericUpDownJumps.Value
        Form1.player.Image = PictureBoxImage.Image
        Me.Close()
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Form1.players.Add(New Character(NumericUpDownX.Value, NumericUpDownY.Value, 50, 100, NumericUpDownMass.Value))
        Form1.players(Form1.players.Count - 1).image = PictureBoxImage.Image
        Form1.players(Form1.players.Count - 1).falling = True

    End Sub

    Private Sub PlayerEditor_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        PictureBoxImage.Image = Form1.player.Image
        NumericUpDownJumps.Value = Form1.player.DoubleJump
        NumericUpDownPower.Value = Form1.player.JumpPower
        NumericUpDownMass.Value = Form1.player.Mass
        NumericUpDownSpeed.Value = Form1.player.Speed
        NumericUpDownX.Value = Form1.player.Location.X
        NumericUpDownY.Value = Form1.player.Location.Y



    End Sub

End Class