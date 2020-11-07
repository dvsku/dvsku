using System.Windows;
using System.Windows.Controls;

namespace dvsku.Wpf.Controls {
    public class LabeledSeparator : Separator {
        static LabeledSeparator() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabeledSeparator), new FrameworkPropertyMetadata(typeof(LabeledSeparator)));
        }

        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(LabeledSeparator),
                new FrameworkPropertyMetadata(""));

        public string LabelText {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public override void OnApplyTemplate() {
            base.OnApplyTemplate();
        }
    }
}