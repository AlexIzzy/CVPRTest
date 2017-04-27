using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CVPRTest.Models;
using CVPRTest.Views;
using PSC.Xamarin.MvvmHelpers;
using Realms;
using Xamarin.Forms;

namespace CVPRTest.ViewModels
{
    public class FindViewModel : BaseViewModel
    {
        private readonly Realm _realm;
        private Visitor _selectedItem;
        private VisitorListViewModel _visitorListViewModel;

        public ObservableCollection<Visitor> MatchedVisitors { get; set; }
        public VisitorListViewModel ListViewModel
        {
            get { return _visitorListViewModel; }
            set
            {
                if (_visitorListViewModel == value) return;
                _visitorListViewModel = value;
                OnPropertyChanged("ListViewModel");
            }
        }
        public Visitor EnteredVisitor { get; set; }

        public FindViewModel(Visitor enteredVisitor, VisitorListViewModel visitorListVM)
        {
            _realm = RealmHelper.GetRealm();
            FindContactsCommand = new Command<string>(FindContacts);
            EnteredVisitor = enteredVisitor;
            ListViewModel = visitorListVM;
        }

        public Visitor SelectedItem
        {
            get
            {
                return _selectedItem;
            }
            set
            {
                if (_selectedItem == value) return;
                _selectedItem = value;
                OnPropertyChanged(nameof(SelectedItem));
                Add(_selectedItem);
                App.NavigationService.GoBack();
            }
        }

        private void Add(Visitor item)
        {
            _realm.Write(() =>
            {
                int i = EnteredVisitor.AddedVisitors.Count;
                EnteredVisitor.AddedVisitors.Insert(i, item);
                ListViewModel.AddedVisitors = new ObservableCollection<Visitor>(EnteredVisitor.AddedVisitors);
            });
        }
        public ICommand FindContactsCommand { get; protected set; }
        private void FindContacts(string name)
        {
            var queryResult = _realm.All<Visitor>().Where(x => x.Name.Contains(name) && !x.Name.Equals(EnteredVisitor.Name));
            var matchedVisitorsList = new List<Visitor>();
            foreach (var visitor in queryResult)
                if (EnteredVisitor.AddedVisitors.FirstOrDefault(x => x.Name == visitor.Name) == null)
                    matchedVisitorsList.Add(visitor);
            MatchedVisitors = new ObservableCollection<Visitor>(matchedVisitorsList);
        }
    }
}
