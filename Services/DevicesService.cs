
using Microsoft.EntityFrameworkCore;

namespace GameZone.Services
{
    public class DevicesService : IDevicesService
    {
        public DevicesService(AppDbContext context)
        {
            _context = context;
        }
        private readonly AppDbContext _context;
        public IEnumerable<SelectListItem> GetDevices()
        {
            return _context.devices.Select(d => new SelectListItem { Value = d.Id.ToString(), Text = d.Name })
              .OrderBy(d => d.Text).AsNoTracking().ToList();
        }
    }
}
