using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel.Design;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class NewzRepo : Repo, IRepo<Newz, int, bool>
    {

        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Newz> Get()
        {
            return db.News.ToList();
        }

        public Newz Get(int id)
        {
            return db.News.Find(id);
        }

        public bool Insert(Newz obj)
        {
            var news = db.News.Add(obj);
            return db.SaveChanges() > 0;
        }

        public bool Update(Newz obj)
        {
            throw new NotImplementedException();
        }
    }
}
