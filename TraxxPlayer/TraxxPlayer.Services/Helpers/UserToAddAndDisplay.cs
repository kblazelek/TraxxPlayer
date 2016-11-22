using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TraxxPlayer.Services.Helpers
{
    public class UserToAddAndDisplay
    {
        public int id { get; set; }
        public string permalink { get; set; }
        public string username { get; set; }
        public string uri { get; set; }
        public string permalink_url { get; set; }
        public string avatar_url { get; set; }
        public string kind { get; set; }
        public string last_modified { get; set; }
        public string country { get; set; }
        public string first_name { get; set; }
        public string last_name { get; set; }
        public string full_name { get; set; }
        public string description { get; set; }
        public string city { get; set; }
        public string discogs_name { get; set; }
        public string myspace_name { get; set; }
        public string website { get; set; }
        public string website_title { get; set; }
        public bool online { get; set; }
        public int track_count { get; set; }
        public int playlist_count { get; set; }
        public string plan { get; set; }
        public int public_favorites_count { get; set; }
        public int followers_count { get; set; }
        public int followings_count { get; set; }

        //public UserToAddAndDisplay()
        //{

        //}
        //public UserToAddAndDisplay(SoundCloudUser u)
        //{
        //    this.avatar_url = u.avatar_url;
        //    this.city = (string)u.city;
        //    this.country = (string)u.country;
        //    this.description = (string)u.description;
        //    this.discogs_name = (string)u.discogs_name;
        //    this.first_name = u.first_name;
        //    this.followers_count = u.followers_count;
        //    this.followings_count = u.followings_count;
        //    this.full_name = u.full_name;
        //    this.id = u.id;
        //    this.kind = u.kind;
        //    this.last_modified = u.last_modified;
        //    this.last_name = u.last_name;
        //    this.myspace_name = (string)u.myspace_name;
        //    this.online = u.online;
        //    this.permalink = u.permalink;
        //    this.permalink_url = u.permalink_url;
        //    this.plan = u.plan;
        //    this.playlist_count = u.playlist_count;
        //    this.public_favorites_count = u.public_favorites_count;
        //    this.track_count = u.track_count;
        //    this.uri = u.uri;
        //    this.username = u.username;
        //    this.website = (string)u.website;
        //    this.website_title = (string)u.website_title;
        //}
        //public override bool Equals(object obj)
        //{
        //    if (obj == null)
        //    {
        //        return false;
        //    }
        //    UserToAddAndDisplay u = obj as UserToAddAndDisplay;
        //    if ((System.Object)u == null)
        //    {
        //        return false;
        //    }
        //    return
        //        (
        //        this.avatar_url == u.avatar_url &&
        //        this.city == (string)u.city &&
        //        this.country == (string)u.country &&
        //        this.description == (string)u.description &&
        //        this.discogs_name == (string)u.discogs_name &&
        //        this.first_name == u.first_name &&
        //        this.followers_count == u.followers_count &&
        //        this.followings_count == u.followings_count &&
        //        this.full_name == u.full_name &&
        //        this.id == u.id &&
        //        this.kind == u.kind &&
        //        this.last_modified == u.last_modified &&
        //        this.last_name == u.last_name &&
        //        this.myspace_name == (string)u.myspace_name &&
        //        this.online == u.online &&
        //        this.permalink == u.permalink &&
        //        this.permalink_url == u.permalink_url &&
        //        this.plan == u.plan &&
        //        this.playlist_count == u.playlist_count &&
        //        this.public_favorites_count == u.public_favorites_count &&
        //        this.track_count == u.track_count &&
        //        this.uri == u.uri &&
        //        this.username == u.username &&
        //        this.website == (string)u.website &&
        //        this.website_title == (string)u.website_title
        //        );
        //}

        //public bool Equals(SoundCloudUser u)
        //{
        //    if ((System.Object)u == null)
        //    {
        //        return false;
        //    }
        //    return
        //        (
        //        this.avatar_url == u.avatar_url &&
        //        this.city == (string)u.city &&
        //        this.country == (string)u.country &&
        //        this.description == (string)u.description &&
        //        this.discogs_name == (string)u.discogs_name &&
        //        this.first_name == u.first_name &&
        //        this.followers_count == u.followers_count &&
        //        this.followings_count == u.followings_count &&
        //        this.full_name == u.full_name &&
        //        this.id == u.id &&
        //        this.kind == u.kind &&
        //        this.last_modified == u.last_modified &&
        //        this.last_name == u.last_name &&
        //        this.myspace_name == (string)u.myspace_name &&
        //        this.online == u.online &&
        //        this.permalink == u.permalink &&
        //        this.permalink_url == u.permalink_url &&
        //        this.plan == u.plan &&
        //        this.playlist_count == u.playlist_count &&
        //        this.public_favorites_count == u.public_favorites_count &&
        //        this.track_count == u.track_count &&
        //        this.uri == u.uri &&
        //        this.username == u.username &&
        //        this.website == (string)u.website &&
        //        this.website_title == (string)u.website_title
        //        );
        //}
    }
}
