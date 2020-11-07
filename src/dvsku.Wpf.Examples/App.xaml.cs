using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using System.Windows;
using dvsku.Wpf.Themes;

namespace dvsku.Wpf.Examples {
    public partial class App : Application {
        protected override void OnStartup(StartupEventArgs e) {
            base.OnStartup(e);

            ThemeManager.Instance.SetTheme("Dark");
        }
    }
}