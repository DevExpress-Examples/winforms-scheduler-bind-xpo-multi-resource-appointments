using System;
using System.Windows.Forms;
using DevExpress.Xpo;
using DevExpress.XtraScheduler;

namespace XPO_Bound_Multiresource {
    public partial class Form1 : Form {
        public Form1() {
            InitializeComponent();
        }

        private void OnAppointmentsChanged(object sender, PersistentObjectsEventArgs e) {
            foreach (Appointment apt in e.Objects) {
                XPBaseObject o = apt.GetSourceObject(schedulerStorage1) as XPBaseObject;
                if (o != null)
                    o.Save();
            }
        }

        private void Form1_Load(object sender, EventArgs e) {
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