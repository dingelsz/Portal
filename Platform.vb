'Platform class for platforms in the game. Has multiple images depending on were the platform is (if it's below another use bottom image)

Public Class Platform
    Inherits PhysicalObject

    '==============================================================================================================
    '**************************************************************************************************************
    '-------------------------------------------------- Construcotr -----------------------------------------------
    '**************************************************************************************************************
    '==============================================================================================================

    'The defualt images are 25 x 10 so using those dimensions help.
    Sub New(ByVal x As Double, ByVal y As Double, ByVal Width As Double, ByVal Height As Double)
        MyBase.New(x, y, Width, Height, 0, "Platform")
        Movable = False
    End Sub

    '==============================================================================================================
    '**************************************************************************************************************
    '-------------------------------------------------- Properties ------------------------------------------------
    '**************************************************************************************************************
    '==============================================================================================================

    Private _topImage As Bitmap = New Bitmap("bmp\platform.bmp")
    Public ReadOnly Property TopImage()
        Get
            Return _topImage
        End Get
    End Property

    Private _bottomImage As Bitmap = New Bitmap("bmp\platformbottom.bmp")
    Public ReadOnly Property BottomImage() As Bitmap
        Get
            Return _bottomImage
        End Get
    End Property

End Class
