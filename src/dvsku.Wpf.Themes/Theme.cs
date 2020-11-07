using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace dvsku.Wpf.Themes {
    public class Theme {
        public string Name { get; }
        public string Description { get; }
        public Uri Source { get; }

        public Theme(string name, string description, Uri source) {
            Name = name;
            Description = description;
            Source = source;
        }
    }
}