using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfEmailScraper
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        SiteEmailScraper scraper = new SiteEmailScraper();
        public MainWindow()
        {
            InitializeComponent();
        }

        //event handler
        private void ScrapeEmailsBtn_Click(object sender, RoutedEventArgs e)
        {
            //get contents of URL
            string url = URLTextBox.Text;

            scraper.Results.Clear();

            //scrape input URL
            scraper.Scrape(url);

            //put results in list box
            ResultsListBox.ItemsSource = scraper.Results;

            //refresh list box
            ResultsListBox.Items.Refresh();
        }

        private void URLTextBox_GotFocus(object sender, RoutedEventArgs e)
        {
            URLTextBox.Clear();
        }

        private void btnClear_Click(object sender, RoutedEventArgs e)
        {
            URLTextBox.Clear();
            URLTextBox.Focus();
        }
    }
}
