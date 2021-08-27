<!-- default badges list -->
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E81)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
<!-- default badges end -->
<!-- default file list -->
*Files to look at*:

* [Form1.cs](./CS/Form1.cs) (VB: [Form1.vb](./VB/Form1.vb))
* [XPObjects.cs](./CS/XPObjects.cs) (VB: [XPObjects.vb](./VB/XPObjects.vb))
<!-- default file list end -->
# How to bind the XtraScheduler with multi-resource appointments to XPO


<p>To bind the <strong>XtraScheduler</strong> to <a href="http://devexpress.com/Products/NET/XPO/">eXpress Persistent Objects</a>, if an Apppointment Storage contains <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument4217">multi-resource appointments</a> (the <a href="http://devexpress.com/Help/Content.aspx?help=XtraScheduler&document=DevExpressXtraSchedulerAppointmentStorageResourceSharingtopic.htm">AppointmentStorage.ResourceSharing</a> property is set to <strong>true</strong>), perform the following steps:</p>
<p>1. Add the DevExpress.Xpo.vX.y.dll assembly to the references list of the project.<br />2. Declare <strong>XPAppointment</strong> and <strong>XPResource</strong> classes (derived from <a href="http://documentation.devexpress.com/#XPO/CustomDocument2030">XPObject</a>).<br />3. Rebuild the application, so that these objects can be used for the <a href="http://documentation.devexpress.com/#XPO/CustomDocument2031">XPCollection</a>.<br />4. Drop two <strong>XPCollection</strong> components from the toolbox onto a Form and name them <strong>xpCollectionAppointments</strong> and <strong>xpCollectionResources</strong>.<br />5. Set their <a href="http://documentation.devexpress.com/#XPO/DevExpressXpoXPCollection_ObjectClassInfotopic">ObjectClassInfo</a> properties to the <strong>XPAppointment</strong> and <strong>XPResource</strong> objects, respectively.<br />6. Set the <a href="http://help.devexpress.com/#CoreLibraries/DevExpressXpoXPBaseCollection_DeleteObjectOnRemovetopic">DeleteObjectOnRemove</a> property of the <strong>xpCollectionAppointments</strong> to <strong>true</strong>.<br />7. Set the <strong>SchedulerStorage.Appointments.DataSource</strong> property to xpCollectionAppointments, and the <strong>SchedulerStorage.Resources.DataSource</strong> property to xpCollectionResources.<br />8. Specify all required <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument3289">mappings</a> for the <strong>AppointmentStorage</strong> and the <strong>ResourceStorage</strong>.<br />9. Handle the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerStorageBase_AppointmentsChangedtopic">SchedulerStorage.AppointmentsChanged</a> and <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerStorageBase_AppointmentsInsertedtopic">SchedulerStorage.AppointmentsInserted</a> events using the event handler which calls the <a href="http://documentation.devexpress.com/#XPO/DevExpressXpoXPBaseObject_Savetopic">XPBaseObject.Save</a> method. The event handler is the same for both events.</p>
<p>This approach is illustrated by the sample project.</p>

<br/>


