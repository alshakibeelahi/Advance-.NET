using BLL.DTOs;
using DAL.Model;
using DAL.Repo;
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
            var data = NewzRepo.AllNews();
            return Convert(data);

        }
        public static NewzDTOs SpecNews(int id)
        {
            var data = NewzRepo.GetNewz(id);
            return Convert(data);
        }
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
