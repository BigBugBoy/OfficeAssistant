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
            SqlHelper sh = new SqlHelper();
            string sql = @"select * from Users";
            gridControl1.DataSource = sh.executeSqlDataTable(sql);
        }
    }
}
