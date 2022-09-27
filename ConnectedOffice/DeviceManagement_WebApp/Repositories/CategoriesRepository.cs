using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repositories
{ 
    public class CategoriesRepository<C> : GenericRepository<C>, ICategoriesRepository<C> where C : class
    {
        readonly ICategoriesRepository<C> _categoriesRepository;

        public CategoriesRepository(ConnectedOfficeContext context) : base(context)
        {
            _categoriesRepository = new CategoriesRepository<C>(context);
        }

        public Task GetCategory()
        {
            _context.Category.OrderByDescending(category => category.DateCreated).FirstOrDefault();

            return default(Task);
        }

        public Task Details<C>(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var category = _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return null;
            }

            return default(Task);
        }

        public Task Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _context.Add(category);
            _context.SaveChangesAsync();

            return default(Task);
        }

        public Task Edit<C>(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var category = _context.Category.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            return default(Task);
        }

        public Task Edit(Guid id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            try 
            {
                _context.Update(category);
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) 
            {
                if (!CategoryExists(category.CategoryId)) 
                {
                    return null;
                }
                else 
                {
                    throw;
                }
            }

            return default(Task);
        }

        public Task Delete<C>(Guid? id)
        {
            if (id == null) 
            {
                return null;
            }

            var category = _context.Category.FirstOrDefaultAsync(m => m.CategoryId == id);

            if (category == null) 
            {
                return null;
            }
            return default(Task);
        }

        public Task DeleteConfirmed(Guid id)
        {
            var category = _context.Category.Find(id);
            _context.Category.Remove(category);
            _context.SaveChangesAsync();

            return default(Task);
        }

        public bool CategoryExists(Guid id)
        {
            return _context.Category.Any(c => c.CategoryId == id);
        }
    }
}
