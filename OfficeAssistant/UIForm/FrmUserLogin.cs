using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Windows.Forms;

using OfficeAssistant.Helper;

namespace OfficeAssistant.UIForm
{
    public partial class FrmUserLogin : Form
    {
        public FrmUserLogin()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 登录按钮触发函数，记录静态变量roler和userID，一个是权限、一个是用户唯一标识
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton1_Click(object sender, EventArgs e)
        {
            int lj2 =loginJugle2(lc_localIP.Text.ToString(), te_userName.Text.ToString(), te_userPsd.Text.ToString());
            try
            {
                switch (lj2)
                {
                    case 0:
                        SqlHelper sh = new SqlHelper();
                        string sql = @"select userRole from  [Users] where userIP='" + lc_localIP.Text.ToString() + "'";
                        StaticHelper.roler = Convert.ToInt32(sh.getSelectRows(sql));
                        string sql2 = @"select userID from  [Users] where userIP='" + lc_localIP.Text.ToString() + "'";
                        StaticHelper.userID = Convert.ToInt32(sh.getSelectRows(sql2));
                        StaticHelper sth = new StaticHelper();
                        sth.updateUserName();
                        MessageBox.Show("登录成功！");
                        this.Close();
                        break;
                    case 1: MessageBox.Show("账号或密码信息不全");
                        break;
                    case 2: MessageBox.Show("IP地址不正确");
                        break;
                    case 3: MessageBox.Show("账号或密码错误", "提示");
                        break;
                    default: MessageBox.Show("登录失败", "提示");
                        break;
                }
            }
            catch
            {
                MessageBox.Show("登录失败", "提示");
            }
        }

        /// <summary>
        /// 判断输入的ip、用户名和密码是否一致
        /// </summary>
        /// <param name="ip"></param>
        /// <param name="name"></param>
        /// <param name="psd"></param>
        /// <returns></returns>
        private int loginJugle2(string ip,string name,string psd)
        {
            //获取IP地址数量
            string sqlIP = @"select count(*) from [Users] where  userIP='" + ip + "'";
            //根据IP地址和用户名，查询用户密码
            string sql = @"select userPassWord from [Users] where userName ='" + name + "' and userIP='" + ip + "'";
            SqlHelper sh = new SqlHelper();
            if (!loginJugle())
                return 1;
            else if (Convert.ToInt32(sh.getSelectRows(sqlIP)) == 0)
                return 2;
            else if (sh.getSelectRows(sql).ToString() != psd)
                return 3;
            else
                return 0;
        }

        /// <summary>
        /// 获取本地IP地址方法1
        /// </summary>
        /// <returns></returns>
        public string GetLocalIp1()
        {
            
            string AddressIP = string.Empty;
            foreach (IPAddress _IPAddress in Dns.GetHostEntry(Dns.GetHostName()).AddressList)
            {
                if (_IPAddress.AddressFamily.ToString() == "InterNetwork")
                {
                    AddressIP = _IPAddress.ToString();
                }
            }
            return AddressIP;
        }

        /// <summary>
        /// 获取本地IP地址方法2
        /// </summary>
        /// <returns></returns>
        public string GetLocalIP2()
        {
            try
            {

                string HostName = Dns.GetHostName(); //得到主机名
                IPHostEntry IpEntry = Dns.GetHostEntry(HostName);
                for (int i = 0; i < IpEntry.AddressList.Length; i++)
                {
                    //从IP地址列表中筛选出IPv4类型的IP地址
                    //AddressFamily.InterNetwork表示此IP为IPv4,
                    //AddressFamily.InterNetworkV6表示此地址为IPv6类型
                    if (IpEntry.AddressList[i].AddressFamily == AddressFamily.InterNetwork)
                    {
                        string ip = "";
                        ip = IpEntry.AddressList[i].ToString();
                        return IpEntry.AddressList[i].ToString();
                    }
                }
                return "";
            }
            catch (Exception ex)
            {
                return ex.Message;
            }
        }

        /// <summary>
        /// 判断登陆界面输入信息是否为空
        /// </summary>
        /// <returns></returns>
        private bool loginJugle()
        {
            if (lc_localIP.Text.Trim() == "" || string.IsNullOrEmpty(lc_localIP.Text))
            {
                MessageBox.Show("获取本地IP地址失败，请联系管理员！", "登录提示");
                return false;
            }
            else if (te_userPsd.Text.Trim() == "" || string.IsNullOrEmpty(te_userPsd.Text))
            {
                //MessageBox.Show("密码不能为空！", "登录提示");
                te_userPsd.Focus();
                return false;
            }
            else if (te_userName.Text.Trim() == "" || string.IsNullOrEmpty(te_userName.Text))
            {
                //MessageBox.Show("用户名不能为空！", "登录提示");
                te_userName.Focus();
                return false;
            }
            else return true;
        }

        /// <summary>
        /// 窗体显示时，利用方法1，获取本地IP地址
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void UserLogin_Load(object sender, EventArgs e)
        {
            lc_localIP.Text = GetLocalIp1();
        }

        /// <summary>
        /// 点击退出按钮，关闭当前窗口
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void simpleButton2_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
