using Microsoft.Win32;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.Policy;
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
    /// Interaction logic for UpdatePost.xaml
    /// </summary>
    public partial class UpdatePost : Window
    {
        private ViewModel viewModel;
        public UpdatePost(ViewModel mainViewModel)
        {
            InitializeComponent();
            viewModel = mainViewModel;
            this.DataContext = viewModel;
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

            viewModel.SelectedPost.Title = TBTitle.Text;
            viewModel.SelectedPost.Content = TBContent.Text;
            viewModel.SelectedPost.Url = TBFileName.Text;
            viewModel.SelectedPost.Date = DateTime.Now;
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
            }
        }
    }
}
