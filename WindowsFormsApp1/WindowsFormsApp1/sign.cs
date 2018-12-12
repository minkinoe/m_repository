using System;
using System.Collections;
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
    public partial class sign : Form
    {       
        string zhanghao, mima;
        string constr = @"server=.;database=Hostital1;Integrated Security=True";
        public sign()
        {
            InitializeComponent();
        }
        private void sign_Load(object sender, EventArgs e)
        {
           
        }

        private void label1_Click(object sender, EventArgs e)
        {
            

        }
        private void button1_Click(object sender, EventArgs e)
        {
           
            zhanghao = Login.Text;           
            mima = Password.Text;
            bool pzhanhao=false;         
            DataTable dt = new DataTable();
            dt=OperateDatabase.QueryData("select * from  Zhaohao",constr);
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                if (zhanghao.Trim().Equals(dt.Rows[i][0].ToString().Trim()))
                {
                    pzhanhao = true;
                    if (mima.Trim().Equals(dt.Rows[i][1].ToString().Trim()))
                    {
                        ID.setid(zhanghao);
                        this.DialogResult = DialogResult.OK;
                    }
                    else
                        MessageBox.Show("密码错误！请重新输入");
                    break;
                }

            }
            if(pzhanhao==false)
            {
                MessageBox.Show("账号不存在");
            }
        }
        private void button2_Click(object sender, EventArgs e)
        {
            Zhuce z = new Zhuce();
            z.Show();
           
        }
        private void Login_TextChanged(object sender, EventArgs e)
        {

        }
       
    }
}
