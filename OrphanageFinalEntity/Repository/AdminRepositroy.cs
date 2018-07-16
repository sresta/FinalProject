using OrphanageFinalEntity.Controllers;
using OrphanageFinalEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrphanageFinalEntity.Repository
{
    public interface IAdminRepository
    {
        Admin Login(string email, string password);

    }

    public class AdminRepositroy:DatabaseController , IAdminRepository
    {
        public Admin Login(string email, string password)
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