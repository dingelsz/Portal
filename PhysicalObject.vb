'This is the base class for all of the objects in the game. Every physicalobject must have has a width, height, mass, and type as well as
'multiple flags for different reasons (because vb is so awesome I can't put them in child)

'==============================================================================================================
'**************************************************************************************************************
'-------------------------------------------------- Constructor -----------------------------------------------
'**************************************************************************************************************
'==============================================================================================================

Public Class PhysicalObject
    Sub New(ByVal Width As Double, ByVal Height As Double, ByVal Mass As Double, ByVal Type As String)
        _width = Width
        _height = Height
        _mass = Mass
        _type = Type

    End Sub

    Sub New(ByVal x As Double, ByVal y As Double, ByVal Width As Integer, ByVal Height As Integer, ByVal Mass As Double, ByVal Type As String)
        Me.New(Width, Height, Mass, Type)
        _location.X = x
        _location.Y = y
        _boundaryBounce = 0.75
    End Sub

    '==============================================================================================================
    '**************************************************************************************************************
    '-------------------------------------------------- Properties ------------------------------------------------
    '**************************************************************************************************************
    '==============================================================================================================

    Private _type As String
    Public ReadOnly Property Type() As String
        Get
            Return _type
        End Get
    End Property


    Private _height As Double
    ReadOnly Property Height() As Double
        Get
            Return _height
        End Get
    End Property

    Private _width As Double
    ReadOnly Property Width() As Double
        Get
            Return _width
        End Get
    End Property

    ReadOnly Property Area() As Double
        Get
            Return _width * _height
        End Get
    End Property

    Private _mass As Double
    ReadOnly Property Mass() As Double
        Get
            Return _mass
        End Get
    End Property

    Private _location As System.Drawing.Point
    Public Property Location() As System.Drawing.Point
        Get
            Return _location
        End Get
        Set(ByVal value As System.Drawing.Point)
            _location = value
        End Set
    End Property

    Public ReadOnly Property Top() As Integer
        Get
            Return Location.Y
        End Get
    End Property

    Public ReadOnly Property Right() As Integer
        Get
            Return Location.X + _width
        End Get
    End Property

    Public ReadOnly Property Bottom() As Integer
        Get
            Return Location.Y + _height
        End Get
    End Property

    Public ReadOnly Property Left() As Integer
        Get
            Return Location.X
        End Get
    End Property

    Private _movable As Boolean
    Public Property Movable() As Boolean
        Set(ByVal value As Boolean)
            _movable = value
        End Set
        Get
            Return _movable
        End Get
    End Property

    Private _xVelocity As Double
    Public Property XVelocity() As Double
        Get
            Return _xVelocity
        End Get
        Set(ByVal value As Double)
            _xVelocity = value
        End Set
    End Property

    Private _yVelocity As Double
    Public Property YVelocity() As Double
        Get
            Return _yVelocity
        End Get
        Set(ByVal value As Double)
            _yVelocity = value
        End Set
    End Property

    Private _moving As Boolean
    Public Property Moving() As Boolean
        Get
            Return _moving
        End Get
        Set(ByVal value As Boolean)
            _moving = value
        End Set
    End Property


    Private _falling As Boolean = False
    Public Property Falling() As Boolean
        Get
            Return _falling
        End Get
        Set(ByVal value As Boolean)
            _falling = value
        End Set
    End Property

    Private _boundaryBounce As Double
    Public Property BoundaryBounce() As Double
        Get
            Return _boundaryBounce
        End Get
        Set(ByVal value As Double)
            If value < 0 Or value > 1 Then
                Debug.Print("---Error--- Set a valid BOUNDARY BOUNCE: 0 < value < 1. No value set.")
            Else
                _boundaryBounce = value
            End If
        End Set
    End Property

    Public Property XMomentum() As Double
        Get
            Return _mass * _xVelocity
        End Get
        Set(ByVal value As Double)
            _xVelocity = value / _mass
        End Set
    End Property

    Public Property YMomentum() As Double
        Get
            Return _mass * _yVelocity
        End Get
        Set(ByVal value As Double)
            _yVelocity = value / _mass
        End Set
    End Property

    Private _collisionChecked As Boolean = False
    Public Property collisionChecked() As Boolean
        Get
            Return _collisionChecked
        End Get
        Set(ByVal value As Boolean)
            _collisionChecked = value
        End Set
    End Property

    Private _standingOn As Rectangle
    Public Property StandingOn() As Rectangle
        Get
            Return _standingOn
        End Get
        Set(ByVal value As Rectangle)
            _standingOn = value
        End Set
    End Property

    '==============================================================================================================
    '**************************************************************************************************************
    '---------------------------------------------------- Methods -------------------------------------------------
    '**************************************************************************************************************
    '==============================================================================================================

    'Different move methods for moving the character, you can move relavent to your current location, to the origin or just pass in a point.
    Public Sub Move(ByVal x As Double, ByVal y As Double)
        Debug.Print(x.ToString)
        _location = New System.Drawing.Point(Location.X + x, Location.Y + y)
    End Sub

    Public Sub MoveToLocation(ByVal x As Double, ByVal y As Double)
        _location = New System.Drawing.Point(x, y)
    End Sub

    Public Sub MoveToLocation(ByRef p As System.Drawing.Point)
        _location = p
    End Sub

End Class
