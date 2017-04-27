using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVPRTest.Models;
using CVPRTest.ViewModels;
using Realms;
using Xamarin.Forms;

namespace CVPRTest.Views
{
    public partial class FindPage : ContentPage
    {
        public FindPage(Visitor visitor, VisitorListViewModel visitorListVm)
        {
            InitializeComponent();
            var findViewModel = new FindViewModel(visitor, visitorListVm);
            BindingContext = findViewModel;
        }
    }
}
