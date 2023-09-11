Namespace XPO_Bound_Multiresource

    Partial Class Form1

        ''' <summary>
        ''' Required designer variable.
        ''' </summary>
        Private components As System.ComponentModel.IContainer = Nothing

        ''' <summary>
        ''' Clean up any resources being used.
        ''' </summary>
        ''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        Protected Overrides Sub Dispose(ByVal disposing As Boolean)
            If disposing AndAlso (Me.components IsNot Nothing) Then
                Me.components.Dispose()
            End If

            MyBase.Dispose(disposing)
        End Sub

#Region "Windows Form Designer generated code"
        ''' <summary>
        ''' Required method for Designer support - do not modify
        ''' the contents of this method with the code editor.
        ''' </summary>
        Private Sub InitializeComponent()
            Me.components = New System.ComponentModel.Container()
            Dim timeRuler1 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Dim timeRuler2 As DevExpress.XtraScheduler.TimeRuler = New DevExpress.XtraScheduler.TimeRuler()
            Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.schedulerStorage1 = New DevExpress.XtraScheduler.SchedulerStorage(Me.components)
            Me.dateNavigator1 = New DevExpress.XtraScheduler.DateNavigator()
            Me.xpCollectionAppointments = New DevExpress.Xpo.XPCollection()
            Me.xpCollectionResources = New DevExpress.Xpo.XPCollection()
            CType((Me.schedulerControl1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.schedulerStorage1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.dateNavigator1), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.xpCollectionAppointments), System.ComponentModel.ISupportInitialize).BeginInit()
            CType((Me.xpCollectionResources), System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.schedulerControl1.GroupType = DevExpress.XtraScheduler.SchedulerGroupType.Resource
            Me.schedulerControl1.Location = New System.Drawing.Point(0, 0)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.Size = New System.Drawing.Size(576, 460)
            Me.schedulerControl1.Start = New System.DateTime(2011, 4, 7, 0, 0, 0, 0)
            Me.schedulerControl1.Storage = Me.schedulerStorage1
            Me.schedulerControl1.TabIndex = 0
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler2)
            ' 
            ' schedulerStorage1
            ' 
            Me.schedulerStorage1.Appointments.DataSource = Me.xpCollectionAppointments
            Me.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay"
            Me.schedulerStorage1.Appointments.Mappings.Description = "Description"
            Me.schedulerStorage1.Appointments.Mappings.[End] = "Finish"
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
            Me.schedulerStorage1.AppointmentsChanged += New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf Me.OnAppointmentsChanged)
            Me.schedulerStorage1.AppointmentsInserted += New DevExpress.XtraScheduler.PersistentObjectsEventHandler(AddressOf Me.OnAppointmentsChanged)
            ' 
            ' dateNavigator1
            ' 
            Me.dateNavigator1.Dock = System.Windows.Forms.DockStyle.Right
            Me.dateNavigator1.HotDate = Nothing
            Me.dateNavigator1.Location = New System.Drawing.Point(576, 0)
            Me.dateNavigator1.Name = "dateNavigator1"
            Me.dateNavigator1.SchedulerControl = Me.schedulerControl1
            Me.dateNavigator1.Size = New System.Drawing.Size(179, 460)
            Me.dateNavigator1.TabIndex = 1
            ' 
            ' xpCollectionAppointments
            ' 
            Me.xpCollectionAppointments.DeleteObjectOnRemove = True
            Me.xpCollectionAppointments.ObjectType = GetType(XPO_Bound_Multiresource.XPAppointment)
            ' 
            ' xpCollectionResources
            ' 
            Me.xpCollectionResources.DeleteObjectOnRemove = True
            Me.xpCollectionResources.ObjectType = GetType(XPO_Bound_Multiresource.XPResource)
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6F, 13F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(755, 460)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Controls.Add(Me.dateNavigator1)
            Me.Name = "Form1"
            Me.Text = "Form1"
            Me.Load += New System.EventHandler(AddressOf Me.Form1_Load)
            CType((Me.schedulerControl1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.schedulerStorage1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.dateNavigator1), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.xpCollectionAppointments), System.ComponentModel.ISupportInitialize).EndInit()
            CType((Me.xpCollectionResources), System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)
        End Sub

#End Region
        Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl

        Private schedulerStorage1 As DevExpress.XtraScheduler.SchedulerStorage

        Private dateNavigator1 As DevExpress.XtraScheduler.DateNavigator

        Private xpCollectionAppointments As DevExpress.Xpo.XPCollection

        Private xpCollectionResources As DevExpress.Xpo.XPCollection
    End Class
End Namespace
