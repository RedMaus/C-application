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
    public partial class AddComand : Form
    {
        int id;
        TaskT ts=new TaskT();
        public AddComand(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (ts.AddTask(Convert.ToInt32(textBox4.Text), textBox1.Text, Convert.ToInt32(textBox2.Text), textBox3.Text, id))
            {
                Admin ad = new Admin(id);
                ad.Show();
                this.Close();
            }
            else MessageBox.Show("Cann't Create this task", "ERROR");
        }
    }
}
