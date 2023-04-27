using BLL.DTOS;
using DAL;
using DAL.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL.Services
{
    public class ProjectService
    {
        public static bool Create(ProjectDTO proj)
        {
            var data = Convert(proj);
            return DataAccess.ProjectContext().Insert(data);
        }
        public static List<ProjectDTO> GetAll()
        {
            var data = DataAccess.ProjectContext().Get();
            return Convert(data);
        }
        public static List<ProjectDTO> GetSpec(string stats)
        {
            var data = DataAccess.ProjectContextSpec().GetSameStatus(stats);
            return Convert(data);
        }
        public static List<ProjectDTO> GetSpecTime(string stats, DateTime tmt)
        {
            var data = DataAccess.ProjectContextSpec().GetTStat(stats, tmt);
            return Convert(data);
        }
        static List<ProjectDTO> Convert(List<Project> projects)
        {
            var data = new List<ProjectDTO>();
            foreach (Project proj in projects)
            {
                data.Add(Convert(proj));
            }
            return data;
        }
        static ProjectDTO Convert(Project proj)
        {
            return new ProjectDTO()
            {
                Id = proj.Id,
                Title= proj.Title,
                Status= proj.Status,
                StartDate= proj.StartDate,
                EndDate= proj.EndDate,
            };
        }
        static List<Project> Convert(List<ProjectDTO> projects)
        {
            var data = new List<Project>();
            foreach (ProjectDTO proj in projects)
            {
                data.Add(Convert(proj));
            }
            return data;
        }
        static Project Convert(ProjectDTO proj)
        {
            return new Project()
            {
                Title = proj.Title,
                Status = proj.Status,
                StartDate = proj.StartDate,
                EndDate = proj.EndDate,
            };
        }
    }
}
