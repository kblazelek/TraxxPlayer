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
    public static class PlaylistService
    {
        public static IEnumerable<PlaylistToDisplay> GetPlaylists(int userID)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Playlists.Where(p => p.UserID == userID).Select(x => new PlaylistToDisplay()
                {
                    id = x.id,
                    CreationDate = x.CreationDate,
                    Name = x.Name,
                    UserID = x.UserID
                }).ToList();
            }
        }

        public static PlaylistToDisplay GetPlaylist(int playlistID)
        {
            using (var db = new TraxxPlayerContext())
            {
                var playlist = db.Playlists.Where(p => p.id == playlistID).FirstOrDefault();
                if (playlist != null)
                {
                    return new PlaylistToDisplay()
                    {
                        id = playlist.id,
                        CreationDate = playlist.CreationDate,
                        Name = playlist.Name,
                        UserID = playlist.UserID
                    };
                }
                else
                {
                    throw new Exception("Playlist with the id provided does not exist. Get playlist failed.");
                }
            }
        }

        public static bool PlaylistExist(int playlistID)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.Playlists.Any(p => p.id == playlistID);
            }
        }

        public static void ModifyPlaylist(PlaylistToDisplay playlist)
        {
            if (playlist != null)
            {
                using (var db = new TraxxPlayerContext())
                {
                    if (PlaylistExist(playlist.id))
                    {
                        var playlistToModify = db.Playlists.First(p => p.id == playlist.id);
                        playlistToModify.Name = playlist.Name;
                        db.SaveChanges();
                    }
                    else
                    {
                        throw new Exception("Playlist with provided id doesn't exist. Modify failed");
                    }
                }
            }
            else
            {
                throw new Exception("Playlist cannot be null. Modify failed");
            }
        }

        public static void AddPlaylist(PlaylistToAdd playlist)
        {
            using (var db = new TraxxPlayerContext())
            {
                if (playlist != null)
                {
                    db.Playlists.Add(new Playlist() { Name = playlist.Name, UserID = playlist.UserID });
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Playlist to add cannot be null. Add playlist failed.");
                }
            }
        }

        public static void DeletePlaylist(int playlistID)
        {
            using (var db = new TraxxPlayerContext())
            {
                var playlistToDelete = db.Playlists.Where(p => p.id == playlistID).FirstOrDefault();
                if (playlistToDelete != null)
                {
                    db.Playlists.Remove(playlistToDelete);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Playlist with the id specified does not exist. Delete playlist failed.");
                }
            }
        }
    }
}
