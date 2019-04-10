Imports DevExpress.Xpo
Imports DevExpress.XtraScheduler
Imports DevExpress.XtraScheduler.Xml
Imports System

Namespace XPO_MultiResource_Example
	#Region "#xpappointment"
	' XP object
	<DeferredDeletion(false)>
	Public Class XPAppointment
		Inherits XPObject

		Public Sub New(ByVal session As Session)
			MyBase.New(session)
		End Sub

		Public AllDay As Boolean ' Appointment.AllDay

		<Size(SizeAttribute.Unlimited)>
		Public Description As String ' Appointment.Description -  !!! To set the Memo field type.

		Public Finish As Date ' Appointment.End
		Public Label As Integer ' Appointment.Label
		Public Location As String ' Appointment.Location

		<Size(SizeAttribute.Unlimited)>
		Public Recurrence As String ' Appointment.RecurrenceInfo -  !!! To set the Memo field type.

		<Size(SizeAttribute.Unlimited)>
		Public Reminder As String ' Appointment.ReminderInfo -  !!! To set the Memo field type.

		Public Created As Date ' Appointment.Start
		Public Status As Integer ' Appointment.Status
		<Size(SizeAttribute.Unlimited)>
		Public Subject As String ' Appointment.Subject -  !!! To set the Memo field type.
		Public AppointmentType As Integer ' Appointment.Type

		<Association()>
		Public ReadOnly Property Resources() As XPCollection(Of XPResource)
			Get
				Return GetCollection(Of XPResource)("Resources")
			End Get
		End Property

		<NonPersistent()>
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
'INSTANT VB NOTE: The variable resourceIds was renamed since Visual Basic does not handle local variables named the same as class members well:
			Dim resourceIds_Renamed As New ResourceIdCollection()
			Dim count As Integer = Resources.Count
			For i As Integer = 0 To count - 1
				resourceIds_Renamed.Add(Resources(i).Oid)
			Next i

			Dim helper As New AppointmentResourceIdCollectionXmlPersistenceHelper(resourceIds_Renamed)
			Return helper.ToXml()
		End Function
	End Class
	#End Region ' #xpappointment
End Namespace
