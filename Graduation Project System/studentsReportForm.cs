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
    public partial class studentsReportForm : Form
    {
        CrystalReport3 CR;

        public studentsReportForm()
        {
            InitializeComponent();
        }

        private void studentsReportForm_Load(object sender, EventArgs e)
        {
            CR = new CrystalReport3();
            crystalReportViewer1.ReportSource = CR; 

        }
    }
}
