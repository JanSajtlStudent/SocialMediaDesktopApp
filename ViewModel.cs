using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;
using System.Windows.Media;

namespace Social_Media
{
    public class ViewModel : INotifyPropertyChanged
    {
        public ObservableCollection<Post> Posts { get; set; }
        private Post selectedPost;
        private int selectedIndex;

        public ObservableCollection<Friend> Friends { get; set; }
        private Friend selectedFriend;
        private int selectedFriendIndex;

        private UpdatePost updatePost {  get; set; }


        public ICommand AddPostCommand { get; set; }
        public ICommand RemovePostCommand { get; set; }
        public ICommand EditPostCommand { get; set; }

        public ICommand AddFriendCommand { get; set; }
        public ICommand RemoveFriendCommand { get; set; }
        public ICommand EditFriendCommand { get; set; }

        public ViewModel()
        {
            AddPostCommand = new Command(AddPost, CanAddPost);
            RemovePostCommand = new Command(RemovePost, CanAddPost);
            EditPostCommand = new Command(EditPost, CanAddPost);

            AddFriendCommand = new Command(AddFriend, CanAddFriend);
            RemoveFriendCommand = new Command(RemoveFriend, CanAddFriend);
            EditFriendCommand = new Command(EditFriend, CanAddFriend);

            Friends = new ObservableCollection<Friend>
            {
                new Friend(1, "Jaka", "Kekec", 20),
                new Friend(2, "Anej", "Sukič", 20),
                new Friend(3, "Tine", "Založnik", 20)
            };

            Posts = new ObservableCollection<Post>
            {
                new Post(1, "What is Lorem Ipsum?", "Lorem Ipsum is simply dummy text of the printing and typesetting industry. Lorem Ipsum has been the industry's standard dummy text ever since the 1500s, when an unknown printer took a galley of type and scrambled it to make a type specimen book.", "https://i00.eu/img/605/1024x1024/2cj4v0gx/237680.jpg", Friends),
                new Post(2, "Where does it come from?", "Contrary to popular belief, Lorem Ipsum is not simply random text.", "https://www.lifepng.com/wp-content/uploads/2020/09/Black-Cat-Sideview-png-hd.png", Friends),
                new Post(3, "Why do we use it?", "The standard chunk of Lorem Ipsum used since the 1500s is reproduced below for those interested.", "https://www.lifepng.com/wp-content/uploads/2020/09/Black-Cat-Scratching-png-hd.png", Friends)
            };
        }

        public Post SelectedPost
        {
            get 
            {
                return selectedPost;
            }
            set
            {
                selectedPost = value;
                OnPropertyChanged(nameof(SelectedPost));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void AddPost(object obj)
        {
            AddPost addpost = new AddPost(this);
            addpost.ShowDialog();
            //Post post = new Post(4, "New Post", "New Post Conent", "https://www.lifepng.com/wp-content/uploads/2020/09/Black-Cat-Sideview-png-hd.png", new ObservableCollection<string> { "Friend1", "Friend2" });
            //Posts.Add(post);
        }

        private bool CanAddPost(object obj)
        {
            return true;
        }

        private void RemovePost(object obj)
        {
            try
            {
                Posts.Remove(SelectedPost);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Izbran ni noben element!");
            }
            
                
        }

        private void EditPost(object obj)
        {
            if (updatePost == null || !updatePost.IsVisible)
            {
                try
                {
                    updatePost = new UpdatePost(this);
                    updatePost.Topmost = true;
                    updatePost.Show();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    MessageBox.Show("Izbran ni noben element!");
                }
            }
        }

        public Friend SelectedFriend
        {
            get
            {
                return selectedFriend;
            }
            set
            {
                selectedFriend = value;
                OnPropertyChanged(nameof(SelectedFriend));
            }
        }

        public int SelectedFriendIndex
        {
            get
            {
                return selectedFriendIndex;
            }
            set
            {
                selectedFriendIndex = value;
                OnPropertyChanged(nameof(SelectedFriendIndex));
            }
        }

        private bool CanAddFriend(object obj)
        {
            return true;
        }

        private void AddFriend (object obj)
        {
            try
            {
                Friend friend = new Friend(4, SelectedFriend.Name, SelectedFriend.Surname, SelectedFriend.Age);
                Friends.Add(friend);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Izbran ni noben element!");
            }
        }

        private void RemoveFriend (object obj)
        {
            try
            {
                Friends.Remove(SelectedFriend);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Izbran ni noben element!");
            }
        }

        private void EditFriend(object obj)
        {
            try
            {
                SelectedFriend.Name = SelectedFriend.Name;
                SelectedFriend.Surname = SelectedFriend.Surname;
                SelectedFriend.Age = SelectedFriend.Age;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
                MessageBox.Show("Izbran ni noben element!");
            }
        }
    }
}
