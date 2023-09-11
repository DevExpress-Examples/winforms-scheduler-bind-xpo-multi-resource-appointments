Imports System
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.XtraScheduler

Namespace XPO_Bound_Multiresource

    Public Partial Class Form1
        Inherits Form

        Public Sub New()
            InitializeComponent()
            PrepareXpCollections()
            PrepareScheduler()
        End Sub

        Private Sub PrepareScheduler()
            schedulerStorage1.Appointments.DataSource = xpCollectionAppointments
            schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
            schedulerStorage1.Appointments.Mappings.Description = "Description"
            schedulerStorage1.Appointments.Mappings.[End] = "Finish"
            schedulerStorage1.Appointments.Mappings.Label = "Label"
            schedulerStorage1.Appointments.Mappings.Location = "Location"
            schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "Recurrence"
            schedulerStorage1.Appointments.Mappings.ReminderInfo = "Reminder"
            schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceIds"
            schedulerStorage1.Appointments.Mappings.Start = "Created"
            schedulerStorage1.Appointments.Mappings.Status = "Status"
            schedulerStorage1.Appointments.Mappings.Subject = "Subject"
            schedulerStorage1.Appointments.Mappings.Type = "AppointmentType"
            schedulerStorage1.Appointments.ResourceSharing = True
            schedulerStorage1.Resources.DataSource = xpCollectionResources
            schedulerStorage1.Resources.Mappings.Caption = "Name"
            schedulerStorage1.Resources.Mappings.Color = "Color"
            schedulerStorage1.Resources.Mappings.Id = "Oid"
            schedulerStorage1.AppointmentsChanged += New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf Me.OnAppointmentsChanged)
            schedulerStorage1.AppointmentsInserted += New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf Me.OnAppointmentsChanged)
        End Sub

        Private Sub PrepareXpCollections()
            CType(xpCollectionAppointments, System.ComponentModel.ISupportInitialize).BeginInit()
            CType(xpCollectionResources, System.ComponentModel.ISupportInitialize).BeginInit()
            xpCollectionAppointments.DeleteObjectOnRemove = True
            xpCollectionAppointments.ObjectType = GetType(XPAppointment)
            xpCollectionResources.DeleteObjectOnRemove = True
            xpCollectionResources.ObjectType = GetType(XPResource)
            CType(xpCollectionResources, System.ComponentModel.ISupportInitialize).EndInit()
            CType(xpCollectionAppointments, System.ComponentModel.ISupportInitialize).EndInit()
        End Sub

        Private Sub OnAppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs)
            For Each apt As Appointment In e.Objects
                Dim o As XPBaseObject = TryCast(apt.GetSourceObject(schedulerStorage1), XPBaseObject)
                If o IsNot Nothing Then o.Save()
            Next
        End Sub

        Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs)
            Dim resources As ResourceBaseCollection = schedulerStorage1.Resources.Items
            If resources.Count <= 0 Then
                resources.Add(New Resource(0, "Andrew Fuller"))
                resources.Add(New Resource(1, "Nancy Davolio"))
                resources.Add(New Resource(2, "Janet Leverling"))
                resources.Add(New Resource(3, "Margaret Peacock"))
            End If

            resources(0).Color = System.Drawing.Color.Cornsilk
            resources(1).Color = System.Drawing.Color.Lavender
            resources(2).Color = System.Drawing.Color.PaleGreen
            resources(3).Color = System.Drawing.Color.Plum
            Dim count As Integer = xpCollectionResources.Count
            For i As Integer = 0 To count - 1
                Dim o As XPObject = CType(xpCollectionResources(i), XPObject)
                o.Save()
            Next
        End Sub
    End Class
End Namespace
