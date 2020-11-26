using System.Collections.ObjectModel;
using System.ComponentModel;
using dvsku.Wpf.Themes;

namespace dvsku.Wpf.Examples.ViewModels {
    public class MainWindowViewModel : INotifyPropertyChanged {
        public event PropertyChangedEventHandler PropertyChanged;

        private ObservableCollection<Theme> _themes;
        public ObservableCollection<Theme> Themes {
            get => _themes;
            set {
                _themes = value;
                RaisePropertyChanged(nameof(Themes));
            }
        }
        private Theme _selectedTheme;
        public Theme SelectedTheme {
            get => _selectedTheme;
            set {
                _selectedTheme = value;
                ThemeManager.Instance.SetTheme(_selectedTheme);
                RaisePropertyChanged(nameof(SelectedTheme));
            }
        }

        public MainWindowViewModel() {
            ThemeManager.Instance.SetTheme("System");
            Themes = new ObservableCollection<Theme>(ThemeManager.Instance.Themes);
            SelectedTheme = ThemeManager.Instance.CurrentTheme;
        }

        public void RaisePropertyChanged(string property) {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(property));
        }
    }
}