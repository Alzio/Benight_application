using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using System.Windows.Data;
using Microsoft.Phone.Controls;
using Microsoft.Phone.Shell;
using System.Data.Linq;
using Parse;
using System.Collections.ObjectModel;
using System.Runtime.CompilerServices;
using System.ComponentModel;

namespace Benight_application
{
    public partial class Overview : PhoneApplicationPage
    {
        private MyParseUsersData parseUserData;
        private MyParseEventData parseEventData;
        public ObservableCollection<string> listEvent { get; set; }
        public IEnumerable<ParseObject> ResultsEvent { get; set; }
        List<string> _events = new List<string>();

        public Overview()
        {
            DataContext = this;

            
            InitializeComponent();

            parseUserData = new MyParseUsersData { userPseudo = ParseUser.CurrentUser.Username.ToString()};
            DataContext = parseUserData;

            //ListEvent = App.CustomNavigationService.data as ObservableCollection<string>;

            
            List_Events();            
            //parseEventData = new MyParseEventData { eventName = TodoEv.My_EventName };
        }


        private async void List_Events()
        {
            //var queryEvent = ParseObject.GetQuery("Event");
            //ResultsEvent = await queryEvent.FindAsync();

            //EventListBox.ItemsSource = ResultsEvent;

            var query = from name in ParseObject.GetQuery(TodoEv.ClassName)
                        orderby name.CreatedAt
                        select name;
            ResultsEvent = await query.FindAsync();
            EventListBox.ItemsSource = ResultsEvent;


            //try
            //{
            //    var allItems = from item in await query.FindAsync()
            //                   select new TodoEv(item);
            //    var itemList = new ObservableCollection<TodoEv>(allItems);
            //    EventListBox.ItemsSource = ResultsEvent;
            //}
            //catch (Exception e)
            //{
            //    MessageBox.Show("Erreur:\n" + e);
            //}
        }
        private void ButtonLogOut_Click(object sender, RoutedEventArgs e)
        {
            ParseUser.LogOut();
            NavigationService.Navigate(new Uri("/MainPage.xaml", UriKind.Relative));
        }
    }
}