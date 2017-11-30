using CRUD.SQLiteEF.Entities;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace CRUD.SQLiteEF.DAL
{
    public class EmployeeMasterRepository : BaseRepository
    {
        EmployeeMasterContext _context;

        public EmployeeMasterRepository()
        {
            _context = new EmployeeMasterContext(conStringName);
        }

        public int Create(EmployeeMaster employeeMaster)
        {
            _context.Set<EmployeeMaster>().Add(employeeMaster);
            return _context.SaveChanges();
        }

        public List<EmployeeMaster> Read()
        {
            return _context.Set<EmployeeMaster>().ToList();
        }

        public int Update(EmployeeMaster employeeMaster)
        {
            var empUpdate = _context.Set<EmployeeMaster>().Single(x => x.ID == employeeMaster.ID);
            empUpdate.EmpName = employeeMaster.EmpName;
            empUpdate.Salary = employeeMaster.Salary;

            _context.Set<EmployeeMaster>().Attach(empUpdate);
            _context.Entry(empUpdate).State = EntityState.Modified;
            return _context.SaveChanges();
        }

        public int Delete(EmployeeMaster employeeMaster)
        {
            _context.Set<EmployeeMaster>().Attach(employeeMaster);
            _context.Entry(employeeMaster).State = EntityState.Deleted;
            return _context.SaveChanges();
        }
    }
}
