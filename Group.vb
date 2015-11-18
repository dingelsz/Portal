'Group is a special array that has a flag that is used when checking comparing it to other groups, to make sure a group only gets checked once. Like the
'handshake problem, you only want to shake a hand once.
Public Class Group
    Inherits ArrayList
    Public Sub New()
        MyBase.New()
    End Sub

    'Use this when doing collision checks to see if group has been checked against other.
    Private _checked As Boolean
    Public Property Checked() As Boolean
        Get
            Return _checked
        End Get
        Set(ByVal value As Boolean)
            _checked = value
        End Set
    End Property


End Class
