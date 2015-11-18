'Class for scenery. Scenery is not a physical object because it is just a picture and doesn't interact with the rest of the space.

Public Class Scenery

    '==============================================================================================================
    '**************************************************************************************************************
    '-------------------------------------------------- Constructor -----------------------------------------------
    '**************************************************************************************************************
    '==============================================================================================================

    Sub New(ByVal Width As Double, ByVal Height As Double)
        _width = Width
        _height = Height
    End Sub

    Sub New(ByVal P As Point, ByVal Width As Double, ByVal Height As Double)
        _location = P
        _width = Width
        _height = Height
    End Sub

    Sub New(ByVal x As Double, ByVal y As Double, ByVal Width As Double, ByVal Height As Double)
        Me.New(New Point(x, y), Width, Height)
    End Sub

    '==============================================================================================================
    '**************************************************************************************************************
    '-------------------------------------------------- Properties ------------------------------------------------
    '**************************************************************************************************************
    '==============================================================================================================

    Private _width As Double
    Public ReadOnly Property Width() As Double
        Get
            Return _width
        End Get
    End Property

    Private _height As Double
    Public ReadOnly Property Height() As Double
        Get
            Return _height
        End Get
    End Property

    Private _location As Point
    Public Property Location() As Point
        Get
            Return _location
        End Get
        Set(ByVal value As Point)
            _location = value
        End Set
    End Property

    Private _image As Bitmap
    Public Property Image() As Bitmap
        Get
            Return _image
        End Get
        Set(ByVal value As Bitmap)
            _image = value
        End Set
    End Property

End Class
