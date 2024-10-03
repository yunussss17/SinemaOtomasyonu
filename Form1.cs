using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
// sql veritanına ait  kütüphaneyi eklemen ve bunu programa belirtmen gerekiyor.
using System.Data.SqlClient;
namespace Sinema
{
    public partial class FrmAcilis : Form
    {
        public FrmAcilis()
        {
            InitializeComponent();
        }

        // connectionstring dediğimiz veritabımızın  yolunu projemize eklememiz gerekiyor ve veritanımızın      yolunu programızıa söyelemeiz gerekiyor
        // SqlConnection connection = new SqlConnection("Data Source =Veritabanımızın_Yolu ;Initial Catalog =Veritabanımızın_Adı ; Integrated Security=True");

        SqlConnection connection = new SqlConnection("Data Source =DESKTOP-IC95M72\\SQLEXPRESS ;Initial Catalog =SinematixVT ; Integrated Security=True");
     


        private void button1_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void GirişYap_Click_Click(object sender, EventArgs e)
        {

            // kullanıcı giriş işlmemlerini gerçekleştirceğiz
            // select  insert uptadate delete
            // şart yada koşul tümcemiz  WHERE idi
              connection.Open();
            // * proglama dilinde ALL anlamına gelmektedir . yani tüm , tümü anlamı karşılamaktadır.
              SqlCommand sorgula = new SqlCommand("SELECT * FROM Table_kullanıcilar WHERE kullnıcı_adi = @username AND kullanici_sifre = @password", connection);

            sorgula.Parameters.AddWithValue("@username",KullaniciAd_textbox.Text);
            sorgula.Parameters.AddWithValue("@password",KullanıcıSıfre_textbox.Text);

            SqlDataReader oku = sorgula.ExecuteReader();

            if (oku.Read()) // okuma işlemi başarılı ise . yani girmiş olduğumuz veriler veri tabanında mevcut ise veya bilgiler eşleşiyor ise yada bilgiler doğru ise yapıalacak işlemler.
            {
                //MessageBox.Show("GİRİŞ BAŞARILI");
                FrmAnaform frm = new FrmAnaform();
                frm.kisiAdiSoyadi = oku["Ad_Soyad"].ToString();
                frm.Show();  // showdialog
                this.Hide();
            }
            else
            {
                MessageBox.Show("KULLANICI KAYDI BULUNAMADI ! KULLANICI ADI VEYA ŞİFRE HATALI");
            }

            connection.Close();


            KullaniciAd_textbox.Text = "";
            KullanıcıSıfre_textbox.Text = ""; 
            KullaniciAd_textbox.Focus();   // imleci konumlandırmak demek





            //veitanına bağlanma işlemi sorgulama 

           /* connection.Open();
            if (connection.State==ConnectionState.Open)
            {
                MessageBox.Show("Başarılı");
            }
            connection.Close();
           */
        }
    }
}
