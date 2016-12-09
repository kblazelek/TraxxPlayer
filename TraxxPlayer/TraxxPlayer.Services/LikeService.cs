using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using TraxxPlayer.Data;
using TraxxPlayer.Services.Helpers;
using TraxxPlayer.Data.Models;

namespace TraxxPlayer.Services
{
    public static class LikeService
    {
        public static IEnumerable<LikeToDisplay> GetLikes(int userID)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Likes.Where(l => l.UserID == userID).Select(x => new LikeToDisplay()
                {
                    id = x.id,
                    CreationDate = x.CreationDate,
                    TrackID = x.TrackID,
                    UserID = x.UserID
                }).ToList();
            }
        }

        public static LikeToDisplay GetLike(int likeID)
        {
            using (var db = new TraxxPlayerContext())
            {
                var like = db.Likes.Where(l => l.id == likeID).FirstOrDefault();
                if (like != null)
                {
                    return new LikeToDisplay()
                    {
                        id = like.id,
                        CreationDate = like.CreationDate,
                        TrackID = like.TrackID,
                        UserID = like.UserID
                    };
                }
                else
                {
                    throw new Exception("Like with the id provided does not exist. Get like failed.");
                }
            }
        }

        public static bool LikeExist(int likeID)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Likes.Any(l => l.id == likeID);
            }
        }

        public static void ModifyLike(LikeToDisplay like)
        {
            if (like != null)
            {
                using (var db = new TraxxPlayerContext())
                {
                    if (LikeExist(like.id))
                    {
                        var likeToModify = db.Likes.First(l => l.id == like.id);
                        likeToModify.TrackID = like.TrackID;
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Like with provided id doesn't exist. Modify like failed");
                    }
                }
            }
            else
            {
                throw new Exception("Like cannot be null. Modify like failed");
            }
        }

        public static void AddLike(LikeToAdd like)
        {
            using (var db = new TraxxPlayerContext())
            {
                if (like != null)
                {
                    db.Likes.Add(new Like() { TrackID = like.TrackID, UserID = like.UserID });
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Like to add cannot be null. Add like failed.");
                }
            }
        }

        public static void DeleteLike(int likeID)
        {
            using (var db = new TraxxPlayerContext())
            {
                var likeToDelete = db.Likes.Where(l => l.id == likeID).FirstOrDefault();
                if (likeToDelete != null)
                {
                    db.Likes.Remove(likeToDelete);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Like with the id specified does not exist. Delete like failed.");
                }
            }
        }
    }
}
