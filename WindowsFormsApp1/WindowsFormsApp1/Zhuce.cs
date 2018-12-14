using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Zhuce : Form
    {
        string name, zhanghao, tel, password;
        string constr= @"Data Source =.\SQLEXPRESS; Initial Catalog = Hostital1; Integrated Security = True";
        public Zhuce()
        {
            InitializeComponent();
        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            name = textBox1.Text.ToString().Trim();
            tel = textBox2.Text.ToString().Trim();
            zhanghao = textBox3.Text.ToString().Trim();
            password = textBox4.Text.ToString().Trim();
            DataTable dt =new DataTable();
            dt = OperateDatabase.QueryData("select* from Zhaohao where ID='"+zhanghao +"'",constr);
            if (dt.Rows.Count > 0)
            {
                MessageBox.Show("账号已存在！");
                return;
            }
            Boolean flag = OperateDatabase.AddData("insert into Zhaohao(ID,Passwords)values('"+zhanghao+"','"+password+"')", constr);
            if (flag == true)
            {
                Boolean boo = OperateDatabase.AddData("insert into Person (ID,Pname,Tel,idex) values('"+zhanghao+"','"+name+"','"+tel+"',0)",constr);
                MessageBox.Show("注册成功，请重新登录");
            }
            else
                MessageBox.Show("数据库插入失败，注册失败，请重试");
            this.Close();
          

        }

        private void Zhuce_Load(object sender, EventArgs e)
        {

        }
    }
}
    

