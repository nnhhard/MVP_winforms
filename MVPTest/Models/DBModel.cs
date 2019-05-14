using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MVPTest.Models
{
    public interface IDBModel
    {
        bool Authorization(String login, String password);
    }

    class DBModel: IDBModel
    {
        public bool Authorization(String login, String password)
        {
            if(login == "root" && password == "root")
                return true;
            else
                return false;
        }
    }
}
