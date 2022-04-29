using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Oracle.DataAccess.Client;
using Oracle.DataAccess.Types;

namespace Graduation_Project_System
{
    public partial class TeamsInfoForm : Form
    {
        OracleDataAdapter adapter;
        OracleCommandBuilder builder;
        DataSet ds;
        OracleConnection conn;

        public TeamsInfoForm()
        {
            InitializeComponent();
           
        }

        private void Form2_Load(object sender, EventArgs e)
        {
        
        }


        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=ORCL; User Id=scott;Password=tiger;";
            string cmdstr = "select* from students where teamID =: n";

            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("n", teamIDtxt.Text);
            ds = new DataSet();
            adapter.Fill(ds);
            dataGridView.DataSource = ds.Tables[0];



            //////////////////////
            ///connected Mode Project Name
            ///
            string cmdstr2 = "select projectname from teams where teamID =: n";

            conn = new OracleConnection(constr);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = cmdstr2;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", teamIDtxt.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                label2.Text = dr[0].ToString();
            dr.Close();


        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void button4_MouseHover(object sender, EventArgs e)
        {
            button4.ForeColor = Color.FromArgb(75, 123, 229);

        }

        private void button4_MouseLeave(object sender, EventArgs e)
        {
            button4.ForeColor = Color.Silver; 

        }

        private void button4_Click(object sender, EventArgs e)
        {
            string constr = "Data Source=ORCL; User Id=scott;Password=tiger;";
            string cmdstr = "select studid , studname , teamid from students where teamID =: n";

            adapter = new OracleDataAdapter(cmdstr, constr);
            adapter.SelectCommand.Parameters.Add("n", teamIDtxt.Text);
            ds = new DataSet();
            adapter.Fill(ds);
            ds.Tables[0].Columns[0].ColumnName = "ID";
            ds.Tables[0].Columns[1].ColumnName = "NAME";
            ds.Tables[0].Columns[2].ColumnName = "TEAM ID";
       





            dataGridView.DataSource = ds.Tables[0];



            /// connected 
            string cmdstr2 = "select projectname from teams where teamID =: n";

            conn = new OracleConnection(constr);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = cmdstr2;
            cmd.CommandType = CommandType.Text;
            cmd.Parameters.Add("id", teamIDtxt.Text);
            OracleDataReader dr = cmd.ExecuteReader();
            if (dr.Read())
                label2.Text = dr[0].ToString().ToUpper();
            dr.Close();


        }

        private void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            builder = new OracleCommandBuilder(adapter);
            adapter.Update(ds.Tables[0]);
        }

        private void button3_Click(object sender, EventArgs e)
        {
            foreach (DataGridViewRow row in dataGridView.SelectedRows)
                if (!row.IsNewRow) dataGridView.Rows.Remove(row);
        }

        private void dataGridView_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button5_Click(object sender, EventArgs e)
        {
            studentsReportForm f3 = new studentsReportForm(); // Instantiate a Form3 object.
            f3.Show();
        }
    }
}
