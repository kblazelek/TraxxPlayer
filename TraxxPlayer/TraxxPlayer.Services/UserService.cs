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
        /// <summary>
        /// Migrates database, used only during development
        /// </summary>
        public static void MigrateDatabase()
        {
            using (var db = new TraxxPlayerContext())
            {
                db.Database.Migrate();
            }
        }

        /// <summary>
        /// Gets users from database
        /// </summary>
        /// <returns></returns>
        public static IEnumerable<UserToDisplay> GetUsers()
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Users.Select(user => new UserToDisplay()
                {
                    id = user.id,
                    username = user.username,
                    isDefault = user.isDefault
                }).ToList();
            }
        }

        /// <summary>
        /// Checks wheter user exist in database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static bool UserExist(int id)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Users.Any(user => user.id == id);
            }
        }

        /// <summary>
        /// Checks wheter user exist in database
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static bool UserExist(string userName)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Users.Any(user => user.username == userName);
            }
        }

        /// <summary>
        /// Gets single user from database
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static UserToDisplay GetUser(int id)
        {
            using (var db = new TraxxPlayerContext())
            {
                var user = db.Users.Where(u => u.id == id).FirstOrDefault();
                if (user != null)
                {
                    return new UserToDisplay()
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

        /// <summary>
        /// Gets single user from database
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        public static UserToDisplay GetUser(string userName)
        {
            using (var db = new TraxxPlayerContext())
            {
                var user = db.Users.Where(u => u.username == userName).FirstOrDefault();
                if (user != null)
                {
                    return new UserToDisplay()
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

        /// <summary>
        /// Ads user to database
        /// </summary>
        /// <param name="user"></param>
        public static void AddUser(UserToAdd user)
        {
            if (user == null)
            {
                throw new Exception("User cannot be null. Add user failed");
            }
            if (UserExist(user.username))
            {
                throw new Exception("User with provided user name already exists. Add failed");
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
                    username = user.username,
                    isDefault = user.isDefault
                });
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes user from database
        /// </summary>
        /// <param name="id"></param>
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

        /// <summary>
        /// Modifies user in database
        /// </summary>
        /// <param name="user"></param>
        public static void ModifyUser(UserToDisplay user)
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

        /// <summary>
        /// Sets user as default user. Default user is automatically logged in during launch.
        /// </summary>
        /// <param name="id"></param>
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

        /// <summary>
        /// Removes current default flag in database
        /// </summary>
        /// <param name="id"></param>
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

        /// <summary>
        /// Gets current default user from database
        /// </summary>
        /// <returns></returns>
        public static UserToDisplay GetDefaultUser()
        {
            using (var db = new TraxxPlayerContext())
            {
                var defaultUser = db.Users.Where(u => u.isDefault == true).FirstOrDefault();
                if (defaultUser != null)
                {
                    return new UserToDisplay()
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
