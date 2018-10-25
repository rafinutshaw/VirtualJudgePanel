using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using VJP_Entity;
using VJP_Interface;

namespace VJP_Repository
{
    public class UserRepository : Repository<User>, IUserRepository
    {
        VJPDBContext context = new VJPDBContext();

        public User GetByEmailAndPass(User u)
        {
            return this.context.Users.SingleOrDefault(x => x.Email == u.Email && x.Password == u.Password);
        }

        //public User GetByEmail(string email)
        //{
        //    return this.context.Users.SingleOrDefault(x => x.Email == email);
        //}

        public bool DuplicateEmail(string email)
        {
            var check = this.context.Users.SingleOrDefault(x => x.Email == email);

            return check != null ? true : false;
        }
    }
}
