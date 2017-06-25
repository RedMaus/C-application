using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using BL;
using Microsoft.VisualBasic;
namespace Project
{
    public partial class Admin : Form
    {
        User us = new User();
        TaskT ts = new TaskT();
        int id;
        public Admin(int id1)
        {
            id = id1;
            InitializeComponent();
            this.RefreshTask();
            this.Refreshi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            UserAdd user = new UserAdd(id);
            this.Close();
            user.Show();
        }
        private void Refreshi()
        {
            dataGridView1.Rows.Clear();
            List<Tuple<int, string, string>> tmp = new List<Tuple<int, string, string>>();
            tmp = us.GetAllUsers(textBox1.Text,textBox2.Text,textBox3.Text);
            if (tmp.Count != 0)
            {
                dataGridView1.RowCount = tmp.Count();
                for (int i = 0; i < us.GetAllUsers(textBox1.Text, textBox2.Text, textBox3.Text).Count; i++)
                {
                    dataGridView1[0, i].Value = tmp[i].Item1;
                    dataGridView1[1, i].Value = tmp[i].Item2;
                    dataGridView1[2, i].Value = tmp[i].Item3;
                }
            }
        }
        
        private void Admin_Load(object sender, EventArgs e)
        {
            this.Refreshi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            int i = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1[0, i].Value);
            string FIO = Convert.ToString(dataGridView1[1, i].Value);
            string position = Convert.ToString(dataGridView1[2, i].Value);
            if(!us.DeleteUser(id,FIO,position))MessageBox.Show("Cann't delete this user","Error");
            this.Refreshi();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string txt;
            int i = dataGridView1.CurrentCell.RowIndex;
            int id = Convert.ToInt32(dataGridView1[0, i].Value);
            string FIO = Convert.ToString(dataGridView1[1, i].Value);
            string position = Convert.ToString(dataGridView1[2, i].Value);
            switch (dataGridView1.CurrentCell.ColumnIndex)
            {
                case 1:
                    txt = Interaction.InputBox("Enter new data:");
                    us.UpdateUser(id, FIO, position, id, txt, position);
                    break;
                case 2:
                    txt = Interaction.InputBox("Enter new data:");
                    us.UpdateUser(id, FIO, position, id, FIO, txt);
                    break;
            }
            this.Refreshi();
        }


        private void button8_Click(object sender, EventArgs e)
        {
            this.Refreshi();
        }

        private void RefreshTask()
        {
            dataGridView2.Rows.Clear();
            List<Tuple<int, string, int, int, string, string>> tmp = new List<Tuple<int, string, int, int, string, string>>();
            tmp = ts.GetAllTasks();
            if (tmp.Count != 0)
            {
                dataGridView2.RowCount = tmp.Count();
                for (int i = 0; i < tmp.Count; i++)
                {
                    dataGridView2[0, i].Value = tmp[i].Item1;
                    dataGridView2[1, i].Value = tmp[i].Item2;
                    dataGridView2[2, i].Value = tmp[i].Item3;
                    dataGridView2[3, i].Value = tmp[i].Item4;
                    dataGridView2[4, i].Value = tmp[i].Item5;
                    dataGridView2[5, i].Value = tmp[i].Item6;
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            AddComand user = new AddComand(id);
            this.Close();
            user.Show();
        }
    }
}
