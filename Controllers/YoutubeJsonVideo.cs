using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bulabi.WebUI.Controllers
{
    public class YoutubeJsonVideo
    {
        public class Id
        {
            public string t { get; set; }
        }

        public class Published
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
            public string label { get; set; }
        }

        public class Title
        {
            public string t { get; set; }
            public string type { get; set; }
        }

        public class Content
        {
            public string t { get; set; }
            public string type { get; set; }
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

        public class GdfeedLink
        {
            public string rel { get; set; }
            public string href { get; set; }
            public int countHint { get; set; }
        }

        public class Gdcomments
        {
            public GdfeedLink gdfeedLink { get; set; }
        }

        public class Ythd
        {
        }

        public class Mediacategory
        {
            public string t { get; set; }
            public string label { get; set; }
            public string scheme { get; set; }
        }

        public class Mediacontent
        {
            public string url { get; set; }
            public string type { get; set; }
            public string medium { get; set; }
            public string isDefault { get; set; }
            public string expression { get; set; }
            public int duration { get; set; }
            public int ytformat { get; set; }
        }

        public class Mediadescription
        {
            public string t { get; set; }
            public string type { get; set; }
        }

        public class Mediakeywords
        {
        }

        public class Mediaplayer
        {
            public string url { get; set; }
        }

        public class Mediarestriction
        {
            public string t { get; set; }
            public string type { get; set; }
            public string relationship { get; set; }
        }

        public class Mediathumbnail
        {
            public string url { get; set; }
            public int height { get; set; }
            public int width { get; set; }
            public string time { get; set; }
        }

        public class Mediatitle
        {
            public string t { get; set; }
            public string type { get; set; }
        }

        public class Ytduration
        {
            public string seconds { get; set; }
        }

        public class Mediagroup
        {
            public List<Mediacategory> mediacategory { get; set; }
            public List<Mediacontent> mediacontent { get; set; }
            public Mediadescription mediadescription { get; set; }
            public Mediakeywords mediakeywords { get; set; }
            public List<Mediaplayer> mediaplayer { get; set; }
            public Mediarestriction mediarestriction { get; set; }
            public List<Mediathumbnail> mediathumbnail { get; set; }
            public Mediatitle mediatitle { get; set; }
            public Ytduration ytduration { get; set; }
        }

        public class Gdrating
        {
            public double average { get; set; }
            public int max { get; set; }
            public int min { get; set; }
            public int numRaters { get; set; }
            public string rel { get; set; }
        }

        public class Ytstatistics
        {
            public string favoriteCount { get; set; }
            public string viewCount { get; set; }
        }

        public class Entry
        {
            public string xmlns { get; set; }
            public string xmlnsmedia { get; set; }
            public string xmlnsgd { get; set; }
            public string xmlnsyt { get; set; }
            public Id id { get; set; }
            public Published published { get; set; }
            public Updated updated { get; set; }
            public List<Category> category { get; set; }
            public Title title { get; set; }
            public Content content { get; set; }
            public List<Link> link { get; set; }
            public List<Author> author { get; set; }
            public Gdcomments gdcomments { get; set; }
            public Ythd ythd { get; set; }
            public Mediagroup mediagroup { get; set; }
            public Gdrating gdrating { get; set; }
            public Ytstatistics ytstatistics { get; set; }
        }


        public string version { get; set; }
        public string encoding { get; set; }
        public Entry entry { get; set; }
        
  
    }
}