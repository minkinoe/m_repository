using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class main : Form
    {
        string constr = @"Data Source =.\SQLEXPRESS; Initial Catalog = Hostital1; Integrated Security = True";
        string id= ID.getid();      
        public main()
        {
          
            InitializeComponent();
            
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }

        private void main_Load(object sender, EventArgs e)
        {
            bool panduan = false;
            if (id.Length < 4)
            {
                DataTable dt1 = new DataTable();
                dt1 = OperateDatabase.QueryData("select Dname from Dc where Dno='" + id + "'", constr);
                label1.Text = dt1.Rows[0][0].ToString().Trim() + "医生!!欢迎您！！";
                DataTable dt3 = new DataTable();
                dt3 = OperateDatabase.QueryData("select Pid from Manger", constr);
                for (int i = 0; i < dt3.Rows.Count; i++)
                {
                    if (dt3.Rows[i][0].ToString().Trim().Equals(id))
                    {
                        button1.Visible = true;
                        button2.Visible = false;
                        button3.Visible = true;
                        button4.Visible = true;
                        panduan = true;
                        break;
                    }

                }
                if (panduan == false)
                {
                    button1.Visible = true;
                    button2.Visible = false;
                    button3.Visible = false;
                    button4.Visible = false;
                }
            }
            
            if (id.Length > 4)
            {
                DataTable dt2 = new DataTable();
                dt2 = OperateDatabase.QueryData("select Pname from Person where ID='" + id + "'", constr);
                label1.Text = dt2.Rows[0][0].ToString().Trim() + "!!欢迎您！！";
                button1.Visible = true;
                button2.Visible = true;
                button3.Visible = false;
                button4.Visible = false;
            }          
            }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 form1 = new Form1();
            form1.ShowDialog();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2();
            form2.ShowDialog();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            Form3 form3 = new Form3();
            form3.ShowDialog();
        }
    }
}
