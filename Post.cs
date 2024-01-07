using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace Social_Media
{
    public class Post : INotifyPropertyChanged
    {
        private int id;
        private string title;
        private string content;
        private string url;
        private DateTime date;
        private ObservableCollection<Friend> friends;

        public Post(int id, string title, string content, string url, ObservableCollection<Friend> friends) {
            this.Id = id;
            this.Title = title;
            this.Content = content;
            this.Url = url;
            this.Date = DateTime.Now;
            this.Friends = friends;
        }

        public int Id
        {
            get => id;
            set
            {
                id = value;
                OnPropertyChanged("Id");
            }
        }

        public string Title
        {
            get => title;
            set
            {
                title = value;
                OnPropertyChanged("Title");
            }
        }

        public string Content
        {
            get => content;
            set
            {
                content = value;
                OnPropertyChanged("Content");
            }
        }

        public string Url
        {
            get => url;
            set
            {
                url = value;
                OnPropertyChanged("Url");
            }
        }

        public DateTime Date
        {
            get => date;
            set
            {
                date = value;
                OnPropertyChanged("Date");
            }
        }

        public ObservableCollection<Friend> Friends
        {
            get => friends;
            set
            {
                friends = value;
                OnPropertyChanged("Friend");
            }
        }

        public string FriendsToString
        {
            get
            {
                if (Friends == null)
                {
                    return "";
                }
                return string.Join(", ", Friends.Select(f => $"{f.Name} {f.Surname}"));
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
