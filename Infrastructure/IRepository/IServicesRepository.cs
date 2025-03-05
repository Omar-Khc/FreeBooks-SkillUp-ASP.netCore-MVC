using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuree.IRepository
{
    public interface IServicesRepository<T> where T : class
    {
        List<T> GetAll();

        T FindById(Guid id);

        T FindByName(string name);

        bool Save(T model);

        bool Delete(Guid id);
    }
}
