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
                    avatar_url = user.avatar_url,
                    city = user.city,
                    country = user.country,
                    description = user.description,
                    discogs_name = user.discogs_name,
                    first_name = user.first_name,
                    followers_count = user.followers_count,
                    followings_count = user.followings_count,
                    full_name = user.full_name,
                    kind = user.kind,
                    last_modified = user.last_modified,
                    last_name = user.last_name,
                    myspace_name = user.myspace_name,
                    online = user.online,
                    permalink = user.permalink,
                    permalink_url = user.permalink_url,
                    plan = user.plan,
                    playlist_count = user.playlist_count,
                    public_favorites_count = user.public_favorites_count,
                    track_count = user.track_count,
                    uri = user.uri,
                    username = user.username,
                    website = user.website,
                    website_title = user.website_title
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
                        avatar_url = user.avatar_url,
                        city = user.city,
                        country = user.country,
                        description = user.description,
                        discogs_name = user.discogs_name,
                        first_name = user.first_name,
                        followers_count = user.followers_count,
                        followings_count = user.followings_count,
                        full_name = user.full_name,
                        kind = user.kind,
                        last_modified = user.last_modified,
                        last_name = user.last_name,
                        myspace_name = user.myspace_name,
                        online = user.online,
                        permalink = user.permalink,
                        permalink_url = user.permalink_url,
                        plan = user.plan,
                        playlist_count = user.playlist_count,
                        public_favorites_count = user.public_favorites_count,
                        track_count = user.track_count,
                        uri = user.uri,
                        username = user.username,
                        website = user.website,
                        website_title = user.website_title
                    };
                }
                else
                {
                    throw new Exception("User with the id provided does not exist. Get user failed.");
                }
            }
        }

        public static void AddUser(UserToAddAndDisplay user)
        {
            if (user != null)
            {
                using (var db = new TraxxPlayerContext())
                {
                    if (!UserExist(user.id))
                    {
                        db.Users.Add(new User()
                        {
                            id = user.id,
                            avatar_url = user.avatar_url,
                            city = user.city,
                            country = user.country,
                            description = user.description,
                            discogs_name = user.discogs_name,
                            first_name = user.first_name,
                            followers_count = user.followers_count,
                            followings_count = user.followings_count,
                            full_name = user.full_name,
                            kind = user.kind,
                            last_modified = user.last_modified,
                            last_name = user.last_name,
                            myspace_name = user.myspace_name,
                            online = user.online,
                            permalink = user.permalink,
                            permalink_url = user.permalink_url,
                            plan = user.plan,
                            playlist_count = user.playlist_count,
                            public_favorites_count = user.public_favorites_count,
                            track_count = user.track_count,
                            uri = user.uri,
                            username = user.username,
                            website = user.website,
                            website_title = user.website_title
                        });
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("User with provided id already exists. Add failed");
                    }
                }
            }
            else
            {
                throw new Exception("User cannot be null. Add failed");
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
                        userToModify.id = user.id;
                        userToModify.avatar_url = user.avatar_url;
                        userToModify.city = user.city;
                        userToModify.country = user.country;
                        userToModify.description = user.description;
                        userToModify.discogs_name = user.discogs_name;
                        userToModify.first_name = user.first_name;
                        userToModify.followers_count = user.followers_count;
                        userToModify.followings_count = user.followings_count;
                        userToModify.full_name = user.full_name;
                        userToModify.kind = user.kind;
                        userToModify.last_modified = user.last_modified;
                        userToModify.last_name = user.last_name;
                        userToModify.myspace_name = user.myspace_name;
                        userToModify.online = user.online;
                        userToModify.permalink = user.permalink;
                        userToModify.permalink_url = user.permalink_url;
                        userToModify.plan = user.plan;
                        userToModify.playlist_count = user.playlist_count;
                        userToModify.public_favorites_count = user.public_favorites_count;
                        userToModify.track_count = user.track_count;
                        userToModify.uri = user.uri;
                        userToModify.username = user.username;
                        userToModify.website = user.website;
                        userToModify.website_title = user.website_title;
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
                        avatar_url = defaultUser.avatar_url,
                        city = defaultUser.city,
                        country = defaultUser.country,
                        description = defaultUser.description,
                        discogs_name = defaultUser.discogs_name,
                        first_name = defaultUser.first_name,
                        followers_count = defaultUser.followers_count,
                        followings_count = defaultUser.followings_count,
                        full_name = defaultUser.full_name,
                        kind = defaultUser.kind,
                        last_modified = defaultUser.last_modified,
                        last_name = defaultUser.last_name,
                        myspace_name = defaultUser.myspace_name,
                        online = defaultUser.online,
                        permalink = defaultUser.permalink,
                        permalink_url = defaultUser.permalink_url,
                        plan = defaultUser.plan,
                        playlist_count = defaultUser.playlist_count,
                        public_favorites_count = defaultUser.public_favorites_count,
                        track_count = defaultUser.track_count,
                        uri = defaultUser.uri,
                        username = defaultUser.username,
                        website = defaultUser.website,
                        website_title = defaultUser.website_title
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
