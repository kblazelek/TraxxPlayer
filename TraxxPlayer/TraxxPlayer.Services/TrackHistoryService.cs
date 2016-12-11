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
    public static class TrackHistoryService
    {
        public static IEnumerable<TrackHistoryToDisplay> GetTracksHistory(int userID)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.TracksHistory.Where(th => th.UserID == userID).Select(x => new TrackHistoryToDisplay()
                {
                    id = x.id,
                    CreationDate = x.CreationDate,
                    TrackID = x.TrackID,
                    UserID = x.UserID
                }).ToList();
            }
        }

        public static IEnumerable<TrackHistoryToDisplay> GetTracksHistory(int userID, int recordLimit)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.TracksHistory.Where(th => th.UserID == userID).OrderByDescending(t => t.CreationDate).Take(recordLimit).Select(x => new TrackHistoryToDisplay()
                {
                    id = x.id,
                    CreationDate = x.CreationDate,
                    TrackID = x.TrackID,
                    UserID = x.UserID
                }).ToList();
            }
        }

        public static TrackHistoryToDisplay GetTrackHistory(int trackHistoryID)
        {
            using (var db = new TraxxPlayerContext())
            {
                var trackhistory = db.TracksHistory.Where(th => th.id == trackHistoryID).FirstOrDefault();
                if (trackhistory != null)
                {
                    return new TrackHistoryToDisplay()
                    {
                        id = trackhistory.id,
                        CreationDate = trackhistory.CreationDate,
                        TrackID = trackhistory.TrackID,
                        UserID = trackhistory.UserID
                    };
                }
                else
                {
                    throw new Exception("Track history with the id provided does not exist. Get track history failed.");
                }
            }
        }

        public static bool TrackHistoryExist(int trackHistoryID)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.TracksHistory.Any(th => th.id == trackHistoryID);
            }
        }

        public static void Modifytrackhistory(TrackHistoryToDisplay trackHistory)
        {
            if (trackHistory != null)
            {
                using (var db = new TraxxPlayerContext())
                {
                    if (TrackHistoryExist(trackHistory.id))
                    {
                        var trackhistoryToModify = db.TracksHistory.First(th => th.id == trackHistory.id);
                        trackhistoryToModify.TrackID = trackHistory.TrackID;
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Track history with provided id doesn't exist. Modify track history failed");
                    }
                }
            }
            else
            {
                throw new Exception("Track history cannot be null. Modify track history failed");
            }
        }

        public static void AddTrackHistory(TrackHistoryToAdd trackhistory)
        {
            using (var db = new TraxxPlayerContext())
            {
                if (trackhistory != null)
                {
                    db.TracksHistory.Add(new TrackHistory() { TrackID = trackhistory.TrackID, UserID = trackhistory.UserID });
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Track history to add cannot be null. Add track history failed.");
                }
            }
        }

        public static void DeleteTrackHistory(int trackHistoryID)
        {
            using (var db = new TraxxPlayerContext())
            {
                var trackHistoryToDelete = db.TracksHistory.Where(th => th.id == trackHistoryID).FirstOrDefault();
                if (trackHistoryToDelete != null)
                {
                    db.TracksHistory.Remove(trackHistoryToDelete);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Track history with the id specified does not exist. Delete track history failed.");
                }
            }
        }
    }
}
