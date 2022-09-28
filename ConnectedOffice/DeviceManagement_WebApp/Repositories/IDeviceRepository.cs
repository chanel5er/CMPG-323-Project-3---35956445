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
    public interface IDeviceRepository<D> : IGenericRepository<D> where D : class
    {
        Task GetDevice();
        Task Details<D>(Guid? id);
        Task Create();
        Task Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device);
        Task Edit<D>(Guid? id);
        Task Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device);
        Task Delete<D>(Guid? id);
        Task DeleteConfirmed(Guid id);
        bool DeviceExists(Guid id);
    }
}
