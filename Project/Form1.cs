using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Entity;
using DAL;
using BL;
namespace Project
{
    public partial class Form1:Form
    {
        public Form1()
        {
            InitializeComponent();
            //db = new Model();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            User _new = new User();
            switch (_new.Authethification(textBox1.Text, textBox2.Text))
            {
                case "admin":
                    
                    Admin frm = new Admin(Convert.ToInt32(textBox2.Text));
                    frm.Show();
                    this.Hide();

                    break;
                case "employer":
                    this.Hide();
                    Employer frm1 = new Employer(Convert.ToInt32(textBox2.Text));
                    frm1.Show();
                    
                    break;
                case "manager":
                    this.Hide();
                    Manager frm2 = new Manager(Convert.ToInt32(textBox2.Text));
                    frm2.Show();
                    
                    break;
                case "":
                    MessageBox.Show("incorect id or FIO","ERROR");
                    break;

            }
        }
    }
}
