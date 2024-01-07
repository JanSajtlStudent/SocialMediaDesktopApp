using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace Social_Media
{
    /// <summary>
    /// Interaction logic for AddPost.xaml
    /// </summary>
    public partial class AddPost : Window
    {
        private ViewModel viewModel;
        public AddPost(ViewModel mainViewModel)
        {
            InitializeComponent();
            viewModel = mainViewModel;
            LVFriends.ItemsSource = viewModel.Friends;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            ObservableCollection<Friend> selectedItems = new ObservableCollection<Friend>();

            foreach (var friend in LVFriends.SelectedItems)
            {
                if (friend is Friend selectedFriend)
                {
                    selectedItems.Add(selectedFriend);
                }
            }

            Post post = new Post(5, TBTitle.Text, TBContent.Text, TBFileName.Text, selectedItems);
            viewModel.Posts.Add(post);
            Close();
        }

        private void PostImg_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            OpenFileDialog openFileDialog = new OpenFileDialog();
            openFileDialog.Filter = "Image files (*.png;*.bmp;*.jpg;*.jpeg)|*.png;*.bmp;*.jpg;*.jpeg";

            bool? result = openFileDialog.ShowDialog();

            if (result == true)
            {
                TBFileName.Text = openFileDialog.FileName;
                BitmapImage bitmapImage = new BitmapImage(new Uri(openFileDialog.FileName));
                PostImg.Source = bitmapImage;
            }
        }
    }
}
