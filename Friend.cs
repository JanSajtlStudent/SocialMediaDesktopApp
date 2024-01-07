using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Social_Media
{
    public class Friend
    {
        private int id;
        private string name;
        private string surname;
        private int age;

        public Friend(int id, string name, string surname, int age) 
        {
            this.id = id;
            this.name = name;
            this.surname = surname;
            this.age = age;
        }

        public int Id
        {
            get { return id; }
            set 
            {
                id = value;
                OnPropertyChanged("id");
            }
        }

        public string Name 
        {
            get { return name; }
            set
            {
                name = value;
                OnPropertyChanged("name");
            }
        }

        public string Surname
        {
            get { return surname; }
            set
            {
                surname = value;
                OnPropertyChanged("surname");
            }
        }

        public int Age
        {
            get { return age; }
            set
            {
                age = value;
                OnPropertyChanged("age");
            }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
