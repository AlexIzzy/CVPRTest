using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CVPRTest.Helpers;
using CVPRTest.Models;
using CVPRTest.Views;
using PSC.Xamarin.MvvmHelpers;
using Realms;
using Xamarin.Forms;

namespace CVPRTest.ViewModels
{
    public class VisitorListViewModel : BaseViewModel
    {
        private Visitor _selectedSpeaker;
        public ObservableCollection<Visitor> AddedVisitors { get; set; }

        public Visitor EnteredVisitor { get; set; }

        public VisitorListViewModel(Visitor enteredVisitor)
        {
            EnteredVisitor = enteredVisitor;
            AddedVisitors = new ObservableCollection<Visitor>(enteredVisitor.AddedVisitors);
            FindContactsCommand = new Command(FindContacts);
            GetTranslationsCommand = new Command(GetTranslations);
        }

        public Visitor SelectedSpeaker
        {
            get { return _selectedSpeaker; }
            set
            {
                if (_selectedSpeaker == value) return;
                var enteredVisitor = EnteredVisitor;
                var tempSpeaker = value;
                _selectedSpeaker = null;
                OnPropertyChanged("SelectedSpeaker");
                App.NavigationService.NavigateTo(Locator.VisitorPage, new object[]{ new VisitorViewModel(tempSpeaker,enteredVisitor)});
            }
        }
        public ICommand FindContactsCommand { protected set; get; }
        private void FindContacts()
        {
            App.NavigationService.NavigateTo(Locator.FindPage, new object[] { EnteredVisitor, this});
        }
        public  ICommand GetTranslationsCommand { get; protected set; }

        private void GetTranslations()
        {
            App.NavigationService.NavigateTo(Locator.TranslationsPage, new object[] {new TranslationsViewModel()});
        }
    }
}
