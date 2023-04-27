using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class Repo
    {
        internal PAContest db;
        internal Repo()
        {
            db = new PAContest();
        }
    }
}
