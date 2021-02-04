using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace OfficeAssistant.Helper
{
    public class StaticHelper
    {
        //登录用户角色，默认0，为临时人员
        public static int roler = 0;

        //登录用户唯一ID，用于绑定个人信息
        public static int userID = 0;

        public static string userName = "";

        public void updateUserName()
        {
            getUserName();
        }

        /// <summary>
        /// 根据静态userID值，获取用户姓名
        /// </summary>
        /// <returns></returns>
        private void getUserName()
        {
            SqlHelper sh = new SqlHelper();
            string sql = @"select userName from  [Users] where userID='" + userID + "'";
            userName = sh.getSelectRows(sql).ToString();
        }
    }
}
