using System;
using System.Text;
using System.Web.Mvc;
using bulabi.WebUI.Models;
using System.Net;
using System.Text.RegularExpressions;
using System.Web;

namespace bulabi.WebUI.HtmlHelpers
{
    public static class LocationHelpers
    {

        public static MvcHtmlString GuestLocation(this HtmlHelper html )
        {

            //string host = Dns.GetHostName();
            //IPHostEntry ip = Dns.GetHostEntry(host);
            // string  ipadd = ip.AddressList[0].ToString();


            WebClient Client = new WebClient();
            string link1 = "http://checkip.dyndns.org/";


            string htmlCode1 = Client.DownloadString(link1);

            string start1 = "Current IP Address: ";
            string end1 = "</body>";


            Regex r1 = new Regex(Regex.Escape(start1) + "(.*?)" + Regex.Escape(end1));
            MatchCollection matches1 = r1.Matches(htmlCode1);
            string ipadd = "";
            foreach (Match match in matches1)
            {
                ipadd = match.Groups[1].Value;

            }


            string ipinfodb_key = "08fc246ed001721c19bdad1ed187c7db14b9f95b8b6d6347f0291fdd47b785eb";

            string link2 = "http://api.ipinfodb.com/v2/ip_query.php?key=" + ipinfodb_key
                          + "&" + "ip=" + ipadd + "&timezone=false";


            string htmlCode2 = Client.DownloadString(link2);
            string start2 = "<CountryCode>";
            string end2 = "</CountryCode>";
            Regex r2 = new Regex(Regex.Escape(start2) + "(.*?)" + Regex.Escape(end2));
            MatchCollection matches2 = r2.Matches(htmlCode2);
            string cat = "";

            foreach (Match match in matches2)
            {
                cat = match.Groups[1].Value;

            }

            return MvcHtmlString.Create( cat);
        }

        public static string GuestCountry()
        {

            WebClient Client = new WebClient();

            string ipadd = "";
            //HttpContext.Current.Request.ServerVariables["REMOTE_ADDR"];


            string link1 = "http://www.geoplugin.net/json.gp?ip=" + ipadd;

            string htmlCode2 = Client.DownloadString(link1);


            return link1; 
        }

    }
}