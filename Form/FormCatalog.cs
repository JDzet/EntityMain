using EntityMain.DataBase;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityMain
{
    public partial class FormCatalog : Form
    {
        DemoEntities1 db = new DemoEntities1();

        public FormCatalog()
        {
            InitializeComponent();
        }

        Thread th;
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
            th = new Thread(CloseCatalog);
            th.SetApartmentState(ApartmentState.STA);
            th.Start();

        }
        public void CloseCatalog() 
        {
            Application.Run(new FormAuthori());
        }

        private void FormCatalog_Load(object sender, EventArgs e)
        {
          //  dataGridView1.DataSource = db.Product.ToList();
            dataGridView1.DataSource = db.Product.Select(x => x.Name.ToString()).ToList();
        }
    }
}
