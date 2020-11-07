using System.Collections.ObjectModel;
using dvsku.Wpf.Themes;
using dvsku.Wpf.ViewModels;

namespace dvsku.Wpf.Examples {
    public class ViewModel : PageViewModel {
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

        public ViewModel() {
            Themes = new ObservableCollection<Theme>(ThemeManager.Instance.Themes);
            SelectedTheme = ThemeManager.Instance.CurrentTheme;
        }

    }
}