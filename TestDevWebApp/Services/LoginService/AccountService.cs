using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TestDevWebApp.Models;
using Microsoft.EntityFrameworkCore;

namespace TestDevWebApp.Services.LoginService
{
    public class AccountService : IAccountService
    {
        private UserWebAppContext _context;
        public AccountService(UserWebAppContext context)
        {
            _context = context;
        }
        public UserDto GetUser(User loginUser)
        {
            var user = _context.User.Where(u => u.Username == loginUser.Username && u.Password == loginUser.Password).Include(i => i.Role).ToList().FirstOrDefault();
            if (user != null)
                return new UserDto { Username = user.Username, RoleDescription = user.Role.RoleDescription };
            return null;
        }
    }
}
