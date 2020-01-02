using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

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

            contents = new List<Content> {
                new Content("Title1", "Bullet1", "Description1", "A1", 10),
                new Content("Zitle2", "Bullet2", "Description2", "A2", 20),
                new Content("Title3", "Bullet3", "Description3", "A3", 30),
                new Content("Title4", "Bullet4", "Description4", "A4", 40),
                new Content("Title5", "Bullet5", "Description5", "A5", 50)
            };

            SetSource();
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
        private void Key_Down(object sender, KeyRoutedEventArgs e)
        {
            if (e.Key == Windows.System.VirtualKey.Enter)
            {
                GetItems(Input.Text);
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

        public void GetItems(string endpoint)
        {
            contents = new List<Content> {
                new Content("New Title1", "Bullet1", "Description1", "A1", 10),
                new Content("New Title2", "Bullet2", "Description2", "A2", 20),
                new Content("New Title3", "Bullet3", "Description3", "A3", 30),
                new Content("New Title4", "Bullet4", "Description4", "A4", 40),
                new Content("New Title5", "Bullet5", "Description5", "A5", 50),
                new Content("New Title6", "Bullet6", "Description6", "A5", 60),
                new Content("New Title7", "Bullet7", "Description7", "A5", 70)
            };

            SetSource();
        }
    }
}
