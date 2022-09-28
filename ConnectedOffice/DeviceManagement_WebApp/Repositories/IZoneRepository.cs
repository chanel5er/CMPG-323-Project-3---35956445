using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using System;
using System.Runtime.InteropServices;

namespace DeviceManagement_WebApp.Repositories
{
    public interface IZoneRepository<Z> : IGenericRepository<Z> where Z : class
    {
        Task GetZone();
        Task Details<Z>(Guid? id);
        Task Create([Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone);
        Task Edit<Z>(Guid? id);
        Task Edit(Guid id, [Bind("ZoneId,ZoneName,ZoneDescription,DateCreated")] Zone zone);
        Task Delete<Z>(Guid? id);
        Task DeleteConfirmed(Guid id);
        bool ZoneExists(Guid id);
    }
}
