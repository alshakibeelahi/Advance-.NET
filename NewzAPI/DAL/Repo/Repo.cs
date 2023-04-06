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
        internal NZContest db;
        internal Repo()
        {
            db = new NZContest();
        }
    }
}
