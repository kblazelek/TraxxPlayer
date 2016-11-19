using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TraxxPlayer.Services.Helpers;
using Microsoft.EntityFrameworkCore;
using TraxxPlayer.Data;
using TraxxPlayer.Data.Models;

namespace TraxxPlayer.Services
{
    public static class PlaylistTrackService
    {
        public static IEnumerable<PlaylistTrackToDisplay> GetPlaylistTracks(int playlistID)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.PlaylistTracks.Where(pt => pt.PlaylistID == playlistID).Select(x => new PlaylistTrackToDisplay()
                {
                    PlaylistID = x.PlaylistID,
                    TrackID = x.TrackID,
                    TrackOrder = x.TrackOrder,
                    id = x.id 
                }).ToList();
            }
        }

        public static PlaylistTrackToDisplay GetPlaylistTrack(int playlistTrackID)
        {
            using (var db = new TraxxPlayerContext())
            {
                var playlistTrack = db.PlaylistTracks.Where(pt => pt.id == playlistTrackID).FirstOrDefault();
                if (playlistTrack != null)
                {
                    return new PlaylistTrackToDisplay()
                    {
                        PlaylistID = playlistTrack.PlaylistID,
                        TrackID = playlistTrack.TrackID,
                        TrackOrder = playlistTrack.TrackOrder,
                        id = playlistTrack.id
                    };
                }
                else
                {
                    throw new Exception("Playlist track with the id provided does not exist. Get playlist track failed.");
                }
            }
        }

        public static bool PlaylistTrackExist(int playlistTrackID)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.PlaylistTracks.Any(pt => pt.id == playlistTrackID);
            }
        }

        public static void AddPlaylistTrack(PlaylistTrackToAdd playlistTrack)
        {
            using (var db = new TraxxPlayerContext())
            {
                if (playlistTrack != null)
                {
                    if(GetPlaylistTracks(playlistTrack.PlaylistID).Where(pt => pt.TrackID == playlistTrack.TrackID).FirstOrDefault() != null)
                    {
                        throw new Exception("Playlist track with the TrackID and PlaylistID provided already exists. Add playlist track failed.");
                    }
                    int trackOrder = 0;
                    var trackWithHighestTrackOrder = GetPlaylistTracks(playlistTrack.PlaylistID).OrderByDescending(pt => pt.TrackOrder).FirstOrDefault();
                    if(trackWithHighestTrackOrder != null)
                    {
                        trackOrder = trackWithHighestTrackOrder.TrackOrder + 1;
                    }
                    db.PlaylistTracks.Add(new PlaylistTrack() { PlaylistID = playlistTrack.PlaylistID, TrackID = playlistTrack.TrackID, TrackOrder = trackOrder });
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Playlist track to add cannot be null. Add playlist track failed.");
                }
            }
        }

        public static void DeletePlaylistTrack(int playlistTrackID)
        {
            using (var db = new TraxxPlayerContext())
            {
                var playlistTrackToDelete = db.PlaylistTracks.Where(pt => pt.id == playlistTrackID).FirstOrDefault();
                if (playlistTrackToDelete != null)
                {
                    db.PlaylistTracks.Remove(playlistTrackToDelete);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("Playlist track with the id specified does not exist. Delete playlist track failed.");
                }
            }
        }
    }
}
