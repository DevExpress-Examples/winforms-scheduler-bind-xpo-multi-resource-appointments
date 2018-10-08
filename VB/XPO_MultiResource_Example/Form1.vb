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

            schedulerDataStorage1.Appointments.DataSource = xpCollectionAppointments
            schedulerDataStorage1.Resources.DataSource = xpCollectionResources

            CreateMappings()
            InitResources()

            AddHandler Me.schedulerDataStorage1.AppointmentsChanged, AddressOf schedulerDataStorage1_AppointmentsChanged
            AddHandler Me.schedulerDataStorage1.AppointmentsInserted, AddressOf schedulerDataStorage1_AppointmentsChanged


            Me.schedulerControl1.Views.DayView.GroupType = SchedulerGroupType.Resource
        End Sub

        Private Sub CreateMappings()
            Me.schedulerDataStorage1.Appointments.Mappings.AllDay = "AllDay"
            Me.schedulerDataStorage1.Appointments.Mappings.Description = "Description"
            Me.schedulerDataStorage1.Appointments.Mappings.End = "Finish"
            Me.schedulerDataStorage1.Appointments.Mappings.Label = "Label"
            Me.schedulerDataStorage1.Appointments.Mappings.Location = "Location"
            Me.schedulerDataStorage1.Appointments.Mappings.RecurrenceInfo = "Recurrence"
            Me.schedulerDataStorage1.Appointments.Mappings.ReminderInfo = "Reminder"
            Me.schedulerDataStorage1.Appointments.Mappings.ResourceId = "ResourceIds"
            Me.schedulerDataStorage1.Appointments.Mappings.Start = "Created"
            Me.schedulerDataStorage1.Appointments.Mappings.Status = "Status"
            Me.schedulerDataStorage1.Appointments.Mappings.Subject = "Subject"
            Me.schedulerDataStorage1.Appointments.Mappings.Type = "AppointmentType"

            Me.schedulerDataStorage1.Resources.Mappings.Caption = "Name"
            Me.schedulerDataStorage1.Resources.Mappings.Color = "Color"
            Me.schedulerDataStorage1.Resources.Mappings.Id = "ResId"
            Me.schedulerDataStorage1.Resources.Mappings.Image = "Image"
        End Sub

        Private Sub InitResources()
            If xpCollectionResources.Count <= 0 Then
                For i As Integer = 0 To resourceNames.Length - 1
                    Dim res As Resource = schedulerDataStorage1.Resources.CreateResource(i)
                    res.Caption = resourceNames(i)
                    res.ColorValue = resourceColors(i)
                    schedulerDataStorage1.Resources.Add(res)
                Next i
                session1.Save(xpCollectionResources)
            End If
        End Sub

        Private Sub schedulerDataStorage1_AppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            For Each apt As Appointment In e.Objects
                Dim o As XPBaseObject = TryCast(apt.GetSourceObject(schedulerDataStorage1), XPBaseObject)
                If o IsNot Nothing Then
                    o.Save()
                End If
            Next apt
        End Sub
	End Class
End Namespace
