using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVPRTest.Models;
using CVPRTest.ViewModels;
using Xamarin.Forms;

namespace CVPRTest.Views
{
    public partial class VisitorListPage : ContentPage
    {
        public VisitorListPage(Visitor visitor)
        {
            InitializeComponent();
            var visitorVm = new VisitorListViewModel(visitor);
            BindingContext = visitorVm;

        }
    }
}
