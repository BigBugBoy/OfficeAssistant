using System;
using System.Collections.Generic;
using System.Text;
using System.Data;
using System.Data.SqlClient;

namespace OfficeAssistant
{
    public class SqlHelper
    {
        private string ServerIP = "(local)";
        private string ServerDBSource = "DB_wwj";
        private string ServerDBUserName = "sa";
        private string ServerDBPsw = "123456";

        private string con_str;
        public SqlConnection conn;

        private void getCon_str()
        {
            con_str = string.Format("Data Source={0};Initial Catalog={1};uid={2};pwd={3}", ServerIP, ServerDBSource, ServerDBUserName, ServerDBPsw);
            conn = new SqlConnection(con_str);
        }

        private void getCon_str(string ip)
        {
            con_str = string.Format("Data Source={0};Initial Catalog={1};uid={2};pwd={3}", ServerIP, ServerDBSource, ServerDBUserName, ServerDBPsw);
            conn = new SqlConnection(con_str);
        }

        private void openBrokenConnect()
        {
            try
            {
                conn.Close();
                conn.Open();
            }
            catch (SqlException e)
            {
                conn.Close();
                conn.Dispose();
                e.ToString();
            }
        }

        private void openClosedConnect()
        {
            try
            {
                conn.Open();
            }
            catch (SqlException e)
            {
                conn.Close();
                conn.Dispose();
                e.ToString();
            }
        }

        //数据库连接，初始化函数
        public void InitCon()
        {
            //如果连接对象未实例化
            if (conn == null)
                getCon_str();
            //如果中断状态，重启
            if (conn.State == ConnectionState.Broken)
                openBrokenConnect();
            //如果关闭状态
            if (conn.State == ConnectionState.Closed)
                openClosedConnect();
        }

        // 第一次登陆，数据库连接，初始化函数
        public void InitCon(string ip)
        {
            //如果连接对象未实例化
            if (conn == null)
                getCon_str(ip);
            //如果中断状态，重启
            if (conn.State == ConnectionState.Broken)
                openBrokenConnect();
            //如果关闭状态
            if (conn.State == ConnectionState.Closed)
                openClosedConnect();
        }

        //登陆使用，执行select，返回查询结果
        public object getSelectRows(string ip, string sql)
        {
            InitCon(ip);
            SqlCommand com = new SqlCommand(sql, conn);
            object row = com.ExecuteScalar();
            conn.Close();
            return row;
        }

        //对连接执行 Transact-SQL 语句并返回受影响的行数，返回收影响的行数
        public int getExecuteRows(string sql, SqlParameter[] parmas)
        {
            InitCon();
            SqlCommand com = new SqlCommand(sql, conn);
            for (int i = 0; i < parmas.Length; i++)
            {
                com.Parameters.Add(parmas[i]);
            }
            return com.ExecuteNonQuery();
        }

        //执行删改增时，返回受影响的行数
        public int getExecuteRows(string sql)
        {
            InitCon();
            SqlCommand com = new SqlCommand(sql, conn);
            int row = com.ExecuteNonQuery();
            conn.Close();
            return row;
        }

        //将数据库查询结果保存到内存DataTable表中
        public DataTable executeSqlDataTable(string sql)
        {
            InitCon();
            DataTable dt = new DataTable();
            SqlDataAdapter dp = new SqlDataAdapter(sql, conn);
            dt.Clear();
            dp.Fill(dt);
            conn.Close();
            return dt;
        }

        //执行select，用于第一行第一列的值（一个表相当于一个类，每一列相当于他的实例，在此处，可以利用select返回一个唯一实例）
        public object getSelectRows(string sql)
        {
            InitCon();
            SqlCommand com = new SqlCommand(sql, conn);
            object row = com.ExecuteScalar();
            conn.Close();
            return row;
        }
    }
}
