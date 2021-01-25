using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraBars.Helpers;

namespace OfficeAssistant
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();

            //加载dvE界面样式
            SkinHelper.InitSkinGallery(ribbonGalleryBarItem1);
        }

        private void barButtonItem1_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            panelControl1.Controls.Clear();
            UserPanel up = new UserPanel();
            up.Dock = DockStyle.Fill;
            panelControl1.Controls.Add(up);
        }

    }
}
