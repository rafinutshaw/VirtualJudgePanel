﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VJP_Entity;
using VJP_Interface;

namespace VJP_Repository
{
    public class EventSubscribeRepository : Repository<EventSubscribe>, IEventSubscribeRepository
    {
        VJPDBContext context = new VJPDBContext();

        
    }
}
