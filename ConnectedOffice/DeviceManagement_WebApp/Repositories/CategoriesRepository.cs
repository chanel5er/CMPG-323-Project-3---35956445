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

        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            var category = await _context.Category.FindAsync(id);
            _context.Category.Remove(category);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

       public bool CategoryExists(Guid categoryID)
        {
            return _context.Category.Any(e => e == categoryID);
        }
    }
}
