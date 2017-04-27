using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
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
    public class VisitorViewModel : BaseViewModel
    {
        private readonly Realm _realm = RealmHelper.GetRealm();

        public Visitor ChatVisitor { get; }
        public Visitor EnteredVisitor { get; }
        public ObservableCollection<Message> Messages { get; set; }

        public VisitorViewModel(Visitor chatVisitor, Visitor enteredVisitor)
        {
            ChatVisitor = chatVisitor;
            EnteredVisitor = enteredVisitor;
            var result = _realm.All<Message>().Where(x => (x.Sender == chatVisitor && x.Reciever == enteredVisitor)
                                                          || (x.Sender == enteredVisitor && x.Reciever == chatVisitor));
            _realm.Write(() =>
            {
                foreach (var message in result)
                {
                    var sender = message.Sender;
                    message.IsSent = sender.Equals(enteredVisitor);
                }
            });
            Messages = new ObservableCollection<Message>(result);
            SendMessageCommand = new Command<string>(SendMessage);
        }

        public string Name { get; set; }

        public string Id { get; set; }

        public string Email { get; set; }
        
        public ICommand SendMessageCommand { protected set; get; }

        private void SendMessage(string text)
        {
            // Работает только синхронный вариант
            // Асинхронный по прежнему выдает исключение
            // Realms.Exceptions.RealmObjectManagedByAnotherRealmException
            _realm.Write(() =>
            {
                var enteredVisitor = _realm.Find<Visitor>(EnteredVisitor.Id);
                var chatVisitor = _realm.Find<Visitor>(ChatVisitor.Id);
                var newMessage = new Message
                {
                    MessageText = text,
                    ID = Guid.NewGuid().ToString(),
                    MessageDateTime = DateTimeOffset.Now,
                    Sender = enteredVisitor,
                    Reciever = chatVisitor,
                    IsSent = true
                };
                _realm.Add(newMessage);
                Messages.Add(newMessage);
            });
        }
    }
}
