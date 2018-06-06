using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace MediClinicChannelingSystem
{
    class DBConnection
    {
        SqlConnection con;
        public SqlConnection getConnection()
        {
            try
            {
                con = new SqlConnection("DATA SOURCE=(localdb)\\MSSQLLocalDB;INITIAL CATALOG=MediClinicDatabase;INTEGRATED SECURITY=True ;MultipleActiveResultSets = True;");
            }
            catch(SqlException ex)
            {
                MessageBox.Show(null ,"An error occured when establishing the database connection\nError: " + ex,"Connection Error",MessageBoxButtons.OK,MessageBoxIcon.Error);
            }
            return con;
        }
    }
}
