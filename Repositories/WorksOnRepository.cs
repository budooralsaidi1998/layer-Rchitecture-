using Microsoft.EntityFrameworkCore;
using OutsysCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsysCompany.Repositories
{
    public class WorksOnRepository
    {
        private readonly ApplicationDbContext _context;

        public WorksOnRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<WorksOn> GetAll()
        {
            return _context.WorksOn.ToList();
        }

        public WorksOn GetById(int essn, int pno)
        {
            return _context.WorksOn.Find(essn, pno);
        }

        public void Add(WorksOn worksOn)
        {
            _context.WorksOn.Add(worksOn);
            _context.SaveChanges();
        }

        public void Update(WorksOn worksOn)
        {
            _context.WorksOn.Update(worksOn);
            _context.SaveChanges();
        }

        public void Delete(int essn, int pno)
        {
            var worksOn = GetById(essn, pno);
            if (worksOn != null)
            {
                _context.WorksOn.Remove(worksOn);
                _context.SaveChanges();
            }
        }

        public IEnumerable<WorksOn> GetWorksOnByEmployee(int essn)
        {
            return _context.WorksOn.Where(w => w.Essn == essn).ToList();
        }

        public IEnumerable<WorksOn> GetWorksOnByProject(int pno)
        {
            return _context.WorksOn.Where(w => w.Pno == pno).ToList();
        }
    }
}
