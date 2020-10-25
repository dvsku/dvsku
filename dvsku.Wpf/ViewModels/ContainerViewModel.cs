using System.Collections.ObjectModel;
using System.Windows.Input;
using dvsku.Wpf.Commands;

namespace dvsku.Wpf.ViewModels {
    public abstract class ContainerViewModel : PageViewModel {
        protected ObservableCollection<PageViewModel> _views;
        protected PageViewModel _currentView;

        public ObservableCollection<PageViewModel> Views {
            get {
                return _views;
            }
            set {
                _views = value;
                RaisePropertyChanged(nameof(Views));
            }
        }
        public PageViewModel CurrentView {
            get {
                return _currentView;
            }
            set {
                _currentView = value;
                RaisePropertyChanged(nameof(CurrentView));
            }
        }

        public ICommand ChangeView { get; set; }

        public ContainerViewModel() : base() {
            Views = new ObservableCollection<PageViewModel>();
        }

        protected override void InitCommands() {
            ChangeView = new ParameterisedCommand<PageViewModel>((view) => ExecuteChangeView(view));
            base.InitCommands();
        }

        protected abstract void ExecuteChangeView(PageViewModel view);
    }
}