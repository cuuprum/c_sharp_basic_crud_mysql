using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace PembayaranKampus
{
    public partial class frmUser : Form
    {
        db Db = new db();

        public frmUser()
        {
            InitializeComponent();
            Db.Koneksi();
            tampilData();
            txtId.Enabled = false;
        }

        public void tampilData()
        {
            String query = "SELECT `id`, `username`, `password`, `jabatan` FROM `data_admin`";
            Db.DA = new System.Data.Odbc.OdbcDataAdapter(query, Db.CONN);
            Db.DS = new DataSet();
            DataTable table = new DataTable();
            Db.DA.Fill(table);
            dgvUser.DataSource = table;
            dgvUser.ReadOnly = true;
            pbxProfile.BackgroundImage = Properties.Resources.user_bg;
        }

        public void TampilDataById(String _id) {
            String query = String.Format("SELECT * FROM data_admin WHERE id ='{0}';", _id.Trim());
            Db.CMD = new System.Data.Odbc.OdbcCommand(query, Db.CONN);
            Db.DR = Db.CMD.ExecuteReader();
            Db.DR.Read();

            if(Db.DR.HasRows)
            {
                txtId.Text = Db.DR[0].ToString();
                txtUsername.Text = Db.DR[1].ToString();
                txtPassword.Text = Db.DR[2].ToString();
                txtJabatan.Text = Db.DR[3].ToString();
            }
            else
            {
                MessageBox.Show("Data Tidak Ada!", "Error Tampil Data by Id", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void headerKolom()
        {
            dgvUser.Columns[0].HeaderText = "ID  User";
            dgvUser.Columns[1].HeaderText = "Username";
            dgvUser.Columns[2].HeaderText = "Password";
            dgvUser.Columns[3].HeaderText = "Jabatan";
        }

        public void lebarKolom()
        {
            dgvUser.Columns[0].Width = 80;
            dgvUser.Columns[1].Width = 125;
            dgvUser.Columns[2].Width = 90;
            dgvUser.Columns[3].Width = 90;
        }

        public void Simpan()
        {
            if (txtId.Text == String.Empty || txtUsername.Text == String.Empty || txtPassword.Text == String.Empty || txtJabatan.Text == String.Empty)
            {
                MessageBox.Show("Data textbox kosong!");
            }
            else
            { 
                String query = String.Format("INSERT INTO `data_admin`(`id`, `username`, `password`, `jabatan`, `image`) VALUES ('{0}','{1}','{2}','{3}', '{4}')", txtId.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtJabatan.Text.Trim(), SetImage(txtImageUrl.Text.Trim()));
                txtJabatan.Text = query;
                Db.CMD = new System.Data.Odbc.OdbcCommand(query, Db.CONN);
                Db.CMD.ExecuteNonQuery();
                clearTextBox();
                tampilData();
                MessageBox.Show("Data Telah Di Simpan!"); 
            }
        }

        public void Update()
        {
            if (txtId.Text == String.Empty)
            {
                MessageBox.Show("Data textbox kosong!");
            }
            else
            {
                String query = String.Format("UPDATE `data_admin` SET `username`='{1}',`password`='{2}',`jabatan`='{3}', `image` = '{4}' WHERE `id`='{0}'", txtId.Text.Trim(), txtUsername.Text.Trim(), txtPassword.Text.Trim(), txtJabatan.Text.Trim(), SetImage(txtImageUrl.Text.Trim()));
                txtJabatan.Text = query;
                Db.CMD = new System.Data.Odbc.OdbcCommand(query, Db.CONN);
                Db.CMD.ExecuteNonQuery();
                clearTextBox();
                tampilData();
                MessageBox.Show("Data Telah Di Update!");
            }
        }

        public void Hapus()
        {
            if (txtId.Text == String.Empty)
            {
                MessageBox.Show("Id belum disini!");
            }
            else
            { 
                if(MessageBox.Show("Apa Anda Yakin?", "Konfirmasi", MessageBoxButtons.YesNo, MessageBoxIcon.Information) == DialogResult.Yes)
                {
                    String query = String.Format("DELETE FROM `data_admin` WHERE `id` = '{0}'", txtId.Text.Trim());
                    Db.CMD = new System.Data.Odbc.OdbcCommand(query, Db.CONN);

                    if (Db.CMD.ExecuteNonQuery() == 1)
                    {
                        MessageBox.Show("Delete data berhasil!");
                        tampilData();
                    }
                    else
                    {
                        MessageBox.Show("Delete data gagal!");
                    }
                }
            }
        }

        private String newId()
        { 
            String id = String.Empty;
            int intId = 0;
            String query = "SELECT MAX(`id`) FROM `data_admin`;";

            Db.CMD = new System.Data.Odbc.OdbcCommand(query, Db.CONN);
            Db.DR = Db.CMD.ExecuteReader();
            if(Db.DR.HasRows)
            {
                id = Db.DR[0].ToString();

                if (id.Length == 0)
                    id = "0";
                else
                { 
                   intId = Convert.ToInt32(id);
                   id = Convert.ToString(intId + 1);
                }
            }
            return id;        
        }
        private void clearTextBox()
        {
            txtId.Clear();
            txtUsername.Clear();
            txtPassword.Clear();
            txtJabatan.Clear();
            pbxProfile.BackgroundImage = Properties.Resources.user_bg;
            pbxProfile.Image = null;
        }

        private byte[] SetImage(String _imageUrl)
        {
            FileStream fs;
            BinaryReader br;
            byte[] imageData = {};
            try
            {
                fs = new FileStream(_imageUrl, FileMode.Open, FileAccess.Read);
                br = new BinaryReader(fs);
                imageData = br.ReadBytes((int)fs.Length);
                br.Close();
                fs.Close();
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.ToString());
            }

            return imageData;
        }

        // Masih blm bisa
        private Image GetImage(byte[] _imageByte)
        { 
            MemoryStream ms = new MemoryStream();
            ms.Write(_imageByte, 0, Convert.ToInt32(_imageByte.Length));
            Bitmap bm = new Bitmap(ms,false);
            ms.Dispose();

            return bm;
        }

        private void dgvUser_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            String idRow = String.Empty;

            try
            {
                idRow = dgvUser.Rows[e.RowIndex].Cells[0].Value.ToString().Trim();
                TampilDataById(idRow);
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.ToString());
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            clearTextBox();
            tampilData();
        }

        private void btnSimpan_Click(object sender, EventArgs e)
        {
            Simpan();
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            Update();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            Hapus();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            clearTextBox();
            txtId.Text = newId();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog openFileDialog = new OpenFileDialog();
                openFileDialog.Filter = "Image files | *.png";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    txtImageUrl.Text = openFileDialog.FileName;
                    pbxProfile.BackgroundImage = null;
                    pbxProfile.Image = Image.FromFile(openFileDialog.FileName);
                }
            }
            catch (Exception _ex)
            {
                MessageBox.Show(_ex.ToString());
            }
        }
    }
}
