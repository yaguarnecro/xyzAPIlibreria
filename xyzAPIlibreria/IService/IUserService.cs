using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace xyzAPIlibreria.IService
{
    public interface IUserService
    {
        bool CheckUser(string username, string password);
    }
}
