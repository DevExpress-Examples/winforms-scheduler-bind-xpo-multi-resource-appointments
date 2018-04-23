using System;
using System.Xml;
using System.Text;
#region #usings
using System.Drawing;
using DevExpress.Xpo;
using DevExpress.Xpo.Metadata;
using DevExpress.XtraScheduler;
using DevExpress.Utils.Serializing.Helpers;
using DevExpress.XtraScheduler.Xml;
#endregion #usings


namespace XPO_Bound_Multiresource
{
    #region #xpappointment
    // XP object
    public class XPAppointment : XPObject {
        public XPAppointment(Session session) : base(session) { }

        public bool AllDay;              // Appointment.AllDay

        [Size(SizeAttribute.Unlimited)]  // !!! To set the Memo field type.
        public string Description;       // Appointment.Description

        public DateTime Finish;          // Appointment.End
        public int Label;                // Appointment.Label
        public string Location;          // Appointment.Location

        [Size(SizeAttribute.Unlimited)]  // !!! To set the Memo field type.
        public string Recurrence;        // Appointment.RecurrenceInfo

        [Size(SizeAttribute.Unlimited)]  // !!! To set the Memo field type.
        public string Reminder;          // Appointment.ReminderInfo

        public DateTime Created;         // Appointment.Start
        public int Status;               // Appointment.Status
        [Size(SizeAttribute.Unlimited)]  // !!! To set the Memo field type.
        public string Subject;           // Appointment.Subject
        public int AppointmentType;      // Appointment.Type

        [Association()]
        public XPCollection<XPResource> Resources {
            get {
                return GetCollection<XPResource>("Resources");
            }
        }

        [NonPersistent()]
        public string ResourceIds {
            get {
                return GenerateResourceIdsString();
            }
            set {
                ResourceIdCollection resourceIds = GenerateResourceIdsString(value);
                Resources.SuspendChangedEvents();
                try {
                    ClearResources();
                    int count = resourceIds.Count;
                    for (int i = 0; i < count; i++) {
                        XPResource resource = this.Session.GetObjectByKey<XPResource>(resourceIds[i]);
                        if (resource != null)
                            Resources.Add(resource);
                    }
                } finally {
                    Resources.ResumeChangedEvents();
                }
            }
        }

        void ClearResources() {
            int count = Resources.Count;
            while (count > 0) {
                Resources.Remove(Resources[0]);
                count--;
            }
        }
        ResourceIdCollection GenerateResourceIdsString(string xml) {  
            ResourceIdCollection result = new ResourceIdCollection();
            if (String.IsNullOrEmpty(xml))
                return result;

            return AppointmentResourceIdCollectionXmlPersistenceHelper.ObjectFromXml(result, xml);
        }

        string GenerateResourceIdsString() {
            ResourceIdCollection resourceIds = new ResourceIdCollection();
            int count = Resources.Count;
            for (int i = 0; i < count; i++)
                resourceIds.Add(Resources[i].Oid);

            AppointmentResourceIdCollectionXmlPersistenceHelper helper = new AppointmentResourceIdCollectionXmlPersistenceHelper(resourceIds);
            return helper.ToXml();
        }
    }

#endregion #xpappointment

    #region #xpresource

    // XP object
    public class XPResource : XPObject {
        public XPResource(Session session) : base(session) { }

        [Size(SizeAttribute.Unlimited)]  // !!! To set the Memo field type.
        public string Name;              // Resource.Caption
        [ValueConverter(typeof(ColorValueConverter))]
        public int Color;
        public Image Image;



        [Association()]
        public XPCollection<XPAppointment> Appointments {
            get {
                return GetCollection<XPAppointment>("Appointments");
            }
        }
    }
    public class ColorValueConverter : ValueConverter
    {
        public override Type StorageType { get { return typeof(Int32); } }
        public override object ConvertToStorageType(object value)
        {
            if (!(value is Color)) return null;
            return ((Color)value).ToArgb();
        }
        public override object ConvertFromStorageType(object value)
        {
            if (!(value is Int32)) return null;
            return Color.FromArgb((Int32)value);
        }
    }
    #endregion #xpresource

}