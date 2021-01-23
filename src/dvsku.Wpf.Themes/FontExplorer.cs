using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Markup;
using System.Windows.Media;

namespace dvsku.Wpf.Themes {
    public class FontExplorer : MarkupExtension {
        public string Key { get; set; }

        private static readonly Dictionary<string, FontFamily> _cachedFonts = new Dictionary<string, FontFamily>();

        static FontExplorer() {
            foreach (FontFamily fontFamily in Fonts.GetFontFamilies(new Uri("pack://application:,,,/dvsku.Wpf.Themes;Component/"), "./Resources/Fonts/")) {
                _cachedFonts.Add(fontFamily.FamilyNames.First().Value, fontFamily);
            }
        }

        public override object ProvideValue(IServiceProvider serviceProvider) {
            return ReadFont();
        }

        private object ReadFont() {
            if (!string.IsNullOrEmpty(Key)) {
                if (_cachedFonts.ContainsKey(Key))
                    return _cachedFonts[Key];
            }

            return SystemFonts.MessageFontFamily;
        }

        public static FontFamily GetFont(string key) {
            if (!string.IsNullOrEmpty(key)) {
                if (_cachedFonts.ContainsKey(key))
                    return _cachedFonts[key];
            }

            return SystemFonts.MessageFontFamily;
        }
       
    }
}
