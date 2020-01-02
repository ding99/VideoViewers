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

// The Blank Page item template is documented at https://go.microsoft.com/fwlink/?LinkId=234238

namespace TitleViewer
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class TitlePage : Page
    {
        private List<Content> contents;
        private int index;

        public TitlePage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Display details for one title and title index
        /// </summary>
        /// <param name="content">title details to view</param>
        private void Display(Content content)
        {
            title.Text = content.title;
            runningTime.Text = content.runningTime.ToString();
            bulletText.Text = content.bulletText;
            description.Text = content.description;
            id.Text = content.id;

            StatusSub.Text = " Title# " + (index + 1);
        }

        /// <summary>
        /// Switch to next title, or warn the last title
        /// </summary>
        private void Next_Tapped()
        {
            if (index + 1 < contents.Count)
                Display(contents[++index]);
            else
                StatusSub.Text = "Already the last title!";
        }

        /// <summary>
        /// Go back to main page
        /// </summary>
        private void Back_Tapped()
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }

        /// <summary>
        /// Receive selected selected data
        /// </summary>
        /// <param name="e"></param>
        protected override void OnNavigatedTo(NavigationEventArgs e)
        {
            ListView view = e.Parameter as ListView;

            contents = view.Items.Cast<Content>().ToList();
            index = view.SelectedIndex;

            Display((Content)view.SelectedItem);

            base.OnNavigatedTo(e);
        }
    }
}
