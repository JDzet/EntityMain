using EntityMain.DataBase;
using EntityMain.Properties;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace EntityMain.Class
{
    internal class Requests
    {
        DemoContextMain db = new DemoContextMain();
        public User Get(string log, string pas)
        {
            var user = db.User.FirstOrDefault(x => x.Login == log && x.Password == pas);
            return user;
        }

        public List<object[]> DataGridV(List<Product> pr)
        {

            List<object[]> prod = new List<object[]>();
            foreach (var x in pr)
            {
                prod.Add(new object[4]);

                prod[prod.Count - 1][0] = pr.ToString();

                if (x.Photo == "")
                    prod[prod.Count - 1][1] = Resources.picture;
                else
                    prod[prod.Count - 1][1] = Resources.ResourceManager.GetObject(x.Photo.ToString());


                prod[prod.Count - 1][2] = $"{x.Name}\n{x.Description}\nПроизводитель: {x.Manufacture.ManufactureName}" +
                    $"\nЦена: {x.Price}";
                prod[prod.Count - 1][3] = $"{x.DiscountNow}%";
            }

            return prod;


        }
    }
}
