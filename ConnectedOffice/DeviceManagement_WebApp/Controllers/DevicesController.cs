using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using DeviceManagement_WebApp.Data;
using DeviceManagement_WebApp.Models;
using DeviceManagement_WebApp.Repositories;

namespace DeviceManagement_WebApp.Controllers
{
    public class DevicesController : Controller
    {
        private readonly IDeviceRepository<Device> _deviceRepository;

        public DevicesController(IDeviceRepository<Device> deviceRepository)
        {
            _deviceRepository = deviceRepository;
        }

        // GET: Devices
        public async Task<IActionResult> Index()
        {
            await _deviceRepository.GetDevice();
            return View();
        }

        // GET: Devices/Details/5
        public async Task<IActionResult> Details(Guid? id)
        {
            var device = _deviceRepository.Details<Device>(id);
            if (device == null)
            {
                return NotFound();
            }

            return View(device);
        }

        // GET: Devices/Create
        public IActionResult Create()
        {
            _deviceRepository.Create();

            return View();
        }

        // POST: Devices/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            await _deviceRepository.Create(device);

            return RedirectToAction(nameof(Index));


        }

        // GET: Devices/Edit/5
        public async Task<IActionResult> Edit(Guid? id)
        {
            var device = _deviceRepository.Edit<Device>(id);
            if (device == null)
            {
                return NotFound();
            }

            ViewData["CategoryId"] = new SelectList(_context.Category, "CategoryId", "CategoryName", device.CategoryI);
            ViewData["ZoneId"] = new SelectList(_context.Zone, "ZoneId", "ZoneName", device.ZoneId);

            return View(device);
        }

        // POST: Devices/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(Guid id, [Bind("DeviceId,DeviceName,CategoryId,ZoneId,Status,IsActive,DateCreated")] Device device)
        {
            var editDevice = _deviceRepository.Edit(id, device);

            if (editDevice == null)
            {
                return NotFound();
            }

            return RedirectToAction(nameof(Index));

        }

        // GET: Devices/Delete/5
        public async Task<IActionResult> Delete(Guid? id)
        {
            var device = _deviceRepository.Delete<Device>(id);

            if (device == null) 
            {
                return NotFound();
            }

            return View(device);
        }

        // POST: Devices/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _deviceRepository.DeleteConfirmed(id);
            return RedirectToAction(nameof(Index));
        }

        private bool DeviceExists(Guid id)
        {
            return _deviceRepository.DeviceExists(id);
        }
    }
}
