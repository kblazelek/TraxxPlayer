using TraxxPlayer.Common.Enums_and_constants;
using HtmlAgilityPack;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Net;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using TraxxPlayer.Common.Models;

namespace TraxxPlayer.Common.Helpers
{
    public static class SoundCloudHelper
    {
        /// <summary>
        /// Gets dictionary of available genres on SoundCloud
        /// </summary>
        /// <returns>Dictionary of genres</returns>
        public async static Task<Dictionary<string, string>> GetGenres()
        {
            Dictionary<string, string> Genres = new Dictionary<string, string>();
            var webRequest = WebRequest.CreateHttp("https://soundcloud.com/charts/");
            webRequest.Headers["User-Agent"] =
    "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
    "(compatible; MSIE 6.0; Windows NT 5.1; " +
    ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            string html = "";
            var response = await webRequest.GetResponseAsync();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                html = reader.ReadToEnd();
            }
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            HtmlNode articleNode = document.DocumentNode.Descendants("article").Where(x => x.InnerHtml.Contains("Choose a genre")).FirstOrDefault();
            var list = articleNode.Descendants("ul").FirstOrDefault();
            var listItems = list.Descendants().Where(x => x.Name == "li");
            foreach (var l in listItems)
            {
                var a = l.Descendants("a").FirstOrDefault();
                var href = a.GetAttributeValue("href", "empty");
                if (href != "empty")
                {
                    var decodedHref = WebUtility.HtmlDecode(href);
                    Regex regex = new Regex(@"genre=(?<genre>.+)");
                    Match match = regex.Match(decodedHref);
                    if (match.Success)
                    {
                        var key = match.Groups["genre"].Value;
                        var value = WebUtility.HtmlDecode(a.InnerText);
                        Genres.Add(key, value);
                    }
                }
            }
            return Genres;
        }
        /// <summary>
        /// Gets dictionary of available kinds on SoundCloud
        /// </summary>
        /// <returns>Dictionary of kinds</returns>
        public async static Task<Dictionary<string, string>> GetKinds()
        {
            Dictionary<string, string> Kinds = new Dictionary<string, string>();
            var webRequest = WebRequest.CreateHttp("https://soundcloud.com/charts/");
            webRequest.Headers["User-Agent"] =
    "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) " +
    "(compatible; MSIE 6.0; Windows NT 5.1; " +
    ".NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            string html = "";
            var response = await webRequest.GetResponseAsync();
            using (var reader = new StreamReader(response.GetResponseStream()))
            {
                html = reader.ReadToEnd();
            }
            HtmlDocument document = new HtmlDocument();
            document.LoadHtml(html);
            HtmlNode articleNode = document.DocumentNode.Descendants("article").Where(x => x.InnerHtml.Contains("Top 50 or Trending")).FirstOrDefault();
            var list = articleNode.Descendants("ul").FirstOrDefault();
            var listItems = list.Descendants().Where(x => x.Name == "li");
            foreach (var l in listItems)
            {
                var a = l.Descendants("a").FirstOrDefault();
                var href = a.GetAttributeValue("href", "empty");
                if (href != "empty")
                {
                    var decodedHref = WebUtility.HtmlDecode(href);
                    Regex regex = new Regex(@"charts/(?<kind>.+)\?");
                    Match match = regex.Match(decodedHref);
                    if (match.Success)
                    {
                        var key = match.Groups["kind"].Value;
                        var value = WebUtility.HtmlDecode(a.InnerText);
                        Kinds.Add(key, value);
                    }
                }
            }
            return Kinds;
        }

        /// <summary>
        /// Returns soundcloud tracks that match query specified by "query" parameter
        /// </summary>
        /// <param name="query">Query that returned tracks should match</param>
        /// <param name="maxResults">Maximum number of tracks returned</param>
        /// <returns>List of SoundCloud tracks</returns>
        public async static Task<List<SoundCloudTrack>> SearchTracks(string query, int maxResults)
        {
            List<SoundCloudTrack> searchedTracks = new List<SoundCloudTrack>();
            //http://api.soundcloud.com/tracks.json?client_id=9c79c1a0aeb2fc8972d215e07934a8bf&q=odesza&limit=50
            string responseText = await JsonHelper.GetjsonStream(SoundCloudConstants.SoundCloudAPILink + "tracks.json?" + "client_id=" + SoundCloudConstants.SoundCloudClientId + "&q=" + query + "&limit=" + maxResults.ToString());
            searchedTracks = JsonConvert.DeserializeObject<List<SoundCloudTrack>>(responseText);
            //remove songs which do not have stream url
            searchedTracks = searchedTracks.Where(t => t.stream_url != null).ToList();
            //add "?client_id=" + App.SoundCloudClientId to stream url
            Task<List<SoundCloudTrack>> task = Task.Run(() =>
            {
                return searchedTracks.Select(t => { t.stream_url += "?client_id=" + SoundCloudConstants.SoundCloudClientId; return t; }).ToList();
            });
            return task.Result;
        }

        /// <summary>
        /// Gets SoundCloud tracks based on kind and genre specified
        /// </summary>
        /// <param name="kind">Music kind</param>
        /// <param name="genre">Music genre</param>
        /// <returns>List of SoundCloud tracks that match kind and genre specified</returns>
        public async static Task<List<SoundCloudTrack>> GetTracksByKindAndGenre(string kind, string genre)
        {
            string responseText = await JsonHelper.GetjsonStream(@"https://api-v2.soundcloud.com/" + "charts?kind=" + kind + "&genre=soundcloud%3Agenres%3A" + genre + "&client_id=" + SoundCloudConstants.SoundCloudClientId + "&limit=50&linked_partitioning=1");
            SoundCloudChart chart = JsonConvert.DeserializeObject<SoundCloudChart>(responseText);
            var tempTracks = chart.collection.Select(ts => ts.track);
            Task<List<SoundCloudTrack>> task = Task.Run(() =>
            {
                return chart.collection.Select(ts => ts.track).ToList();
            });
            return task.Result;
        }

        /// <summary>
        /// Gets information about SoundCloud user
        /// </summary>
        /// <param name="SoundCloudUserName"></param>
        /// <returns></returns>
        public static async Task<SoundCloudUser> GetUserDetails(string SoundCloudUserName)
        {
                string responseText = await JsonHelper.GetjsonStream(SoundCloudConstants.SoundCloudAPILink + SoundCloudConstants.SoundCloudAPIUsers + SoundCloudUserName + ".json?client_id=" + SoundCloudConstants.SoundCloudClientId);
                Task<SoundCloudUser> task = Task.Run(() =>
                {
                    return JsonConvert.DeserializeObject<SoundCloudUser>(responseText);
                });
                return task.Result;
        }

        /// <summary>
        /// Gets information about SoundCloud track
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public static async Task<SoundCloudTrack> GetSoundCloudTrack(int id)
        {
            string responseText = await JsonHelper.GetjsonStream(SoundCloudConstants.SoundCloudAPILink + SoundCloudConstants.SoundCloudAPITracks + id + ".json?client_id=" + SoundCloudConstants.SoundCloudClientId);
            Task<SoundCloudTrack> task = Task.Run(() =>
            {
                var track = JsonConvert.DeserializeObject<SoundCloudTrack>(responseText);
                if (track != null)
                {
                    if (String.IsNullOrEmpty(track.stream_url))
                    {
                        if (String.IsNullOrEmpty(track.uri))
                        {
                            track.stream_url = track.uri + "/stream?client_id=" + SoundCloudConstants.SoundCloudClientId;
                        }
                    }
                    else
                    {
                        track.stream_url += "?client_id=" + SoundCloudConstants.SoundCloudClientId;
                    }
                }
                return track;
            });
            
            return task.Result;
        }
    }
}
