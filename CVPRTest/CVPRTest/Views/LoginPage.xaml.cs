using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CVPRTest.Helpers;
using CVPRTest.Models;
using CVPRTest.ViewModels;
using Xamarin.Forms;

namespace CVPRTest.Views
{
    public partial class LoginPage : ContentPage
    {
        private void Submit(object sender, EventArgs e)
        {
            var realm = RealmHelper.GetRealm();
            var visitor = realm.All<Visitor>().FirstOrDefault(x => x.Name.Equals(logEntry.Text.Trim())
                                                                   && x.Password.Equals(passEntry.Text.Trim()));
            if (visitor != null)
            {
                App.NavigationService.NavigateTo(Locator.VisitorListPage, new object[] { visitor });
                //App.NavigationService.NavigateTo(Locator.MainAppPage, new object[] {visitor, new TranslationsViewModel()});
            }

            else
                DisplayAlert("Error!", "User doesn't exist!", "OK");
        }
        public LoginPage()
        {
            InitializeComponent();
        }
    }
}
