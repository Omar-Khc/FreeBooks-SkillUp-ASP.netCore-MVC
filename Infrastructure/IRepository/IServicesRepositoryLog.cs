using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuree.IRepository
{
    public interface IServicesRepositoryLog<T> where T : class
    {
        List<T> GetAll();

        T FindById(Guid id);

        bool Save(Guid id, Guid UserId);

        bool Update(Guid id, Guid UserId);

        bool Delete(Guid id, Guid UserId);

        bool DeleteLog(Guid id);

    }
}
