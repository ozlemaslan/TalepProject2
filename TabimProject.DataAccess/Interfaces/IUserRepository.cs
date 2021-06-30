
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TabimProject.Model;

namespace TabimProject.DataAccess.Interfaces
{
    public interface IUserRepository
    {
        User Add(User user);
        User Delete(User user);
        User Update(User user);
        User GetUserId(int id);
        List<User> GetAllUser();
    }
}
