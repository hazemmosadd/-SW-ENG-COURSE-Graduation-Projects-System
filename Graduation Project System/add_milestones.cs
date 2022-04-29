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
    
    public partial class add_milestones : Form
    {
        string ordb = "Data source =orcl; User Id =scott; Password= tiger;";
        OracleConnection conn;

        public add_milestones()
        {
            InitializeComponent();
        }

        private void add_milestones_Load(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "Milestone";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("id", OracleDbType.RefCursor, ParameterDirection.Output);
            OracleDataReader dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0]);
            }
            dr.Close();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            OracleCommand C = new OracleCommand();
            C.Connection = conn;
            C.CommandText = "select milestoneName , requirements from milestones where milestoneID =:ID";
            C.CommandType = CommandType.Text;
            C.Parameters.Add("ID", comboBox1.SelectedItem.ToString());
            OracleDataReader re = C.ExecuteReader();
            if (re.Read())
            {
                textBox1.Text = re[0].ToString();
                textBox2.Text = re[1].ToString();

            }
        }

  
        private void button3_Click(object sender, EventArgs e)
        {
            conn = new OracleConnection(ordb);
            conn.Open();
            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "RECENT_MILESTONE";
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("idd", OracleDbType.Int32, ParameterDirection.Output);
            cmd.Parameters.Add("namee", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
            cmd.Parameters.Add("req", OracleDbType.Varchar2, 32767).Direction = ParameterDirection.Output;
            cmd.ExecuteNonQuery();

            //string x= cmd.Parameters["idd"].Value.ToString();
            //comboBox1.SelectedIndex = comboBox1.FindStringExact("x");
            comboBox1.SelectedIndex = comboBox1.Items.Count - 1;
            //comboBox1.SelectedItem = x;
            textBox1.Text = cmd.Parameters["namee"].Value.ToString();
            textBox2.Text = cmd.Parameters["req"].Value.ToString();
        }



private void button4_Click(object sender, EventArgs e)
        {

            OracleCommand cmd = new OracleCommand();
            cmd.Connection = conn;
            cmd.CommandText = "insert into milestones values(:id,:name,:description)";
            cmd.Parameters.Add("id", comboBox1.Text);
            cmd.Parameters.Add("name", textBox1.Text);
            cmd.Parameters.Add("description", textBox2.Text);
            int ex = cmd.ExecuteNonQuery();
            if (ex != -1)
            {
                comboBox1.Items.Add(comboBox1.Text);
                MessageBox.Show("milestone is added successfully");
            }
    }
}
}
