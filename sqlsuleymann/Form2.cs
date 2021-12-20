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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=FINISTD033;Initial Catalog=Personel;Integrated Security=True");                

        private void Form2_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlCommand veriekle = new SqlCommand("insert into kişi(Tc,Ad,Soyad,Tel,Email,Adres) values (@Tc,@Ad,@Soyad,@Tel,@Email,@Adres)", baglantı);
            veriekle.Parameters.AddWithValue("@Tc", textBox1.Text);
            veriekle.Parameters.AddWithValue("@Ad", textBox2.Text);
            veriekle.Parameters.AddWithValue("@Soyad", textBox3.Text);
            veriekle.Parameters.AddWithValue("@Tel", textBox4.Text);
            veriekle.Parameters.AddWithValue("@Email", textBox5.Text);
            veriekle.Parameters.AddWithValue("@Adres", textBox6.Text);
            veriekle.ExecuteNonQuery();
            baglantı.Close();
            MessageBox.Show("Kişi Eklendi");
        }
    }
}
