using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Controllers;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace DeviceManagement_WebApp.Repositories
{
    public class DeviceRepository<D> : GenericRepository<D>, IDeviceRepository<D> where D : class
    {
        readonly IDeviceRepository<D> _deviceRepository;

        public DeviceRepository(ConnectedOfficeContext context) : base(context)
        {
            _deviceRepository = new DeviceRepository<D>(context);
        }

        public Task GetDevice()
        {
            var connectedOfficeContext = _context.Device.Include(d => d.Category).Include(d => d.Zone);

            return default(Task);
        }

        public Task Details<C>(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var device = _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);
            if (device == null)
            {
                return null;
            }

            return default(Task);
        }

        public Task Create()
        {
            var catId = new SelectList(_context.Category, "CategoryId", "CategoryName");
            var zoneId = new SelectList(_context.Zone, "ZoneId", "ZoneName");

            return default(Task);
        }

        public Task Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            device.DeviceId = Guid.NewGuid();
            _context.Add(device);
            _context.SaveChangesAsync();

            return default(Task);
        }

        public Task Edit<C>(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var device = _context.Device.FindAsync(id);
            if (device == null)
            {
                return null;
            }
            
            return default(Task);
        }

        public Task Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            if (id != device.DeviceId)
            {
                return null;
            }
            try
            {
                _context.Update(device);
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!DeviceExists(device.DeviceId))
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

            var device = _context.Device
                .Include(d => d.Category)
                .Include(d => d.Zone)
                .FirstOrDefaultAsync(m => m.DeviceId == id);

            if (device == null) 
            {
                return null;
            }
            return default(Task);
        }

        public Task DeleteConfirmed(Guid id)
        {
            var device = _context.Device.Find(id);
            _context.Device.Remove(device);
            _context.SaveChangesAsync();

            return default(Task);
        }

        public bool DeviceExists(Guid id)
        {
            return _context.Device.Any(e => e.DeviceId == id);
        }
    }
}
