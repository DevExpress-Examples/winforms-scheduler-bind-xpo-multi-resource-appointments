Imports Microsoft.VisualBasic
Imports System
Imports System.Xml
Imports System.Text
#Region "#usings"
Imports System.Drawing
Imports DevExpress.Xpo
Imports DevExpress.Xpo.Metadata
Imports DevExpress.XtraScheduler
Imports DevExpress.Utils.Serializing.Helpers
Imports DevExpress.XtraScheduler.Xml
#End Region ' #usings


Namespace XPO_Bound_Multiresource
	#Region "#xpappointment"
	' XP object
	Public Class XPAppointment
		Inherits XPObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Public AllDay As Boolean ' Appointment.AllDay

		<Size(SizeAttribute.Unlimited)> _
		Public Description As String ' Appointment.Description

		Public Finish As DateTime ' Appointment.End
		Public Label As Integer ' Appointment.Label
		Public Location As String ' Appointment.Location

		<Size(SizeAttribute.Unlimited)> _
		Public Recurrence As String ' Appointment.RecurrenceInfo

		<Size(SizeAttribute.Unlimited)> _
		Public Reminder As String ' Appointment.ReminderInfo

		Public Created As DateTime ' Appointment.Start
		Public Status As Integer ' Appointment.Status
		<Size(SizeAttribute.Unlimited)> _
		Public Subject As String ' Appointment.Subject
		Public AppointmentType As Integer ' Appointment.Type

		<Association()> _
		Public ReadOnly Property Resources() As XPCollection(Of XPResource)
			Get
				Return GetCollection(Of XPResource)("Resources")
			End Get
		End Property

		<NonPersistent()> _
		Public Property ResourceIds() As String
			Get
				Return GenerateResourceIdsString()
			End Get
			Set(ByVal value As String)
'INSTANT VB NOTE: The local variable resourceIds was renamed since Visual Basic will not allow local variables with the same name as their enclosing function or property:
				Dim resourceIds_Renamed As ResourceIdCollection = GenerateResourceIdsString(value)
				Resources.SuspendChangedEvents()
				Try
					ClearResources()
					Dim count As Integer = resourceIds_Renamed.Count
					For i As Integer = 0 To count - 1
						Dim resource As XPResource = Me.Session.GetObjectByKey(Of XPResource)(resourceIds_Renamed(i))
						If resource IsNot Nothing Then
							Resources.Add(resource)
						End If
					Next i
				Finally
					Resources.ResumeChangedEvents()
				End Try
			End Set
		End Property

		Private Sub ClearResources()
			Dim count As Integer = Resources.Count
			Do While count > 0
				Resources.Remove(Resources(0))
				count -= 1
			Loop
		End Sub
		Private Function GenerateResourceIdsString(ByVal xml As String) As ResourceIdCollection
			Dim result As New ResourceIdCollection()
			If String.IsNullOrEmpty(xml) Then
				Return result
			End If

			Return AppointmentResourceIdCollectionXmlPersistenceHelper.ObjectFromXml(result, xml)
		End Function

		Private Function GenerateResourceIdsString() As String
			Dim resourceIds As New ResourceIdCollection()
			Dim count As Integer = Resources.Count
			For i As Integer = 0 To count - 1
				resourceIds.Add(Resources(i).Oid)
			Next i

			Dim helper As New AppointmentResourceIdCollectionXmlPersistenceHelper(resourceIds)
			Return helper.ToXml()
		End Function
	End Class

#End Region ' #xpappointment

	#Region "#xpresource"

	' XP object
	Public Class XPResource
		Inherits XPObject
		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		<Size(SizeAttribute.Unlimited)> _
		Public Name As String ' Resource.Caption
		<ValueConverter(GetType(ColorValueConverter))> _
		Public Color As Integer
		Public Image As Image



		<Association()> _
		Public ReadOnly Property Appointments() As XPCollection(Of XPAppointment)
			Get
				Return GetCollection(Of XPAppointment)("Appointments")
			End Get
		End Property
	End Class
	Public Class ColorValueConverter
		Inherits ValueConverter
		Public Overrides ReadOnly Property StorageType() As Type
			Get
				Return GetType(Int32)
			End Get
		End Property
		Public Overrides Function ConvertToStorageType(ByVal value As Object) As Object
			If Not(TypeOf value Is Color) Then
				Return Nothing
			End If
			Return (CType(value, Color)).ToArgb()
		End Function
		Public Overrides Function ConvertFromStorageType(ByVal value As Object) As Object
			If Not(TypeOf value Is Int32) Then
				Return Nothing
			End If
			Return Color.FromArgb(CInt(Fix(value)))
		End Function
	End Class
	#End Region ' #xpresource

End Namespace