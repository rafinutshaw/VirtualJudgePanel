using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VJP_Entity;

namespace VJP_Interface
{
    public interface IUserRepository : IRepository<User>
    {
        User GetByEmailAndPass(User u);

        //User GetByEmail(string email);

        bool DuplicateEmail(string email);
    }
}
