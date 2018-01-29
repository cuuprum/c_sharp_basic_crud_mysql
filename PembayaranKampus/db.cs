using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Odbc;
using System.Data;
using System.Windows.Forms;


namespace PembayaranKampus
{
    class db
    {
        public OdbcConnection CONN;
        public OdbcCommand CMD;
        public DataSet DS = new DataSet();
        public OdbcDataAdapter DA;
        public OdbcDataReader DR;
        public String DSN = "dsn=dsn_db_pembayaran_kampus";

        public void Koneksi()
        {
            CONN = new OdbcConnection(DSN);

            if (CONN.State == ConnectionState.Closed)
            {
                try 
                {
                    CONN.Open();
                }
                catch(Exception _ex)
                {
                    MessageBox.Show(_ex.ToString(), "Error Koneksi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }
    }
}
