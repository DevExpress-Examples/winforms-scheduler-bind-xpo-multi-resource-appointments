<!-- default badges list -->
![](https://img.shields.io/endpoint?url=https://codecentral.devexpress.com/api/v1/VersionRange/128633852/20.1.3%2B)
[![](https://img.shields.io/badge/Open_in_DevExpress_Support_Center-FF7200?style=flat-square&logo=DevExpress&logoColor=white)](https://supportcenter.devexpress.com/ticket/details/E81)
[![](https://img.shields.io/badge/📖_How_to_use_DevExpress_Examples-e9f6fc?style=flat-square)](https://docs.devexpress.com/GeneralInformation/403183)
[![](https://img.shields.io/badge/💬_Leave_Feedback-feecdd?style=flat-square)](#does-this-example-address-your-development-requirementsobjectives)
<!-- default badges end -->
# WinForms Scheduler - Bind to multi-resource appointments with XPO

This example demonstrates how to use [Object-Relational Mapping Library (XPO)](https://docs.devexpress.com/XPO/1998/express-persistent-objects) to bind the WinForms Scheduler control with [multi-resource appointments](https://docs.devexpress.com/WindowsForms/4217/controls-and-libraries/scheduler/examples/data-binding/how-to-enable-multi-resource-appointments) (the [AppointmentStorage.ResourceSharing](https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.AppointmentDataStorage.ResourceSharing) option is enabled).

Follow the steps below:

1. Reference the *DevExpress.Xpo.vX.y.dll* assembly.
2. Declare `XPAppointment` and `XPResource` classes derived from [XPObject](https://docs.devexpress.com/XPO/DevExpress.Xpo.XPObject).
3. Rebuild the solution.
4. Drop two [XPCollection](https://docs.devexpress.com/XPO/DevExpress.Xpo.XPCollection) components from the toolbox onto a Form. Name these components as "xpCollectionAppointments" and "xpCollectionResources".
5. Set their [ObjectClassInfo](https://docs.devexpress.com/XPO/DevExpress.Xpo.XPCollection.ObjectClassInfo) properties to the `XPAppointment` and `XPResource` objects, respectively.
6. Set the [DeleteObjectOnRemove](https://docs.devexpress.com/XPO/DevExpress.Xpo.XPBaseCollection.DeleteObjectOnRemove) property of the **xpCollectionAppointments** to **true**.
7. Set the `SchedulerStorage.Appointments.DataSource` property to `xpCollectionAppointments`.
8. Set the `SchedulerStorage.Resources.DataSource` property to `xpCollectionResources`.
9. Set up required [mappings](https://docs.devexpress.com/WindowsForms/15468/controls-and-libraries/scheduler/data-binding/mappings) for `AppointmentStorage` and `ResourceStorage`.
10. Handle [SchedulerStorage.AppointmentsChanged](https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.SchedulerDataStorage.AppointmentsChanged) and [SchedulerStorage.AppointmentsInserted](https://docs.devexpress.com/WindowsForms/DevExpress.XtraScheduler.SchedulerDataStorage.AppointmentsInserted) events to save persistent objects.

![](https://raw.githubusercontent.com/DevExpress-Examples/how-to-bind-the-xtrascheduler-with-multi-resource-appointments-to-xpo-e81/20.1.3%2B/media/winforms-scheduler-xpo.png)


## Documentation

* [Data Binding - WinForms Scheduler](https://docs.devexpress.com/WindowsForms/14807/controls-and-libraries/scheduler/examples/data-binding)
<!-- feedback -->
## Does this example address your development requirements/objectives?

[<img src="https://www.devexpress.com/support/examples/i/yes-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-bind-xpo-multi-resource-appointments&~~~was_helpful=yes) [<img src="https://www.devexpress.com/support/examples/i/no-button.svg"/>](https://www.devexpress.com/support/examples/survey.xml?utm_source=github&utm_campaign=winforms-scheduler-bind-xpo-multi-resource-appointments&~~~was_helpful=no)

(you will be redirected to DevExpress.com to submit your response)
<!-- feedback end -->
