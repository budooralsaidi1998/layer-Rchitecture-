using Microsoft.EntityFrameworkCore;
using OutsysCompany.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OutsysCompany.Repositories
{
    public class EmployeeRepository
    {


        private readonly ApplicationDbContext _context;

        public EmployeeRepository(ApplicationDbContext context)
        {
            _context=context;
        }

        public List<Employee> GetAll()
        {
            return _context.Employees.ToList();
        }

        public int NumOfEmplyees()
        {
            return _context.Employees.Count();
        }


        public Employee GetById(int ssn)
        {
            return _context.Employees.Find(ssn);
        }

        public void Add(Employee employee)
        {
            _context.Employees.Add(employee);
            _context.SaveChanges();
        }

        public void Update(Employee employee)
        {
            _context.Employees.Update(employee);
            _context.SaveChanges();
        }

        public void Delete(int ssn)
        {
            var employee = GetById(ssn);
            if (employee != null)
            {
                _context.Employees.Remove(employee);
                _context.SaveChanges();
            }
        }

        public IEnumerable<Employee> GetEmployeesByDepartmentID(int departmentId)
        {
            return _context.Employees.Where(e => e.Dno == departmentId).ToList();
        }


        public IEnumerable<Employee> GetEmployeesByDepartmentName(string departmentName)
        {
            return _context.Employees.Include(e => e.Department).Where(e=>e.Department.Dname== departmentName)
                   .ToList();
        }

        public IEnumerable<Employee> GetEmployeesWithSupervisor(int supervisorSsn)
        {
            return _context.Employees.Where(e => e.SuperSsn == supervisorSsn).ToList();
        }

        public IEnumerable<Employee> GetByLastName(string lastName)
        {
            return _context.Employees.Where(e => e.Lname == lastName).ToList();
        }

    }
}
