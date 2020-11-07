using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace dvsku.Wpf.Controls {
    [TemplatePart(Name = "PART_Label", Type = typeof(Border))]
    [TemplatePart(Name = "PART_TextBox", Type = typeof(Border))]
    public class LabeledTextBox : TextBox {
        public enum LabelPosition { Top, Left }

        public Label Label { get; private set; }
        public TextBox TextBox { get; private set; }

        static LabeledTextBox() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabeledTextBox), new FrameworkPropertyMetadata(typeof(LabeledTextBox)));
        }

        public static readonly DependencyProperty LabelTextProperty =
            DependencyProperty.Register("LabelText", typeof(string), typeof(LabeledTextBox),
                new FrameworkPropertyMetadata(""));

        public static readonly DependencyProperty LabelPositionProperty =
            DependencyProperty.Register("Position", typeof(LabelPosition), typeof(LabeledTextBox),
                new FrameworkPropertyMetadata(LabelPosition.Top, null));

        public static readonly DependencyProperty TextBoxHeightProperty =
            DependencyProperty.Register("TextBoxHeight", typeof(double), typeof(LabeledTextBox),
                new FrameworkPropertyMetadata(20.0));

        public string LabelText {
            get => (string)GetValue(LabelTextProperty);
            set => SetValue(LabelTextProperty, value);
        }

        public LabelPosition Position {
            get => (LabelPosition)GetValue(LabelPositionProperty);
            set => SetValue(LabelPositionProperty, value);
        }

        public double TextBoxHeight {
            get => (double)GetValue(TextBoxHeightProperty);
            set => SetValue(TextBoxHeightProperty, value);
        }

        public override void OnApplyTemplate() {
            base.OnApplyTemplate();

            Label = GetTemplateChild("PART_Label") as Label;
            TextBox = GetTemplateChild("PART_TextBox") as TextBox;

            if(Label != null) {
                Label.PreviewMouseDown += OnLabelPreviewMouseDown;
            }
        }

        private void OnLabelPreviewMouseDown(object sender, MouseButtonEventArgs e) {
            if (TextBox == null) return;
            TextBox.Focus();
        }
    }
}