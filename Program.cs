using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using OutsysCompany.Models;
using OutsysCompany.Repositories;

namespace OutsysCompany
{
    internal class Program
    {
        static void Main(string[] args)
        {

            //Console.WriteLine("Enter dept name ");
            //string deptName= Console.ReadLine();

            // ApplicationDbContext dbx = new ApplicationDbContext();

            // EmployeeRepository employeeRepository1 = new EmployeeRepository(dbx);

            //var result = employeeRepository1.GetEmployeesByDepartmentName(deptName);

            //foreach (var e in  result)
            //{
            //    Console.WriteLine(e.Fname);
            //}


            //DepartementRepository de = new DepartementRepository(dbx);
            //ProjectRepository projectRepository1 = new ProjectRepository(dbx);




            //Console.WriteLine("using Repo");
            //using (var context = new ApplicationDbContext())
            //{
            //    EmployeeRepository empRep = new EmployeeRepository(context);
            //    var empList = empRep.GetAll();  // c# code call c# code

            //    foreach (var e in empList) 
            //    {
            //        Console.WriteLine(e.Fname);
            //    }
            //}

            //Console.WriteLine("\nusing direct access");
            //using (var context = new ApplicationDbContext())
            //{
            //    var empList = context.Employees.ToList(); //direct access context -- to DB

            //    foreach(var e in empList )
            //    {
            //        Console.WriteLine(e.Fname);   
            //    }

            //}


            //ApplicationDbContext applicationDbContext = new ApplicationDbContext(); // wrong usage of DBcontext

            //using (var Context = new ApplicationDbContext())
            //{

            //    Employee[] employees = new Employee[2];

            //    for (int i = 0; i < 2; i++)
            //    {
            //        Console.WriteLine("Enter employee " + i + 1 + " name ");
            //        string name = Console.ReadLine();
            //        Console.WriteLine("Enter your salary");
            //        decimal sal = decimal.Parse(Console.ReadLine());

            //        employees[i] = new Employee { Fname = name, Salary = sal };
            //    }

            //    Context.Employees.AddRange(employees);

            //    var Emp1 = new Employee();
            //    Emp1.Fname = "karim";
            //    Emp1.Minit = "ali";
            //    Emp1.Salary = 1000;
            //    Emp1.Address = "muscat";
            //    Emp1.Dno = 1;

            //    Context.Employees.Add(Emp1);

            //    Context.SaveChanges();

            //}

            //using (var Context = new ApplicationDbContext())
            //{
            //    var employeesByDepartment = Context.Employees.GroupBy(e => e.Dno)
            //    .Select(g => new { DepartmentId = g.Key, EmployeeCount = g.Count() })
            //    .OrderByDescending(e => e.EmployeeCount)
            //    .ToList();

            //    foreach (var employee in employeesByDepartment)
            //    {
            //        Console.WriteLine(employee.EmployeeCount + employee.DepartmentId);
            //    }
            //}

            //using (var Context = new ApplicationDbContext())
            //{
            //    ////----------------------------------Include------------------------------
            //    //var employeesWithDepartments = Context.Employees.Include(e => e.Department).ToList();

            //    //foreach (var employee in employeesWithDepartments)
            //    //{
            //    //    Console.WriteLine($"Employee {employee.Ssn}: {employee.Fname} {employee.Lname} - Salary: {employee.Salary}, Department: {employee.Department.Dname}");
            //    //}

            //    ////----------------------------------Include--Include-----------------------------
            //    //var emps = Context.Employees.Include(e => e.Department)
            //    //                                                .Include(e=>e.Dependents).ToList();

            //    //foreach (var employee in emps)
            //    //{
            //    //    Console.WriteLine($"Employee {employee.Ssn}: {employee.Fname} {employee.Lname} - Salary: {employee.Salary}, Department: {employee.Department.Dname}");


            //    //    foreach (var dependent in employee.Dependents)
            //    //    {
            //    //        Console.WriteLine($"has :{dependent.Relationship} {dependent.DependentName}");
            //    //    }
            //    //}

            //    //----------------------------Include then include------------------------------------
            //    //var empDeptProject = Context.Employees.Include(e => e.Department)
            //    //                                      .ThenInclude(e=>e.Projects).ToList();

            //    //foreach (var employee in empDeptProject)
            //    //{
            //    //    Console.WriteLine($"Employee {employee.Ssn}: {employee.Fname} {employee.Lname} - Salary: {employee.Salary}, " +
            //    //                              $"works in Department: {employee.Department.Dname}");

            //    //        foreach (var project in employee.Department.Projects)
            //    //        {
            //    //            Console.WriteLine($"which operates Project: {project.Pname}\n");
            //    //        }

            //    //}

            //    //foreach (var employee in empDeptProject)
            //    //{
            //    //    if (employee.Department != null && employee.Department.Projects != null)
            //    //    {
            //    //        foreach (var project in employee.Department.Projects)
            //    //        {
            //    //            Console.WriteLine($"Employee {employee.Ssn}: {employee.Fname} {employee.Lname} - Salary: {employee.Salary}, " +
            //    //                              $"works in Department: {employee.Department.Dname} which operates Project: {project.Pname}");
            //    //        }
            //    //    }
            //    //    else
            //    //    {
            //    //        Console.WriteLine($"Employee {employee.Ssn}: {employee.Fname} {employee.Lname} - Salary: {employee.Salary}, " +
            //    //                          "has no department or projects associated.");
            //    //    }
            //    //}

            //    Console.WriteLine();
            //    //----------------------------------------------------------------
            //    var employeesByDepartment = Context.Employees.GroupBy(e => e.Dno)
            //    .Select(g => new { DepartmentId = g.Key, EmployeeCount = g.Count() })
            //    .OrderByDescending(e => e.EmployeeCount)
            //    .ToList();

            //    foreach (var employee in employeesByDepartment)
            //    {
            //        Console.WriteLine("There are "+employee.EmployeeCount + " Employees in departement " + employee.DepartmentId);
            //    }
            //}
            //----------------------------------------------------------------------------------------
            //----------------------------------------------------------------------------------------

            using var dbContext = new ApplicationDbContext();

            // Create repositories
            var employeeRepository = new EmployeeRepository(dbContext);
            var departmentRepository = new DepartementRepository(dbContext);
            var projectRepository = new ProjectRepository(dbContext);
            var dependentRepository = new DependentRepository(dbContext);
            var deptLocationRepository = new DeptLocationRepository(dbContext);
            var worksOnRepository = new WorksOnRepository(dbContext);
            var attedenceRepository = new AttedenceRepository(dbContext);

            // User interaction loop
            bool running = true;
            while (running)
            {
                Console.WriteLine("\nChoose an option:");
                Console.WriteLine("1. Display all employees");
                Console.WriteLine("2. Add new employee");
                Console.WriteLine("3. Display all departments");
                Console.WriteLine("4. Add new department");
                Console.WriteLine("5. Display all projects");
                Console.WriteLine("6. Add new project");
                Console.WriteLine("7. Exit");
                Console.Write("Enter your choice: ");
                var choice = Console.ReadLine();

                switch (choice)
                {
                    case "1":
                        DisplayAllEmployees(employeeRepository);
                        break;
                    case "2":
                        AddNewEmployee(employeeRepository);
                        break;
                    case "3":
                        DisplayAllDepartments(departmentRepository);
                        break;
                    case "4":
                        AddNewDepartment(departmentRepository);
                        break;
                    case "5":
                        DisplayAllProjects(projectRepository);
                        break;
                    case "6":
                        AddNewProject(projectRepository);
                        break;
                    case "7":
                        running = false;
                        break;
                    default:
                        Console.WriteLine("Invalid choice. Please try again.");
                        break;
                }
            }
        }

        static void DisplayAllEmployees(EmployeeRepository repository)
        {
            var employees = repository.GetAll();
            Console.WriteLine("\nEmployees:");
            foreach (var employee in employees)
            {
                Console.WriteLine($"{employee.Ssn}: {employee.Fname} {employee.Lname} - Salary: {employee.Salary}");
            }
        }

        static void AddNewEmployee(EmployeeRepository repository)
        {
            Console.Write("\nEnter first name: ");
            var fname = Console.ReadLine();
            Console.Write("Enter last name: ");
            var lname = Console.ReadLine();
            Console.Write("Enter gender: ");
            var sex = Console.ReadLine();
            Console.Write("Enter salary: ");
            if (decimal.TryParse(Console.ReadLine(), out var salary))
            {
                var employee = new Employee { Fname = fname, Lname = lname, Sex= sex, Salary = salary };
                repository.Add(employee);
                Console.WriteLine("Employee added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid salary input.");
            }
        }

        static void DisplayAllDepartments(DepartementRepository repository)
        {
            var departments = repository.GetAll();
            Console.WriteLine("\nDepartments:");
            foreach (var department in departments)
            {
                Console.WriteLine($"{department.Dnumber}: {department.Dname}");
            }
        }

        static void AddNewDepartment(DepartementRepository repository)
        {
            Console.Write("\nEnter department name: ");
            var dname = Console.ReadLine();
            Console.Write("Enter manager SSN: ");
            if (int.TryParse(Console.ReadLine(), out var mgrSsn))
            {
                var department = new Department { Dname = dname, MgrSsn = mgrSsn, MgrStartDate = DateTime.Now };
                repository.Add(department);
                Console.WriteLine("Department added successfully!");
            }
            else
            {
                Console.WriteLine("Invalid manager SSN input.");
            }
        }

        static void DisplayAllProjects(ProjectRepository repository)
        {
            var projects = repository.GetAll();
            Console.WriteLine("\nProjects:");
            foreach (var project in projects)
            {
                Console.WriteLine($"{project.Pnumber}: {project.Pname} - Location: {project.Plocation}");
            }
        }

        static void AddNewProject(ProjectRepository repository)
        {
            Console.Write("\nEnter project name: ");
            var pname = Console.ReadLine();
            Console.Write("Enter project location: ");
            var plocation = Console.ReadLine();
            Console.Write("Enter project department number: ");
            if (int.TryParse(Console.ReadLine(), out var dno))
            {
                var proj = new Project { Pname = pname, Plocation = plocation, Dnum=dno };
                repository.Add(proj);
                Console.WriteLine("Project added successfully!");
            }
        }



    }
}
