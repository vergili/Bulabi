using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

using bulabi.Domain.Entities;
using bulabi.Domain.Abstract;
using bulabi.WebUI.Models;
using System.Net;
using bulabi.WebUI.HtmlHelpers;
using Newtonsoft.Json;
using System.IO;
using System.Text;

namespace bulabi.WebUI.Controllers
{
    public class ProductController : Controller
    {
        private IProductRepository repository;
        public int PageSize = 20;

        public ProductController(IProductRepository productRepository)
        {
            this.repository = productRepository;
        }

        public ViewResult List(string category, string country, string timeperiod,string channel, string q, int page = 1)
        {




            #region countries timeperiods
            Dictionary<string, string> timeperiods = new Dictionary<string, string>();
            timeperiods.Add("today", "Today");
            timeperiods.Add("this_week", "This Week");
            timeperiods.Add("this_month", "This Month");
            timeperiods.Add("all_time", "All Time");

            Dictionary<string, string> countries = new Dictionary<string, string>();

            countries.Add("DZ", "Algeria");
            countries.Add("AR", "Argentina");
            countries.Add("AU", "Australia");
            countries.Add("AT", "Austria");
            countries.Add("BH", "Bahrain");
            countries.Add("BE", "Belgium");
            countries.Add("BR", "Brazil");
            countries.Add("CA", "Canada");
            countries.Add("CL", "Chile");
            countries.Add("CO", "Colombia");
            countries.Add("CZ", "Czech Republic");
            countries.Add("DK", "Denmark");
            countries.Add("EG", "Egypt");
            countries.Add("FI", "Finland");
            countries.Add("FR", "France");
            countries.Add("DE", "Germany");
            countries.Add("GH", "Ghana");
            countries.Add("GB", "Great Britain");
            countries.Add("GR", "Greece");
            countries.Add("HK", "Hong Kong");
            countries.Add("HU", "Hungary");
            countries.Add("IN", "India");
            countries.Add("ID", "Indonesia");
            countries.Add("IE", "Ireland");
            countries.Add("IL", "Israel");
            countries.Add("IT", "Italy");
            countries.Add("JP", "Japan");
            countries.Add("JO", "Jordan");
            countries.Add("KE", "Kenya");
            countries.Add("KW", "Kuwait");
            countries.Add("MY", "Malaysia");
            countries.Add("MX", "Mexico");
            countries.Add("MA", "Morocco");
            countries.Add("NL", "Netherlands");
            countries.Add("NZ", "New Zealand");
            countries.Add("NG", "Nigeria");
            countries.Add("NO", "Norway");
            countries.Add("OM", "Oman");
            countries.Add("PE", "Peru");
            countries.Add("PH", "Philippines");
            countries.Add("PL", "Poland");
            countries.Add("PT", "Portugal");
            countries.Add("QA", "Qatar");
            countries.Add("RO", "Romania");
            countries.Add("RU", "Russia");
            countries.Add("SA", "Saudi Arabia");
            countries.Add("SN", "Senegal");
            countries.Add("SG", "Singapore");
            countries.Add("ZA", "South Africa");
            countries.Add("KR", "South Korea");
            countries.Add("ES", "Spain");
            countries.Add("SE", "Sweden");
            countries.Add("CH", "Switzerland");
            countries.Add("TW", "Taiwan");
            countries.Add("TN", "Tunisia");
            countries.Add("TR", "Turkey");
            countries.Add("UG", "Uganda");
            countries.Add("UA", "Ukraine");
            countries.Add("AE", "United Arab Emirates");
            countries.Add("US", "United States");
            countries.Add("UK", "United Kingdom");
            countries.Add("YE", "Yemen");
            #endregion


            WebClient Client = new WebClient();

            
            string ipin = Request.ServerVariables["REMOTE_ADDR"];
            if (string.IsNullOrEmpty(ipin)) ipin = Request.ServerVariables["HTTP_X_FORWARDED_FOR"];
            if (string.IsNullOrEmpty(ipin)) ipin = Request.UserHostAddress;


            string link2 = "http://www.geoplugin.net/json.gp?ip=" + ipin;
            

            string htmlCode2 = Client.DownloadString(link2);


            IpGeoLocation mycountrydat = JsonConvert.DeserializeObject<IpGeoLocation>(htmlCode2);

            if (string.IsNullOrEmpty(country)) country = mycountrydat.geoplugin_countryCode;
            
            
            if (string.IsNullOrEmpty(country))  country = "US";
            if (string.IsNullOrEmpty(timeperiod)) timeperiod = "today";

            string link1=null;

            ProductsListViewModel viewModel = new ProductsListViewModel();


            if (string.IsNullOrEmpty(channel) || channel == viewModel.CurrentChannel)
            {
                if (string.IsNullOrEmpty(q))
                {

                    if (category == null || category == "All")
                        link1 = "http://gdata.youtube.com/feeds/api/standardfeeds/" + country + "/most_viewed?alt=json&time=" + timeperiod + "&lr=" + country + "&max-results=50&prettyprint=True";
                    else
                        link1 = "http://gdata.youtube.com/feeds/api/standardfeeds/" + country + "/most_viewed_" + category + "?alt=json&time=" + timeperiod + "&lr=" + country + "&max-results=50&prettyprint=True";

                }
                else
                {
                    link1 = "http://gdata.youtube.com/feeds/api/videos?alt=json&max-results=50&q=" + q;
                }


            Client.Encoding = Encoding.UTF8;

            string htmlCode1 = Client.DownloadString(link1);


            YoutubeJson mydat =  JsonConvert.DeserializeObject<YoutubeJson>(htmlCode1.Replace("$",""));

            List<string> myLink = new List<string>();
            List<string> myTitle = new List<string>();
            List<string> myView = new List<string>();
            List<string> myImage = new List<string>();
            List<string> myOriginID = new List<string>(); 

            for (int i = 0; i < mydat.feed.entry.Count(); i++)
            {

                myTitle.Add(mydat.feed.entry[i].title.t);
                myImage.Add(mydat.feed.entry[i].mediagroup.mediathumbnail[0].url);

                string LinkTitle = "b-" + mydat.feed.entry[i].link[0].href.Split('&').First().Split('=').Last() + "/video/" +
                mydat.feed.entry[i].title.t
                .Replace("'", "").Replace(" ", "-")
                .Replace("=", "").Replace(")", "").Replace("(", "").Replace(";", "").Replace("?", "").Replace("&", "")
                .Replace("@", "").Replace("\"", "").Replace("#", "").Replace("^", "").Replace("$", "").Replace("%", "")
                .Replace("/", "").Replace("\\", "").Replace("*", "").Replace("+", "").Replace("!", "").Replace(",", "")
                .Replace(".", "").Replace(";", "").Replace(":", "").Replace("_", "-");


                myOriginID.Add(LinkTitle);

                
                if (mydat.feed.entry[i].ytstatistics == null)
                    myView.Add("no information");
                else
                    myView.Add(mydat.feed.entry[i].ytstatistics.viewCount);


                string linkUrl = mydat.feed.entry[i].link[0].href;
                    myLink.Add( "http://www.youtube.com/embed/" + linkUrl.Split('&').First().Split('=').Last() + "?enablejsapi=1&wmode=opaque");
            }


            viewModel.Title = new List<string>();

            foreach (string a in myTitle)
            {
                viewModel.Title.Add(a);

            }


            viewModel.Image = new List<string>();
            foreach (string a in myImage)
            {
                viewModel.Image.Add(a);

            }

            viewModel.OriginID = new List<string>();
            foreach (string a in myOriginID)
            {
                viewModel.OriginID.Add(a);

            }

            viewModel.Link = new List<string>();
                foreach (string a in myLink)
                {
                    viewModel.Link.Add( a );
                    
                }

                viewModel.View = new List<string>();
                foreach (string a in myView)
                {
                    viewModel.View.Add(a);

                }

               viewModel.PagingInfo  = new PagingInfo
                {
                    CurrentPage = page,
                    ItemsPerPage = PageSize,
                    TotalItems = category == null ?
                        repository.Products.Count() :
                        repository.Products.Where(e => e.Category == category && e.Country == country).Count()
                };



               viewModel.CurrentCountry = countries[country];
               viewModel.CurrentCategory = category;
               viewModel.CurrentTimePeriod = timeperiods[timeperiod];
               viewModel.CurrentChannel = null;

            }
            else
            {
                category =null;
                if (channel == null || channel == "All")
                    link1 = "https://gdata.youtube.com/feeds/api/channelstandardfeeds/" + country + "/most_viewed?v=2&alt=json&time="+timeperiod +"&max-results=50";
                else
                    link1 = "https://gdata.youtube.com/feeds/api/channelstandardfeeds/" + country + "/most_viewed_" + channel + "?v=2&alt=json&time="+timeperiod+"&max-results=50";



                Client.Encoding = Encoding.UTF8;

                string htmlCode1 = Client.DownloadString(link1);

                string test = htmlCode1.Replace("$", "");

                YoutubeJsonChannel mydat2 = JsonConvert.DeserializeObject<YoutubeJsonChannel>(htmlCode1.Replace("$", ""));


                viewModel.Title = new List<string>();
                viewModel.Image = new List<string>();
                viewModel.OriginID = new List<string>();
                viewModel.Link = new List<string>();
                viewModel.View = new List<string>();

                for (int i = 0; i < mydat2.feed.entry.Count(); i++)
                {

                    viewModel.Title.Add(mydat2.feed.entry[i].author[0].name.t);
                    viewModel.Image.Add(mydat2.feed.entry[i].mediagroup.mediathumbnail[1].url);
                    viewModel.OriginID.Add(mydat2.feed.entry[i].author[0].uri.t.Split('/').Last());
                    viewModel.Link.Add(mydat2.feed.entry[i].link[0].href);

                    if (mydat2.feed.entry[i].ytchannelStatistics.subscriberCount == null)
                        viewModel.View.Add("no information");
                    else
                        viewModel.View.Add(mydat2.feed.entry[i].ytchannelStatistics.subscriberCount);

                }

                viewModel.CurrentCountry = countries[country];

                viewModel.CurrentCategory = null;
                viewModel.CurrentTimePeriod = timeperiods[timeperiod];
                viewModel.CurrentChannel = channel;

            }

            
            return View(viewModel);
        }


        public ViewResult Video(string originID ) 
        {
            WebClient Client = new WebClient();

            string link1 = null;
            string link2 = null;

            string originID2 =null;

            if (originID.Length > 13 && originID.Substring(13, 7) == "/video/")
                originID2 = originID.Substring(2, 11);
            else
                originID2 = originID;

            link1 = "http://gdata.youtube.com/feeds/api/videos/"+ originID2 + "?alt=json";
            link2 = "http://gdata.youtube.com/feeds/api/videos/" +originID2+"/related?v=2&alt=json";

            Client.Encoding = Encoding.UTF8;

            string htmlCode1 = Client.DownloadString(link1);
            string htmlCode2 = Client.DownloadString(link2).Replace("$","");


            YoutubeJsonVideo mydat = JsonConvert.DeserializeObject<YoutubeJsonVideo>(htmlCode1.Replace("$", ""));
            YoutubeJsonRelated mydat2 = JsonConvert.DeserializeObject<YoutubeJsonRelated>(htmlCode2.Replace("$", ""));


            ProductsListViewModel viewModel = new ProductsListViewModel();

            string frameUrl = "<iframe width=\"90%\" height=\"560\" src=\"//www.youtube.com/embed/" +
                              originID2 +
                             "?autoplay=1\" frameborder=\"0\" allowfullscreen></iframe>";

            viewModel.FrameUrl = frameUrl;

            viewModel.VideoTitle = mydat.entry.mediagroup.mediatitle.t;
            viewModel.VideoImage = mydat.entry.mediagroup.mediathumbnail[0].url;
            viewModel.VideoView = mydat.entry.ytstatistics.viewCount;
            viewModel.VideoDescription = mydat.entry.mediagroup.mediadescription.t;
            viewModel.VideoOriginID = originID2;




            viewModel.RelatedTitle = new List<string>();
            viewModel.RelatedImage = new List<string>();
            viewModel.RelatedOriginID = new List<string>();
            viewModel.RelatedLink = new List<string>();
            viewModel.RelatedView = new List<string>();


            for (int i = 0; i < mydat2.feed.entry.Count(); i++)
            {

                viewModel.RelatedTitle.Add(mydat2.feed.entry[i].title.t);
                viewModel.RelatedImage.Add(mydat2.feed.entry[i].mediagroup.mediathumbnail[4].url);


                string LinkTitle = "b-" + mydat2.feed.entry[i].link[0].href.Split('&').First().Split('=').Last() + "/video/" +
                mydat2.feed.entry[i].title.t
                .Replace("'", "").Replace(" ", "-")
                .Replace("=", "").Replace(")", "").Replace("(", "").Replace(";", "").Replace("?", "").Replace("&", "")
                .Replace("@", "").Replace("\"", "").Replace("#", "").Replace("^", "").Replace("$", "").Replace("%", "")
                .Replace("/", "").Replace("\\", "").Replace("*", "").Replace("+", "").Replace("!", "").Replace(",", "")
                .Replace(".", "").Replace(";", "").Replace(":", "").Replace("_", "-");


                viewModel.RelatedOriginID.Add(LinkTitle);


                if (mydat2.feed.entry[i].ytstatistics == null)
                    viewModel.RelatedView.Add("no information");
                else
                    viewModel.RelatedView.Add(mydat2.feed.entry[i].ytstatistics.viewCount);

            }






            return View(viewModel);
        }

        public ViewResult Channel(string channelID)
        {
            WebClient Client = new WebClient();

            string link1 = null;

            link1 = "https://gdata.youtube.com/feeds/users/" + channelID + "/uploads?alt=json&max-results=50";

            Client.Encoding = Encoding.UTF8;

            string htmlCode1 = Client.DownloadString(link1);


            YoutubeJson mydat = JsonConvert.DeserializeObject<YoutubeJson>(htmlCode1.Replace("$", ""));


            //var j = JsonConvert.SerializeObject(new[] { JsonConvert.DeserializeObject(j1), JsonConvert.DeserializeObject(j2) });

            

            ProductsListViewModel viewModel = new ProductsListViewModel();


            viewModel.Title = new List<string>();
            viewModel.Image = new List<string>();
            viewModel.OriginID = new List<string>();
            viewModel.Link = new List<string>();
            viewModel.View = new List<string>();

            for (int i = 0; i < mydat.feed.entry.Count(); i++)
            {

                viewModel.Title.Add(mydat.feed.entry[i].title.t);
                viewModel.Image.Add(mydat.feed.entry[i].mediagroup.mediathumbnail[0].url);



                string LinkTitle = "b-" + mydat.feed.entry[i].link[0].href.Split('&').First().Split('=').Last() + "/video/" +
                mydat.feed.entry[i].title.t
                .Replace("'", "").Replace(" ", "-")
                .Replace("=", "").Replace(")", "").Replace("(", "").Replace(";", "").Replace("?", "").Replace("&", "")
                .Replace("@", "").Replace("\"", "").Replace("#", "").Replace("^", "").Replace("$", "").Replace("%", "")
                .Replace("/", "").Replace("\\", "").Replace("*", "").Replace("+", "").Replace("!", "").Replace(",", "")
                .Replace(".", "").Replace(";", "").Replace(":", "").Replace("_", "-");



                viewModel.OriginID.Add(LinkTitle);




                if (mydat.feed.entry[i].ytstatistics == null)
                    viewModel.View.Add("no information");
                else
                    viewModel.View.Add(mydat.feed.entry[i].ytstatistics.viewCount);


                string linkUrl = mydat.feed.entry[i].link[0].href;
                viewModel.Link.Add("http://www.youtube.com/embed/" + linkUrl.Split('&').First().Split('=').Last() + "?enablejsapi=1&wmode=opaque");

            }




            return View(viewModel);
        }



        public string WebResponseGet(HttpWebRequest webRequest)
        {
            StreamReader responseReader = null;
            string responseData = "";

            try
            {
                responseReader = new StreamReader(webRequest.GetResponse().GetResponseStream());
                responseData = responseReader.ReadToEnd();
            }
            catch
            {
                throw;
            }
            finally
            {
                responseReader.Close();
            }

            return responseData;
        }

        public ViewResult GetImage(int productId)
        {
            Product prod = repository.Products.FirstOrDefault(p => p.ProductID == productId);
            if (prod != null)
            {
                return View(prod.ImageData);

            }
            else
            {
                return null;
            }
        }

    }
}
