using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace WindowsFormsApp1
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }

        private void set_week_ValueChanged(object sender, EventArgs e)
        {
            set_week.Minimum = 1;     //设置允许的最小值 
            set_week.Maximum = 7;   //设置允许的最大值 
            set_week.Increment = 1;       //设置步长为1 
            set_week.InterceptArrowKeys = true;    //允许通过上下箭头调整值
        }

        SqlConnection conn = new SqlConnection();
        SqlCommand comm = new SqlCommand();
        SqlCommand comm2 = new SqlCommand();
        SqlCommand comm3 = new SqlCommand();
        SqlCommand comm4 = new SqlCommand();
        SqlCommand comm5 = new SqlCommand();
        SqlDataAdapter sda = new SqlDataAdapter();
        SqlDataAdapter sda2 = new SqlDataAdapter();
        SqlDataAdapter sda3 = new SqlDataAdapter();
        SqlDataAdapter sda4 = new SqlDataAdapter();
        DataTable dt = new DataTable();//科室
        DataTable pdt = new DataTable();//医生
        DataTable mdt;
        DataTable ydt;
        DataTable kdt;
        TreeNode Tn;
        TreeNode Tn1;


        private void treeView1_AfterSelect(object sender, TreeViewEventArgs e)
        {
            label2.Text = "        时间          职称                 医生编号             上下午 ";
            listBox1.Items.Clear();

            TreeNode tn = e.Node;

            if (tn.Nodes.Count == 0)//选择医生结点
            {
                listBox2.Visible = false;
                Confirm.Visible = false;//确认排班
                Leave.Visible = true;//请假
                Tn1 = tn;

                comm3.Connection = conn;
                comm3.CommandText = "select * from Dc,[hostital1].[dbo].[Menzhenpaiban] where [Menzhenpaiban].Dno= [hostital1].[dbo].[Dc].Dno and Dname='" + tn.Text + "'";

                sda3.SelectCommand = comm3;
                mdt = new DataTable();

                try
                {
                    conn.Open();
                    sda3.Fill(mdt);
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sda3.Dispose();
                    comm3.Dispose();
                    conn.Close();
                    
                }

                listBox1.BeginUpdate();//显示医生排班信息

                for (int i = 0; i < mdt.Rows.Count; i++)
                {
                    
                    listBox1.Items.Add(mdt.Rows[i]["Mtime"].ToString() + "   " + mdt.Rows[i]["Dzhicheng"].ToString() + " " + mdt.Rows[i]["Dno"].ToString() +"" +zhuanghuan((bool)mdt.Rows[i]["flag"]) );
                }

                listBox1.EndUpdate();
                

            }
            else //选择科室结点，列出一个礼拜的医生排班
            {
                label2.Text = "科室编号             医生工号            星期             上下午";
                Leave.Visible = false;
                Tn = tn;
                listBox2.Items.Clear();
                comm3.Connection = conn;
                comm3.CommandText = "select * from [hostital1].[dbo].[Ks],[hostital1].[dbo].[paiban] where [paiban].Kno= [hostital1].[dbo].[Ks].Kno and Kname='" + tn.Text + "'";

                sda3.SelectCommand = comm3;
                mdt = new DataTable();

                try
                {
                    conn.Open();
                    sda3.Fill(mdt);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sda3.Dispose();
                    comm3.Dispose();
                    conn.Close();

                }

                listBox1.BeginUpdate();

                for (int i = 0; i < mdt.Rows.Count; i++)//显示医生信息
                {
                    listBox1.Items.Add(mdt.Rows[i]["Kno"].ToString() + " " + mdt.Rows[i]["Dno"].ToString() + " " + mdt.Rows[i]["xingqi"].ToString() + "                " + zhuanghuan((bool)mdt.Rows[i]["flag"]));
                }

                listBox1.EndUpdate();

                //选择医生后，排一个星期的班
                listBox2.Visible = true;
                Confirm.Visible = true;
                
                comm4.Connection = conn;
                comm4.CommandText = "select * from [hostital1].[dbo].[Dc],[hostital1].[dbo].[Ks] where [Ks].Kno= [hostital1].[dbo].[Dc].Kno and [Ks].Kname='" + Tn.Text + "'";
                sda4.SelectCommand = comm4;
                ydt = new DataTable();
                try
                {
                    conn.Open();
                    sda4.Fill(ydt);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sda4.Dispose();
                    comm4.Dispose();
                    conn.Close();

                }

                listBox2.BeginUpdate();

                for (int i = 0; i < ydt.Rows.Count; i++)
                {
                    listBox2.Items.Add(ydt.Rows[i]["Dname"].ToString());
                }

                listBox2.EndUpdate();

                if (listBox1.Items.Count == 14)//7天上下午排班排满，应用排班
                {
                    Application.Enabled = true;

                }
                else
                {
                    Application.Enabled = false;
                }
            }
        }
        

        private void Form3_Load(object sender, EventArgs e)
        {

            conn.ConnectionString = @"Data Source=localhost\sqlexpress;Initial Catalog=hostital1;Integrated Security=True";
            comm.Connection = conn;
            comm.CommandText = "select * from [hostital1].[dbo].[Ks]";

            sda.SelectCommand = comm;

            try
            {
                conn.Open();
                sda.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sda.Dispose();
                comm.Dispose();
                conn.Close();
            }

            //添加结点
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                treeView1.Nodes.Add(dt.Rows[i][1].ToString());
                comm2.CommandText = "select * from [hostital1].[dbo].[Dc] where Kno=" + dt.Rows[i][0].ToString();
                comm2.Connection = conn;
                sda2.SelectCommand = comm2;

                try
                {
                    conn.Open();
                    sda2.Fill(pdt);

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                }
                finally
                {
                    sda2.Dispose();
                    comm2.Dispose();
                    conn.Close();
                }

                for (int j = 0; j < pdt.Rows.Count; j++)
                {

                    if (pdt.Rows[j][3].ToString() == dt.Rows[i][0].ToString())//医生表的第4列Kno等于科室表的第1列Kno
                    {
                        treeView1.Nodes[i].Nodes.Add(pdt.Rows[j][1].ToString());
                    }
                }
            }
            
        }
        
        private void button1_Click(object sender, EventArgs e)
        {
            string choose_ks;//选的科室名字 Ks.Kname
           
            int choose_ys;//选的医生 Dc.Dno和paiban.Dno
            int xingqi;//选的星期几 paiban.xingqi
            int wu;//选的上午还是下午 paiban.flag
            choose_ys = listBox2.SelectedIndex;
            xingqi = (int)set_week.Value;

            string ys_ID = ydt.Rows[choose_ys]["Dno"].ToString();//医生工号

            if (set_shang.Checked)
                wu = 0;
            else 
                wu = 1;

            string Kno;
            DataRow[] dr;
            choose_ks= treeView1.SelectedNode.Text;
            dr = dt.Select("Kname='" + choose_ks+"'");
            Kno = dr[0][0].ToString();

            //给医生排班，添加排班信息
            comm5.Connection = conn;
            comm5.CommandText = "insert into [hostital1].[dbo].[paiban](Kno,Dno,xingqi,flag)values("+Kno+","+ys_ID+","+xingqi+","+wu+")";

            try
            {
                conn.Open();
                comm5.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
                mdt.Dispose();
                ydt.Dispose();

            }
            
            reflash();
        
        }
        void reflash()//刷新，重新执行一遍
        {

            listBox1.Items.Clear();
            comm3.Connection = conn;
            comm3.CommandText = "select * from [hostital1].[dbo].[Ks],[hostital1].[dbo].[paiban] where [paiban].Kno= [hostital1].[dbo].[Ks].Kno and Kname='" + Tn.Text + "'";

            sda3.SelectCommand = comm3;
            kdt = new DataTable();

            try
            {
                conn.Open();
                sda3.Fill(kdt);


            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sda3.Dispose();
                comm3.Dispose();
                conn.Close();

            }
            listBox1.BeginUpdate();

            for (int i = 0; i < kdt.Rows.Count; i++)
            {
                listBox1.Items.Add(kdt.Rows[i]["Kno"].ToString() + " " + kdt.Rows[i]["Dno"].ToString() + " " + kdt.Rows[i]["xingqi"].ToString() + " " + zhuanghuan((bool)kdt.Rows[i]["flag"]));
            }

            listBox1.EndUpdate();
            kdt.Dispose();

            if (listBox1.Items.Count == 14)
            {
                Application.Enabled = true;//应用排班

            }
            else
            {
                Application.Enabled = false;
            }
        }

        private void button2_Click(object sender, EventArgs e)//应用排班
        {
            DateTime nowtime = DateTime.Now;
            DateTime newtime = new DateTime(2019,1,1);
            DateTime time = nowtime;
            DateTime oneday = new DateTime(1);

            comm3 = new SqlCommand();
            sda3 = new SqlDataAdapter();

            comm3.Connection = conn;
            comm3.CommandText = "select * from [hostital1].[dbo].[Ks],[hostital1].[dbo].[paiban] where [paiban].Kno= [hostital1].[dbo].[Ks].Kno and Kname='" + Tn.Text + "'";

            sda3.SelectCommand = comm3;
            kdt = new DataTable();

            try
            {
                conn.Open();
                sda3.Fill(kdt);

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sda3.Dispose();
                comm3.Dispose();
                conn.Close();

            }
            int weeks = 1;

            for (int i = 0; i < (newtime - nowtime).Days; i++)
            {
                string week = time.DayOfWeek.ToString();
                
                switch(week)
                {
                    case "Monday":weeks = 1;break;
                    case "Tuesday":weeks = 2;break;
                    case "Wednesday":weeks = 3;break;
                    case "Thursday": weeks = 4; break;
                    case "Friday": weeks = 5; break;
                    case "Saturday": weeks = 6; break;
                    case "Sunday": weeks = 7; break;

                }

                comm3 = new SqlCommand();
                comm3.Connection = conn;
                SqlCommand comm9 = new SqlCommand();
                comm9.Connection=conn;

                DataRow[] dr;
                
                dr = kdt.Select("xingqi='" + weeks + "'");

                int wu1,wu2; 
                if ((bool)dr[0]["flag"])
                    wu1 = 0;
                else
                    wu1 = 1;
                if ((bool)dr[1]["flag"])
                    wu2 = 0;
                else
                    wu2 = 1;

                comm3.CommandText = "insert into [hostital1].[dbo].[Menzhenpaiban](Kno,Dno,Mtime,flag)values(" + dr[0]["Kno"] + "," + dr[0]["Dno"] + "," + "'" +time.Year+"-" + time.Month + "-"+time.Day + "'"+"," + wu1 + ")";
                comm3.CommandText += "insert into [hostital1].[dbo].[Menzhenpaiban](Kno,Dno,Mtime,flag)values(" + dr[1]["Kno"] + "," + dr[1]["Dno"] + "," + "'" + time.Year + "-" + time.Month + "-" + time.Day + "'" + "," + wu2 + ")";
                comm9.CommandText = "insert into [hostital1].[dbo].[Hyc](Kno,Dno,Mtime,flag,haoyuan,keyuyueshu)values(" + dr[0]["Kno"] + "," + dr[0]["Dno"] + "," + "'" + time.Year + "-" + time.Month + "-" + time.Day + "'" + "," + wu1 +","+25+","+0+ ")";
                comm9.CommandText = "insert into [hostital1].[dbo].[Hyc](Kno,Dno,Mtime,flag,haoyuan,keyuyueshu)values(" + dr[1]["Kno"] + "," + dr[1]["Dno"] + "," + "'" + time.Year + "-" + time.Month + "-" + time.Day + "'" + "," + wu2 + "," + 25 + "," + 0 + ")";
                try
                {
                    conn.Open();
                    comm3.ExecuteNonQuery();
                    comm9.ExecuteNonQuery();

                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.ToString());
                }
                finally
                {
                    conn.Close();
                    comm3.Dispose();
                    comm9.Dispose();
                }
                time = nowtime.AddDays(i);

            }

        }

        private void button3_Click(object sender, EventArgs e)//更新号源
        {
            List<Appointmentlist> appointmentlist = new List<Appointmentlist>();
            Appointmentlist haoyuansu = new Appointmentlist();
            string strtommrrow = DateTime.Today.AddDays(1).ToShortDateString();
            string getdate(int i) { return DateTime.Today.AddDays(i).ToShortDateString(); }
            if (true)//strtommrrow == strdatetime
            {
                using (SqlConnection connection = GetConnection())
                {
                    connection.Open();
                    SqlCommand firstcommand = new SqlCommand("delete from Hyc where Mtime='" + getdate(0) + "';delete from Menzhenpaiban where Mtime='" + getdate(0) + "';update Hyc set keyuyueshu+=haoyuan from Hyc where Mtime='" + getdate(1) + "';update Hyc set haoyuan = 0 from Hyc where Mtime = '" + getdate(1) + "'; ", connection);
                    firstcommand.ExecuteNonQuery();
                    /**************** FIRST SQL COMMAND ****************
                     * delete from Hyc where Mtime='" + getdate(0) + "'; 删除今日号源
                     * delete from Menzhenpaiban where Mtime='" + getdate(0) + "';删除今日排班
                     * update Hyc set Kyuyueshu+=Haoyuanshu from Hyc where Mtime='" + getdate(1) + "';放出明日所有号源1：Kyuyueshu+=Haoyuanshu
                     * update Hyc set Haoyuanshu = 0 from Hyc where Mtime = '" + getdate(1) + "';放出明日所有号源2：Haoyuanshu = 0
                    */
                    for (int i = 3; i < 7; i++)
                    {

                        SqlCommand qurecommand = new SqlCommand("SELECT haoyuan FROM Hyc WHERE Mtime='" + getdate(i) + "';", connection);
                        using (SqlDataReader qurereader = qurecommand.ExecuteReader())
                        {
                            while (qurereader.Read())
                            {
                                haoyuansu.Haoyuanshu = int.Parse(qurereader["haoyuan"].ToString());

                            }

                        }
                        if (haoyuansu.Haoyuanshu < 5)
                        {
                            SqlCommand firstcommand2 = new SqlCommand("update Hyc set keyuyueshu+=haoyuan from Hyc where Mtime='" + getdate(i) + "';update Hyc set haoyuan = 0 from Hyc where Mtime = '" + getdate(i) + "'; ", connection);
                            firstcommand2.ExecuteNonQuery();
                        }
                        else
                        {
                            SqlCommand firstcommand3 = new SqlCommand("update Hyc set keyuyueshu+=5 from Hyc where Mtime='" + getdate(i) + "';update Hyc set haoyuan -= 5 from Hyc where Mtime = '" + getdate(i) + "'; ", connection);
                            firstcommand3.ExecuteNonQuery();
                        }
                    }
                }
            }
        }

        private SqlConnection GetConnection()
        {
            return new SqlConnection(@"Data Source=localhost\sqlexpress;Initial Catalog=hostital1;Integrated Security=True");
        }

        private void button4_Click(object sender, EventArgs e)//请假
        {
            int ys;
            ys=listBox1.SelectedIndex;

            int wu1=0;

            if ((bool)mdt.Rows[ys]["flag"])
                wu1 = 1;
            else
                wu1 = 0;
            //mdt
            SqlCommand comm6 = new SqlCommand();
            comm6.Connection = conn;

            comm6.CommandText = "delete from [hostital1].[dbo].[Menzhenpaiban] where Dno='" + mdt.Rows[ys]["Dno"] + "'and Mtime='" + ((DateTime)mdt.Rows[ys]["Mtime"]).Year + "-" + ((DateTime)mdt.Rows[ys]["Mtime"]).Month + "-" + ((DateTime)mdt.Rows[ys]["Mtime"]).Day + "'and flag ='"+wu1+"'";

            try
            {
                conn.Open();
                comm6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
                comm6.Dispose();
                mdt.Dispose();
            }

            listBox1.Items.Clear();
            comm3 = new SqlCommand();
            sda3 = new SqlDataAdapter();
            comm3.CommandText = "select * from Dc,[hostital1].[dbo].[Menzhenpaiban] where [Menzhenpaiban].Dno= [hostital1].[dbo].[Dc].Dno and Dname='" + Tn1.Text + "'";
            comm3.Connection = conn;
            sda3.SelectCommand = comm3;
            mdt = new DataTable();

            try
            {
                conn.Open();
                sda3.Fill(mdt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message);
            }
            finally
            {
                sda3.Dispose();
                comm3.Dispose();
                conn.Close();
                
            }

            listBox1.BeginUpdate();

            for (int i = 0; i < mdt.Rows.Count; i++)
            {
                listBox1.Items.Add(mdt.Rows[i]["Mtime"].ToString() + " " + mdt.Rows[i]["Dzhicheng"].ToString() + " " +zhuanghuan ((bool)mdt.Rows[i]["flag"] )+ " " + mdt.Rows[i]["Dno"].ToString());
            }

            listBox1.EndUpdate();
            mdt.Dispose();
        }

        private void button5_Click(object sender, EventArgs e)//清空排班
        {
            SqlCommand comm6 = new SqlCommand();
            comm6.Connection = conn;

            comm6.CommandText = "delete from [hostital1].[dbo].[Menzhenpaiban]";
            comm6.CommandText += "delete from [hostital1].[dbo].[Hyc]";

            try
            {
                conn.Open();
                comm6.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                conn.Close();
                comm6.Dispose();
                mdt.Dispose();
            }
        }

        string zhuanghuan(bool b)//从0和1转换为显示上下午
        {
            if (b == true)
                return "上午";
            else
                return "下午";
        }
        
    }
}


        


