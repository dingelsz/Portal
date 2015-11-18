Imports Portal.Character
Imports Portal.Space
Public Class Form1

    Private Const S_WIDTH As Double = 800 'Dimensions of the window
    Private Const S_HEIGHT As Double = 600

    Private actions As New Stack
    Private mp As New Point()

    'Set the background image
    Private bgImage As Bitmap = New Bitmap("bmp\bg.bmp")

    'Create a new space
    Private space As New Space(5.9742E+24, 6731.1, S_WIDTH, S_WIDTH)
    Friend player As New Character(5, 400, 10, 25, 10)
    Private enemy As New Character(5, 5, 10, 25, 20)
    Friend scene As Scenery
    Private block As PhysicalObject

    Private platforms As New Group
    Friend players As New Group
    Private blocks As New Group
    Private scenery As New Group

    Private sceneryMode As Boolean

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load
        players.Add(player)
        players.Add(enemy)

        space.addGroup(players)
        space.addGroup(platforms)

        platforms.Add(New Platform(0, 500, 800, 200))

        enemy.Image = New Bitmap("bmp\enemy.bmp")
        enemy.JumpPower = 10
        enemy.Falling = True
        player.Image = New Bitmap("bmp\player.bmp")
        player.JumpPower = 7
        player.Falling = True

        player.BoundaryBounce = 0

        Debug.Print(space.Gravity.ToString)

        DoubleBuffered = True
    End Sub

    Private p As Point = New Point
    Private num As Integer

    Private Sub Form1_Paint(ByVal sender As System.Object, ByVal e As System.Windows.Forms.PaintEventArgs) Handles MyBase.Paint
        e.Graphics.DrawImage(bgImage, New Point(0, 0))

        If scenery.Count > 0 Then
            For Each scene As Scenery In scenery
                e.Graphics.DrawImage(scene.Image, scene.Location)
            Next
        End If

        For Each p As Character In players
            e.Graphics.DrawImage(p.Image, p.Location)
        Next

        'e.Graphics.DrawImage(enemy.Image, enemy.Location)
        platforms.Reverse()
        For Each Plat As Platform In platforms
            For row As Integer = 0 To Plat.Width / 25 - 1
                For Column As Integer = 0 To Plat.Height / 10 - 1
                    If Column = 0 Then
                        e.Graphics.DrawImage(Plat.TopImage, New Point(Plat.Left + row * 25, Plat.Top + Column * 10))
                    Else
                        e.Graphics.DrawImage(Plat.BottomImage, New Point(Plat.Left + row * 25, Plat.Top + Column * 10))
                    End If

                Next
            Next
            If space.EditPlatforms Then
                e.Graphics.DrawRectangle(Pens.Blue, New Rectangle(Plat.Left - 2, Plat.Top - 2, Plat.Width + 4, Plat.Height + 4))
            End If
        Next
        platforms.Reverse()

        If space.EditPlatforms Then
            For row As Integer = 0 To Me.Height / 10
                e.Graphics.DrawLine(Pens.Silver, 0, row * 10, Me.Width, row * 10)
            Next
            For column As Integer = 0 To Me.Width / 25
                e.Graphics.DrawLine(Pens.Silver, column * 25, 0, column * 25, Me.Height)
            Next
        End If
    End Sub

    Private Sub Form1_KeyDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyDown
        Select Case e.KeyCode
            Case Keys.Right
                player.moveRight()
            Case Keys.Left
                player.moveLeft()
            Case Keys.D
                enemy.moveRight()
            Case Keys.A
                enemy.moveLeft()
            Case Keys.Up
                player.jump()
            Case Keys.W
                enemy.jump()
        End Select
    End Sub

    Private Sub Form1_KeyUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.KeyEventArgs) Handles MyBase.KeyUp
        Select Case e.KeyCode
            Case Keys.Right
                player.halt()
            Case Keys.Left
                player.halt()
            Case Keys.D
                enemy.halt()
            Case Keys.A
                enemy.halt()
        End Select

        If e.Control Then
            Select Case e.KeyCode
                Case Keys.Q
                    Application.ExitThread()
            End Select
        End If
    End Sub

    Private Sub gameLoop()
        MsgBox("starting..")
        While True
            Application.DoEvents()
            space.update()
            Refresh()
            Update()
            Threading.Thread.Sleep(31)
        End While
    End Sub

    Private Sub Button1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Button1.Click
        Button1.Hide()
        gameLoop()
    End Sub

    Private Sub Form1_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles MyBase.MouseDown
        If space.EditPlatforms Then
            mp = New Point(e.X, e.Y)
            Debug.Print(e.ToString)
        End If

        If sceneryMode Then
            scene.Location = e.Location
            scenery.Add(scene)
        End If
    End Sub

    Private Sub mouse(ByVal sender As Object, ByVal e As MouseEventArgs) Handles Me.MouseUp
        If mp.Equals(e.Location) Then
            platforms.Reverse()
            For Each plat As Platform In platforms
                If (e.X >= plat.Left And e.X <= plat.Right) And (e.Y >= plat.Top And e.Y <= plat.Bottom) Then
                    platforms.RemoveAt(platforms.IndexOf(plat))
                    Exit Sub
                End If
            Next
            platforms.Reverse()
        End If
        If space.EditPlatforms Then
            drawPlatform(e.Location)
        End If
    End Sub

    Private Sub drawPlatform(ByRef e As Point)
        Dim x As Integer = mp.X
        Dim y As Integer = mp.Y
        Dim w As Integer = Math.Abs(mp.X - e.X)
        Dim h As Integer = Math.Abs(mp.Y - e.Y)
        If e.X < mp.X Then x = e.X
        If e.Y < mp.Y Then y = e.Y

        platforms.Add(New Platform(snapOn(x, 25), snapOn(y, 10), snapOn(w, 25) + 25, snapOn(h, 10) + 10))
    End Sub

    Private Sub BackgroundToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles BackgroundToolStripMenuItem.Click
        Try
            Dim dialog As New OpenFileDialog
            dialog.ShowDialog()
            bgImage = New Bitmap(dialog.FileName)
        Catch ex As Exception
        End Try
    End Sub

    Private Sub ExitToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles ExitToolStripMenuItem.Click
        Application.ExitThread()
    End Sub

    Private Sub PlayerToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlayerToolStripMenuItem1.Click
        Dim playerDialog As New PlayerEditor
        playerDialog.Show()
    End Sub

    Private Function snapOn(ByVal position As Double, ByVal scale As Double) As Double
        position = CInt(position / scale) * scale
        Return CDbl(position)
    End Function

    Private Sub PlatfromsToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles PlatfromsToolStripMenuItem.Click
        If space.EditPlatforms Then
            space.EditPlatforms = False
        Else
            space.EditPlatforms = True
        End If
    End Sub

    Private Sub SceneryEditorToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles SceneryEditorToolStripMenuItem.Click
        Dim dialog As New SceneryDialog()
        dialog.Show()
    End Sub

    Private Sub DrawSceneryToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles DrawSceneryToolStripMenuItem.Click
        sceneryMode = Not sceneryMode
    End Sub

    Private Sub NewToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles NewToolStripMenuItem.Click
        Dim form As New Form1
        form.Show()
    End Sub

    Private Sub CloseToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles CloseToolStripMenuItem.Click
        Me.Close()
    End Sub

    Private Sub AboutToolStripMenuItem_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles AboutToolStripMenuItem.Click
        Dim form As New GameAbout()
        form.Show()
    End Sub

    Private Sub HelpToolStripMenuItem1_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles HelpToolStripMenuItem1.Click
        Dim help As New Help()
        help.Show()
    End Sub
End Class
