Imports DevExpress.Xpo
Imports DevExpress.XtraScheduler
Imports System.Windows.Forms

Namespace XPO_MultiResource_Example
	Partial Public Class Form1
		Inherits Form

		Private resourceNames() As String = { "Andrew Fuller", "Nancy Davolio", "Janet Leverling", "Margaret Peacock" }
		Private resourceColors() As String = { "Cornsilk", "Lavender", "PaleGreen", "0xFF8E4585" }

		Public Sub New()
			InitializeComponent()

			session1.ConnectionString = DevExpress.Xpo.DB.AccessConnectionProvider.GetConnectionString("XPO_MultiResource_Example.mdb")

			schedulerStorage1.Appointments.DataSource = xpCollectionAppointments
			schedulerStorage1.Resources.DataSource = xpCollectionResources

			CreateMappings()
			InitResources()

			AddHandler Me.schedulerStorage1.AppointmentsChanged, AddressOf schedulerStorage1_AppointmentsChanged
			AddHandler Me.schedulerStorage1.AppointmentsInserted, AddressOf schedulerStorage1_AppointmentsChanged

			Me.schedulerStorage1.Appointments.ResourceSharing = True
			Me.schedulerControl1.Views.DayView.GroupType = SchedulerGroupType.Resource
		End Sub

		Private Sub CreateMappings()
			Me.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
			Me.schedulerStorage1.Appointments.Mappings.Description = "Description"
			Me.schedulerStorage1.Appointments.Mappings.End = "Finish"
			Me.schedulerStorage1.Appointments.Mappings.Label = "Label"
			Me.schedulerStorage1.Appointments.Mappings.Location = "Location"
			Me.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "Recurrence"
			Me.schedulerStorage1.Appointments.Mappings.ReminderInfo = "Reminder"
			Me.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceIds"
			Me.schedulerStorage1.Appointments.Mappings.Start = "Created"
			Me.schedulerStorage1.Appointments.Mappings.Status = "Status"
			Me.schedulerStorage1.Appointments.Mappings.Subject = "Subject"
			Me.schedulerStorage1.Appointments.Mappings.Type = "AppointmentType"

			Me.schedulerStorage1.Resources.Mappings.Caption = "Name"
			Me.schedulerStorage1.Resources.Mappings.Color = "Color"
			Me.schedulerStorage1.Resources.Mappings.Id = "ResId"
			Me.schedulerStorage1.Resources.Mappings.Image = "Image"
		End Sub

		Private Sub InitResources()
			If xpCollectionResources.Count <= 0 Then
				For i As Integer = 0 To resourceNames.Length - 1
                    Dim res As Resource = schedulerStorage1.Resources.CreateResource(i)
                    res.Caption = resourceNames(i)
					res.ColorValue = resourceColors(i)
					schedulerStorage1.Resources.Add(res)
				Next i
				session1.Save(xpCollectionResources)
			End If
		End Sub

		Private Sub schedulerStorage1_AppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            For Each apt As Appointment In e.Objects
                Dim o As XPBaseObject = TryCast(apt.GetSourceObject(schedulerStorage1), XPBaseObject)
                If o IsNot Nothing Then
                    o.Save()
                End If
            Next apt
        End Sub
	End Class
End Namespace
