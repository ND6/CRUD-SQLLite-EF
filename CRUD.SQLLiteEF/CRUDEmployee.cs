using CRUD.SQLite.BLL;
using CRUD.SQLiteEF.Entities;
using System;
using System.Collections.Generic;

namespace CRUD.SQLLiteEF
{
    public class CRUDEmployee
    {
        public static void Run()
        {
            EmployeeMasterService empService;
            EmployeeMaster employee = new EmployeeMaster()
            {
                EmpName = "Dika",
                Salary = 1000000
            };

            //Create
            empService = new EmployeeMasterService();
            empService.Create(employee);

            Console.WriteLine("Record After Insert :");
            var data = empService.Read();
            DisplayData(data);

            EmployeeMaster empUpdate = new EmployeeMaster()
            {
                ID = 1,
                EmpName = "Arta",
                Salary = 1000000
            };

            //Update
            empService.Update(empUpdate);

            Console.WriteLine("Record After Update :");
            data = empService.Read();
            DisplayData(data);

            //Delete
            empService.Delete(employee);

            Console.WriteLine("Record After Delete :");
            data = empService.Read();
            DisplayData(data);
        }

        private static void DisplayData(List<EmployeeMaster> data)
        {
            foreach (var item in data)
            {
                Console.Write(string.Format("ID : {0}  Name : {1}  Salary : {2}  {3}", item.ID, item.EmpName, item.Salary, Environment.NewLine));
            }
        }
    }
}
