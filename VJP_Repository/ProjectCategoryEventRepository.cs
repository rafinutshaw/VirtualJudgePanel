using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VJP_Entity;
using VJP_Interface;

namespace VJP_Repository
{
    public class ProjectCategoryEventRepository : Repository<ProjectCategoryEvent>, IProjectCategoryEventRepository
    {
        VJPDBContext context = new VJPDBContext();
        public void DeleteAllByEvent(List<ProjectCategoryEventRepository> pce)
        {

        }
    }
}
