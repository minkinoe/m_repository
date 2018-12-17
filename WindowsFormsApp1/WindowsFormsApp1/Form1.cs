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
    public partial class Form1 : Form
    {
        string patientid;//存患者标识信息
        string departmentid;//存患者所选科室代号
        string doctorid;//存医生工号
        object selectdate = null;//用户所选的日期
        int isdateselect = 0;
        int max = 3;//患者在一个时间段内可预约的数量
        string constr = @"Data Source =.\SQLEXPRESS; Initial Catalog = Hostital1; Integrated Security = True";
        public Form1()
        {
            patientid = ID.getid();
            InitializeComponent();
        }

        private void 患者预约_Load(object sender, EventArgs e)
        {            
            selectks_Load();
        }

        private void selectks_Load()//科室表处理
        {
            DataTable dt = new DataTable();
            dt = OperateDatabase.QueryData("select * from Ks", constr);
            comboBox1.DataSource = dt;
            comboBox1.DisplayMember = "Kname";
            comboBox1.ValueMember = "Kno";
            departmentid = comboBox1.SelectedValue.ToString();
            this.comboBox1.SelectedIndex = -1;//初始状态内容为空
        }

        private void selectdoc_Load()//医生信息表处理
        {
            DataTable dt = new DataTable();
            dt = OperateDatabase.QueryData("select * from Dc where Kno=" + departmentid, constr);
            comboBox2.DataSource = dt;
            comboBox2.DisplayMember = "Dname";
            comboBox2.ValueMember = "Dno";
            this.comboBox2.SelectedIndex = -1;//初始状态内容为空 
            try
            {
                departmentid = comboBox1.SelectedValue.ToString();
            }
            catch (Exception ex) {  }
        }

        private void comboBox1_LostFocus(object sender, EventArgs e)
        {
            try
            {
                departmentid = comboBox1.SelectedValue.ToString();
            }
            catch (Exception ex)
            {
                comboBox2.Refresh();//不知道有没有用
                MessageBox.Show("先选择科室");
                return;
            }
            selectdoc_Load();
        }
        
        private void comboBox2_LostFocus(object sender, EventArgs e)
        {
            try
            {
                doctorid = comboBox2.SelectedValue.ToString();                
                paibantreeView.Nodes.Clear();
                initDeptDocList();
            }
            catch (Exception ex) { }
        }

        private void initDeptDocList()
        { 
            DataTable dt = new DataTable();
            dt = OperateDatabase.QueryData("select * from Menzhenpaiban where Dno=" + doctorid, constr);           
            if (dt.Rows.Count == 0)
            {
                MessageBox.Show("尚未找到该医生的排班信息，请您稍后进行预约！或换个医生");
                paibantreeView.Nodes.Add("暂无排班信息！");
                return;
            }
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                string[] dateInfo = dt.Rows[i][2].ToString().Split(' ');//日期和时间分离
                if (dt.Rows[i][3].Equals(true))//判断上午还是下午
                {
                    paibantreeView.Nodes.Add(dateInfo[0] + " " + changeweek(dt.Rows[i][2]) + " 下午");
                    DataTable dt1 = new DataTable();//子节点（号源表）
                    int flag = 0;//标记
                    dt1 = OperateDatabase.QueryData("select * from Hyc where Dno=" + doctorid, constr);
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        if (dt1.Rows[j][2].Equals(dt.Rows[i][2]) && dt1.Rows[j][3].Equals(true))
                        {
                            paibantreeView.Nodes[i].Nodes.Add("剩余号源数：" + dt1.Rows[j][5]);
                            flag = 1;
                        }
                    }
                    if(flag==0)
                        paibantreeView.Nodes[i].Nodes.Add("数据库错误！！此医生已排班但无号源！");                 
                }
                else
                {
                    paibantreeView.Nodes.Add(dateInfo[0] + " " + changeweek(dt.Rows[i][2]) + " 上午");
                    DataTable dt1 = new DataTable();//子节点（号源表）
                    int flag = 0;//标记
                    dt1 = OperateDatabase.QueryData("select * from Hyc where Dno=" + doctorid, constr);
                    for (int j = 0; j < dt1.Rows.Count; j++)
                    {
                        if (dt1.Rows[j][2].Equals(dt.Rows[i][2]) && dt1.Rows[j][3].Equals(false))
                        {
                            paibantreeView.Nodes[i].Nodes.Add("剩余号源数：" + dt1.Rows[j][5]);
                            flag = 1;
                        }
                    }
                    if (flag == 0)
                        paibantreeView.Nodes[i].Nodes.Add("数据库错误！！此医生已排班但无号源！");
                }
            }          
        }
    
         private string changeweek(object d)
         {
             DateTime dt = (DateTime)d;
             string week = "";
             switch (dt.DayOfWeek.ToString())
             {
                    case "Sunday": week = "星期日"; break;
                    case "Monday": week = "星期一"; break;
                    case "Tuesday": week = "星期二"; break;
                    case "Wednesday": week = "星期三"; break;
                    case "Thursday": week = "星期四"; ; break;
                   case "Friday": week = "星期五"; ; break;
                  case "Saturday": week = "星期六"; break;
              }
                return week;
         }

        private void paibantreeView_AfterSelect(object sender, TreeViewEventArgs e)
        {        
            label3.Text ="已选中排班时间："+paibantreeView.SelectedNode.Text;
            selectdate = paibantreeView.SelectedNode.Text;
            isdateselect = 1;          
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (isdateselect==0)
            {
                MessageBox.Show("请先选择日期");
                return;
            }
           
            if (checkclash() == true)
            {
                MessageBox.Show("单位时间内预约数量超过上限或单位时间内预约多次同一个医生！请重试");
                label4.Text = "请重新选择预约时间或医生";
                return;
            }
            else
            {
                DataTable dt = new DataTable();
                dt = OperateDatabase.QueryData("select *from Person where ID="+patientid,constr);
                string[] str = selectdate.ToString().Split(' ');
                string date1;//日期格式转化
                int ap;
                date1 = str[0] + " " + "0:00:00";
                if (str[2].Equals("上午"))
                    ap = 0;
                else
                    ap = 1;
                DataTable dt1 = new DataTable();
                dt1 = OperateDatabase.QueryData("select * from Hyc where Dno = '" + doctorid + "'and Mtime = '" + date1 + "'and flag = '" + ap + "'", constr);
                if (dt1.Rows.Count == 0)
                {
                    MessageBox.Show("由于排班系统错误，该医生此排班无号源！");
                    return;
                }
                int xvhao = Convert.ToInt32(dt1.Rows[0][4]) - Convert.ToInt32(dt1.Rows[0][5]) + 1;//获取医生顺序号

                string sqlstr = "insert into Yc([ID],[Dno],[Ytime],[flag],[xuhao],[Tel])values('"+patientid+"','"+doctorid+"','"+date1+"','"+ap+ "','"+xvhao+"','"+dt.Rows[0][2].ToString()+"')";         
                if (OperateDatabase.AddData(sqlstr, constr)==true)
                {
                     OperateDatabase.UpdateData("update Hyc set Kyuyueshu='" + (Convert.ToInt32(dt1.Rows[0][5]) - 1).ToString() + "' where Dno='" + doctorid + "'and Mtime='" + date1 + "'and flag='" + ap + "'", constr);
                     label4.Text = "预约成功";
                     MessageBox.Show("预约成功");
                    
                }
                
            }
        }
        private Boolean checkclash()//检验患者在一段时间内预约数量是否超限和检验一段时间内是否预约了同一个医生false通过，true不通过
        {
            DataTable dt = new DataTable();         
            string[] str = selectdate.ToString().Split(' ');
            string date1;//日期格式转化
            Boolean ap;
            date1 = str[0] + " " + "0:00:00"; 
            if (str[2].Equals("上午"))
                ap = false;
            else
                ap = true;
            dt = OperateDatabase.QueryData("select * from Yc where ID=" + patientid, constr);          
            int j = 0;
            for (int i=0;i<dt.Rows.Count;i++)
            {              
                if (dt.Rows[i][3].Equals(ap)&&dt.Rows[i][2].ToString().Equals(date1)) //
                {
                    j++;
                    if (dt.Rows[i][1].Equals(doctorid))
                        return true;//检验一段时间内是否预约了同一个医生
                }
            }
            if (j >= max)
                return true;
            else
                return false;            
        }
        
    }
}
