'Filename: Character.vb
'Author: Zach Dingels
'-----------------------
'This is a class for a character. A character is basiclly any sprite that moves around and is intended to be a human player. It has functions for moving around inside a space
Public Class Character
    Inherits PhysicalObject 'Every object should inherit this or a subclass of it

    '==============================================================================================================
    '**************************************************************************************************************
    '------------------------------------------------- Constructors -----------------------------------------------
    '**************************************************************************************************************
    '==============================================================================================================

    'When making a new character you must provide a width, height and mass. You can also give it a position.
    Sub New(ByVal x As Double, ByVal y As Double, ByVal Width As Integer, ByVal Height As Integer, ByVal Mass As Double)
        Me.New(Width, Height, Mass)
        Location = New Point(x, y)
    End Sub

    Sub New(ByVal Width As Double, ByVal Height As Double, ByVal Mass As Double)
        MyBase.New(Width, Height, Mass, "Character")
        Movable = True
        Speed = 5
    End Sub

    '==============================================================================================================
    '**************************************************************************************************************
    '-------------------------------------------------- Properties ------------------------------------------------
    '**************************************************************************************************************
    '==============================================================================================================

    'How fast the character moves left and right
    Private _speed As Double
    Public Property Speed() As Double
        Get
            Return _speed
        End Get
        Set(ByVal value As Double)
            _speed = value
        End Set
    End Property

    'How fast the character moves up
    Private _jump As Double = 5
    Public Property JumpPower() As Double
        Get
            Return _jump
        End Get
        Set(ByVal value As Double)
            _jump = value
        End Set
    End Property

    'How many times the character can jump.
    Private _doubleJump As Int16 = False
    Public Property DoubleJump() As Int16
        Get
            Return _doubleJump
        End Get
        Set(ByVal value As Int16)
            _doubleJump = value
        End Set
    End Property

    'Image for the character, make sure it is the same size as the characters width and height.
    Private _image As Bitmap
    Public Property Image() As Bitmap
        Get
            Return _image
        End Get
        Set(ByVal value As Bitmap)
            _image = value
            Try
                _image.MakeTransparent()
            Catch ex As Exception

            End Try
        End Set
    End Property


    '==============================================================================================================
    '**************************************************************************************************************
    '---------------------------------------------------- Methods -------------------------------------------------
    '**************************************************************************************************************
    '==============================================================================================================

    'Moves the sprite to the right or left, if it is falling it moves slower. 
    Public Sub moveRight()
        Moving = True
        If XVelocity < _speed Then
            If Not DoubleJump Then
                XVelocity = _speed
            Else
                XVelocity = _speed / 2
            End If
        End If
    End Sub

    Public Sub moveLeft()
        Moving = True
        If XVelocity > -_speed Then
            If Not DoubleJump Then
                XVelocity = -_speed
            Else
                XVelocity = -_speed / 2
            End If
        End If
    End Sub

    'Makes the character move up depending on it's jump power and if it still has jumps left.
    Public Sub jump()
        If Not Falling Then
            DoubleJump = 0
        End If
        If DoubleJump = -1 Or DoubleJump = 2 Then
            Exit Sub
        End If
        DoubleJump += 1
        YVelocity -= _jump
        Falling = True
    End Sub

    'Stops the character from moving on the x axis.
    Public Sub halt()
        If Not Falling Then
            Moving = False
            XVelocity = 0
        End If
    End Sub

End Class
