Namespace XPO_MultiResource_Example
	Partial Public Class Form1
		''' <summary>
		''' Required designer variable.
		''' </summary>
		Private components As System.ComponentModel.IContainer = Nothing

		''' <summary>
		''' Clean up any resources being used.
		''' </summary>
		''' <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
		Protected Overrides Sub Dispose(ByVal disposing As Boolean)
			If disposing AndAlso (components IsNot Nothing) Then
				components.Dispose()
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
			Dim timeRuler1 As New DevExpress.XtraScheduler.TimeRuler()
			Dim timeRuler2 As New DevExpress.XtraScheduler.TimeRuler()
			Dim timeRuler3 As New DevExpress.XtraScheduler.TimeRuler()
			Me.schedulerControl1 = New DevExpress.XtraScheduler.SchedulerControl()
            Me.schedulerDataStorage1 = New DevExpress.XtraScheduler.SchedulerDataStorage(Me.components)
            Me.session1 = New DevExpress.Xpo.Session(Me.components)
            Me.xpCollectionAppointments = New DevExpress.Xpo.XPCollection(Me.components)
            Me.xpCollectionResources = New DevExpress.Xpo.XPCollection(Me.components)
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.schedulerDataStorage1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.session1, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.xpCollectionAppointments, System.ComponentModel.ISupportInitialize).BeginInit()
            DirectCast(Me.xpCollectionResources, System.ComponentModel.ISupportInitialize).BeginInit()
            Me.SuspendLayout()
            ' 
            ' schedulerControl1
            ' 
            Me.schedulerControl1.Dock = System.Windows.Forms.DockStyle.Fill
            Me.schedulerControl1.Location = New System.Drawing.Point(0, 0)
            Me.schedulerControl1.Name = "schedulerControl1"
            Me.schedulerControl1.Size = New System.Drawing.Size(784, 561)
            Me.schedulerControl1.Start = New Date(2015, 9, 28, 0, 0, 0, 0)
            Me.schedulerControl1.DataStorage = Me.schedulerDataStorage1
            Me.schedulerControl1.TabIndex = 0
            Me.schedulerControl1.Text = "schedulerControl1"
            Me.schedulerControl1.Views.DayView.TimeRulers.Add(timeRuler1)
            Me.schedulerControl1.Views.FullWeekView.Enabled = True
            Me.schedulerControl1.Views.FullWeekView.TimeRulers.Add(timeRuler2)
            Me.schedulerControl1.Views.WeekView.Enabled = False
            Me.schedulerControl1.Views.WorkWeekView.TimeRulers.Add(timeRuler3)
            ' 
            ' session1
            ' 
            Me.session1.IsObjectModifiedOnNonPersistentPropertyChange = Nothing
            Me.session1.TrackPropertiesModifications = False
            ' 
            ' xpCollectionAppointments
            ' 
            Me.xpCollectionAppointments.DeleteObjectOnRemove = True
            Me.xpCollectionAppointments.ObjectType = GetType(XPO_MultiResource_Example.XPAppointment)
            Me.xpCollectionAppointments.Session = Me.session1
            ' 
            ' xpCollectionResources
            ' 
            Me.schedulerDataStorage1.Appointments.ResourceSharing = True
            Me.xpCollectionResources.ObjectType = GetType(XPO_MultiResource_Example.XPResource)
            Me.xpCollectionResources.Session = Me.session1
            ' 
            ' Form1
            ' 
            Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0F, 13.0F)
            Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
            Me.ClientSize = New System.Drawing.Size(784, 561)
            Me.Controls.Add(Me.schedulerControl1)
            Me.Name = "Form1"
            Me.StartPosition = FormStartPosition.CenterScreen
            Me.Text = "DataBound_XPO_MultiResource"
            DirectCast(Me.schedulerControl1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.schedulerDataStorage1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.session1, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.xpCollectionAppointments, System.ComponentModel.ISupportInitialize).EndInit()
            DirectCast(Me.xpCollectionResources, System.ComponentModel.ISupportInitialize).EndInit()
            Me.ResumeLayout(False)

        End Sub

#End Region

        Private schedulerControl1 As DevExpress.XtraScheduler.SchedulerControl
        Private schedulerDataStorage1 As DevExpress.XtraScheduler.SchedulerDataStorage
        Private xpCollectionAppointments As DevExpress.Xpo.XPCollection
		Private xpCollectionResources As DevExpress.Xpo.XPCollection
		Private session1 As DevExpress.Xpo.Session
	End Class
End Namespace

