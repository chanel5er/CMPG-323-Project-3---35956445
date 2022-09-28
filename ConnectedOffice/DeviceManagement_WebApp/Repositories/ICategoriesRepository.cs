using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace DeviceManagement_WebApp.Repositories
{
    public interface ICategoriesRepository : IGenericRepository<Category>
    {
        Category GetCategory();
        Task<IActionResult> DeleteConfirmed(Guid id);
        bool CategoryExists(Category categoryID);
    }
}
