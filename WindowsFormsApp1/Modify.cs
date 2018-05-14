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
    public partial class Modify : Form
    {
        SqlConnection conn;
        int EN;
        public Modify(SqlConnection c, int e)
        {
            InitializeComponent();
            conn = c;
            EN = e;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            using (SqlConnection c = new SqlConnection(
                ConfigurationManager.ConnectionStrings["EmployeeDB"].ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("UPDATE Employee " +
                "SET [First Name]=@FN, " +
                "Surname=@LN," +
                "County=@CO," +
                "Country=@C," +
                "Department=@DEP " +
                "WHERE [Emp Number]=@EN;", c);
            cmd.Parameters.AddWithValue("@FN", txtFN.Text);
            cmd.Parameters.AddWithValue("@LN", txtLN.Text);
            cmd.Parameters.AddWithValue("@CO", txtCo.Text);
            cmd.Parameters.AddWithValue("@C", txtCountry.Text);
            cmd.Parameters.AddWithValue("@DEP", txtDept.Text);
            cmd.Parameters.AddWithValue("@EN", EN);

                if (!(c.State == ConnectionState.Open))
                    c.Open();
                cmd.ExecuteNonQuery();
            }
        }

        private void Modify_Load(object sender, EventArgs e)
        {

        }
    }
}
