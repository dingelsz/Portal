'Class for a space. A space is a place were all the physical objects are. It has functions for collision checking, gravity and moving characters.
'There are defaults for space that can be used by calling update() once physical objects have been added to the space. Most methods are public so they can 
'be customized, e.x. if you want to make someone jump whenever they hit a wall you can do it that way.

Imports Microsoft.VisualBasic

Public Class Space

    '==============================================================================================================
    '**************************************************************************************************************
    '-------------------------------------------------- Constructor -----------------------------------------------
    '**************************************************************************************************************
    '==============================================================================================================

    'A space takes a mass and a distance from a mass to create the gravity. Can be used to simulate different bodies like the sun
    Sub New(ByVal mass As Double, ByVal distance As Double)
        _gravity = (0.0000000000667259 * mass) / Math.Pow(distance * Math.Pow(10, 3), 2) 'Mass in kg, distance in km (thats what 1000 is for) formula is (G * m) / r^2 G = Gravity constant, m = mass, r = distance from mass aka gravity for moon is ( G * 1.3e+22) / 1180^2 ~= 0.62
    End Sub

    Sub New(ByVal mass As Double, ByVal distance As Double, ByVal Width As Integer, ByVal Height As Integer) 'Width and Height should be screen size
        Me.New(mass, distance)
        _border = New System.Drawing.Rectangle(0, 0, Width, Height)
    End Sub
    '==============================================================================================================
    '**************************************************************************************************************
    '-------------------------------------------------- Private Vars ----------------------------------------------
    '**************************************************************************************************************
    '==============================================================================================================
    Private _border As System.Drawing.Rectangle ' The border for the space, should be screen size

    Private _groups As New Group
    '==============================================================================================================
    '**************************************************************************************************************
    '--------------------------------------------------- Properties ------------------------------------------------
    '**************************************************************************************************************
    '==============================================================================================================
    Private _gravity As Double
    ReadOnly Property Gravity() As Double
        Get
            Return _gravity
        End Get

    End Property

    ReadOnly Property Border() As String
        Get
            Return (_border.Width.ToString & ", " & _border.Height)
        End Get
    End Property

    ReadOnly Property Height() As Double
        Get
            Return _border.Height
        End Get
    End Property

    ReadOnly Property Width() As Double
        Get
            Return _border.Width
        End Get
    End Property

    Dim _editPlatform As Boolean
    Public Property EditPlatforms() As Boolean
        Get
            Return _editPlatform
        End Get
        Set(ByVal value As Boolean)
            _editPlatform = value
        End Set
    End Property

    '==============================================================================================================
    '**************************************************************************************************************
    '---------------------------------------------------- Methods -------------------------------------------------
    '**************************************************************************************************************
    '==============================================================================================================

    Public Sub addGroup(ByRef list As Group)
        _groups.Add(list)
    End Sub

    Public Sub update()
        'Apply gravity
        For Each group In _groups
            moveGravity(group)
        Next

        'Check for collisions
        For Each group1 In _groups
            For Each group2 In _groups
                If group2.checked Then Continue For
                checkGroupCollision(group1, group2)
            Next
            group1.checked = True
        Next
        uncheckGroups(_groups)

        'ground friction for each sprite
        For Each g In _groups ' buggy
            checkFriction(g)
        Next

        'move grouops
        For Each group In _groups
            moveCharacters(group)
        Next
    End Sub

    'Takes two different groups and checks if each sprite in them collides. If they do then change there velocity depending on which side they hit. This is a preset
    'method so don't use if you want to customize.
    Public Function checkGroupCollision(ByRef list1 As Group, ByRef list2 As Group) As Integer
        For Each sprite1 As PhysicalObject In list1
            For Each sprite2 As PhysicalObject In list2
                Select Case spriteCollide(sprite1, sprite2)
                    Case 0
                        Dim tmp As Double = sprite1.YVelocity
                        If sprite1.Type = "Platform" Or sprite2.Type = "Platform" Then
                            Debug.Print(sprite1.YVelocity.ToString)
                            If (sprite1.YVelocity <= 2 And sprite1.YVelocity >= 0) And sprite2.Top - sprite1.Bottom < 5 Then
                                sprite1.Falling = False
                                sprite1.Moving = True
                                sprite1.XVelocity = 0
                                sprite1.Location = New Point(sprite1.Left, sprite2.Top - tmp - sprite1.Height - (sprite2.Top - sprite1.Bottom))
                                sprite1.StandingOn = New Rectangle(sprite2.Left, sprite2.Top, sprite2.Width, sprite2.Height)
                            Else
                                Debug.Print(sprite1.YVelocity * sprite1.BoundaryBounce.ToString)
                                sprite1.YVelocity = -sprite1.YVelocity * sprite1.BoundaryBounce
                            End If
                        Else
                            sprite1.YVelocity = (sprite2.YVelocity * sprite2.Mass) / sprite1.Mass
                        End If
                    Case 1
                        Debug.Print("yes")
                        If Not sprite2.Movable Then
                            sprite1.XVelocity = -sprite1.XVelocity * sprite1.BoundaryBounce
                        Else
                            Dim tmpv As Double = sprite2.XVelocity
                            sprite2.XVelocity += (sprite1.XVelocity * sprite1.Mass) / sprite2.Mass
                            sprite1.XVelocity -= (tmpv * sprite2.Mass) / sprite1.Mass
                            sprite2.Moving = True
                        End If
                    Case 2
                        If Not sprite2.Movable Then
                            sprite1.YVelocity = -sprite1.YVelocity * sprite1.BoundaryBounce
                        Else
                            sprite1.YVelocity = (sprite2.YVelocity * sprite2.Mass) / sprite1.Mass
                        End If
                    Case 3
                        Debug.Print("yes")
                        If Not sprite2.Movable Then
                            sprite1.XVelocity = -sprite1.XVelocity * sprite1.BoundaryBounce
                        Else
                            Dim tmpv As Double = sprite2.XVelocity
                            sprite2.XVelocity += (sprite1.XVelocity * sprite1.Mass) / sprite2.Mass
                            sprite1.XVelocity -= (tmpv * sprite2.Mass) / sprite1.Mass
                            sprite2.Moving = True
                        End If
                    Case Else
                End Select
            Next
        Next
    End Function


    'This method checks to see fi two physicalobjects hit each other. It returns an integer depending on what side, 0, 1, 2, 3 (angle of size / 90 - 1). If it doesn't hit then returns a sentinel of -1.
    'If the physicalobject + speed goes from one side of the other physicalObject to the other or inside then it hit the physical object. 
    Public Function spriteCollide(ByRef sprite1 As PhysicalObject, ByRef sprite2 As PhysicalObject) As Integer

        'Checks if the x and y collides with the other physicalobject
        Dim xInside As Boolean = isInside(sprite1.Right, sprite2.Left, sprite2.Right) Or isInside(sprite1.Left, sprite2.Left, sprite2.Right)
        Dim yInside As Boolean = isInside(sprite1.Top, sprite2.Top, sprite2.Bottom) Or isInside(sprite1.Bottom, sprite2.Top, sprite2.Bottom)
        'Hit top side
        If testLeftTopSide(sprite1.Bottom, sprite2.Top, sprite1.YVelocity) And xInside Then
            Return 0
        End If

        'If both axis collides on the same one as the second physical object then return a number depending on what side it hits
        'hit right side
        If testRightBottomSide(sprite1.Left, sprite2.Right, sprite1.XVelocity) Then
            If yInside Then
                Return 1
            End If
        End If

        'hit bottom side
        If testRightBottomSide(sprite1.Top, sprite2.Bottom, sprite1.YVelocity) Then
            If xInside Then
                Return 2
            End If
        End If

        'Hit left side
        If testLeftTopSide(sprite1.Right, sprite2.Left, sprite1.XVelocity) Then
            If yInside Then
                Return 3
            End If
        End If

        Return -1
    End Function

    'Used for testing the left or top side. If the point is < the second point and then is > when the velocity is added, it hits
    'Same thing for testRightBottom
    Private Function testLeftTopSide(ByVal p1 As Double, ByVal p2 As Double, ByVal v As Double) As Boolean
        If p1 <= p2 Then
            'Check if p1 + v is greater then p2 aka collides
            If p1 + v > p2 Then
                Return True
            End If
        End If
        Return False
    End Function

    Private Function testRightBottomSide(ByVal p1 As Double, ByVal p2 As Double, ByVal v As Double) As Boolean
        If p1 >= p2 Then 'If p1 + v is less then p2
            If p1 + v < p2 Then
                Return True
            End If
        End If
        Return False
    End Function

    'Checks to see if the point is inside between the other two. 
    Private Function isInside(ByVal p1 As Double, ByVal p2 As Double, ByVal p3 As Double) As Boolean
        If p1 >= p2 And p1 <= p3 Then Return True
        Return False
    End Function


    '------------------------------------------------END OF COLLISION DETECTION ---------------------------------

    'Moves each movable sprite if it is falling by the gravity
    Public Sub moveGravity(ByRef list As ArrayList)
        For Each sprite As PhysicalObject In list
            If sprite.Falling Then
                sprite.YVelocity += _gravity / 15
            End If
        Next
    End Sub

    'Moves each movable object if it is moving or falling and checks if it is goes of the screen.
    Public Sub moveCharacters(ByRef list As Group)
        For Each sprite As PhysicalObject In list
            If sprite.Moving Then
                sprite.Move(sprite.XVelocity, 0)
                If sprite.Right < sprite.StandingOn.Left Or sprite.Left > sprite.StandingOn.Right Then sprite.Falling = True
            End If
            If sprite.Falling Then
                sprite.Move(0, sprite.YVelocity)
            End If
        Next

        checkBorderCollision(list)
    End Sub

    Private Sub checkBorderCollision(ByRef list As Group)
        For Each sprite As PhysicalObject In list
            If sprite.Left + sprite.XVelocity <= 0 Then
                sprite.MoveToLocation(New System.Drawing.Point(0, sprite.Location.Y))
                sprite.XVelocity = -sprite.XVelocity * sprite.BoundaryBounce
            End If
            If sprite.Right + sprite.XVelocity >= _border.Width - 15 Then
                sprite.MoveToLocation(New System.Drawing.Point(_border.Width - 15 - CInt(sprite.Width), sprite.Location.Y))
                sprite.XVelocity = -sprite.XVelocity * sprite.BoundaryBounce
            End If
            'If goes above window, let him go, it looks strange if you don't
            'If sprite.Top + sprite.YVelocity <= 0 Then
            'sprite.MoveToLocation(New System.Drawing.Point(sprite.Location.X, 0))
            'sprite.YVelocity = -sprite.YVelocity
            'End If
            If sprite.Bottom + sprite.YVelocity >= _border.Height - 40 Then
                sprite.MoveToLocation(New System.Drawing.Point(sprite.Location.X, _border.Height - 40 - CInt(sprite.Height)))
                sprite.YVelocity = -sprite.YVelocity * sprite.BoundaryBounce
            End If
        Next
    End Sub

    'Friction for the object, this is a preset so change if you want.
    Private Sub checkFriction(ByVal list As Group)
        For Each sprite As PhysicalObject In list
            If Not sprite.Falling And (sprite.Right > sprite.StandingOn.Left Or sprite.Left < sprite.StandingOn.Right) Then
                If sprite.XVelocity < 0 Then sprite.XVelocity += 0.2
                If sprite.XVelocity > 0 Then sprite.XVelocity -= 0.2
            End If
        Next
    End Sub

    'Checks the distance between two points, should be used to figure out when collision detection is needed
    Private Function distance(ByVal d1 As Double, ByVal d2 As Double) As Double
        Return Math.Sqrt(Math.Pow(d1, 2) + Math.Pow(d2, 2))
    End Function

    'Unchecks each item in a list.
    Private Sub uncheckGroups(ByRef list As Group)
        For Each i In list
            i.checked = False
        Next
    End Sub
End Class
