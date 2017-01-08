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
        /// <summary>
        /// Gets playlist tracks from database
        /// </summary>
        /// <param name="playlistID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets single playlist track from database
        /// </summary>
        /// <param name="playlistTrackID"></param>
        /// <returns></returns>
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

        /// <summary>
        /// Gets single playlist track from database
        /// </summary>
        /// <param name="playlistID"></param>
        /// <param name="trackID"></param>
        /// <returns></returns>
        public static PlaylistTrackToDisplay GetPlaylistTrack(int playlistID, int trackID)
        {
            using (var db = new TraxxPlayerContext())
            {
                var playlistTrack = db.PlaylistTracks.Where(pt => pt.PlaylistID == playlistID && pt.TrackID == trackID).FirstOrDefault();
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
                    throw new Exception($"Playlist track with the track id {trackID} and playlist id {playlistID} does not exist. Get playlist track failed.");
                }
            }
        }

        /// <summary>
        /// Checks wheter playlist track exist
        /// </summary>
        /// <param name="playlistTrackID"></param>
        /// <returns></returns>
        public static bool PlaylistTrackExist(int playlistTrackID)
        {
            using (var db = new TraxxPlayerContext())
            {
                return db.PlaylistTracks.Any(pt => pt.id == playlistTrackID);
            }
        }

        /// <summary>
        /// Adds playlist track to database
        /// </summary>
        /// <param name="playlistTrack"></param>
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

        /// <summary>
        /// Deletes playlist track from database
        /// </summary>
        /// <param name="playlistTrackID"></param>
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

        /// <summary>
        /// Modifies playlist track in database
        /// </summary>
        /// <param name="playlistTrack"></param>
        public static void ModifyPlaylistTrack(PlaylistTrackToDisplay playlistTrack)
        {
            using (var db = new TraxxPlayerContext())
            {
                if(!PlaylistTrackExist(playlistTrack.id))
                {
                    throw new Exception("Playlist track with the id specified does not exist. Modify playlist track failed.");
                }
                var playlistTrackToModify = db.PlaylistTracks.Where(pt => pt.id == playlistTrack.id).FirstOrDefault();
                playlistTrackToModify.id = playlistTrack.id;
                playlistTrackToModify.PlaylistID = playlistTrack.PlaylistID;
                playlistTrackToModify.TrackID = playlistTrack.TrackID;
                playlistTrackToModify.TrackOrder = playlistTrack.TrackOrder;
                db.SaveChanges();
            }
        }

        /// <summary>
        /// Deletes playlist track from database
        /// </summary>
        /// <param name="playlistID"></param>
        /// <param name="trackID"></param>
        public static void DeletePlaylistTrack(int playlistID, int trackID)
        {
            using (var db = new TraxxPlayerContext())
            {
                if(!PlaylistService.PlaylistExist(playlistID))
                {
                    throw new Exception($"Could not find playlist with ID {playlistID}. Delete playlist track failed.");
                }
                var playlistTrack = db.PlaylistTracks.Where(pt => pt.PlaylistID == playlistID && pt.TrackID == trackID).FirstOrDefault();
                if(playlistTrack != null)
                {
                    db.PlaylistTracks.Remove(playlistTrack);
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception($"Playlist with ID {playlistID} does not contain track with ID {trackID}. Delete playlist track failed.");
                }
            }
        }
    }
}
