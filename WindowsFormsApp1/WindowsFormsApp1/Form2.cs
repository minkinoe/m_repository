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
    public partial class Form2 : Form
    {
        string Id;


        public Form2()
        {
            InitializeComponent();
        }

        SqlConnection cnt = new SqlConnection();
        SqlCommand cmd = new SqlCommand();
        SqlDataAdapter da = new SqlDataAdapter();
        DataTable dt = new DataTable();

        private void Form2_Load(object sender, EventArgs e)
        {
            cnt.ConnectionString = @"Data Source =.\SQLEXPRESS; Initial Catalog = Hostital1; Integrated Security = True";
            cmd.Connection = cnt;
            cmd.CommandText = "select * from [Hostital1].[dbo].[Yc] where ID=@id";
            cmd.Parameters.AddWithValue("@id", Id);
            da.SelectCommand = cmd;
            try
            {
                cnt.Open();
                da.Fill(dt);
            }catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                da.Dispose();
                cmd.Dispose();
                cnt.Close();
            }
            listBox1.BeginUpdate();
            for(int i=0;i<dt.Rows.Count;i++)
            {
                listBox1.Items.Add(dt.Rows[i][0].ToString()+ dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString());
            }
            listBox1.EndUpdate();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            cmd = new SqlCommand();
            cmd.Connection = cnt;
            cmd.CommandText = "";
            if (listBox1.SelectedItems.Count == 0)
            {
                MessageBox.Show("您没有选择任何项目");
                cmd.Dispose();
                return;
            }
            for (int i = 0; i < listBox1.SelectedItems.Count; i++)
            {
                if (canresign((DateTime)dt.Rows[listBox1.SelectedIndices[i]][2]))
                {
                    cmd.CommandText += "delete from [Hostital1].[dbo].[Yc] where ID=@id and Dno=@dno and Ytime=@ytime and flag=@fg ";
                    cmd.Parameters.AddWithValue("@id", dt.Rows[listBox1.SelectedIndices[i]][0]);
                    cmd.Parameters.AddWithValue("@dno", dt.Rows[listBox1.SelectedIndices[i]][1]);
                    cmd.Parameters.AddWithValue("@ytime", dt.Rows[listBox1.SelectedIndices[i]][2]);
                    cmd.Parameters.AddWithValue("@fg", dt.Rows[listBox1.SelectedIndices[i]][3]);
                }
            }
            try
            {
                cnt.Open();
                cmd.ExecuteNonQuery();
                MessageBox.Show("成功取消");
                refurbish();
            }
            catch(Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                cmd.Dispose();
                cnt.Close();
            }
        }

        bool canresign(DateTime dt)
        {
            DateTime ndt = new System.DateTime();
            if ((dt-ndt).Days>1)
                return true;
            else
                return false;
        }

        void refurbish()
        {
            listBox1.Items.Clear();
            cmd.Connection = cnt;
            cmd.CommandText = "select * from [Hostital1].[dbo].[Yc] where ID=@id";
            cmd.Parameters.AddWithValue("@id", Id);
            da.SelectCommand = cmd;
            try
            {
                cnt.Open();
                da.Fill(dt);
            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.ToString());
            }
            finally
            {
                da.Dispose();
                cmd.Dispose();
                cnt.Close();
            }
            listBox1.BeginUpdate();
            for (int i = 0; i < dt.Rows.Count; i++)
            {
                listBox1.Items.Add(dt.Rows[i][0].ToString() + dt.Rows[i][1].ToString() + dt.Rows[i][2].ToString());
            }
            listBox1.EndUpdate();
        }

        private void radioButton1_CheckedChanged(object sender, EventArgs e)
        {
            if (radioButton1.Checked)
            {
                for (int i = 0; i < listBox1.Items.Count; i++)
                {
                    listBox1.SelectedIndex = i;
                }
            }
        }
    }
}
