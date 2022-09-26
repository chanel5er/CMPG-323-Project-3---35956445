using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace DeviceManagement_WebApp.Repositories
{
    public interface ICategoriesRepository : IGenericRepository<Category>
    {
        Category GetCategory();
        Task<IActionResult> Details(Guid? id);
        Task Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category);
        Task<IActionResult> Edit(Guid? id);
        Task Edit(Guid id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category);
        Task Delete<IActionResult>(Guid? id);
        Task DeleteConfirmed(Guid id);
        bool CategoryExists(Guid categoryID);
    }
}
