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

#End Region  ' #usings
Namespace XPO_Bound_Multiresource

#Region "#xpappointment"
    ' XP object
    Public Class XPAppointment
        Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        Public AllDay As Boolean ' Appointment.AllDay

        <Size(SizeAttribute.Unlimited)>
        Public Description As String ' Appointment.Description

        Public Finish As DateTime ' Appointment.End

        Public Label As Integer ' Appointment.Label

        Public Location As String ' Appointment.Location

        <Size(SizeAttribute.Unlimited)>
        Public Recurrence As String ' Appointment.RecurrenceInfo

        <Size(SizeAttribute.Unlimited)>
        Public Reminder As String ' Appointment.ReminderInfo

        Public Created As DateTime ' Appointment.Start

        Public Status As Integer ' Appointment.Status

        <Size(SizeAttribute.Unlimited)>
        Public Subject As String ' Appointment.Subject

        Public AppointmentType As Integer ' Appointment.Type

        <Association()>
        Public ReadOnly Property Resources As XPCollection(Of XPResource)
            Get
                Return GetCollection(Of XPResource)("Resources")
            End Get
        End Property

        <NonPersistent()>
        Public Property ResourceIds As String
            Get
                Return GenerateResourceIdsString()
            End Get

            Set(ByVal value As String)
                Dim resourceIds As ResourceIdCollection = Me.GenerateResourceIdsString(value)
                Resources.SuspendChangedEvents()
                Try
                    ClearResources()
                    Dim count As Integer = resourceIds.Count
                    For i As Integer = 0 To count - 1
                        Dim resource As XPResource = Me.Session.GetObjectByKey(Of XPResource)(resourceIds(i))
                        If resource IsNot Nothing Then Resources.Add(resource)
                    Next
                Finally
                    Resources.ResumeChangedEvents()
                End Try
            End Set
        End Property

        Private Sub ClearResources()
            Dim count As Integer = Resources.Count
            While count > 0
                Resources.Remove(Me.Resources(0))
                count -= 1
            End While
        End Sub

        Private Function GenerateResourceIdsString(ByVal xml As String) As ResourceIdCollection
            Dim result As ResourceIdCollection = New ResourceIdCollection()
            If [String].IsNullOrEmpty(xml) Then Return result
            Return AppointmentResourceIdCollectionXmlPersistenceHelper.ObjectFromXml(result, xml)
        End Function

        Private Function GenerateResourceIdsString() As String
            Dim resourceIds As ResourceIdCollection = New ResourceIdCollection()
            Dim count As Integer = Resources.Count
            For i As Integer = 0 To count - 1
                resourceIds.Add(Me.Resources(i).Oid)
            Next

            Dim helper As AppointmentResourceIdCollectionXmlPersistenceHelper = New AppointmentResourceIdCollectionXmlPersistenceHelper(resourceIds)
            Return helper.ToXml()
        End Function
    End Class

#End Region  ' #xpappointment
#Region "#xpresource"
    ' XP object
    Public Class XPResource
        Inherits XPObject

        Public Sub New(ByVal session As Session)
            MyBase.New(session)
        End Sub

        <Size(SizeAttribute.Unlimited)>
        Public Name As String ' Resource.Caption

        <ValueConverter(GetType(ColorValueConverter))>
        Public Color As Integer

        Public Image As Image

        <Association()>
        Public ReadOnly Property Appointments As XPCollection(Of XPAppointment)
            Get
                Return GetCollection(Of XPAppointment)("Appointments")
            End Get
        End Property
    End Class

    Public Class ColorValueConverter
        Inherits ValueConverter

        Public Overrides ReadOnly Property StorageType As Type
            Get
                Return GetType(Int32)
            End Get
        End Property

        Public Overrides Function ConvertToStorageType(ByVal value As Object) As Object
            If Not(TypeOf value Is Color) Then Return Nothing
            Return CType(value, Color).ToArgb()
        End Function

        Public Overrides Function ConvertFromStorageType(ByVal value As Object) As Object
            If Not(TypeOf value Is Int32) Then Return Nothing
            Return Color.FromArgb(CType(value, Int32))
        End Function
    End Class
#End Region  ' #xpresource
End Namespace
