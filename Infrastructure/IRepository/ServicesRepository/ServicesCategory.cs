using Domin.Entity;
using Infrastructuree.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructuree.IRepository.ServicesRepository
{
    public class ServicesCategory : IServicesRepository<Category>
    {
        private readonly Data.BookDbContext _context;

        public ServicesCategory(BookDbContext context)
        {
            _context = context;
        }

        public bool Delete(Guid id)
        {
            try
            {
                var model = FindById(id);

                model.CurrentState = (int)Helper.eCurrentState.Delete;
                _context.Categories.Update(model);
                _context.SaveChanges();
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        public Category FindById(Guid id)
        {
            try
            {
                return _context.Categories.FirstOrDefault(x => x.Id.Equals(id) && x.CurrentState > 0);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public Category FindByName(string name)
        {
            try
            {
                return _context.Categories.FirstOrDefault(x => x.Name.Equals(name.Trim()) && x.CurrentState > 0);
            }
            catch (Exception)
            {
                return null;
            }
        }

        public List<Category> GetAll()
        {
            try
            {
                return _context.Categories.OrderBy(x => x.Name).Where(x => x.CurrentState > 0).ToList();
            }
            catch (Exception)
            {
                return null;
            }
        }

        public bool Save(Category model)
        {
            try
            {
                var result = FindById(model.Id);
                if (result == null)
                {
                    model.Id = Guid.NewGuid();
                    model.CurrentState = (int)Helper.eCurrentState.Active;
                    _context.Categories.Add(model);
                }

                else
                {
                    result.Description = model.Description;
                    result.Name = model.Name;
                    result.CurrentState = (int)Helper.eCurrentState.Active;
                    _context.Categories.Update(result);
                }

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
