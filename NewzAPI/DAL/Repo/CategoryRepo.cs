using DAL.Interfaces;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repo
{
    internal class CategoryRepo : Repo, IRepo<Category, int, bool>
    {
        public bool Delete(int id)
        {
            throw new NotImplementedException();
        }

        public List<Category> Get()
        {
            throw new NotImplementedException();
        }

        public Category Get(int id)
        {
            throw new NotImplementedException();
        }

        public bool Insert(Category obj)
        {
            throw new NotImplementedException();
        }

        public bool Update(Category obj)
        {
            throw new NotImplementedException();
        }
    }
}
