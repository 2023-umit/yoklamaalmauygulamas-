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
using iTextSharp.text.pdf;
using iTextSharp.text;
using System.IO;


namespace WindowsFormsApp1
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            
            string connectionString = "Data Source=DESKTOP-T598O6J\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";

            try
            {
                SqlConnection connection = new SqlConnection(connectionString);
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Ogrenciler", connection);
                DataTable dt = new DataTable();
                da.Fill(dt);

              
                dt.Columns.Add("GeldiMi", typeof(bool));
                dataGridView1.DataSource = dt;
            }
            catch (Exception ex)
            {
                MessageBox.Show("Veri çekilirken hata oluştu: " + ex.Message);
            }
        }

        private void btnYoklamaKaydet_Click(object sender, EventArgs e)
        {
           string connectionString = "Data Source=DESKTOP-T598O6J\\SQLEXPRESS;Initial Catalog=master;Integrated Security=True;";
    
    DateTime baslangicTarihi = new DateTime(2025, 5,20 );


    DateTime secilenTarih = dtpTarihSec.Value.Date;

    
    int gunNo = (secilenTarih - baslangicTarihi).Days + 1;

    if (gunNo < 1 || gunNo > 98)
    {
        MessageBox.Show("Geçerli bir tarih seçiniz. (1 ile 98 gün arası)");
        return;
    }

    string kolonAdi = "Gun" + gunNo;

    foreach (DataGridViewRow row in dataGridView1.Rows)
    {
        if (!row.IsNewRow)
        {
            bool geldiMi = false;

            if (row.Cells["GeldiMi"].Value != null && row.Cells["GeldiMi"].Value != DBNull.Value)
            {
                bool.TryParse(row.Cells["GeldiMi"].Value.ToString(), out geldiMi);
            }

            int ogrenciId = 0;
            string ad = row.Cells["Ad"].Value?.ToString() ?? "";
            string soyad = row.Cells["Soyad"].Value?.ToString() ?? "";
            string numara = row.Cells["Numara"].Value?.ToString() ?? "";

            if (row.Cells["OgrenciID"].Value != null && row.Cells["OgrenciID"].Value != DBNull.Value)
            {
                int.TryParse(row.Cells["OgrenciID"].Value.ToString(), out ogrenciId);
            }

            string query = $"UPDATE Yoklamalar SET {kolonAdi} = @Durum WHERE OgrenciID = @OgrenciID";

            using (SqlConnection con = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(query, con))
            {
                cmd.Parameters.AddWithValue("@OgrenciID", ogrenciId);
                cmd.Parameters.AddWithValue("@Durum", geldiMi);
                con.Open();
                int rowsAffected = cmd.ExecuteNonQuery();
                con.Close();

                if (rowsAffected == 0)
                {
                    string insertQuery = $"INSERT INTO Yoklamalar (OgrenciID, {kolonAdi}) VALUES (@OgrenciID, @Durum)";
                    using (SqlConnection con2 = new SqlConnection(connectionString))
                    using (SqlCommand cmd2 = new SqlCommand(insertQuery, con2))
                    {
                        cmd2.Parameters.AddWithValue("@OgrenciID", ogrenciId);
                        cmd2.Parameters.AddWithValue("@Durum", geldiMi);
                        con2.Open();
                        cmd2.ExecuteNonQuery();
                        con2.Close();
                    }
                }
            }
        }
    }

    MessageBox.Show($"Yoklama kaydedildi. (Tarih: {secilenTarih.ToShortDateString()}, Gün No: {gunNo})");
}

        private void btnPDF_Click(object sender, EventArgs e)
        {
            string dosyaYolu = "YoklamaListesi.pdf";
            Document belge = new Document();
            PdfWriter.GetInstance(belge, new FileStream(dosyaYolu, FileMode.Create));
            belge.Open();

            belge.Add(new Paragraph("Yoklama Listesi"));
            belge.Add(new Paragraph("Tarih: " + DateTime.Now.ToShortDateString()));
            belge.Add(new Paragraph(" "));

            PdfPTable tablo = new PdfPTable(4); 
            tablo.AddCell("Ad");
            tablo.AddCell("Soyad");
            tablo.AddCell("Numara");
            tablo.AddCell("Durum");

            foreach (DataGridViewRow row in dataGridView1.Rows)
            {
                if (!row.IsNewRow)
                {
                    tablo.AddCell(row.Cells["Ad"].Value?.ToString() ?? "");
                    tablo.AddCell(row.Cells["Soyad"].Value?.ToString() ?? "");
                    tablo.AddCell(row.Cells["Numara"].Value?.ToString() ?? "");

                    bool geldiMi = false;
                    if (row.Cells["GeldiMi"].Value != null && row.Cells["GeldiMi"].Value != DBNull.Value)
                    {
                        bool.TryParse(row.Cells["GeldiMi"].Value.ToString(), out geldiMi);
                    }

                    tablo.AddCell(geldiMi ? "Geldi" : "Gelmedi");
                }
            }

            belge.Add(tablo);
            belge.Close();

            string adobeYolu = @"C:\Program Files\Adobe\Acrobat DC\Acrobat\Acrobat.exe";
            System.Diagnostics.Process.Start(adobeYolu, dosyaYolu);
        }
    }
}
