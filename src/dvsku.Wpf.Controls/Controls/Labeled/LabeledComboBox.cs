using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Input;

namespace dvsku.Wpf.Controls {
    [TemplatePart(Name = "PART_Label", Type = typeof(Border))]
    [TemplatePart(Name = "PART_ToggleButton", Type = typeof(ToggleButton))]
    [StyleTypedProperty(Property = "ItemContainerStyle", StyleTargetType = typeof(ComboBoxItem))]
    public class LabeledComboBox : ComboBox {
        public enum Placement { Top, Left }
        private Border _label;
        private ToggleButton _comboBox;

        static LabeledComboBox() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabeledComboBox), new FrameworkPropertyMetadata(typeof(LabeledComboBox)));

            FocusableProperty.OverrideMetadata(typeof(LabeledComboBox), new FrameworkPropertyMetadata(false));

            KeyboardNavigation.TabNavigationProperty.OverrideMetadata(typeof(LabeledComboBox), new FrameworkPropertyMetadata(KeyboardNavigationMode.Local));
            KeyboardNavigation.ControlTabNavigationProperty.OverrideMetadata(typeof(LabeledComboBox), new FrameworkPropertyMetadata(KeyboardNavigationMode.None));
            KeyboardNavigation.DirectionalNavigationProperty.OverrideMetadata(typeof(LabeledComboBox), new FrameworkPropertyMetadata(KeyboardNavigationMode.None));
        }

        #region LabelContent
        public static readonly DependencyProperty LabelContentProperty =
                DependencyProperty.Register("LabelContent", typeof(object), typeof(LabeledComboBox),
                        new FrameworkPropertyMetadata(null));

        public object LabelContent {
            get => GetValue(LabelContentProperty);
            set => SetValue(LabelContentProperty, value);
        }
        #endregion

        #region LabelContentTemplate
        public static readonly DependencyProperty LabelContentTemplateProperty =
                DependencyProperty.Register("LabelContentTemplate", typeof(DataTemplate), typeof(LabeledComboBox),
                        new FrameworkPropertyMetadata(null));

        [Bindable(true)]
        public DataTemplate LabelContentTemplate {
            get => (DataTemplate)GetValue(LabelContentTemplateProperty);
            set => SetValue(LabelContentTemplateProperty, value);
        }
        #endregion

        #region LabelPlacement
        public static readonly DependencyProperty LabelPlacementProperty =
            DependencyProperty.Register("LabelPlacement", typeof(Placement), typeof(LabeledComboBox),
                new FrameworkPropertyMetadata(Placement.Top));

        public Placement LabelPlacement {
            get => (Placement)GetValue(LabelPlacementProperty);
            set => SetValue(LabelPlacementProperty, value);
        }
        #endregion

        #region ComboBoxHeight
        public static readonly DependencyProperty ComboBoxHeightProperty =
            DependencyProperty.Register("ComboBoxHeight", typeof(double), typeof(LabeledComboBox),
                new FrameworkPropertyMetadata(20.0));

        public double ComboBoxHeight {
            get => (double)GetValue(ComboBoxHeightProperty);
            set => SetValue(ComboBoxHeightProperty, value);
        }
        #endregion

        public override void OnApplyTemplate() {
            base.OnApplyTemplate();

            _label = GetTemplateChild("PART_Label") as Border;
            _comboBox = GetTemplateChild("PART_ToggleButton") as ToggleButton;

            if (_label != null) 
                _label.PreviewMouseDown += OnLabelPreviewMouseDown;
        }

        private void OnLabelPreviewMouseDown(object sender, MouseButtonEventArgs e) {
            if(_comboBox != null)
                _comboBox.Focus();
        }
    }
}