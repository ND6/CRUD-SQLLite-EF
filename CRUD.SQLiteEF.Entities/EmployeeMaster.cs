using System.ComponentModel.DataAnnotations;

namespace CRUD.SQLiteEF.Entities
{
    public class EmployeeMaster
    {
        [Key]
        public int ID { get; set; }

        public string EmpName { get; set; }

        public double Salary { get; set; }
    } 
}
