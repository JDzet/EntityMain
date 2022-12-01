using EntityMain.Class;
using EntityMain.DataBase;
using EntityMain.Properties;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.Entity;
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
        DemoContextMain db = new DemoContextMain();
        Requests req = new Requests();

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


        List<Product> pr;
        private void FormCatalog_Load(object sender, EventArgs e)
        {
            /* dataGridView1.DataSource = db.Product
                 .Select(x => new { x.Name }).ToList();*/

            comboBoxCategor.Items.Add("Все категории");
            var i = db.Category.Select(x => x.CategoryName).ToList();
            foreach (var x in i) 
            {
                comboBoxCategor.Items.Add(x);
            }
            comboBoxCategor.SelectedIndex = 0;
 
        }

        public void addDataGrid()
        {
            var prod = req.DataGridV(pr);

            foreach (var x in prod)
            {
                dataGridView1.Rows.Add(x);
            }

        }


        private void comboBoxCategor_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (comboBoxCategor.SelectedIndex) 
            {
                case 0:
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    pr = db.Product.ToList();
                    addDataGrid();
                    break;

                case 1:
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    pr = db.Product.Where(x => x.Category.CategoryName == comboBoxCategor.Text).ToList();
                    addDataGrid();
                    break;

                case 2:
                    dataGridView1.Rows.Clear();
                    dataGridView1.Refresh();
                    pr = db.Product.Where(x => x.Category.CategoryName == comboBoxCategor.Text).ToList();
                    addDataGrid();
                    break;
            }
        }
    } 
}
