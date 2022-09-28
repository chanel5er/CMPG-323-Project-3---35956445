using DeviceManagement_WebApp.Data;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System;
using System.Linq;
using System.Threading.Tasks;
using Zone = DeviceManagement_WebApp.Models.Zone;

namespace DeviceManagement_WebApp.Repositories
{
    public class ZoneRepository<Z> : GenericRepository<Z>, IZoneRepository<Z> where Z : class
    {
        readonly IZoneRepository<Z> _zoneRepository;

        public ZoneRepository(ConnectedOfficeContext context) : base(context)
        {
            _zoneRepository = new ZoneRepository<Z>(context);
        }

        public Task Create([Bind(new[] { "ZoneId,ZoneName,ZoneDescription,DateCreated" })] Zone zone)
        {
            zone.ZoneId = Guid.NewGuid();
            _context.Add(zone);
            _context.SaveChangesAsync();

            return default(Task);
        }

        public Task Delete<Z>(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var zone = _context.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);
            
            if (zone == null)
            {
                return null;
            }

            return default(Task<Z>);
        }

        public Task DeleteConfirmed(Guid id)
        {
            var zone = _context.Zone.Find(id);
            _context.Zone.Remove(zone);
            _context.SaveChangesAsync();

            return default(Task);
        }

        public Task Details<Z>(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var zone = _context.Zone
                .FirstOrDefaultAsync(m => m.ZoneId == id);
            if (zone == null)
            {
                return null;
            }

            return default(Task<Z>);
        }

        public Task Edit<Z>(Guid? id)
        {
            if (id == null)
            {
                return null;
            }

            var zone = _context.Zone.FindAsync(id);
            if (zone == null)
            {
                return null;
            }

            return default(Task<Z>);
        }

        public Task Edit(Guid id, [Bind(new[] { "ZoneId,ZoneName,ZoneDescription,DateCreated" })] Zone zone)
        {
            try
            {
                _context.Update(zone);
                _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!ZoneExists(zone.ZoneId))
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

        public Task GetZone()
        {
            _context.Zone.ToListAsync();

            return default(Task);
        }

        public bool ZoneExists(Guid id)
        {
            return _context.Zone.Any(e => e.ZoneId == id);
        }
    }
}
