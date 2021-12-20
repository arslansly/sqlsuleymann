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
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form2 frm = new Form2();
            frm.Show();
        }
        SqlConnection baglantı = new SqlConnection("Data Source=FINISTD033;Initial Catalog=Personel;Integrated Security=True");

        DataSet daset = new DataSet();
        private void Form1_Load(object sender, EventArgs e)
        {
            baglantı.Open();
            SqlDataAdapter da = new SqlDataAdapter("SELECT * from kişi", baglantı);
            da.Fill(daset, "kişi");
            dataGridView1.DataSource = daset.Tables["kişi"];
            baglantı.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Form3 frm = new Form3();
            frm.Show();
        }
    }
}
