using Microsoft.EntityFrameworkCore;
using OutsysCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsysCompany.Repositories
{
    public class AttedenceRepository
    {
        private readonly ApplicationDbContext _context;

        public AttedenceRepository(ApplicationDbContext context)
        {
            _context = context;
        }

        public IEnumerable<Attedence> GetAll()
        {
            return _context.Attedences.ToList();
        }

        public Attedence GetById(int empleeID, string month, int year)
        {
            return _context.Attedences.Find(empleeID, month, year);
        }

        public void Add(Attedence attedence)
        {
            _context.Attedences.Add(attedence);
            _context.SaveChanges();
        }

        public void Update(Attedence attedence)
        {
            _context.Attedences.Update(attedence);
            _context.SaveChanges();
        }

        public void Delete(int empleeID, string month, int year)
        {
            var attedence = GetById(empleeID, month, year);
            if (attedence != null)
            {
                _context.Attedences.Remove(attedence);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Attedence> GetAttedencesByEmployee(int empleeID)
        {
            return _context.Attedences.Where(a => a.EmpleeID == empleeID).ToList();
        }

        public IEnumerable<Attedence> GetAttedencesByYear(int year)
        {
            return _context.Attedences.Where(a => a.year == year).ToList();
        }

        public IEnumerable<Attedence> GetAttedencesByMonth(string month)
        {
            return _context.Attedences.Where(a => a.month == month).ToList();
        }
    }
}
