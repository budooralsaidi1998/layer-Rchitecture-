using Microsoft.EntityFrameworkCore;
using OutsysCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsysCompany.Repositories
{
    public class DeptLocationRepository
    {
        private readonly ApplicationDbContext _context;

        public DeptLocationRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<DeptLocation> GetAll()
        {
            return _context.DeptLocations.ToList();
        }

        public DeptLocation GetById(int dnumber, string dlocation)
        {
            return _context.DeptLocations.Find(dnumber, dlocation);
        }

        public void Add(DeptLocation deptLocation)
        {
            _context.DeptLocations.Add(deptLocation);
            _context.SaveChanges();
        }

        public void Update(DeptLocation deptLocation)
        {
            _context.DeptLocations.Update(deptLocation);
            _context.SaveChanges();
        }

        public void Delete(int dnumber, string dlocation)
        {
            var deptLocation = GetById(dnumber, dlocation);
            if (deptLocation != null)
            {
                _context.DeptLocations.Remove(deptLocation);
                _context.SaveChanges();
            }
        }

        public IEnumerable<DeptLocation> GetLocationsByDepartment(int departmentId)
        {
            return _context.DeptLocations.Where(dl => dl.Dnumber == departmentId).ToList();
        }
    }
}
