using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Add : Form
    {
        SqlConnection conn;
        public Add(SqlConnection c)
        {
            conn = c;
            InitializeComponent();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            SqlCommand cmd = new SqlCommand("INSERT INTO Employee " +
                "VALUES(@FN,@LN,@CO,@C,@DEP)", conn);
            cmd.Parameters.AddWithValue("@FN",txtFN.Text);
            cmd.Parameters.AddWithValue("@LN",txtLN.Text);
            cmd.Parameters.AddWithValue("@CO",txtCo.Text);
            cmd.Parameters.AddWithValue("@C",txtCountry.Text);
            cmd.Parameters.AddWithValue("@DEP",txtDept.Text);
            {
                conn.Open();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
