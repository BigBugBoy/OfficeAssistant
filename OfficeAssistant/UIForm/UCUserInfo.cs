using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OfficeAssistant
{
    public partial class UserPanel : UserControl
    {
        public UserPanel()
        {
            InitializeComponent();
            bandGridData();
        }

        /// <summary>
        /// 提取数据库用户视图，绑定到grid
        /// </summary>
        private void bandGridData()
        {
            SqlHelper sh = new SqlHelper();
            string sql = @"select * from userView";
            gridControl1.DataSource = sh.executeSqlDataTable(sql);
        }

        /// <summary>
        /// 表示每一行绘制时触发的事件???
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void gridView1_CustomDrawRowIndicator(object sender, DevExpress.XtraGrid.Views.Grid.RowIndicatorCustomDrawEventArgs e)
        {
            if (e.Info.IsRowIndicator && e.RowHandle > 0)
            {
                e.Info.DisplayText = (e.RowHandle + 1).ToString();
            }
        }
    }
}
