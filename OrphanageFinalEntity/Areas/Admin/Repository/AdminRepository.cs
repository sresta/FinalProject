using OrphanageFinalEntity.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrphanageFinalEntity.Areas.Admin.Repository
{
    public interface IAdminRepository
    {
        Models.Admin Login(string email, string password);
    }
    public class AdminRepository:DatabaseController

    {
        public Models.Admin Login(string email, string password)
        {
            var users = db.Admins.Where(u => u.Email == email && u.Password == password);
            if (users.Count() > 0)
            {
                return users.First();
            }
            return null;
        }
    }
}