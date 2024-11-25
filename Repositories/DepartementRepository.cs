using Microsoft.EntityFrameworkCore;
using OutsysCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsysCompany.Repositories
{
    public class DepartementRepository
    {

        private readonly ApplicationDbContext _context;

        public DepartementRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Department> GetAll()
        {
            return _context.Departments.ToList();
        }

        public Department GetById(int dnumber)
        {
            return _context.Departments.Find(dnumber);
        }

        public void Add(Department department)
        {
            _context.Departments.Add(department);
            _context.SaveChanges();
        }

        public void Update(Department department)
        {
            _context.Departments.Update(department);
            _context.SaveChanges();
        }

        public void Delete(int dnumber)
        {
            var department = GetById(dnumber);
            if (department != null)
            {
                _context.Departments.Remove(department);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Department> GetDepartmentsWithProjects()
        {
            return _context.Departments.Include(d => d.Projects).ToList();
        }

        public Department GetDepartmentByManager(int mgrSsn)
        {
            return _context.Departments.FirstOrDefault(d => d.MgrSsn == mgrSsn);
        }

    }
}
