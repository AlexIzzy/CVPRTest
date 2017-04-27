using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using CVPRTest.Helpers;
using CVPRTest.Models;
using CVPRTest.ViewModels;
using CVPRTest.Views;
using Realms;
using Xamarin.Forms;

namespace CVPRTest
{
    public partial class App : Application
    {
        private Realm _realm;
        public static NavigationService NavigationService { get; private set; }

        public App()
        {
            InitializeComponent();
             NavigationService = new NavigationService();
             NavigationService.Configure(Locator.LoginPage, typeof(LoginPage));
             NavigationService.Configure(Locator.FindPage, typeof(FindPage));
             NavigationService.Configure(Locator.TranslationsPage, typeof(TranslationsPage));
             NavigationService.Configure(Locator.VisitorListPage, typeof(VisitorListPage));
             NavigationService.Configure(Locator.VisitorPage, typeof(SpeakerPage));
             NavigationService.Configure(Locator.MainAppPage, typeof(MainAppPage));

             var startPage = new NavigationPage(new LoginPage());
             NavigationService.Initialize(startPage);
             MainPage = startPage;
        }


        protected override void OnStart()
        {
            _realm = RealmHelper.GetRealm();
            _realm.Write(() =>
            {
                _realm.RemoveAll();
            });
            _realm.Write(() =>
            {
                var speaker1 = new Visitor
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Visitor1",
                    Email = "vis1@mail.com",
                    Password = "pass1"
                };
                _realm.Add(speaker1);
                var speaker2 = new Visitor
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Visitor2",
                    Email = "vis2@mail.com",
                    Password = "pass2"
                };
                _realm.Add(speaker2);
                var speaker3 = _realm.Add(new Visitor
                {
                    Id = Guid.NewGuid().ToString(),
                    Name = "Visitor3",
                    Email = "vis3@mail.com",
                    Password = "pass3"
                });
                var message1 = _realm.Add(new Message
                {
                    ID = Guid.NewGuid().ToString(),
                    MessageDateTime = new DateTimeOffset(DateTime.Parse("12:30")),
                    MessageText = "Test message 1",
                    Sender = speaker1,
                    Reciever = speaker2
                });
                var message2 = _realm.Add(new Message
                {
                    ID = Guid.NewGuid().ToString(),
                    MessageDateTime = new DateTimeOffset(DateTime.Parse("13:30")),
                    MessageText = "Test message 2",
                    Sender = speaker2,
                    Reciever = speaker3
                });
                var message3 = _realm.Add(new Message
                {
                    ID = Guid.NewGuid().ToString(),
                    MessageDateTime = new DateTimeOffset(DateTime.Parse("11:30")),
                    MessageText = "Test message 3",
                    Sender = speaker3,
                    Reciever = speaker1
                });
                var myTranslation = new Translation()
                {
                    Id = Guid.NewGuid().ToString(),
                    Url = "http://edge.mixlr.com/channel/nikqs",
                    Name = "Test Translation"
                };
                _realm.Add(myTranslation);
                speaker1.AddedVisitors.Add(speaker2);
                speaker1.AddedVisitors.Add(speaker3);
                speaker2.AddedVisitors.Add(speaker1);
                speaker3.AddedVisitors.Add(speaker1);
            });
            _realm.Dispose();

        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
