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
    public class CategoriesRepository : GenericRepository<Category>, ICategoriesRepository
    {
        public CategoriesRepository(ConnectedOfficeContext context) : base(context)
        {

        }

        public Service GetCatagory()
        {
            return _context.Category.OrderByDescending(category => category.DateCreated).FirstOrDefault();
        }

        public async Task<IActionResult> Details(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);
            if (category == null)
            {
                return null;
            }

            return (IActionResult)category;
        }

        public async Task Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            category.CategoryId = Guid.NewGuid();
            _context.Add(category);
            await _context.SaveChangesAsync();
        }

        public async Task<IActionResult> Edit(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var category = await _context.Category.FindAsync(id);
            if (category == null)
            {
                return null;
            }
            return (IActionResult)category;
        }

        public async Task Edit(Guid id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category)
        {
            try {
                _context.Update(category);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException) {
                if (!CategoryExists(category.CategoryId)) {
                    category = null;
                }
                else {
                    throw;
                }
            }
        }

        public async Task<IActionResult> Delete(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var category = await _context.Category
                .FirstOrDefaultAsync(m => m.CategoryId == id);

            if (category == null)
            {
                return null;
            }
            return (IActionResult)category;
        }

        public async Task DeleteConfirmed(Guid id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
        }

       public bool CategoryExists(Guid categoryID)
        {
            return _context.Category.Find(categoryID) != null;
        }

        
    }
}
