using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace dvsku.Wpf.Controls {
    [TemplatePart(Name = "PART_Label", Type = typeof(Border))]
    [TemplatePart(Name = "PART_ToggleButton", Type = typeof(ToggleButton))]
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(ComboBoxItem))]
    public class LabeledComboBox : ComboBox {
        public enum LabelPosition { Top, Left }

        public Border Label { get; private set; }
        public ToggleButton ComboBox { get; private set; }

        static LabeledComboBox() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabeledComboBox), new FrameworkPropertyMetadata(typeof(LabeledComboBox)));

            FocusableProperty.OverrideMetadata(typeof(LabeledComboBox), new FrameworkPropertyMetadata(false));

            KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof(LabeledComboBox), new FrameworkPropertyMetadata(KeyboardNavigationMode.Local));
            KeyboardNavigation.ControlTabNavigationProperty.OverrideMetadata(typeof(LabeledComboBox), new FrameworkPropertyMetadata(KeyboardNavigationMode.None));
            KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(typeof(LabeledComboBox), new FrameworkPropertyMetadata(KeyboardNavigationMode.None));
        }

        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(LabeledComboBox),
                new FrameworkPropertyMetadata(""));

        public static readonly DependencyProperty LabelPositionProperty =
            DependencyProperty.Register("Position", typeof(LabelPosition), typeof(LabeledComboBox),
                new FrameworkPropertyMetadata(LabelPosition.Top, null));

        public static readonly DependencyProperty ComboBoxHeightProperty =
            DependencyProperty.Register("ComboBoxHeight", typeof(double), typeof(LabeledComboBox),
                new FrameworkPropertyMetadata(20.0));

        public string LabelText {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public LabelPosition Position {
            get => (LabelPosition)GetValue(LabelPositionProperty);
            set => SetValue(LabelPositionProperty, value);
        }

        public double ComboBoxHeight {
            get => (double)GetValue(ComboBoxHeightProperty);
            set => SetValue(ComboBoxHeightProperty, value);
        }

        public override void OnApplyTemplate() {
            base.OnApplyTemplate();

            Label = GetTemplateChild("PART_Label") as Border;
            ComboBox = GetTemplateChild("PART_ToggleButton") as ToggleButton;

            if (Label != null) {
                Label.PreviewMouseDown += OnLabelPreviewMouseDown;
            }
        }

        private void OnLabelPreviewMouseDown(object sender, MouseButtonEventArgs e) {
            ComboBox.Focus();
        }
    }
}