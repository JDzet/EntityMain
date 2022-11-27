using EntityMain.DataBase;
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

            /* foreach (var x in db.Product) 
             {
                 //dataGridView1.Rows.Add(Stig(x));
             }*/
            /* string[] product;
             product = db.Product.Select(x => new { x.Name }).ToArray();
             dataGridView1.DataSource = product.ToList();*/


            var pr = db.Product.ToList();
            List<string[]> prod = new List<string[]>();
            int i = 0;
            foreach (var x in pr)
            {
                prod.Add(new string[4]);

                prod[prod.Count - 1][0] = pr.ToString();
                //prod[prod.Count - 1][1] =
                prod[prod.Count - 1][2] = $"{x.Name} \t\nКак какать{ x.Manufacture.ManufactureName}";
                prod[prod.Count - 1][3] = x.Price;
                i++;
            }

            foreach(string[] s in prod) 
            {
                dataGridView1.Rows.Add(s);
            }

          //  dataGridView1.Rows.Add*/

        }

        public void Stig()
        {
            

        }

     
    } 
}
