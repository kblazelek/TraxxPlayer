﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundAudioShared
{
    public class SoundCloudUser
    {
        public int id { get; set; }
        public string permalink { get; set; }
        public string username { get; set; }
        public string uri { get; set; }
        public string permalink_url { get; set; }
        public string avatar_url { get; set; }

        public string kind { get; set; }
        public string last_modified { get; set; }
        public object country { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
        public object description { get; set; }
        public object city { get; set; }
        public object discogs_name { get; set; }
        public object myspace_name { get; set; }
        public object website { get; set; }
        public object website_title { get; set; }
        public bool online { get; set; }
        public int track_count { get; set; }
        public int playlist_count { get; set; }
        public string plan { get; set; }
        public int public_favorites_count { get; set; }
        public int followers_count { get; set; }
        public int followings_count { get; set; }
    }
}
