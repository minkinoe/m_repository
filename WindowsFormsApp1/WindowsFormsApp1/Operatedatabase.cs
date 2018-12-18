using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Data;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    class OperateDatabase
    {
        /// <summary>
        /// 查询数据
        /// </summary>
        /// <param name="sqlStr">查询语句</param>
        /// <returns></returns>
        public static DataTable QueryData(string sqlStr, string constr)
        {
            SqlConnection con = new SqlConnection();
            SqlCommand com = new SqlCommand();
            SqlDataAdapter sda = new SqlDataAdapter();
            DataTable dt = new DataTable();
            con.ConnectionString = constr;
            com.CommandText = sqlStr;
            // com.Parameters.AddWithValue("@s",str);
            com.Connection = con;
            sda.SelectCommand = com;
            try
            {
                con.Open();
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                //MessageBox.Show(ex.Message);
            }
            finally
            {
                sda.Dispose();
                com.Dispose();
                con.Close();
            }
            return dt;
        }
        /// <summary>
        /// 更新数据
        /// </summary>
        /// <param name="sqlStr">更新语句</param>
        /// <returns></returns>
        public static bool UpdateData(string sqlStr, string constr)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(sqlStr);
                    cmd.Connection = conn;
                    conn.ConnectionString = constr;
                    conn.Open();
                    var row = cmd.ExecuteNonQuery();//执行SQL语句并返回受影响行数
                    conn.Close();
                    if (row > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除数据异常！！！" + ex.Message);
                return false;
            }
        }
        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="sqlStr">删除语句</param>
        /// <returns></returns>
        public static bool DeleteData(string sqlStr, string constr)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(sqlStr);
                    cmd.Connection = conn;
                    conn.ConnectionString = constr;
                    conn.Open();
                    var row = cmd.ExecuteNonQuery();//执行SQL语句并返回受影响行数
                    conn.Close();
                    if (row > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("删除数据异常]]]]]" + ex.Message);
                return false;
            }
        }
        /// <summary>
        ///添加数据
        /// </summary>
        /// <param name="sqlStr">删除语句</param>
        /// <returns></returns>
        public static bool AddData(string sqlStr, string constr)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection())
                {
                    SqlCommand cmd = new SqlCommand(sqlStr);
                    cmd.Connection = conn;
                    conn.ConnectionString = constr;
                    conn.Open();
                    var row = cmd.ExecuteNonQuery();//执行SQL语句并返回受影响行数
                    conn.Close();
                    if (row > 0)
                    {
                        return true;
                    }
                    return false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("添加数据异常" + ex.Message);
                return false;
            }
        }
    }
}

