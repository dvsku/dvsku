using System.Windows;
using dvsku.Wpf.Examples.ViewModels;

namespace dvsku.Wpf.Examples {
    public partial class MainWindow : Window {
        public MainWindow() {
            InitializeComponent();
            DataContext = new MainWindowViewModel();
        }
    }
}