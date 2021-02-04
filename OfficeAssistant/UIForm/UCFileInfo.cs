using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Data;
using System.Linq;
using System.Text;
using System.Windows.Forms;

namespace OfficeAssistant.UIForm
{
    public partial class UCFileInfo : UserControl
    {
        public UCFileInfo()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 提取数据库用户视图，绑定到grid
        /// </summary>
        private void bandGridData()
        {
            SqlHelper sh = new SqlHelper();
            string sql = @"select * from fileInfo";
            gridControl1.DataSource = sh.executeSqlDataTable(sql);
        }
    }
}
