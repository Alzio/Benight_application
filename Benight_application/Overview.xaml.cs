using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using Parse;

namespace Benight_application
{
    public partial class Overview : PhoneApplicationPage
    {
        //public ParseUsersData parseUserDt;
        public Overview()
        {
            InitializeComponent();

            //var user = new ParseUser();
            //string uName = user.Username;
            //parseUserDt = new ParseUsersData { userPseudo = uName };
            //this.DataContext = parseUserDt;
        }

        private void ButtonLogOut_Click(object sender, RoutedEventArgs e)
        {
            ParseUser.LogOut();
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}