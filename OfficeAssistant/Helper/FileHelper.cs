using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


using System.IO;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using System.Drawing;

namespace OfficeAssistant.Helper
{
    public class FileHelper
    {
        SqlHelper sh = new SqlHelper();
        
        //获取路径，暂时好像没用上这个函数
        public string getFoldPath()
        {
            string foldPath = null;
            SaveFileDialog s = new SaveFileDialog();

            FolderBrowserDialog dialog = new FolderBrowserDialog();
            dialog.Description = "请选择保存路径";
            if (dialog.ShowDialog() == DialogResult.OK)
            {
                foldPath = dialog.SelectedPath;
                //textBox1.Text = foldPath;
            }
            return foldPath;
        }

        //把文件存入数据库，返回判断存入是否成功
        //filePath文件路径（包含文件名）
        public bool storeFiles(string[] fileinfo,int fileID)
        {
            try
            {
                sh.InitCon();
                string fileName = fileinfo[0].Substring(fileinfo[0].LastIndexOf("\\") + 1);
                FileStream pFileStream = new FileStream(fileinfo[0], FileMode.Open, FileAccess.Read);
                byte[] bytes = new byte[pFileStream.Length];
                pFileStream.Read(bytes, 0, (int)pFileStream.Length);
                string strSQL = "insert into fileinfo(id, filename, fileDate, fileClassID, fileUserID, fileNote, fileDatas, workClassID) values (@id, @filename, @fileDate, @fileClassID, @fileUserID, @fileNote, @fileDatas, @workClassID)";
                using (SqlCommand cmd = new SqlCommand(strSQL, sh.conn))
                {
                    cmd.Parameters.Add("@id", SqlDbType.Int);//文档id，唯一识别码
                    cmd.Parameters.Add("@filename", SqlDbType.NVarChar);//文件名称
                    cmd.Parameters.Add("@fileDate", SqlDbType.NVarChar);//文件存储日期，12个长度的字符串存储
                    cmd.Parameters.Add("@fileClassID", SqlDbType.Int);//文件类别编号
                    cmd.Parameters.Add("@fileUserID", SqlDbType.Int);//文件承办人编号
                    cmd.Parameters.Add("@workClassID", SqlDbType.Int);//文件业务编号
                    cmd.Parameters.Add("@fileNote", SqlDbType.NVarChar);//文件备注，包括承办意见等
                    cmd.Parameters.Add("@fileDatas", SqlDbType.Image);//文件内容
                    cmd.Parameters["@id"].Value = fileID;//int.Parse(fileinfo[0]);
                    cmd.Parameters["@filename"].Value = fileName;
                    cmd.Parameters["@fileDate"].Value = fileinfo[4];//
                    cmd.Parameters["@fileClassID"].Value = int.Parse(fileinfo[1]);
                    cmd.Parameters["@fileUserID"].Value = int.Parse(fileinfo[2]);
                    cmd.Parameters["@fileNote"].Value = fileinfo[3];
                    cmd.Parameters["@fileDatas"].Value = bytes;
                    cmd.Parameters["@workClassID"].Value = fileinfo[5];
                    cmd.ExecuteNonQuery();
                }
                return true;
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
        }

        //通过文件id获取文件名
        private string getFileName(int id)
        {
            sh = new SqlHelper();
            string sql = string.Format("select fileName from fileInfo where id='{0}'", id);
            return sh.getSelectRows(sql).ToString();
        }

        //打开文件,设置后台缓存，再打开，并删除！
        public void openFile(int fileID)
        {
            sh.InitCon();
            string strSql = string.Format("select fileDatas from fileinfo where id='{0}'", fileID);
            SqlCommand cmd = new SqlCommand(strSql, sh.conn);
            SqlDataReader dr = cmd.ExecuteReader();
            byte[] file = null;
            if (dr.Read())
                file = (byte[])dr[0];
            dr.Close();
            string fn = getFileName(fileID);
            string fileName = @"C:\" + fn;
            FileStream fs = new FileStream(fileName, FileMode.OpenOrCreate, FileAccess.Write);
            BinaryWriter bw = new BinaryWriter(fs);
            bw.Write(file, 0, file.Length);
            bw.Close();
            fs.Close();
            System.Diagnostics.Process.Start(fileName);
        }
        
        //删除文件
        public void file_delete(int id)
        {
            string path_str = @"C:\";
            string sql = string.Format("select fileName from fileInfo where id='{0}'", id);
            string filename = sh.getSelectRows(sql).ToString();
            path_str = path_str + filename;
            File.Delete(path_str);
        }

        //将数据库中数据写入文件
        //destFilePath目标文件路径（包含文件名）
        //filename主要用于查找文件信息，转换为id更合适
        public bool wrietFromDB2File(int fileID, string FilePath)
        {
            string fileFullName = FilePath + "/" + getFileName(fileID);
            
            FileStream pFileStream = null;
            try
            {
                sh.InitCon();
                string strSql = string.Format("select fileDatas from fileinfo where id='{0}'", fileID);
                SqlCommand cmd = new SqlCommand(strSql, sh.conn);
                SqlDataReader dr = cmd.ExecuteReader();
                dr.Read();

                byte[] bytes = (byte[])dr[0];
                pFileStream = new FileStream(fileFullName, FileMode.OpenOrCreate, FileAccess.ReadWrite);
                pFileStream.Write(bytes, 0, bytes.Length);

                return true;
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
                return false;
            }
            finally
            {
                if (pFileStream != null)
                {
                    pFileStream.Close();
                }
            }
        }
    }
}
