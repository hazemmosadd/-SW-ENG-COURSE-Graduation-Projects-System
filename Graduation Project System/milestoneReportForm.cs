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
    public partial class milestoneReportForm : Form
    {
        MilestoneReport CR;
        public milestoneReportForm()
        {
            InitializeComponent();
        }

        private void crystalReportViewer1_Load(object sender, EventArgs e)
        {
            CR = new MilestoneReport();
            crystalReportViewer1.ReportSource = CR;
        }
    }
}
