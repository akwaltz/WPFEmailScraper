using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
using System.Net.Mail;
using System.Net;

namespace WpfEmailScraper
{
    class SiteEmailScraper
    {
        //private class members
        private HashSet<MailAddress> _results = new HashSet<MailAddress>();
        private HashSet<Uri> _sitesToScrape = new HashSet<Uri>();
        private HashSet<Uri> _sitesScraped = new HashSet<Uri>();

        public HashSet<MailAddress> Results
        {
            get
            {
                return this._results;
            }
        }

        public void Scrape(string url)
        {
            WebClient client = new WebClient();
            try
            {
                string urlContent = client.DownloadString(url);
                //search for URLs in urlContent
                LinkScraper ls = new LinkScraper();

                ls.Scrape(url);
                _sitesToScrape = ls.Results;

                _sitesToScrape.Add(new Uri(url));

                //store found emails in the results
                foreach (Uri uri in _sitesToScrape)
                {
                    EmailScraper es = new EmailScraper();

                    if (uri.Authority == "www.southhills.edu")
                    {
                        es.Scrape(uri.AbsoluteUri);
                        _sitesScraped.Add(new Uri(uri.AbsoluteUri));
                        //current results (_results) appended to Results- if it works
                        _results.UnionWith(es.Results);
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
