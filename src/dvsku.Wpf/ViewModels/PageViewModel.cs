using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvsku.Wpf.ViewModels {
    public abstract class PageViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        public PageViewModel() {
            InitCommands();
        }

        protected virtual void InitCommands() { }

        public void RaisePropertyChanged(string property) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}