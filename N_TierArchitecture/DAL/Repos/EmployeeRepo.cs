using DAL.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL.Repos
{
    public class EmployeeRepo
    {
        static NTContext db;
        static EmployeeRepo()
        {
            db = new NTContext();
        }
        public static List<Employee> GetAll()
        {
            return db.Employees.ToList();
        }
        public static Employee Get(int id)
        {
            return db.Employees.Find(id);
        }
        public static bool Create(Employee emp)
        {
            db.Employees.Add(emp);
            return db.SaveChanges() > 0;
        }
        public static bool Update(Employee emp)
        {
            var extemp = Get(emp.Id);
            extemp.Id=emp.Id;
            extemp.Name=emp.Name;
            return db.SaveChanges() > 0;
        }
        public static bool Delete(int id)
        {
            var extemp = Get(id);
            db.Employees.Remove(extemp);
            return db.SaveChanges() > 0;
        }
    }
}
