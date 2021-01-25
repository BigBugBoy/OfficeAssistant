using System;
using System.Collections.Generic;
using System.Text;

using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace OfficeAssistant
{
    public class UiHelper
    {

        private int dgv_currentRow;

        private int dgv_currentCol;

        public int dgv_CurrentRow
        {
            get { return dgv_currentRow; }
            set { dgv_currentRow = value; }
        }

        public int dgv_CurrentCol
        {
            get { return dgv_currentCol; }
            set { dgv_currentCol = value; }
        }

        //combox绑定数据
        public List<string> cb_Bind(DataTable dt, DataGridView dgv,  ComboBox cb)
        {
            List<string> Onit = new List<string>();
            Onit.Clear();
            cb.Items.Clear();
            dgv.DataSource = dt;
            dgv.ReadOnly = true;
            int i = 0;
            while (i < (dgv.Rows.Count - 1))
            {
                Onit.Add(dgv.Rows[i].Cells[0].Value.ToString().Trim());
                i++;
            }
            cb.Items.AddRange(Onit.ToArray());
            return Onit;
        }

        //跟随输入刷新下拉菜单
        public void cb_Update(List<string> Onit, ComboBox cb)
        {
            List<string> New = new List<string>();
            cb.Items.Clear();
            New.Clear();
            foreach (var item in Onit)
            {
                if (item.Contains(cb.Text))
                    New.Add(item);
            }
            cb.Items.AddRange(New.ToArray());

            //光标锁定在最右边
            cb.SelectionStart = cb.Text.Trim().Length;

            //自动弹出下拉菜单
            //cb.DroppedDown = true;
        }

        //初始化文件dgv格式
        public void init_dgvFileInfoFormat(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;//表格只读
            dgv.RowHeadersVisible = true;//标题行可见
            dgv.Columns[0].Visible = false;//第一列为空
            //dgv.ColumnHeadersHeight =1000;为啥不起作用？？
            dgv.Columns[1].FillWeight = 50;
            //dgv.Columns[1].Frozen = true;//第1列冻结，
            dgv.SelectionMode = DataGridViewSelectionMode.FullRowSelect;//行选中
            for (int i = 2; i < dgv.Columns.Count - 1; i++)
            {
                //设置列宽和文本居中
                dgv.Columns[i].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
                dgv.Columns[i].Width = 80;
            }
            //设置数据行行高
            for (int i = 0; i < dgv.RowCount ; i++)
            {
                dgv.Rows[i].Height = 40;
            }
            dgv.ColumnHeadersHeight =40;
            dgv.RowTemplate.Height = 40;
            dgv.Columns[1].Width = 450;
            dgv.Columns[6].Width = 200;
            dgv.Update();
        }


        //初始化语句dgv格式
        public void init_dgvSQLInfoFormat(DataGridView dgv)
        {
            dgv.AllowUserToAddRows = false;
            dgv.ReadOnly = true;//表格只读
            dgv.RowHeadersVisible = true;//标题行可见
            dgv.Columns[0].Visible = false;//第一列为空
            dgv.Columns[1].FillWeight = 50;
            dgv.Columns[1].Width = 300;
            dgv.Columns[2].DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
            dgv.Columns[2].Width = 80;
            dgv.Columns[3].Width = 500;

            //设置数据行行高
            for (int i = 0; i < dgv.RowCount; i++)
            {
                dgv.Rows[i].Height = 40;
            }
            //标题行的行高
            dgv.ColumnHeadersHeight = 40;
            dgv.RowTemplate.Height = 40;
            //dgv.Columns[1].Width = 50;
            dgv.Update();
        }


        //绘制dgv行号
        public void init_dgv(DataGridViewRowPostPaintEventArgs e, DataGridView dgv)
        {
            SolidBrush b = new SolidBrush(dgv.RowHeadersDefaultCellStyle.ForeColor);
            e.Graphics.DrawString((e.RowIndex + 1).ToString(System.Globalization.CultureInfo.CurrentUICulture), dgv.DefaultCellStyle.Font, b, e.RowBounds.Location.X + 20, e.RowBounds.Location.Y + 4);
        }

        //单击鼠标右键，返回dgv当前“行”索引值
        public void dgv_CellMouseDown(DataGridViewCellMouseEventArgs e, DataGridView dgv, ContextMenuStrip cms, int x, int y)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    if (dgv.Rows[e.RowIndex].Selected == false)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[e.RowIndex].Selected = true;
                    }
                    if (dgv.SelectedRows.Count == 1)
                    {
                        dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    dgv_currentRow = (int)dgv.Rows[e.RowIndex].Cells[0].Value;
                    dgv_currentCol = e.ColumnIndex;
                    //当前位置，产生下拉菜单
                    cms.Show(x, y);
                }
            }
        }

        //bigwork
        public int dgv_CellMouseDown(DataGridViewCellMouseEventArgs e, DataGridView dgv)
        {
            if (e.Button == MouseButtons.Right)
            {
                if (e.RowIndex >= 0)
                {
                    if (dgv.Rows[e.RowIndex].Selected == false)
                    {
                        dgv.ClearSelection();
                        dgv.Rows[e.RowIndex].Selected = true;
                    }
                    if (dgv.SelectedRows.Count == 1)
                    {
                        dgv.CurrentCell = dgv.Rows[e.RowIndex].Cells[e.ColumnIndex];
                    }
                    //dgv_currentRow = (int)dgv.Rows[e.RowIndex].Cells[0].Value;
                    dgv_currentRow = (int)dgv.Rows[e.RowIndex].Cells[1].Value;
                    dgv_currentCol = e.ColumnIndex;

                    return (int)dgv.Rows[e.RowIndex].Cells[0].Value;
                    //当前位置，产生下拉菜单
                }
            }
            return 0;
        }
    }
}
