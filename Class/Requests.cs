using EntityMain.DataBase;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EntityMain.Class
{
    internal class Requests
    {
        DemoContext Db = new DemoContext();
        public User Get(string log, string pas)
        {
            var user = Db.User.FirstOrDefault(x => x.Login == log && x.Password == pas);
            return user;
        }
    }
}
