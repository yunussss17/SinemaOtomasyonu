using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Sinema
{
    public partial class FrmAnaform : Form
    {
        public FrmAnaform()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
        // public değişkeni tüm alanlarda kulanıma açar
        public string kisiAdiSoyadi = "";

        private void FrmAnaform_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            FrmYonetmen frm = new FrmYonetmen();
            frm.ShowDialog(); // show   // bu pencere kapanmadan diğer pencere kapanmaz
                         // this.Close();
           // this.Hide();        
        }
    }
}
