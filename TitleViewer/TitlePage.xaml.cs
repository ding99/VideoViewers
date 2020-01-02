using System.Collections.Generic;
using System.Linq;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Navigation;

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
