using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CRUD.SQLLiteEF
{
    class Program
    {
        public static void Main(string[] args)
        {
            EmployeeContext context = new EmployeeContext();
            Console.WriteLine("Enter Employee ID");
            string EmployeeId = Console.ReadLine();
            Console.WriteLine("Enter Employee name");
            string name = Console.ReadLine();
            Console.WriteLine("Enter Salary");
            double salary = Convert.ToDouble(Console.ReadLine());
            Console.WriteLine("Enter Designation");
            string designation = Console.ReadLine();
            EmployeeMaster employee = new EmployeeMaster()
            {
                ID = int.Parse(EmployeeId),
                EmpName = name,
                Designation = designation,
                Salary = salary
            };
            context.EmployeeMaster.Add(employee);
            context.SaveChanges();

            var data = context.EmployeeMaster.ToList();
            foreach (var item in data)
            {
                Console.Write(string.Format("ID : {0}  Name : {1}  Salary : {2}   Designation : {3}{4}", item.ID, item.EmpName, item.Salary, item.Designation, Environment.NewLine));
            }

            Console.ReadKey();
        }
    }
}
