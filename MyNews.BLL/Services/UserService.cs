using MyNews.BLL.Interfaces;
using MyNews.DAL.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyNews.BLL.Services
{
    public class UserService : IUserService
    {
        private readonly MyNewsDataContext appDbContext;

        public UserService(MyNewsDataContext appDbContext)
        {
            this.appDbContext = appDbContext;
        }

        public void InitAdmin()
        {
            if (!appDbContext.Users.Any(u => u.Username == "admin"))
            {
                appDbContext.Users.Add(new DAL.Entities.User
                {
                    Username = "admin",
                    Password = "123",
                    Email = "admin@mynews.com"
                });

                appDbContext.SaveChanges();
            }
        }
    }
}