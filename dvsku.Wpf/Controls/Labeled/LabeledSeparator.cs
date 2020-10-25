using System.Windows;
using System.Windows.Controls;

namespace dvsku.Controls {
    [TemplatePart(Name = "LabelElement", Type = typeof(Label))]
    [TemplatePart(Name = "SeparatorElement", Type = typeof(Separator))]
    public class LabeledSeparator : Control {
        public Label LabelElement { get; private set; }
        public Separator SeparatorElement { get; private set; }

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
            LabelElement = GetTemplateChild("PART_Label") as Label;
            SeparatorElement = GetTemplateChild("PART_Seperator") as Separator;
            base.OnApplyTemplate();
        }
    }
}