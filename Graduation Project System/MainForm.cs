using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Graduation_Project_System
{
    public partial class MainForm : Form
    {
        private Form activeForm ;
        bool active = false;
        public MainForm()
        {
           
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (active)
                activeForm.Close();
            label3.Text = "HOME";

        }

        private void button3_Click(object sender, EventArgs e)
        {
            label3.Text = "ADD MILESTONES";


            openChildForm(new add_milestones());
            active = true; 
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label3.Text = "TEAMS INFORMATION"; 

            openChildForm(new TeamsInfoForm());
            active = true;

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
          internal void openChildForm(Form childForm)
        {
            if (active)
             activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            panel3.Controls.Add(childForm);
            panel3.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        private void panel2_Paint(object sender, PaintEventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        

        private void panel3_Paint(object sender, PaintEventArgs e)
        {

        }

        private void panel2_Paint_1(object sender, PaintEventArgs e)
        {

        }

        private void button4_Click(object sender, EventArgs e)
        {
          
           // openChildForm(new studentsReportForm());
        }
    }
}
