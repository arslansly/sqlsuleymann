using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;
namespace sqlsuleymann
{
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=FINISTD033\\;Initial Catalog=Personel;Integrated Security=True");
        DataSet daset = new DataSet();
        
        void güncelle()
        {
            baglantı.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT *from kişi", baglantı);
            da.Fill(daset, "kişi");
            dataGridView1.DataSource = daset.Tables["kişi"];
            baglantı.Close();
        }
      
        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("update kişi set Ad=@Ad , Soyad=@Soyad, Tel=@Tel, Email=@Email, Adres=@Adres where tc=@tc", baglantı);
            komut.Parameters.AddWithValue("@Tc", textBox1.Text);
            komut.Parameters.AddWithValue("@Ad", textBox2.Text);
            komut.Parameters.AddWithValue("@Soyad", textBox3.Text);
            komut.Parameters.AddWithValue("@Tel", textBox4.Text);
            komut.Parameters.AddWithValue("@Email", textBox5.Text);
            komut.Parameters.AddWithValue("@Adres", textBox6.Text);
            komut.ExecuteNonQuery();
            baglantı.Close();
            daset.Tables["kişi"].Clear();
            güncelle();
            MessageBox.Show("Kişi Bilgileri Güncellendi");
        }
        private void Form3_Load(object sender, EventArgs e)
        {
            güncelle();
        }
        private void dataGridView1_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            textBox1.Text = dataGridView1.CurrentRow.Cells["Tc"].Value.ToString();
            textBox2.Text = dataGridView1.CurrentRow.Cells["Ad"].Value.ToString();
            textBox3.Text = dataGridView1.CurrentRow.Cells["Soyad"].Value.ToString();
            textBox4.Text = dataGridView1.CurrentRow.Cells["Tel"].Value.ToString();
            textBox5.Text = dataGridView1.CurrentRow.Cells["Email"].Value.ToString();
            textBox6.Text = dataGridView1.CurrentRow.Cells["Adres"].Value.ToString();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand komut = new SqlCommand("delete from kişi where tc='" + dataGridView1.CurrentRow.Cells["tc"].Value.ToString() + "'", baglantı);
            komut.ExecuteNonQuery();
            baglantı.Close();
            daset.Tables["kişi"].Clear();
            güncelle();
            MessageBox.Show("Kişi Silinmiştir");

        }

        private void textBox7_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglantı.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from kişi where tc like '%" + textBox7.Text + "%'", baglantı);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglantı.Close();
        }

        private void textBox8_TextChanged(object sender, EventArgs e)
        {
            DataTable tablo = new DataTable();
            baglantı.Open();
            SqlDataAdapter da = new SqlDataAdapter("select * from kişi where isim like '%" + textBox8.Text + "%'", baglantı);
            da.Fill(tablo);
            dataGridView1.DataSource = tablo;
            baglantı.Close();
        }
    }
}
