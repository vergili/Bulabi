using bulabi.Domain.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace bulabi.WebUI.Controllers {
    public class NavController : Controller {
        private IProductRepository repository;

        public NavController(IProductRepository repo) {
            repository = repo;
        }


        public PartialViewResult Country(string country = null, string category = null, string timeperiod = null, string channel=null)
        {

            ViewBag.SelectedCountry = country;
            ViewBag.SelectedCategory = category;
            ViewBag.SelectedTimePeriod = timeperiod;
            ViewBag.SelectedChannel = channel;

            Dictionary<string, string> countries = new Dictionary<string, string>();

            countries.Add("DZ" ,"Algeria"   );
            countries.Add("AR" ,"Argentina" );
            countries.Add("AU" ,"Australia" );
            countries.Add("AT" ,"Austria"   );
            countries.Add("BH" , "Bahrain"  );
            countries.Add("BE" ,"Belgium"   );
            countries.Add("BR" ,"Brazil"   );
            countries.Add("CA" ,"Canada"   );
            countries.Add("CL" ,"Chile"     );
            countries.Add("CO" ,"Colombia" );
            countries.Add("CZ" ,"Czech Republic"); 
            countries.Add("DK" , "Denmark");
            countries.Add("EG" ,"Egypt"   );
            countries.Add("FI" , "Finland");
            countries.Add("FR" ,"France" );
            countries.Add("DE" ,"Germany" );
            countries.Add("GH" , "Ghana"   );
            countries.Add("GB" ,"Great Britain"); 
            countries.Add("GR" ,"Greece"      );
            countries.Add("HK" ,"Hong Kong"  );
            countries.Add("HU" ,"Hungary"    );
            countries.Add("IN" ,"India"      );
            countries.Add("ID" , "Indonesia" );
            countries.Add("IE" ,"Ireland"    );
            countries.Add("IL" ,"Israel"); 
            countries.Add("IT" ,"Italy" );
            countries.Add("JP" ,"Japan" );
            countries.Add("JO" ,"Jordan"); 
            countries.Add("KE","Kenya" );
            countries.Add("KW","Kuwait" );
            countries.Add("MY" ,"Malaysia"); 
            countries.Add("MX" ,"Mexico" ); 
            countries.Add("MA" ,"Morocco" ); 
            countries.Add("NL" ,"Netherlands" ); 
            countries.Add("NZ" ,"New Zealand" );
            countries.Add("NG", "Nigeria"     );
            countries.Add("NO", "Norway"      );
            countries.Add("OM", "Oman"        );
            countries.Add("PE" ,"Peru"   ); 
            countries.Add("PH" ,"Philippines" ); 
            countries.Add("PL" ,"Poland"    );
            countries.Add("PT" ,"Portugal"  );
            countries.Add("QA" ,"Qatar"     );
            countries.Add("RO" ,"Romania"   );
            countries.Add("RU" ,"Russia"    );
            countries.Add("SA" ,"Saudi Arabia" );
            countries.Add("SN" , "Senegal" );
            countries.Add("SG" ,"Singapore"  );
            countries.Add("ZA" ,"South Africa" ); 
            countries.Add("KR" ,"South Korea"  );
            countries.Add("ES" ,"Spain"  );
            countries.Add("SE" ,"Sweden" ); 
            countries.Add("CH" ,"Switzerland" ); 
            countries.Add("TW" ,"Taiwan"      );
            countries.Add("TN" ,"Tunisia"     );
            countries.Add("TR" ,"Turkey"      );
            countries.Add("UG" ,"Uganda"      );
            countries.Add("UA" ,"Ukraine"     );
            countries.Add("AE" ,"United Arab Emirates" );
            countries.Add("US" ,"United States"        );
            countries.Add("UK" ,"United Kingdom"       );
            countries.Add("YE" ,"Yemen"                );


                //repository.Products
                //                    .Select(x => x.Country)
                //                    .Distinct()
                //                    .OrderBy(x => x);

            return PartialView(countries);
        }

        public PartialViewResult Category(string category = null, string country = null, string timeperiod = null, string channel=null)
        {

            ViewBag.SelectedCategory = category;
            ViewBag.SelectedCountry = country;
            ViewBag.SelectedTimePeriod = timeperiod;
            ViewBag.SelectedChannel = channel;


            List<string> categories = new List<string> { "All", "Autos", "Comedy", "Education", 
                "Entertainment", "Film", "Howto", "Music", "News", "People", "Animals", "Tech", "Sports", "Travel" };


            //IEnumerable<string> categories = repository.Products
            //                        .Select(x => x.Category)
            //                        .Distinct()
            //                        .OrderBy(x => x);

            return PartialView(categories);
        }

        public PartialViewResult TimePeriod(string category = null,string country = null, string timeperiod = null, string channel=null)
        {

            ViewBag.SelectedCategory = category;
            ViewBag.SelectedCountry = country;
            ViewBag.SelectedTimePeriod = timeperiod;
            ViewBag.SelectedChannel = channel;


            //List<string> timeperiods = new List<string> { "today", "this_week", "this_month", "all_time" };

            Dictionary<string, string> timeperiods = new Dictionary<string, string>();

            timeperiods.Add("today", "Today");
            timeperiods.Add("this_week", "This Week");
            timeperiods.Add("this_month", "This Month");
            timeperiods.Add("all_time", "All Time");

            //IEnumerable<string> categories = repository.Products
            //                        .Select(x => x.Category)
            //                        .Distinct()
            //                        .OrderBy(x => x);

            return PartialView(timeperiods);
        }


        public PartialViewResult Channel(string category = null, string country = null, string timeperiod = null, string channel = null)
        {

            ViewBag.SelectedCategory = category;
            ViewBag.SelectedCountry = country;
            ViewBag.SelectedTimePeriod = timeperiod;
            ViewBag.SelectedChannel = channel;


            //List<string> channels = new List<string> { "All", "Comedians", "Directors", "Gurus", "Musicians", "Partners", "Politicians", "Reporters", "Sponsors" };
            List<string> channels = new List<string> { "All", "Comedians", "Directors", "Gurus", "Musicians", "Partners", "Reporters", "Sponsors" };


            //IEnumerable<string> categories = repository.Products
            //                        .Select(x => x.Category)
            //                        .Distinct()
            //                        .OrderBy(x => x);

            return PartialView(channels);
        }



        public PartialViewResult PublishSection(string publishsection = null)
        {

            ViewBag.SelectedPublishSection = publishsection;

            IEnumerable<string> publishsections = repository.Products
                                    .Select(x => x.PublishSection)
                                    .Distinct()
                                    .OrderBy(x => x);

            return PartialView(publishsections);
        }
        

    }
}
