using Microsoft.EntityFrameworkCore;
using OutsysCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsysCompany.Repositories
{
    public class DependentRepository
    {
        private readonly ApplicationDbContext _context;

        public DependentRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Dependent> GetAll()
        {
            return _context.Dependents.ToList();
        }

        public Dependent GetById(int essn, string dependentName)
        {
            return _context.Dependents.Find(essn, dependentName);
        }

        public void Add(Dependent dependent)
        {
            _context.Dependents.Add(dependent);
            _context.SaveChanges();
        }

        public void Update(Dependent dependent)
        {
            _context.Dependents.Update(dependent);
            _context.SaveChanges();
        }

        public void Delete(int essn, string dependentName)
        {
            var dependent = GetById(essn, dependentName);
            if (dependent != null)
            {
                _context.Dependents.Remove(dependent);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Dependent> GetDependentsByEmployee(int essn)
        {
            return _context.Dependents.Where(d => d.Essn == essn).ToList();
        }
    }
}
