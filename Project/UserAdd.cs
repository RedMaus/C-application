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
    public partial class UserAdd : Form
    {
        int id;
        public UserAdd(int id)
        {
            this.id = id;
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User us = new User();
            if (us.AddUser(Convert.ToInt32(textBox2.Text), textBox1.Text, comboBox1.Text))
                 {
                      Admin ad = new Admin(id);
                      ad.Show();
                      this.Close();
                   }
            else MessageBox.Show("cann't create user with such ID");
            
        }
    }
}
