using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using CVPRTest.Helpers;
using CVPRTest.Models;
using PSC.Xamarin.MvvmHelpers;
using Realms;
using Xamarin.Forms;

namespace CVPRTest.ViewModels
{
    public class TranslationsViewModel : BaseViewModel
    {
        private readonly Realm _realm = RealmHelper.GetRealm();
        private Translation _selectedTranslation;

        public string TranslationSource { get; set; }
        public ObservableCollection<Translation> Translations { get; set; }
        public Translation SelectedTranslation
        {
            get { return _selectedTranslation; }
            set
            {
                if (_selectedTranslation == value) return;
                var tempTranslation = value;
                _selectedTranslation = null;
                OnPropertyChanged(nameof(SelectedTranslation));
                PlayPause(tempTranslation.Url);
            }
        }
        public TranslationsViewModel()
        {
            var queryResult = _realm.All<Translation>();
            Translations = new ObservableCollection<Translation>(queryResult);
            TranslationSource = Translations[0].Url;
            PlayPauseCommand = new Command<string>(PlayPause);
            StopCommand = new Command(Stop);
        }
        public ICommand PlayPauseCommand { get; protected set; }

        private void PlayPause(string url)
        {
            DependencyService.Get<IAudio>().Play_Pause(url);
        }
        public ICommand StopCommand { get; protected set; }

        private void Stop()
        {
            DependencyService.Get<IAudio>().Stop(true);
        }
    }
}
