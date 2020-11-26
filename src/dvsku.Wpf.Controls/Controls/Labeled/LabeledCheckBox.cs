using System;
using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace dvsku.Wpf.Controls {
    public class LabeledCheckBox : CheckBox {
        public enum Placement { Left, Right }

        static LabeledCheckBox() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabeledCheckBox), new FrameworkPropertyMetadata(typeof(LabeledCheckBox)));
        }

        #region LabelContent
        public static readonly DependencyProperty LabelContentProperty =
                DependencyProperty.Register("LabelContent", typeof(object), typeof(LabeledCheckBox),
                        new FrameworkPropertyMetadata(null));

        public object LabelContent {
            get => GetValue(LabelContentProperty);
            set => SetValue(LabelContentProperty, value);
        }
        #endregion

        #region LabelContentTemplate
        public static readonly DependencyProperty LabelContentTemplateProperty =
                DependencyProperty.Register("LabelContentTemplate", typeof(DataTemplate), typeof(LabeledCheckBox),
                        new FrameworkPropertyMetadata(null));

        [Bindable(true)]
        public DataTemplate LabelContentTemplate {
            get => (DataTemplate)GetValue(LabelContentTemplateProperty);
            set => SetValue(LabelContentTemplateProperty, value);
        }
        #endregion

        #region LabelPlacement
        public static readonly DependencyProperty LabelPlacementProperty =
            DependencyProperty.Register("LabelPlacement", typeof(Placement), typeof(LabeledCheckBox),
                new FrameworkPropertyMetadata(Placement.Right));

        public Placement LabelPlacement {
            get => (Placement)GetValue(LabelPlacementProperty);
            set => SetValue(LabelPlacementProperty, value);
        }
        #endregion

        #region TextBoxHeight
        public static readonly DependencyProperty TextBoxHeightProperty =
            DependencyProperty.Register("TextBoxHeight", typeof(double), typeof(LabeledCheckBox),
                new FrameworkPropertyMetadata(20.0));

        public double TextBoxHeight {
            get => (double)GetValue(TextBoxHeightProperty);
            set => SetValue(TextBoxHeightProperty, value);
        }
        #endregion

        public override void OnApplyTemplate() {
            base.OnApplyTemplate();

            PreviewKeyDown += OnPreviewKeyDown;
        }

        private void OnPreviewKeyDown(object sender, KeyEventArgs e) {
            if (IsFocused && e.Key == Key.Enter)
                IsChecked = !IsChecked;
        }
    }
}