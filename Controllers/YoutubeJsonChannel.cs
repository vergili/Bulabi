using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bulabi.WebUI.Controllers
{
    public class YoutubeJsonChannel
    {

        public class Id
        {
            public string t { get; set; }
        }

        public class Updated
        {
            public string t { get; set; }
        }

        public class Category
        {
            public string scheme { get; set; }
            public string term { get; set; }
        }

        public class Title
        {
            public string t { get; set; }
        }

        public class Logo
        {
            public string t { get; set; }
        }

        public class Link
        {
            public string rel { get; set; }
            public string type { get; set; }
            public string href { get; set; }
        }

        public class Name
        {
            public string t { get; set; }
        }

        public class Uri
        {
            public string t { get; set; }
        }

        public class Author
        {
            public Name name { get; set; }
            public Uri uri { get; set; }
        }

        public class Generator
        {
            public string t { get; set; }
            public string version { get; set; }
            public string uri { get; set; }
        }

        public class OpenSearchtotalResults
        {
            public int t { get; set; }
        }

        public class OpenSearchstartIndex
        {
            public int t { get; set; }
        }

        public class OpenSearchitemsPerPage
        {
            public int t { get; set; }
        }

        public class Id2
        {
            public string t { get; set; }
        }

        public class Updated2
        {
            public string t { get; set; }
        }

        public class Category2
        {
            public string scheme { get; set; }
            public string term { get; set; }
        }

        public class Title2
        {
            public string t { get; set; }
        }

        public class Summary
        {
            public string t { get; set; }
        }

        public class Link2
        {
            public string rel { get; set; }
            public string type { get; set; }
            public string href { get; set; }
        }

        public class Name2
        {
            public string t { get; set; }
        }

        public class Uri2
        {
            public string t { get; set; }
        }

        public class YtuserId
        {
            public string t { get; set; }
        }

        public class Author2
        {
            public Name2 name { get; set; }
            public Uri2 uri { get; set; }
            public YtuserId ytuserId { get; set; }
        }

        public class YtchannelId
        {
            public string t { get; set; }
        }

        public class YtchannelStatistics
        {
            public string commentCount { get; set; }
            public string subscriberCount { get; set; }
            public string totalUploadViewCount { get; set; }
            public string videoCount { get; set; }
            public string viewCount { get; set; }
        }

        public class Mediathumbnail
        {
            public string url { get; set; }
            public string ytname { get; set; }
        }

        public class Mediatitle
        {
            public string t { get; set; }
        }

        public class Mediagroup
        {
            public List<Mediathumbnail> mediathumbnail { get; set; }
            public Mediatitle mediatitle { get; set; }
        }

        public class Entry
        {
            public Id2 id { get; set; }
            public Updated2 updated { get; set; }
            public List<Category2> category { get; set; }
            public Title2 title { get; set; }
            public Summary summary { get; set; }
            public List<Link2> link { get; set; }
            public List<Author2> author { get; set; }
            public YtchannelId ytchannelId { get; set; }
            public YtchannelStatistics ytchannelStatistics { get; set; }
            public Mediagroup mediagroup { get; set; }
        }

        public class Feed
        {
            public string xmlns { get; set; }
            public string xmlnsmedia { get; set; }
            public string xmlnsopenSearch { get; set; }
            public string xmlnsgd { get; set; }
            public string xmlnsyt { get; set; }
            public string gdetag { get; set; }
            public Id id { get; set; }
            public Updated updated { get; set; }
            public List<Category> category { get; set; }
            public Title title { get; set; }
            public Logo logo { get; set; }
            public List<Link> link { get; set; }
            public List<Author> author { get; set; }
            public Generator generator { get; set; }
            public OpenSearchtotalResults openSearchtotalResults { get; set; }
            public OpenSearchstartIndex openSearchstartIndex { get; set; }
            public OpenSearchitemsPerPage openSearchitemsPerPage { get; set; }
            public List<Entry> entry { get; set; }
        }


            public string version { get; set; }
            public string encoding { get; set; }
            public Feed feed { get; set; }
        
        
    }
}