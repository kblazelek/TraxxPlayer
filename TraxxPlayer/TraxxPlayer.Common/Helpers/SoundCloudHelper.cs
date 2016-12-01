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
        public static ObservableCollection<SoundCloudTrack> GetChartTracks()
        {
            return null;
        }

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

        public async static Task<List<SoundCloudTrack>> GetLikedTracks(int userID)
        {
            List<SoundCloudTrack> likes = new List<SoundCloudTrack>();
            string responseText = await JsonHelper.GetjsonStream(SoundCloudConstants.SoundCloudAPILink + SoundCloudConstants.SoundCloudAPIUsers + userID + "/favorites.json?client_id=" + SoundCloudConstants.SoundCloudClientId);
            likes = JsonConvert.DeserializeObject<List<SoundCloudTrack>>(responseText);
            //remove songs which do not have stream url
            likes = likes.Where(t => t.stream_url != null).ToList();
            //add "?client_id=" + App.SoundCloudClientId to stream url
            Task<List<SoundCloudTrack>> task = Task.Run(() =>
            {
                return likes.Select(t => { t.stream_url += "?client_id=" + SoundCloudConstants.SoundCloudClientId; return t; }).ToList();
            });
            return task.Result;
        }

        public static async Task<SoundCloudUser> GetUserDetails(string SoundCloudUserName)
        {
                string responseText = await JsonHelper.GetjsonStream(SoundCloudConstants.SoundCloudAPILink + SoundCloudConstants.SoundCloudAPIUsers + SoundCloudUserName + ".json?client_id=" + SoundCloudConstants.SoundCloudClientId);
                Task<SoundCloudUser> task = Task.Run(() =>
                {
                    return JsonConvert.DeserializeObject<SoundCloudUser>(responseText);
                });
                return task.Result;
        }

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
