using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.Sql;
using System.Data.SqlClient;



namespace WindowsFormsApp1
{
    public partial class Form1 : Form
        
    {
        SqlConnection con;
        SqlDataReader dr;
        SqlCommand com;

        public Form1()
        {
            InitializeComponent();
        }

        private void giris_Click(object sender, EventArgs e)
        {
string user = txt_kullanıcı.Text;
string password = txt_sifre.Text;
            


            con = new SqlConnection("Data Source=DESKTOP-T598O6J\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;");
            com = new SqlCommand();
            con.Open();
            com.Connection = con;
            com.CommandText="Select*From Kullanici_Bilgi Where Kullanici_adi='"+txt_kullanıcı.Text+"'And sifre='" + txt_sifre.Text + "'";
            dr = com.ExecuteReader();
            if (dr.Read())
            {
                MessageBox.Show(" basarılı");
                Form2 gecis = new Form2();
                gecis.Show();
                this.Hide();
            }
            else
            {
                MessageBox.Show("hata");
               
            }
            con.Close();

        }

        private void txt_kullanıcı_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
