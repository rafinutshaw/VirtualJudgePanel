using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VJP_Entity;
using VJP_Interface;

namespace VJP_Repository
{
    public class EventRepository : Repository<Event>, IEventRepository
    {
        VJPDBContext context = new VJPDBContext();

        public List<Event> GetRunningEvents()
        {
            return context.Events.ToList().FindAll(ev => ev.ClosingDate >= DateTime.Now);
        }
    }
}
