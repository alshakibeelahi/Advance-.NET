using BLL.DTOs;
using DAL;
using DAL.Interfaces;
using DAL.Model;
using DAL.Repo;
using Microsoft.SqlServer.Server;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class NewzServices
    {
        public static List<NewzDTOs> AllNews()
        {
            var data = DataAccess.NewsContent().Get();
            return Convert(data);

        }
        public static NewzDTOs SpecNews(int id)
        {
            var data = DataAccess.NewsContent().Get(id);
            return Convert(data);
        }
        /*public static List<NewzDTOs> CatNewz(string name)
        {
            var data = NewzRepo.CatgNewz(name);
            return Convert(data);
        }*/
        static List<NewzDTOs> Convert(List<Newz> nwz)
        {
            var data = new List<NewzDTOs>();
            foreach (Newz ns in nwz)
            {
                data.Add(Convert(ns));
            }
            return data;
        }

        static NewzDTOs Convert(Newz newz)
        {
            return new NewzDTOs()
            {
                Id = newz.Id,
                Title = newz.Title,
                Description = newz.Description,
                Date = newz.Date,
                CId = newz.CId,
            };
        }
    }
}
