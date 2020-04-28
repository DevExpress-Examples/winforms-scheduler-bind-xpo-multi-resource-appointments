using DevExpress.Xpo;
using DevExpress.XtraScheduler;
using System.Windows.Forms;

namespace XPO_MultiResource_Example {
    public partial class Form1 : Form {
        string[] resourceNames = { "Andrew Fuller", "Nancy Davolio", "Janet Leverling", "Margaret Peacock" };
        string[] resourceColors = { "Cornsilk", "Lavender", "PaleGreen", "0xFF8E4585" };

        public Form1() {
            InitializeComponent();

            session1.ConnectionString = "XpoProvider=InMemoryDataStore";

            schedulerDataStorage1.Appointments.DataSource = xpCollectionAppointments;
            schedulerDataStorage1.Resources.DataSource = xpCollectionResources;

            CreateMappings();
            InitResources();
            
            this.schedulerDataStorage1.AppointmentsChanged += schedulerDataStorage1_AppointmentsChanged;
            this.schedulerDataStorage1.AppointmentsInserted += schedulerDataStorage1_AppointmentsChanged;

            
            this.schedulerControl1.Views.DayView.GroupType = SchedulerGroupType.Resource;
        }

        private void CreateMappings() {
            this.schedulerDataStorage1.Appointments.Mappings.AllDay = "AllDay";
            this.schedulerDataStorage1.Appointments.Mappings.Description = "Description";
            this.schedulerDataStorage1.Appointments.Mappings.End = "Finish";
            this.schedulerDataStorage1.Appointments.Mappings.Label = "Label";
            this.schedulerDataStorage1.Appointments.Mappings.Location = "Location";
            this.schedulerDataStorage1.Appointments.Mappings.RecurrenceInfo = "Recurrence";
            this.schedulerDataStorage1.Appointments.Mappings.ReminderInfo = "Reminder";
            this.schedulerDataStorage1.Appointments.Mappings.ResourceId = "ResourceIds";
            this.schedulerDataStorage1.Appointments.Mappings.Start = "Created";
            this.schedulerDataStorage1.Appointments.Mappings.Status = "Status";
            this.schedulerDataStorage1.Appointments.Mappings.Subject = "Subject";
            this.schedulerDataStorage1.Appointments.Mappings.Type = "AppointmentType";

            this.schedulerDataStorage1.Resources.Mappings.Caption = "Name";
            this.schedulerDataStorage1.Resources.Mappings.Color = "Color";
            this.schedulerDataStorage1.Resources.Mappings.Id = "ResId";
            this.schedulerDataStorage1.Resources.Mappings.Image = "Image";
        }

        private void InitResources() {
            if (xpCollectionResources.Count <= 0) {
                for (int i = 0; i < resourceNames.Length; i++) {
                    Resource res = schedulerDataStorage1.Resources.CreateResource(i);
                    res.Caption = resourceNames[i];
                    res.ColorValue = resourceColors[i];
                    schedulerDataStorage1.Resources.Add(res);
                }
                session1.Save(xpCollectionResources);
            }
        }

        void schedulerDataStorage1_AppointmentsChanged(object sender, PersistentObjectsEventArgs e) {
            foreach (Appointment apt in e.Objects) {
                XPBaseObject o = apt.GetSourceObject(schedulerDataStorage1) as XPBaseObject;
                if (o != null)
                    o.Save();
            }
        }
    }
}
