using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        private SqlConnection conn;
        public Form1()
        {
            InitializeComponent();
            conn = new SqlConnection(ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString);
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("DELETE" +
                " FROM Employee WHERE [Emp Number] =@EN;",
                conn);
            cmd.Parameters.AddWithValue("@EN", int.Parse(txtEMPNo.Text));
            using (conn)
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            new Add(conn).ShowDialog();
        }

        private void btnModify_Click(object sender, EventArgs e)
        {
            new Modify(conn, int.Parse(txtEMPNo.Text)).ShowDialog();
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("SELECT " +
                "[Emp Number], [First Name]," +
                "Surname, Department FROM Employee;", conn);
            using (conn)
            {
                conn.Open();
                SqlDataReader rd = cmd.ExecuteReader();
                DataTable dt = new DataTable();
                dt.Load(rd);
                dgvEmployees.DataSource = dt;
            }
        }
    }
}
