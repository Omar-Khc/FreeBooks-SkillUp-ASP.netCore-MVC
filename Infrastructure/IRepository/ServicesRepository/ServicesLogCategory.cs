using Domin.Entity;
using Infrastructuree.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuree.IRepository.ServicesRepository
{
    public class ServicesLogCategory : IServicesRepositoryLog<LogGategory>
    {
        private readonly BookDbContext _context;

        public ServicesLogCategory(BookDbContext context)
        {
            _context = context;
        }

        public bool DeleteLog(Guid id)
        {
            try
            {
                var logD = FindById(id);
                if (logD == null)
                    return false;

                {
                    _context.LogGategories.Remove(logD);
                    _context.SaveChanges();
                    return true;
                }
            }
            catch (Exception)
            {
                return false;
            }
            throw new NotImplementedException();
        }

        public LogGategory FindById(Guid id)
        {
            try
            {
                return _context.LogGategories.FirstOrDefault(x => x.Id == id);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<LogGategory> GetAll()
        {
            try
            {
                return _context.LogGategories.OrderBy(x => x.Date).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Delete(Guid id, Guid UserId)
        {
            try
            {
                var logCat = new LogGategory()
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Action = "Delete",
                    UserId = UserId,
                    CategoryId = id
                };
                _context.LogGategories.Add(logCat);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Save(Guid id, Guid UserId)
        {
            try
            {
                var logCat = new LogGategory()
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Action = "Save",
                    UserId = UserId,
                    CategoryId = id
                };
                _context.LogGategories.Add(logCat);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public bool Update(Guid id, Guid UserId)
        {
            try
            {
                var logCat = new LogGategory()
                {
                    Id = Guid.NewGuid(),
                    Date = DateTime.Now,
                    Action = "Update",
                    UserId = UserId,
                    CategoryId = id
                };
                _context.LogGategories.Add(logCat);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }
    }
}
