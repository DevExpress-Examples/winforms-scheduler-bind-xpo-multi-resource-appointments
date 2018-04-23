using DevExpress.Xpo;
using System;
using System.Drawing;

namespace XPO_MultiResource_Example {
    #region #xpresource
    // XP object
    public class XPResource : XPObject {
        public XPResource(Session session) : base(session) { }
        public int ResId;
        [Size(SizeAttribute.Unlimited)]  // !!! To set the Memo field type.
        public string Name;              // Resource.Caption
        public Int32 Color;
        public Image Image;

        [Association()]
        public XPCollection<XPAppointment> Appointments {
            get {
                return GetCollection<XPAppointment>("Appointments");
            }
        }
    }
    #endregion #xpresource
}