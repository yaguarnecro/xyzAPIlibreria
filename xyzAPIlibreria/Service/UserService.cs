using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using xyzAPIlibreria.IService;

namespace xyzAPIlibreria.Service
{
    public class UserService: IUserService
    {
        public bool CheckUser(string username, string password)
        {
            return username.Equals("ThumbIKR") && password.Equals("123");
        }
    }
}
