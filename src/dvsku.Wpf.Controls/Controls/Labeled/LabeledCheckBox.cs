using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace dvsku.Wpf.Controls {
    [TemplatePart(Name = "LabelElement", Type = typeof(Label))]
    [TemplatePart(Name = "CheckBoxElement", Type = typeof(CheckBox))]
    public class LabeledCheckBox : CheckBox {
        public enum LabelPosition { Left, Right }

        public Label LabelElement { get; private set; }
        public CheckBox CheckBoxElement { get; private set; }

        static LabeledCheckBox() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabeledCheckBox), new FrameworkPropertyMetadata(typeof(LabeledCheckBox)));

            
        }

        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(LabeledCheckBox),
                new FrameworkPropertyMetadata(""));

        public static readonly DependencyProperty LabelPositionProperty =
            DependencyProperty.Register("Position", typeof(LabelPosition), typeof(LabeledCheckBox),
                new FrameworkPropertyMetadata(LabelPosition.Right));

        public string LabelText {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public LabelPosition Position {
            get => (LabelPosition)GetValue(LabelPositionProperty);
            set => SetValue(LabelPositionProperty, value);
        }

        public override void OnApplyTemplate() {
            this.PreviewKeyDown += OnPreviewKeyDown;
            LabelElement = GetTemplateChild("PART_Label") as Label;
            CheckBoxElement = GetTemplateChild("PART_CheckBox") as CheckBox;
            base.OnApplyTemplate();
        }

        private void OnPreviewKeyDown(object sender, KeyEventArgs e) {
            if (IsFocused && e.Key == Key.Enter) {
                IsChecked = !IsChecked;
            }
        }
    }
}