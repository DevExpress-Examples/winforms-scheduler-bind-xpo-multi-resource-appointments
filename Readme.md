<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128633852/18.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E81)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# How to bind the XtraScheduler with multi-resource appointments to XPO


<p>To bind the <strong>XtraScheduler</strong> to <a href="http://devexpress.com/Products/NET/XPO/">eXpress Persistent Objects</a>, if an Apppointment Storage contains <a href="https://documentation.devexpress.com/#WindowsForms/CustomDocument4217">multi-resource appointments</a> (the <a href="http://devexpress.com/Help/Content.aspx?help=XtraScheduler&document=DevExpressXtraSchedulerAppointmentStorageResourceSharingtopic.htm">AppointmentStorage.ResourceSharing</a> property is set to <strong>true</strong>), perform the following steps:</p>
<p>1. Add the DevExpress.Xpo.vX.y.dll assembly to the references list of the project.<br />2. Declare <strong>XPAppointment</strong> and <strong>XPResource</strong> classes (derived from <a href="http://documentation.devexpress.com/#XPO/CustomDocument2030">XPObject</a>).<br />3. Rebuild the application, so that these objects can be used for the <a href="http://documentation.devexpress.com/#XPO/CustomDocument2031">XPCollection</a>.<br />4. Drop two <strong>XPCollection</strong> components from the toolbox onto a Form and name them <strong>xpCollectionAppointments</strong> and <strong>xpCollectionResources</strong>.<br />5. Set their <a href="http://documentation.devexpress.com/#XPO/DevExpressXpoXPCollection_ObjectClassInfotopic">ObjectClassInfo</a> properties to the <strong>XPAppointment</strong> and <strong>XPResource</strong> objects, respectively.<br />6. Set the <a href="http://help.devexpress.com/#CoreLibraries/DevExpressXpoXPBaseCollection_DeleteObjectOnRemovetopic">DeleteObjectOnRemove</a> property of the <strong>xpCollectionAppointments</strong> to <strong>true</strong>.<br />7. Set the <strong>SchedulerStorage.Appointments.DataSource</strong> property to xpCollectionAppointments, and the <strong>SchedulerStorage.Resources.DataSource</strong> property to xpCollectionResources.<br />8. Specify all required <a href="http://documentation.devexpress.com/#WindowsForms/CustomDocument3289">mappings</a> for the <strong>AppointmentStorage</strong> and the <strong>ResourceStorage</strong>.<br />9. Handle the <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerStorageBase_AppointmentsChangedtopic">SchedulerStorage.AppointmentsChanged</a> and <a href="http://documentation.devexpress.com/#WindowsForms/DevExpressXtraSchedulerSchedulerStorageBase_AppointmentsInsertedtopic">SchedulerStorage.AppointmentsInserted</a> events using the event handler which calls the <a href="http://documentation.devexpress.com/#XPO/DevExpressXpoXPBaseObject_Savetopic">XPBaseObject.Save</a> method. The event handler is the same for both events.</p>
<p>This approach is illustrated by the sample project.</p>

<br/>


<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-bind-xpo-multi-resource-appointments&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-bind-xpo-multi-resource-appointments&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
