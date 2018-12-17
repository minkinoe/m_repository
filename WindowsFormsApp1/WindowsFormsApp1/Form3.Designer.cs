namespace WindowsFormsApp1
{
    partial class Form3
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.treeView1 = new System.Windows.Forms.TreeView();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.Empty = new System.Windows.Forms.Button();
            this.Leave = new System.Windows.Forms.Button();
            this.listBox1 = new System.Windows.Forms.ListBox();
            this.Update_num = new System.Windows.Forms.Button();
            this.set_xia = new System.Windows.Forms.RadioButton();
            this.set_shang = new System.Windows.Forms.RadioButton();
            this.Application = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.Confirm = new System.Windows.Forms.Button();
            this.listBox2 = new System.Windows.Forms.ListBox();
            this.label1 = new System.Windows.Forms.Label();
            this.set_week = new System.Windows.Forms.NumericUpDown();
            this.hostital1DataSet1BindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.mccBindingSource = new System.Windows.Forms.BindingSource(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.set_week)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostital1DataSet1BindingSource)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.mccBindingSource)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.treeView1);
            this.groupBox1.Location = new System.Drawing.Point(29, 29);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox1.Size = new System.Drawing.Size(144, 415);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "科室选择";
            // 
            // treeView1
            // 
            this.treeView1.Location = new System.Drawing.Point(9, 29);
            this.treeView1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.treeView1.Name = "treeView1";
            this.treeView1.Size = new System.Drawing.Size(131, 370);
            this.treeView1.TabIndex = 0;
            this.treeView1.AfterSelect += new System.Windows.Forms.TreeViewEventHandler(this.treeView1_AfterSelect);
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.Empty);
            this.groupBox2.Controls.Add(this.Leave);
            this.groupBox2.Controls.Add(this.listBox1);
            this.groupBox2.Controls.Add(this.Update_num);
            this.groupBox2.Controls.Add(this.set_xia);
            this.groupBox2.Controls.Add(this.set_shang);
            this.groupBox2.Controls.Add(this.Application);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.Controls.Add(this.Confirm);
            this.groupBox2.Controls.Add(this.listBox2);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.set_week);
            this.groupBox2.Location = new System.Drawing.Point(192, 29);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.groupBox2.Size = new System.Drawing.Size(506, 415);
            this.groupBox2.TabIndex = 1;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "排班操作";
            // 
            // Empty
            // 
            this.Empty.Location = new System.Drawing.Point(415, 162);
            this.Empty.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Empty.Name = "Empty";
            this.Empty.Size = new System.Drawing.Size(75, 31);
            this.Empty.TabIndex = 18;
            this.Empty.Text = "清空排班";
            this.Empty.UseVisualStyleBackColor = true;
            this.Empty.Click += new System.EventHandler(this.button5_Click);
            // 
            // Leave
            // 
            this.Leave.Location = new System.Drawing.Point(325, 162);
            this.Leave.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Leave.Name = "Leave";
            this.Leave.Size = new System.Drawing.Size(68, 31);
            this.Leave.TabIndex = 17;
            this.Leave.Text = "医生请假";
            this.Leave.UseVisualStyleBackColor = true;
            this.Leave.Visible = false;
            this.Leave.Click += new System.EventHandler(this.button4_Click);
            // 
            // listBox1
            // 
            this.listBox1.FormattingEnabled = true;
            this.listBox1.ItemHeight = 12;
            this.listBox1.Location = new System.Drawing.Point(28, 244);
            this.listBox1.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox1.Name = "listBox1";
            this.listBox1.Size = new System.Drawing.Size(462, 136);
            this.listBox1.TabIndex = 6;
            // 
            // Update_num
            // 
            this.Update_num.Location = new System.Drawing.Point(230, 162);
            this.Update_num.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Update_num.Name = "Update_num";
            this.Update_num.Size = new System.Drawing.Size(70, 31);
            this.Update_num.TabIndex = 16;
            this.Update_num.Text = "更新号源";
            this.Update_num.UseVisualStyleBackColor = true;
            this.Update_num.Click += new System.EventHandler(this.button3_Click);
            // 
            // set_xia
            // 
            this.set_xia.AutoSize = true;
            this.set_xia.Location = new System.Drawing.Point(151, 112);
            this.set_xia.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.set_xia.Name = "set_xia";
            this.set_xia.Size = new System.Drawing.Size(71, 16);
            this.set_xia.TabIndex = 15;
            this.set_xia.TabStop = true;
            this.set_xia.Text = "下午排班";
            this.set_xia.UseVisualStyleBackColor = true;
            // 
            // set_shang
            // 
            this.set_shang.AutoSize = true;
            this.set_shang.Location = new System.Drawing.Point(46, 112);
            this.set_shang.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.set_shang.Name = "set_shang";
            this.set_shang.Size = new System.Drawing.Size(71, 16);
            this.set_shang.TabIndex = 14;
            this.set_shang.TabStop = true;
            this.set_shang.Text = "上午排班";
            this.set_shang.UseVisualStyleBackColor = true;
            // 
            // Application
            // 
            this.Application.Enabled = false;
            this.Application.Location = new System.Drawing.Point(140, 162);
            this.Application.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Application.Name = "Application";
            this.Application.Size = new System.Drawing.Size(66, 31);
            this.Application.TabIndex = 13;
            this.Application.Text = "应用排班";
            this.Application.UseVisualStyleBackColor = true;
            this.Application.Click += new System.EventHandler(this.button2_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(26, 219);
            this.label2.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 9;
            this.label2.Text = "label2";
            // 
            // Confirm
            // 
            this.Confirm.Location = new System.Drawing.Point(32, 161);
            this.Confirm.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Confirm.Name = "Confirm";
            this.Confirm.Size = new System.Drawing.Size(71, 32);
            this.Confirm.TabIndex = 8;
            this.Confirm.Text = "确认排班";
            this.Confirm.UseVisualStyleBackColor = true;
            this.Confirm.Visible = false;
            this.Confirm.Click += new System.EventHandler(this.button1_Click);
            // 
            // listBox2
            // 
            this.listBox2.FormattingEnabled = true;
            this.listBox2.ItemHeight = 12;
            this.listBox2.Location = new System.Drawing.Point(288, 40);
            this.listBox2.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.listBox2.Name = "listBox2";
            this.listBox2.Size = new System.Drawing.Size(151, 88);
            this.listBox2.TabIndex = 7;
            this.listBox2.Visible = false;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 56);
            this.label1.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(29, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "星期";
            // 
            // set_week
            // 
            this.set_week.Location = new System.Drawing.Point(109, 54);
            this.set_week.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.set_week.Name = "set_week";
            this.set_week.Size = new System.Drawing.Size(90, 21);
            this.set_week.TabIndex = 0;
            this.set_week.Value = new decimal(new int[] {
            1,
            0,
            0,
            0});
            this.set_week.ValueChanged += new System.EventHandler(this.set_week_ValueChanged);
            // 
            // Form3
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(736, 463);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Margin = new System.Windows.Forms.Padding(2, 2, 2, 2);
            this.Name = "Form3";
            this.Text = "排班";
            this.Load += new System.EventHandler(this.Form3_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.set_week)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.hostital1DataSet1BindingSource)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.mccBindingSource)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown set_week;
        private System.Windows.Forms.TreeView treeView1;
        private System.Windows.Forms.BindingSource mccBindingSource;
        private System.Windows.Forms.BindingSource hostital1DataSet1BindingSource;
        private System.Windows.Forms.ListBox listBox1;
        private System.Windows.Forms.ListBox listBox2;
        private System.Windows.Forms.Button Confirm;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button Application;
        private System.Windows.Forms.RadioButton set_xia;
        private System.Windows.Forms.RadioButton set_shang;
        private System.Windows.Forms.Button Update_num;
        private System.Windows.Forms.Button Leave;
        private System.Windows.Forms.Button Empty;
    }
}