using EntityMain.Class;
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
    public partial class FormAuthori : Form
    {
        public string _login;
        public string _password;
        public FormAuthori()
        {
            InitializeComponent();
        }

        Requests req = new Requests();
        Thread th;
        private void button1_Click(object sender, EventArgs e)
        {
            var user = req.Get(_login, _password);
            if (user != null)
            {
                MessageBox.Show($"Имя - {user.Name} Роль: {user.Role.RoleName}");
                this.Close();
                th = new Thread(opne);
                th.SetApartmentState(ApartmentState.STA);
                th.Start();
            }
            else
            {
                MessageBox.Show("Неудача");
            }
        }

        public void opne() 
        {
            Application.Run(new FormCatalog());
        }

        private void textBoxLog_TextChanged(object sender, EventArgs e)
        {
            _login = ((TextBox)sender).Text;
        }

        private void textBoxPass_TextChanged(object sender, EventArgs e)
        {
            _password = ((TextBox)sender).Text;
        }
    }
}
