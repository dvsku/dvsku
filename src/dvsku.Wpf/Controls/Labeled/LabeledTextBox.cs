using System.Windows;
using System.Windows.Controls;

namespace dvsku.Controls {
    [TemplatePart(Name = "LabelElement", Type = typeof(Label))]
    [TemplatePart(Name = "TextBoxElement", Type = typeof(TextBox))]
    public class LabeledTextBox : Control {
        public enum LabelPosition { Top, Left }

        public Label LabelElement { get; private set; }
        public TextBox TextBoxElement { get; private set; }

        static LabeledTextBox() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabeledTextBox), new FrameworkPropertyMetadata(typeof(LabeledTextBox)));
        }

        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(LabeledTextBox),
                new FrameworkPropertyMetadata(""));

        public static readonly DependencyProperty LabelPositionProperty =
            DependencyProperty.Register("Position", typeof(LabelPosition), typeof(LabeledTextBox),
                new FrameworkPropertyMetadata(LabelPosition.Top, null));

        public string LabelText {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public LabelPosition Position {
            get => (LabelPosition)GetValue(LabelPositionProperty);
            set => SetValue(LabelPositionProperty, value);
        }

        public static readonly DependencyProperty TextBoxTextProperty =
            DependencyProperty.Register("Text", typeof(string), typeof(LabeledTextBox),
                new FrameworkPropertyMetadata("", FrameworkPropertyMetadataOptions.BindsTwoWayByDefault));

        public string Text {
            get => (string)GetValue(TextBoxTextProperty);
            set => SetValue(TextBoxTextProperty, value);
        }

        public override void OnApplyTemplate() {
            LabelElement = GetTemplateChild("PART_Label") as Label;
            TextBoxElement = GetTemplateChild("PART_TextBox") as TextBox;
            base.OnApplyTemplate();
        }
    }
}