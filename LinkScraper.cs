using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Net;
using System.Text.RegularExpressions;
using HtmlAgilityPack;

namespace WpfEmailScraper
{
    class LinkScraper
    {
        //private class members
        private HashSet<Uri> _results = new HashSet<Uri>();

        //siteEmailScraper will need to use this, so it's public
        public HashSet<Uri> Results
        {
            get
            {
                return this._results;
            }
        }

        public void Scrape(string url)
        {
            WebClient client = new WebClient();
            //catch that shit
            try
            {
                //string urlContent = client.DownloadString(url);
                
                HtmlWeb site = new HtmlWeb();
                HtmlDocument doc = site.Load(url);

                //store found links in the results
                foreach (HtmlNode link in doc.DocumentNode.SelectNodes("//a[@href]"))
                {
                    try
                    {
                        HtmlAttribute att = link.Attributes["href"];
                        this._results.Add(new Uri(att.Value));
                    }
                    catch
                    {
                        
                    }

                }

            }
            catch
            {
                //how to handle this?
            }
        }
    }
}
