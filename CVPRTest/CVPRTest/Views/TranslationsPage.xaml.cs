using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using CVPRTest.ViewModels;
using Xamarin.Forms;

namespace CVPRTest.Views
{
    public partial class TranslationsPage : ContentPage
    {
        public TranslationsPage(TranslationsViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
        }
    }
}
