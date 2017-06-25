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
namespace Project
{
    public partial class Employer : Form
    {
        Chat ch = new Chat();
        User u = new User();
        int id;
        public Employer(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void Employer_Load(object sender, EventArgs e)
        {
            Refreshi();
        }
        private void Add()
        {
            List<string> st = new List<string>();
            st = ch.ShowChat(u.GetUserCOmand(id));
            listBox1.Items.Add(st[st.Count-1]);
        }
        private void Refreshi()
        {
            listBox1.Items.Clear();
            List<string> st = new List<string>();
            st = ch.ShowChat(u.GetUserCOmand(id));
            for (int i = 0; i < st.Count(); i++)
                listBox1.Items.Add(st[i]);
        }
        private void button7_Click(object sender, EventArgs e)
        {
            ch.SendMessage(richTextBox1.Text, id);
            Add();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            Refreshi();
        }
    }
}
