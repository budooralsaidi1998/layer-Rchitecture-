using Microsoft.EntityFrameworkCore;
using OutsysCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsysCompany.Repositories
{
    public class ProjectRepository
    {

        private readonly ApplicationDbContext _context;

        public ProjectRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Project> GetAll()
        {
            return _context.Projects.ToList();
        }

        public Project GetById(int pnumber)
        {
            return _context.Projects.Find(pnumber);
        }

        public void Add(Project project)
        {
            _context.Projects.Add(project);
            _context.SaveChanges();
        }

        public void Update(Project project)
        {
            _context.Projects.Update(project);
            _context.SaveChanges();
        }

        public void Delete(int pnumber)
        {
            var project = GetById(pnumber);
            if (project != null)
            {
                _context.Projects.Remove(project);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Project> GetProjectsByDepartment(int departmentId)
        {
            return _context.Projects.Where(p => p.Dnum == departmentId).ToList();
        }

        public IEnumerable<Project> GetProjectsWithEmployees()
        {
            return _context.Projects.Include(p => p.WorksOnEmployees).ThenInclude(w => w.Employee).ToList();
        }

    }
}
