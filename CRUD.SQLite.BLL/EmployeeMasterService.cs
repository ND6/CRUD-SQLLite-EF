using CRUD.SQLiteEF.DAL;
using CRUD.SQLiteEF.Entities;
using System.Collections.Generic;

namespace CRUD.SQLite.BLL
{
    public class EmployeeMasterService
    {
        EmployeeMasterRepository _repo = null;

        public EmployeeMasterService()
        {
            _repo = new EmployeeMasterRepository();
        }

        public int Create(EmployeeMaster employeeMaster)
        {
            return _repo.Create(employeeMaster);
        }

        public List<EmployeeMaster> Read()
        {
            return _repo.Read();
        }

        public int Update(EmployeeMaster employeeMaster)
        {
            return _repo.Update(employeeMaster);
        }

        public int Delete(EmployeeMaster employeeMaster)
        {
            return _repo.Delete(employeeMaster);
        }
    }
}
