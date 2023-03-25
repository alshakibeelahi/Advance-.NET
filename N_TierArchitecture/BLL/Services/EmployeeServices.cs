using DAL.Models;
using DAL.Repos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class EmployeeServices
    {

        public static Object GetAll()
        {
            return EmployeeRepo.GetAll();
        }
        public static Object GetById(int id)
        {
            return EmployeeRepo.Get(id);
        }
    }
}
