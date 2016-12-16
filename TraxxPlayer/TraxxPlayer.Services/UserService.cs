using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraxxPlayer.Data;
using TraxxPlayer.Data.Models;
using TraxxPlayer.Services.Helpers;
using Microsoft.EntityFrameworkCore;

namespace TraxxPlayer.Services
{
    public static class UserService
    {

        public static void MigrateDatabase()
        {
            using (var db = new TraxxPlayerContext())
            {
                db.Database.Migrate();
            }
        }
        public static IEnumerable<UserToAddAndDisplay> GetUsers()
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Users.Select(user => new UserToAddAndDisplay()
                {
                    id = user.id,
                    username = user.username,
                    isDefault = user.isDefault
                }).ToList();
            }
        }

        public static bool UserExist(int id)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Users.Any(user => user.id == id);
            }
        }

        public static bool UserExist(string userName)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Users.Any(user => user.username == userName);
            }
        }

        public static UserToAddAndDisplay GetUser(int id)
        {
            using (var db = new TraxxPlayerContext())
            {
                var user = db.Users.Where(u => u.id == id).FirstOrDefault();
                if (user != null)
                {
                    return new UserToAddAndDisplay()
                    {
                        id = user.id,
                        username = user.username,
                        isDefault = user.isDefault
                    };
                }
                else
                {
                    throw new Exception("User with the id provided does not exist. Get user failed.");
                }
            }
        }

        public static UserToAddAndDisplay GetUser(string userName)
        {
            using (var db = new TraxxPlayerContext())
            {
                var user = db.Users.Where(u => u.username == userName).FirstOrDefault();
                if (user != null)
                {
                    return new UserToAddAndDisplay()
                    {
                        id = user.id,
                        username = user.username,
                        isDefault = user.isDefault
                    };
                }
                else
                {
                    throw new Exception("User with the user name provided does not exist. Get user failed.");
                }
            }
        }

        public static void AddUser(UserToAddAndDisplay user)
        {
            if (user == null)
            {
                throw new Exception("User cannot be null. Add user failed");
            }
            if (!UserExist(user.id))
            {
                throw new Exception("User with provided id already exists. Add failed");
            }
            using (var db = new TraxxPlayerContext())
            {
                if(user.isDefault)
                {
                    var currentDefaultUser = GetDefaultUser();
                    if(currentDefaultUser != null)
                    {
                        currentDefaultUser.isDefault = false;
                    }
                }
                db.Users.Add(new User()
                {
                    id = user.id,
                    username = user.username,
                    isDefault = user.isDefault
                });
                db.SaveChanges();
            }
        }

        public static void DeleteUser(int id)
        {
            using (var db = new TraxxPlayerContext())
            {
                var userToDelete = db.Users.FirstOrDefault(u => u.id == id);
                if (userToDelete == null)
                {
                    throw new Exception("There is no user with the id provided. Delete failed.");
                }
                else
                {
                    db.Users.Remove(userToDelete);
                    db.SaveChanges();
                }
            }
        }

        public static void ModifyUser(UserToAddAndDisplay user)
        {
            if (user != null)
            {
                using (var db = new TraxxPlayerContext())
                {
                    if (UserExist(user.id))
                    {
                        var userToModify = db.Users.First(u => u.id == user.id);
                        userToModify.username = user.username;
                        userToModify.isDefault = user.isDefault;
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("User with provided id doesn't exist. Add failed");
                    }
                }
            }
            else
            {
                throw new Exception("User cannot be null. Add failed");
            }
        }

        public static void SetDefaultUser(int id)
        {
            using (var db = new TraxxPlayerContext())
            {
                var nextDefaultUser = db.Users.Where(u => u.id == id).FirstOrDefault();
                if (nextDefaultUser != null)
                {
                    var previousDefaultUser = db.Users.Where(u => u.isDefault == true).FirstOrDefault();
                    if (previousDefaultUser != null)
                    {
                        previousDefaultUser.isDefault = false;
                    }
                    nextDefaultUser.isDefault = true;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("There is no user with the id provided. Setting default user failed.");
                }
            }
        }

        public static void RemoveDefaultUser(int id)
        {
            using (var db = new TraxxPlayerContext())
            {
                var defaultUser = db.Users.Where(u => u.id == id).FirstOrDefault();
                if (defaultUser != null)
                {
                    defaultUser.isDefault = false;
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("There is no user with the id provided. Removing default user failed.");
                }
            }
        }

        public static UserToAddAndDisplay GetDefaultUser()
        {
            using (var db = new TraxxPlayerContext())
            {
                var defaultUser = db.Users.Where(u => u.isDefault == true).FirstOrDefault();
                if (defaultUser != null)
                {
                    return new UserToAddAndDisplay()
                    {
                        id = defaultUser.id,
                        isDefault = defaultUser.isDefault,
                        username = defaultUser.username
                    };
                }
                else
                {
                    return null;
                }
            }
        }

    }
}
