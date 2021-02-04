using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;

using DevExpress.XtraBars.Helpers;

using OfficeAssistant.UIForm;
using OfficeAssistant.Helper;

namespace OfficeAssistant
{
    public partial class FrmMain : DevExpress.XtraBars.Ribbon.RibbonForm
    {
        public FrmMain()
        {
            InitializeComponent();

            //加载dvE界面样式，供用户选择
            SkinHelper.InitSkinGallery(ribbonGalleryBarItem1);
        }

        /// <summary>
        /// 点击文件修改按钮，激活文件修改panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem9_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {

        }

        /// <summary>
        /// 点击登录按钮，生成登录Form
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem3_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            FrmUserLogin ul = new FrmUserLogin();
            ul.ShowDialog();
            updateUIForm();
        }

        /// <summary>
        /// 主窗口展开，激活UI显示事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_Load(object sender, EventArgs e)
        {
            updateUIForm();
        }

        /// <summary>
        /// 根据用户权限不同，不同界面修改权限控制
        /// </summary>
        private void updateUIForm()
        {
            switch(StaticHelper.roler)
            {
                case 0:
                    barStaticItem1.Caption = "欢迎，您现在是游客身份，请先登录！";
                    UIshow0();   //临时人员
                    break;
                case 1:
                    barStaticItem1.Caption = "欢迎管理员：" + StaticHelper.userName;
                    UIshow1();   //管理员
                    break;
                case 2:
                    barStaticItem1.Caption = "欢迎超级用户：" + StaticHelper.userName;
                    UIshow2();   //超级用户
                    break;
                case 3:
                    barStaticItem1.Caption = "欢迎普通用户：" + StaticHelper.userName;
                    UIshow3();   //普通用户
                    break;
                default: 
                    UIshow0();
                    break;
            }
        }

        /// <summary>
        /// 临时人员，界面显示
        /// </summary>
        private void UIshow0()
        {

        }

        /// <summary>
        /// 管理员，界面显示
        /// </summary>
        private void UIshow1()
        {
 
        }

        /// <summary>
        /// 超级用户
        /// </summary>
        private void UIshow2()
        { }

        /// <summary>
        /// 普通用户
        /// </summary>
        private void UIshow3()
        { }

        /// <summary>
        /// 修改用户信息，管理员权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem2_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showUserModifyInfoForm();
        }

        /// <summary>
        /// 激活用户信息修改界面
        /// </summary>
        private void showUserModifyInfoForm()
        {
            panelControl0.Controls.Clear();
            UCUserInfoChange umi = new UCUserInfoChange(StaticHelper.userID);
            umi.Dock = DockStyle.Fill;
            panelControl0.Controls.Add(umi);
        }

        /// <summary>
        /// 中止所有线程，退出程序
        /// </summary>
        private void stopPrograme()
        {
            //程序退出确认
            DialogResult quit = MessageBox.Show("请再次确认是否退出？", "退出确认", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (quit.ToString() == "Cancel")
            {
                return;
            }
            else
            {
                Dispose();
                //暴力终止所有线程，退出程序
                System.Environment.Exit(0);
            }
        }

        /// <summary>
        /// 点击退出按钮，触发程序中止函数
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem45_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            stopPrograme();
        }

        /// <summary>
        /// 主窗体关闭后，触发线程缓存释放，强制关闭所有按钮
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void FrmMain_FormClosed(object sender, FormClosedEventArgs e)
        {
            Dispose();
            System.Environment.Exit(0);
        }

        /// <summary>
        /// 查询所有用户信息，管理员权限
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem47_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showUserPanel();
        }

        /// <summary>
        /// 激活用户容器，userPanel
        /// </summary>
        private void showUserPanel()
        {
            panelControl0.Controls.Clear();
            UserPanel up = new UserPanel();
            up.Dock = DockStyle.Fill;
            panelControl0.Controls.Add(up);
        }

        /// <summary>
        /// 点击-文件-查询-按钮，激活文件panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem5_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showFileInfoPanel();
        }

        /// <summary>
        /// 显示文件信息表
        /// </summary>
        private void showFileInfoPanel()
        {
            panelControl0.Controls.Clear();
            UCFileInfo fi = new UCFileInfo();
            fi.Dock = DockStyle.Fill;
            panelControl0.Controls.Add(fi);
        }

        /// <summary>
        /// 点击上传按钮，激活文件上传Panel
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void barButtonItem6_ItemClick(object sender, DevExpress.XtraBars.ItemClickEventArgs e)
        {
            showUCFileUpload();
        }

        /// <summary>
        /// 上传文件Panel
        /// </summary>
        private void showUCFileUpload()
        {
            panelControl0.Controls.Clear();
            UCFileUpload ucfu = new UCFileUpload();
            ucfu.Dock = DockStyle.Fill;
            panelControl0.Controls.Add(ucfu);
        }
    }
}
