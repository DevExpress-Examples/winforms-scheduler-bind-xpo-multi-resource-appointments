﻿Imports Microsoft.VisualBasic
Imports System
Imports System.Windows.Forms
Imports DevExpress.Xpo
Imports DevExpress.XtraScheduler

Namespace XPO_Bound_Multiresource
	Partial Public Class Form1
		Inherits Form
		Public Sub New()
			InitializeComponent()
			PrepareXpCollections()
			PrepareScheduler()
		End Sub
		Private Sub PrepareScheduler()
			Me.schedulerStorage1.Appointments.DataSource = Me.xpCollectionAppointments
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
			Me.schedulerStorage1.Appointments.ResourceSharing = True
			Me.schedulerStorage1.Resources.DataSource = Me.xpCollectionResources
			Me.schedulerStorage1.Resources.Mappings.Caption = "Name"
			Me.schedulerStorage1.Resources.Mappings.Color = "Color"
			Me.schedulerStorage1.Resources.Mappings.Id = "Oid"
			AddHandler schedulerStorage1.AppointmentsChanged, AddressOf OnAppointmentsChanged
			AddHandler schedulerStorage1.AppointmentsInserted, AddressOf OnAppointmentsChanged
		End Sub
		Private Sub PrepareXpCollections()
			CType(Me.xpCollectionAppointments, System.ComponentModel.ISupportInitialize).BeginInit()
			CType(Me.xpCollectionResources, System.ComponentModel.ISupportInitialize).BeginInit()
			Me.xpCollectionAppointments.DeleteObjectOnRemove = True
			Me.xpCollectionAppointments.ObjectType = GetType(XPO_Bound_Multiresource.XPAppointment)
			Me.xpCollectionResources.DeleteObjectOnRemove = True
			Me.xpCollectionResources.ObjectType = GetType(XPO_Bound_Multiresource.XPResource)
			CType(Me.xpCollectionResources, System.ComponentModel.ISupportInitialize).EndInit()
			CType(Me.xpCollectionAppointments, System.ComponentModel.ISupportInitialize).EndInit()
		End Sub
		Private Sub OnAppointmentsChanged(ByVal sender As Object, ByVal e As PersistentObjectsEventArgs) Handles schedulerStorage1.AppointmentsChanged, schedulerStorage1.AppointmentsInserted
			For Each apt As Appointment In e.Objects
				Dim o As XPBaseObject = TryCast(apt.GetSourceObject(schedulerStorage1), XPBaseObject)
				If o IsNot Nothing Then
					o.Save()
				End If
			Next apt
		End Sub
		Private Sub Form1_Load(ByVal sender As Object, ByVal e As EventArgs) Handles MyBase.Load
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
			Next i
		End Sub
	End Class
End Namespace