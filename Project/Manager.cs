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
    public partial class Manager : Form
    {
        int id;
        ManagerCl m = new ManagerCl();
        Chat ch = new BL.Chat();
        public Manager(int id)
        {
            this.id = id;            
            InitializeComponent();
            label6.Text += m.GetName(id);
            Refreshi();
        }
        private void Refreshi()
        {
            listBox1.Items.Clear();
            List<string> st = new List<string>();
            st = ch.ShowChat(m.GetCom(id));
            for (int i = 0; i < st.Count(); i++)
                listBox1.Items.Add(st[i]);
            List<Tuple<int, string>> tmp1 = new List<Tuple<int, string>>();
            tmp1 = m.GetAllEmployers(id);
            if (tmp1.Count != 0)
            {
                dataGridView2.RowCount = tmp1.Count();
                for (int i = 0; i < tmp1.Count; i++)
                {
                    dataGridView2[0, i].Value = tmp1[i].Item1;
                    dataGridView2[1, i].Value = tmp1[i].Item2;
                }
            }
            listBox2.Items.Clear();
            label2.Text = m.State(id);
            label3.Text = m.Deadline(id);
            var tmp = m.ShowEdits(id);
            listBox2.Items.Add(tmp[0]);
        }
        private void Manager_Load(object sender, EventArgs e)
        {
            Refreshi();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string st = Interaction.InputBox("Enter your edits:", "edit window");
            string st1 = Interaction.InputBox("Enter new state:", "State");
            m.ChangeState(id, st, st1);
            Refreshi();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string st = Interaction.InputBox("Enter your edits:", "edit window");
            int st1 = Convert.ToInt32(Interaction.InputBox("Enter new deadline:", "State"));
            m.ChangeDeadline(id, st, st1);
            Refreshi();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            string tmp = Interaction.InputBox("Enter FIO:", "New Employer");
            m.AddEmploye(id, tmp);
            Refreshi();
        }

        private void button5_Click(object sender, EventArgs e)
        {
            string tmp = Convert.ToString(dataGridView2.CurrentCell.Value);
            m.DeleteEmploye(id, tmp);
            Refreshi();
        }
    }
}
