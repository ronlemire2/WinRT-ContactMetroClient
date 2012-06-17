using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace ContactMetroClient.ViewModel {
    public class MyCommand<T> : ICommand {
        readonly Action<T> callback;

        public MyCommand(Action<T> callback) {
            this.callback = callback;
        }

        public bool CanExecute(object parameter) {
            return true;
        }

        public event EventHandler CanExecuteChanged;

        public void Execute(object parameter) {
            if (callback != null) { callback((T)parameter); }
        }
    }
}
