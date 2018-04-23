using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraScheduler;

namespace XPO_Bound_Multiresource {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
            PrepareXpCollections();
            PrepareScheduler();
        }
        void PrepareScheduler() {
            this.schedulerStorage1.Appointments.DataSource = this.xpCollectionAppointments;
            this.schedulerStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerStorage1.Appointments.Mappings.End = "Finish";
            this.schedulerStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerStorage1.Appointments.Mappings.RecurrenceInfo = "Recurrence";
            this.schedulerStorage1.Appointments.Mappings.ReminderInfo = "Reminder";
            this.schedulerStorage1.Appointments.Mappings.ResourceId = "ResourceIds";
            this.schedulerStorage1.Appointments.Mappings.Start = "Created";
            this.schedulerStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerStorage1.Appointments.Mappings.Type = "AppointmentType";
            this.schedulerStorage1.Appointments.ResourceSharing = true;
            this.schedulerStorage1.Resources.DataSource = this.xpCollectionResources;
            this.schedulerStorage1.Resources.Mappings.Caption = "Name";
            this.schedulerStorage1.Resources.Mappings.Color = "Color";
            this.schedulerStorage1.Resources.Mappings.Id = "Oid";
            this.schedulerStorage1.AppointmentsChanged += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.OnAppointmentsChanged);
            this.schedulerStorage1.AppointmentsInserted += new DevExpress.XtraScheduler.PersistentObjectsEventHandler(this.OnAppointmentsChanged);
        }
        void PrepareXpCollections() {
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionAppointments)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionResources)).BeginInit();
            this.xpCollectionAppointments.DeleteObjectOnRemove = true;
            this.xpCollectionAppointments.ObjectType = typeof(XPO_Bound_Multiresource.XPAppointment);
            this.xpCollectionResources.DeleteObjectOnRemove = true;
            this.xpCollectionResources.ObjectType = typeof(XPO_Bound_Multiresource.XPResource);
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionResources)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.xpCollectionAppointments)).EndInit();
        }
        void OnAppointmentsChanged(object sender, PersistentObjectsEventArgs e) {
            foreach (Appointment apt in e.Objects) {
                XPBaseObject o = apt.GetSourceObject(schedulerStorage1) as XPBaseObject;
                if (o != null)
                    o.Save();
            }
        }
        void Form1_Load(object sender, EventArgs e) {
            ResourceBaseCollection resources = schedulerStorage1.Resources.Items;
            if (resources.Count <= 0) {
                resources.Add(new Resource(0, "Andrew Fuller"));
                resources.Add(new Resource(1, "Nancy Davolio"));
                resources.Add(new Resource(2, "Janet Leverling"));
                resources.Add(new Resource(3, "Margaret Peacock"));
            }
            resources[0].Color = System.Drawing.Color.Cornsilk;
            resources[1].Color = System.Drawing.Color.Lavender;
            resources[2].Color = System.Drawing.Color.PaleGreen;
            resources[3].Color = System.Drawing.Color.Plum;

            int count = xpCollectionResources.Count;
            for (int i = 0; i < count; i++) {
                XPObject o = (XPObject)xpCollectionResources[i];
                o.Save();
            }
        }
    }
}