using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using MetroFramework.Forms;

namespace Covid_19_WinForm_XML_To_DataGridView
{
    public partial class Form1 : MetroFramework.Forms.MetroForm
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            /*
             1-Dataset Veritabanınızdan bağlantısız olan çalışan bir nesnedir. Saf XML tabanlı yapısı sayesinde web formları ve DotNet componentleri ile kusursuz bir entegrasyon sağlar. 
            Bu alandan referans alıyoruz.
            */
            DataSet ds = new DataSet();

            /*
             2-Asp.net ile baska bir yerden veri cekmeye çalıştığınızda hata alıyorsanız içeriği download etmeden önce aşağıdaki kodu eklemek
             */
            ServicePointManager.Expect100Continue = true;
            ServicePointManager.SecurityProtocol = SecurityProtocolType.Tls12;

            /*
             3-XML yapısını referans aldığımız ds değişkenine tama işlemi yapıyor ve ds değişkenine xml içeriğini yüklemiş oluyoruz.
 */
            ds.ReadXml("https://api.memleketyazilim.com/covid-19-turkey-master/dataset/timeline.xml");

            // ds değişkeni içerisindeki verileri dataGridView içerisine basıyoruz.
            dataGridView1.DataSource = ds.Tables[0];

            // O anki tarih bilgisini ve toplam data bilgisini kullanıcıya sunuyoruz.
            label6.Text = $@"{DateTime.Now.ToShortDateString()} tarihi itibari ile toplam data sayısı {dataGridView1.RowCount.ToString()}";
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            // dataGridView her tıklandığında tıklanan alandaki değerleri ilgili labele basıyoruz.
            lblTarih.Text = dataGridView1.CurrentRow.Cells[0].Value.ToString();
            lblTest.Text = dataGridView1.CurrentRow.Cells[1].Value.ToString();
            lblVaka.Text = dataGridView1.CurrentRow.Cells[2].Value.ToString();
            lblOlum.Text = dataGridView1.CurrentRow.Cells[3].Value.ToString();
            lblKurtarilan.Text = dataGridView1.CurrentRow.Cells[4].Value.ToString();
        }
    }
}
