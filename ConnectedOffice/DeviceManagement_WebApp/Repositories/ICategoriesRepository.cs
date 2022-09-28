using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;

namespace DeviceManagement_WebApp.Repositories
{
    public interface ICategoriesRepository<C> : IGenericRepository<C> where C : class
    {
        Task GetCategory();
        Task Details<C>(Guid? id);
        Task Create([Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category);
        Task Edit<C>(Guid? id);
        Task Edit(Guid id, [Bind("CategoryId,CategoryName,CategoryDescription,DateCreated")] Category category);
        Task Delete<C>(Guid? id);
        Task DeleteConfirmed(Guid id);
        bool CategoryExists(Guid id);
    }
}
