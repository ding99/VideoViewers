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

        private void Display(Content content)
        {
            title.Text = content.title;
            runningTime.Text = content.runningTime.ToString();
            bulletText.Text = content.bulletText;
            description.Text = content.description;
            id.Text = content.id;

            StatusSub.Text += " Title# " + (index + 1);
        }

        private void Next_Tapped()
        {
            ;//TODO
        }

        private void Back_Tapped()
        {
            if (Frame.CanGoBack)
                Frame.GoBack();
        }
    }
}
