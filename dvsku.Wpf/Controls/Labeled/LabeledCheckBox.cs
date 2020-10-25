using System.Windows;
using System.Windows.Controls;

namespace dvsku.Controls {
    [TemplatePart(Name = "LabelElement", Type = typeof(Label))]
    [TemplatePart(Name = "CheckBoxElement", Type = typeof(CheckBox))]
    public class LabeledCheckBox : Control {
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

        public static readonly DependencyProperty IsCheckedProperty =
            DependencyProperty.Register("IsChecked", typeof(bool), typeof(LabeledCheckBox),
                new FrameworkPropertyMetadata(false, FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public bool IsChecked {
            get => (bool)GetValue(IsCheckedProperty);
            set => SetValue(IsCheckedProperty, value);
        }

        public override void OnApplyTemplate() {
            LabelElement = GetTemplateChild("PART_Label") as Label;
            CheckBoxElement = GetTemplateChild("PART_CheckBox") as CheckBox;
            base.OnApplyTemplate();
        }
    }
}