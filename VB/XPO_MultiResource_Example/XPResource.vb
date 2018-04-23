Imports DevExpress.Xpo
Imports System
Imports System.Drawing

Namespace XPO_MultiResource_Example
	#Region "#xpresource"
	' XP object
	Public Class XPResource
		Inherits XPObject

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub
		Public ResId As Integer
		<Size(SizeAttribute.Unlimited)>
		Public Name As String ' Resource.Caption -  !!! To set the Memo field type.
		Public Color As Int32
		Public Image As Image

		<Association()>
		Public ReadOnly Property Appointments() As XPCollection(Of XPAppointment)
			Get
				Return GetCollection(Of XPAppointment)("Appointments")
			End Get
		End Property
	End Class
	#End Region ' #xpresource
End Namespace