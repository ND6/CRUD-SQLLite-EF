using CRUD.SQLiteEF.DAL;
using CRUD.SQLiteEF.Entities;
using System.Collections.Generic;

namespace CRUD.SQLite.BLL
{
    public class ProductInformationService
    {
        ProductInformationRepository _repo = null;

        public ProductInformationService()
        {
            _repo = new ProductInformationRepository();
        }

        public int Create(ProductInformation productInfo)
        {
            return _repo.Create(productInfo);
        }

        public List<ProductInformation> Read()
        {
            return _repo.Read();
        }

        public int Update(ProductInformation productInfo)
        {
            return _repo.Update(productInfo);
        }

        public int Delete(ProductInformation productInfo)
        {
            return _repo.Delete(productInfo);
        }
    }
}
