using OrphanageFinalEntity.Controllers;
using OrphanageFinalEntity.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace OrphanageFinalEntity.Repository
{
    public interface IUserRepository
    {
        User Login(string email, string password);
        int Insert(User user);
        User GetByUserName(string username);
        User GetByUserEmail(string Email);
        User Activate(string code);
        int UpdateLastLogin(int id);
        List<User> GetAll();
    }
    public class UserRepository : DatabaseController, IUserRepository
    {
        public int Insert(Models.User user)
        {
            db.Users.Add(user);
            int result = db.SaveChanges();

            return result;
        }
        public User Login(string email, string password)
        {
            var users = db.Users.Where(u => u.Email == email && u.Password == password);
            if (users.Count() > 0)
            {
                return users.First();
            }
            return null;
        }
        public User Activate(string code)
        {
            User user = null;
            var users = db.Users.Where(u => u.AuthCode == code);
            if (users.Count() > 0)
            {
                user = users.First();
                user.Status = true;
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                db.SaveChanges();
            }
            return user;

        }

        public User GetByUserEmail(string email)
        {
            var users = db.Users.Where(u => u.Email == email);
            if (users.Count() > 0)
            {
                return users.First();
            }
            return null;
        }

        public User GetByUserName(string username  )
        {
            var users = db.Users.Where(u => u.UserName == username);
            if (users.Count() > 0)
            {
                return users.First();
            }
            return null;
        } 

          public int UpdateLastLogin(int id)
        {
            User user = db.Users.Find(id);
            if (user != null)
            {
               
                db.Entry(user).State = System.Data.Entity.EntityState.Modified;
                return db.SaveChanges();

            }
            return 0;

        }

        public List<User> GetAll()
        {

            return db.Users.ToList();
        }
    }
}