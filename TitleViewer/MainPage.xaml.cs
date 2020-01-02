using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Windows.Data.Json;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Input;

namespace TitleViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {

        private List<Content> contents;

        public MainPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Sort title list
        /// </summary>
        private void SetSource()
        {
            Titles.ItemsSource = contents = contents.OrderBy(p => p.title).ToList();
            StatusMain.Text = contents.Count().ToString();
        }

        /// <summary>
        /// Response for input endpoint
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private async void Key_Down(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                await GetItems(Input.Text);
            }
        }

        /// <summary>
        /// Jump to title page when a tilte is selected
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Title_Tapped(object sender, TappedRoutedEventArgs e)
        {
            Frame.Navigate(typeof(TitlePage), sender);
        }

        /// <summary>
        /// Get title data via HTTP request
        /// </summary>
        /// <param name="endpoint"></param>
        public async Task GetItems(string endpoint)
        {
            StatusMain.Text = string.Empty;
            string data;

            try
            {
                using (var httpClient = new System.Net.Http.HttpClient())
                {
                    var stream = await httpClient.GetStreamAsync(endpoint);
                    StreamReader reader = new StreamReader(stream);
                    data = reader.ReadToEnd();
                }

            }
            catch (Exception e)
            {
                StatusMain.Text = e.Message;
                return;
            }

            uint i = 0;
            try
            {
                var cont = JsonValue.Parse(data).GetArray();

                contents = new List<Content>();
                for (i = 0; i < cont.Count; i++)
                    contents.Add(new Content(
                        cont.GetObjectAt(i).GetNamedString("title"),
                        cont.GetObjectAt(i).GetNamedString("bulletText"),
                        cont.GetObjectAt(i).GetNamedString("description"),
                        cont.GetObjectAt(i).GetNamedString("id"),
                        (int)cont.GetObjectAt(i).GetNamedNumber("runningTime")));

                SetSource();
            }
            catch (Exception ex)
            {
                StatusMain.Text = "Exception at Title# " + i + ": " + ex.Message;
            }

        }
    }
}
