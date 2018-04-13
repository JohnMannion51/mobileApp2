using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using UWPSoundboard.Model;
using Windows.Foundation;
using Windows.Foundation.Collections;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Windows.UI.Xaml.Controls.Primitives;
using Windows.UI.Xaml.Data;
using Windows.UI.Xaml.Input;
using Windows.UI.Xaml.Media;
using Windows.UI.Xaml.Navigation;

// The Blank Page item template is documented at http://go.microsoft.com/fwlink/?LinkId=402352&clcid=0x409

namespace UWPSoundboard
{
    /// <summary>
    /// An empty page that can be used on its own or navigated to within a Frame.
    /// </summary>
    public sealed partial class MainPage : Page
    {
        private ObservableCollection<Sound> Sounds;

        private List<MenuItem> MenuItems;
        public MainPage()
        {
            this.InitializeComponent();
            Sounds = new ObservableCollection<Sound>();
            SoundManager.GetAllSounds(Sounds);
            // calls the sounds from the soundManager
            MenuItems = new List<MenuItem>();
            // adds menu items and icons to the app using categories
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/teams.png", Category = SoundCategory.Teams });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/taunt.png", Category = SoundCategory.Chants });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/manager.png", Category = SoundCategory.Managers });
            MenuItems.Add(new MenuItem { IconFile = "Assets/Icons/fans.png", Category = SoundCategory.Other });
            // hides the back button on start up
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void HamburgerButton_Click(object sender, RoutedEventArgs e)
        {
            MySplitView.IsPaneOpen = !MySplitView.IsPaneOpen;
        }

        private void BackButton_Click(object sender, RoutedEventArgs e)
        { 
            //displays all the sounds on the when the back button is clicked
            SoundManager.GetAllSounds(Sounds);
            // text dislayed on screen
            CategoryTextBlock.Text = "All Sounds";
            MenuItemsListView.SelectedItem = null;
            // hides the back button on start up
            BackButton.Visibility = Visibility.Collapsed;
        }

        private void MenuItemsListView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var menuItem = (MenuItem)e.ClickedItem;

            // Filter on category
            CategoryTextBlock.Text = menuItem.Category.ToString();
            // groups each menu item by category
            SoundManager.GetSoundsByCategory(Sounds, menuItem.Category);
            // back button becomes visible
            BackButton.Visibility = Visibility.Visible;
        }

        private void SoungGridView_ItemClick(object sender, ItemClickEventArgs e)
        {
            var sound = (Sound)e.ClickedItem;
            // sets the path to the audio file
            MyMediaElement.Source = new Uri(this.BaseUri, sound.AudioFile);

        }
    }
}
