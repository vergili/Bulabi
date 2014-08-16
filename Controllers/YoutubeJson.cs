using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace bulabi.WebUI.Controllers
{
    public class YoutubeJson
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
            public string type { get; set; }
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

        public class Published
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
            public string label { get; set; }
        }

        public class Title2
        {
            public string t { get; set; }
            public string type { get; set; }
        }

        public class Content
        {
            public string type { get; set; }
            public string src { get; set; }
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

        public class Author2
        {
            public Name2 name { get; set; }
            public Uri2 uri { get; set; }
        }

        public class YtaccessControl
        {
            public string action { get; set; }
            public string permission { get; set; }
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

        public class Mediacredit
        {
            public string t { get; set; }
            public string role { get; set; }
            public string scheme { get; set; }
            public string ytdisplay { get; set; }
            public string yttype { get; set; }
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

        public class YtaspectRatio
        {
            public string t { get; set; }
        }

        public class Ytduration
        {
            public string seconds { get; set; }
        }

        public class Ytuploaded
        {
            public string t { get; set; }
        }

        public class YtuploaderId
        {
            public string t { get; set; }
        }

        public class Ytvideoid
        {
            public string t { get; set; }
        }

        public class Mediarestriction
        {
            public string t { get; set; }
            public string type { get; set; }
            public string relationship { get; set; }
        }

        public class Mediagroup
        {
            public List<Mediacategory> mediacategory { get; set; }
            public List<Mediacontent> mediacontent { get; set; }
            public List<Mediacredit> mediacredit { get; set; }
            public Mediadescription mediadescription { get; set; }
            public Mediakeywords mediakeywords { get; set; }
            public List<Mediaplayer> mediaplayer { get; set; }
            public List<Mediathumbnail> mediathumbnail { get; set; }
            public Mediatitle mediatitle { get; set; }
            public YtaspectRatio ytaspectRatio { get; set; }
            public Ytduration ytduration { get; set; }
            public Ytuploaded ytuploaded { get; set; }
            public YtuploaderId ytuploaderId { get; set; }
            public Ytvideoid ytvideoid { get; set; }
            public Mediarestriction mediarestriction { get; set; }
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

        public class Ytrating
        {
            public string numDislikes { get; set; }
            public string numLikes { get; set; }
        }

        public class Ythd
        {
        }

        public class Gmlpos
        {
            public string t { get; set; }
        }

        public class GmlPoint
        {
            public Gmlpos gmlpos { get; set; }
        }

        public class Georsswhere
        {
            public GmlPoint gmlPoint { get; set; }
        }

        public class Entry
        {
            public Id2 id { get; set; }
            public Published published { get; set; }
            public Updated2 updated { get; set; }
            public List<Category2> category { get; set; }
            public Title2 title { get; set; }
            public Content content { get; set; }
            public List<Link2> link { get; set; }
            public List<Author2> author { get; set; }
            public List<YtaccessControl> ytaccessControl { get; set; }
            public Gdcomments gdcomments { get; set; }
            public Mediagroup mediagroup { get; set; }
            public Gdrating gdrating { get; set; }
            public Ytstatistics ytstatistics { get; set; }
            public Ytrating ytrating { get; set; }
            public Ythd ythd { get; set; }
            public Georsswhere georsswhere { get; set; }
        }

        public class Feed
        {
            public string xmlns { get; set; }
            public string xmlnsmedia { get; set; }
            public string xmlnsopenSearch { get; set; }
            public string xmlnsgd { get; set; }
            public string xmlnsgml { get; set; }
            public string xmlnsyt { get; set; }
            public string xmlnsgeorss { get; set; }
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