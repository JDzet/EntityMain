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
            /* dataGridView1.DataSource = db.Product
                 .Select(x => new { x.Name }).ToList();*/



            var pr = db.Product.ToList();
            List<object[]> prod = new List<object[]>();
            foreach (var x in pr)
            {
                prod.Add(new object[4]);

                prod[prod.Count - 1][0] = pr.ToString();

                if (x.Photo == "") 
                     prod[prod.Count - 1][1] = Resources.picture;
                else
                    prod[prod.Count - 1][1] = Resources.ResourceManager.GetObject(x.Photo.ToString());


                prod[prod.Count - 1][2] = $"{x.Name}\n{ x.Description}\nПроизводитель: {x.Manufacture.ManufactureName}" +
                    $"\nЦена: {x.Price}";
                prod[prod.Count - 1][3] = $"{x.DiscountNow}%";
            }

            foreach(object[] s in prod) 
            {
                dataGridView1.Rows.Add(s);
            }
        }
    } 
}
