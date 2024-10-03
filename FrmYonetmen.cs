using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

using System.Data.SqlClient;  // kütüphanemizi ekliyoruz 

namespace Sinema
{
    public partial class FrmYonetmen : Form
    {
        public FrmYonetmen()
        {
            InitializeComponent();
        }
        // connectionstring

        SqlConnection connection = new SqlConnection("Data Source=DESKTOP-IC95M72\\SQLEXPRESS;Initial Catalog=SinematixVT;Integrated Security=True");


        private void button1_Click(object sender, EventArgs e)
        {
            //Application.Exit();  bunu kullanırsak uygulamayı tümüyle kapatır biz sadece pencereyi kapatmak istiyoruz
            this.Close(); 
        }
        public string resimyolu = "";

        private void BtnResimYükle_Click(object sender, EventArgs e)
        {
            OpenFileDialog ofd = new OpenFileDialog();
            ofd.Title = "Resim Seçme Ekranı";
            ofd.Filter = "PNG | * .png | JPG - JPEG | * .jpg ; * .jpeg | ALL Files | *.* ";
            ofd.FilterIndex = 3;

            if (ofd.ShowDialog() == DialogResult.OK)

            {
                // resim alma işemini bu alanda gerçekleştirilecek
                Pbresim1.Image = new Bitmap(ofd.FileName);
                resimyolu = ofd.FileName.ToString();


            }
        }

        private void RadioE_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "0";
        }

        private void Radiokız_CheckedChanged(object sender, EventArgs e)
        {
            cinsiyet = "1";
        }

        public string cinsiyet = "0";

        private void button3_Click(object sender, EventArgs e)
        {
            yasHesaplama();

            MessageBox.Show(byas);
            
            string adsoyad = txtAd.Text.ToString().ToUpper() + " " + txtsoyad.Text.ToString().ToUpper(); // kullanıcıdını adını ve soyadını alıp birleştirmiş oluyoruz 

            
            // TOUPPER kodumuuz var olan karakterlerin tümünü büyük harfe çevirmeye yarayan  komudumuzdur    // örnek ----> yunus -- YUNUS
            // insert , update , delete ,select 
            connection.Open();               //insert into Table Yönetmenler (alanlarımız,) VALUES (@değerlerimiz,) 

            SqlCommand Kayit = new SqlCommand("insert into Table_Yönetmenler (ADSOYAD, CINSIYET, YAS, BİYOGRAFİ, RESİM) VALUES (@p1, @p2, @p3, @p4, @p5)", connection);


            Kayit.Parameters.AddWithValue("@p1",adsoyad);
            Kayit.Parameters.AddWithValue("@p2",cinsiyet);
            Kayit.Parameters.AddWithValue("@p3",byas);
            Kayit.Parameters.AddWithValue("@p4",txtBiyografi.Text.ToString().ToUpper());
            Kayit.Parameters.AddWithValue("@p5",resimyolu);
            var sonuc = Kayit.ExecuteNonQuery();
            if (sonuc > 0)
            {
                MessageBox.Show("Yönetmen kayıt işlemi başarılı bir şekilde gerçekleştirildi.");
            }
            else
            {
                MessageBox.Show("Kayıt işlemi başarısız oldu.");
            }

            connection.Close();
            MessageBox.Show("yöneymen kayıt işlemi başarılı bir şekilde gerçekleştirildi.");
            //ARAÇ TEMİZLEME KOMUDU YAZMAMAIZ GEREKECEK
           
        }
        public string byas="00";

        void yasHesaplama()

         {
            string dogum = Ngün.Value.ToString() + "- " + Nay.Value.ToString() + "-" + Nyıl.Value.ToString();
            // MessageBox.Show(dogum);

            DateTime dogumtarihi = Convert.ToDateTime(dogum);
            DateTime bugun = DateTime.Today;
            int yas = bugun.Year - dogumtarihi.Year;

         
            MessageBox.Show(yas.ToString());

/*
            if (yas < 0)
            {
                MessageBox.Show("yaşınız Negatif olamaz !");
            }
            else if (yas < 18 )

            {

                MessageBox.Show("yaşınız 18 den küçükttür !");

            }

            else
            {

                MessageBox.Show(yas.ToString());
            }
*/
            byas = yas.ToString();
        }

        

        private void txtBiyografi_TextChanged(object sender, EventArgs e)
        {
            int karaktersyisi = txtBiyografi.Text.Length;
            int geri = 300 - karaktersyisi;
            lblKarakter.Text = geri.ToString();
            //MessageBox.Show(karaktersyisi.ToString());
            // ayarlar kısmından maxlengt kısmından da ayarlayabilir siniz.
        }
    }
}
