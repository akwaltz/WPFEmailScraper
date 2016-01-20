using System;
using System.Collections.Generic;
using System.Net;
using System.Text.RegularExpressions;
using System.Net.Mail;

namespace WpfEmailScraper
{
    class EmailScraper
    {
        //private class members
        private HashSet<MailAddress> _results = new HashSet<MailAddress>();

        public HashSet<MailAddress> Results
        {
            get
            {
                return this._results;
            }
        }

        //public methods
        public void Scrape(string url)
        {
            WebClient client = new WebClient();
            //catch that shit
            try
            {
                string urlContent = client.DownloadString(url);
                //search for emails in urlContent
                Regex regex = new Regex(@"[A-Z0-9._%+-]+@[A-Z0-9.-]+\.[A-Z]{2,6}", RegexOptions.IgnoreCase);
                MatchCollection matches = regex.Matches(urlContent);

                //store found emails in the results
                foreach (Match match in matches)
                {
                    this._results.Add(new MailAddress(match.Value));
                }

            }
            catch
            {
                //how to handle this?
            }
        }
    }
}
