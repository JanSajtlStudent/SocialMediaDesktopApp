using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;

namespace Social_Media
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public static ViewModel SharedViewModel { get; set; } = new ViewModel();
        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);
            Social_Media.Properties.Settings.Default.Reload();
        }
    }
}
