using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace FrmCalc
{
    public partial class FrmEntryCal : Form
    {
        // deklarasi tipe data untuk event OnCreate dan OnUpdate
        public delegate void CreateUpdateEventHandler(Calculator cal);

        // deklarasi event ketika terjadi proses input data baru
        public event CreateUpdateEventHandler OnCreate;

        // deklarasi event ketika terjadi proses update data
        public event CreateUpdateEventHandler OnUpdate;

        // deklarasi field untuk menyimpan entry data
        private bool isNewData = true;

        // deklarasi field untuk meyimpan objek kalkulator
        private Calculator cal;

        public FrmEntryCal()
        {
            InitializeComponent();

        }
        public FrmEntryCal(string title) : this()
        {
            this.Text = title;
        }
        private void btnProses_Click(object sender, EventArgs e)
        {
            if (isNewData) cal = new Calculator();
            if (txtNilaiA.Text == "" || txtNilaiB.Text == "")
            {
                MessageBox.Show("Data belum diisi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                txtNilaiA.Focus();
            }
            else if(cmbOperasi.Text=="")
            {
                MessageBox.Show("Pilih Operasi", "Peringatan", MessageBoxButtons.OK, MessageBoxIcon.Exclamation);
                cmbOperasi.Focus();
            }
            else
            {
                if (cmbOperasi.Text == "Penjumlahan")
                {
                    cal.Hasil = "Hasil Penjumlahan " + txtNilaiA.Text + " + " + txtNilaiB.Text + " = " + (int.Parse(txtNilaiA.Text) + int.Parse(txtNilaiB.Text));
                }
                else if (cmbOperasi.Text == "Pengurangan")
                {
                    cal.Hasil = "Hasil Pengurangan " + txtNilaiA.Text + " - " + txtNilaiB.Text + " = " + (int.Parse(txtNilaiA.Text) - int.Parse(txtNilaiB.Text));
                }
                else if (cmbOperasi.Text == "Perkalian")
                {
                    cal.Hasil = "Hasil Perkalian " + txtNilaiA.Text + " x " + txtNilaiB.Text + " = " + (int.Parse(txtNilaiA.Text) * int.Parse(txtNilaiB.Text));
                }
                else if (cmbOperasi.Text == "Pembagian")
                {
                    cal.Hasil = "Hasil Pembagian " + txtNilaiA.Text + " : " + txtNilaiB.Text + " = " + (int.Parse(txtNilaiA.Text) / int.Parse(txtNilaiB.Text));
                }
                if (isNewData) // data baru
                {
                    OnCreate(cal);
                }
                else // update
                {
                    OnUpdate(cal); 
                    this.Close();
                }
            }
        }

        private void cmbOperasi_SelectedIndexChanged(object sender, EventArgs e)
        {
            
        }

        private void FrmEntryCal_Load(object sender, EventArgs e)
        {

        }
    }
}
