using DevExpress.Xpo;
using DevExpress.XtraScheduler;
using System.Drawing;
using System.Windows.Forms;

namespace XPO_MultiResource_Example {
    public partial class Form1 : Form {
        string[] resourceNames = { "Andrew Fuller", "Nancy Davolio", "Janet Leverling", "Margaret Peacock" };
        Color [] resourceColors = { Color.Cornsilk, Color.Lavender, Color.PaleGreen, Color.FromArgb(0x788E4585) };

        public Form1() {
            InitializeComponent();

            session1.ConnectionString = DevExpress.Xpo.DB.AccessConnectionProvider.GetConnectionString("XPO_MultiResource_Example.mdb");

            schedulerStorage1.Appointments.DataSource = xpCollectionAppointments;
            schedulerStorage1.Resources.DataSource = xpCollectionResources;

            CreateMappings();
            InitResources();

            this.schedulerStorage1.AppointmentsChanged += schedulerStorage1_AppointmentsChanged;
            this.schedulerStorage1.AppointmentsInserted += schedulerStorage1_AppointmentsChanged;

            this.schedulerStorage1.Appointments.ResourceSharing = true;
            this.schedulerControl1.Views.DayView.GroupType = SchedulerGroupType.Resource;
        }

        private void CreateMappings() {
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

            this.schedulerStorage1.Resources.Mappings.Caption = "Name";
            this.schedulerStorage1.Resources.Mappings.Color = "Color";
            this.schedulerStorage1.Resources.Mappings.Id = "ResId";
            this.schedulerStorage1.Resources.Mappings.Image = "Image";
        }

        private void InitResources() {
            if (xpCollectionResources.Count <= 0) {
                for (int i = 0; i < resourceNames.Length; i++) {
                    Resource res = new Resource(i, resourceNames[i]);
                    res.Color = resourceColors[i];
                    schedulerStorage1.Resources.Add(res);
                }
                session1.Save(xpCollectionResources);
            }
        }

        void schedulerStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e) {
            foreach (Appointment apt in e.Objects) {
                XPBaseObject o = apt.GetSourceObject(schedulerStorage1) as XPBaseObject;
                if (o != null)
                    o.Save();
            }
        }
    }
}
