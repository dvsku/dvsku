using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Windows;

namespace dvsku.Wpf.Themes {
    public class ThemeManager {
        #region Singleton
        private static readonly Lazy<ThemeManager> _themeManager = new Lazy<ThemeManager>(() => new ThemeManager());
        public static ThemeManager Instance => _themeManager.Value;
        #endregion

        #region Ctor
        private ThemeManager() {
            LoadThemes();
            _readonlyThemes = new ReadOnlyCollection<Theme>(_themes);
        }
        #endregion

        private const string _themesLocation = "pack://application:,,,/dvsku.Wpf.Themes;component/Themes/";
        private List<Theme> _themes;
        private readonly ReadOnlyCollection<Theme> _readonlyThemes;

        public IReadOnlyCollection<Theme> Themes => _readonlyThemes;

        private void LoadThemes() {
            _themes = new List<Theme>();
            // Only changes custom controls
            _themes.Add(new Theme("System", "Default custom controls theme.", new Uri($"{_themesLocation}Theme.System.xaml")));
            // Changes all controls
            _themes.Add(new Theme("Dark", "Inspired by Visual Studio dark theme.", new Uri($"{_themesLocation}Theme.Dark.xaml")));
            // Changes all controls
            _themes.Add(new Theme("Light", "Inspired by Visual Studio light theme.", new Uri($"{_themesLocation}Theme.Light.xaml")));
        }

        public Theme GetTheme(string name) => _readonlyThemes.FirstOrDefault(x => x.Name == name);

        public void SetTheme(string name) => ChangeTheme(GetTheme(name));

        public void SetTheme(Theme theme) => ChangeTheme(theme);

        private const string _templatesSource = "pack://application:,,,/dvsku.Wpf.Controls;component/Theme/Templates.xaml";
        public Theme CurrentTheme { get; private set; }


        private void ChangeTheme(Theme theme) {
            if (theme is null) return;              // Throw exception

            ClearLoadedThemes(Application.Current.Resources.MergedDictionaries);
            ResourceDictionary templatesDictionary = new ResourceDictionary();
            templatesDictionary.Source = new Uri(_templatesSource);
            ResourceDictionary themeDictionary = new ResourceDictionary();
            themeDictionary.Source = theme.Source;

            Application.Current.Resources.MergedDictionaries.Insert(0, templatesDictionary);
            Application.Current.Resources.MergedDictionaries.Insert(1, themeDictionary);
            CurrentTheme = theme;
        }

        private void ClearLoadedThemes(ICollection<ResourceDictionary> resources) {
            if (resources.Count == 0) return;

            List<ResourceDictionary> toRemove = new List<ResourceDictionary>();
            for(int i = 0; i < resources.Count; i++) {
                ResourceDictionary resourceDictionary = resources.ElementAt(i);
                if (_themes.Exists(x => x.Source == resourceDictionary.Source) || resourceDictionary.Source.AbsoluteUri == _templatesSource) {
                    toRemove.Add(resourceDictionary);
                }
                if(resourceDictionary.MergedDictionaries.Count > 0) {
                    ClearLoadedThemes(resourceDictionary.MergedDictionaries);
                }
            }
            toRemove.ForEach((resourceDictionary) => { resources.Remove(resourceDictionary); });
        }
    }
}