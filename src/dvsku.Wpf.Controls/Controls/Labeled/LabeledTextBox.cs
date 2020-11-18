using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace dvsku.Wpf.Controls {
    [TemplatePart(Name = "PART_Label", Type = typeof(Border))]
    [TemplatePart(Name = "PART_TextBox", Type = typeof(Border))]
    public class LabeledTextBox : TextBox {
        public enum Placement { Top, Left }

        private Border _label;
        private Border _textBox;

        static LabeledTextBox() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabeledTextBox), new FrameworkPropertyMetadata(typeof(LabeledTextBox)));
        }

        #region LabelContent
        public static readonly DependencyProperty LabelContentProperty =
                DependencyProperty.Register("LabelContent", typeof(object), typeof(LabeledTextBox),
                        new FrameworkPropertyMetadata(null));

        public object LabelContent {
            get => (object)GetValue(LabelContentProperty);
            set => SetValue(LabelContentProperty, value);
        }
        #endregion

        #region LabelContentTemplate
        public static readonly DependencyProperty LabelContentTemplateProperty =
                DependencyProperty.Register("LabelContentTemplate", typeof(DataTemplate), typeof(LabeledTextBox),
                        new FrameworkPropertyMetadata(null));

        [Bindable(true)]
        public DataTemplate LabelContentTemplate {
            get => (DataTemplate)GetValue(LabelContentTemplateProperty);
            set => SetValue(LabelContentTemplateProperty, value);
        }
        #endregion

        #region LabelPlacement
        public static readonly DependencyProperty LabelPlacementProperty =
            DependencyProperty.Register("LabelPlacement", typeof(Placement), typeof(LabeledTextBox),
                new FrameworkPropertyMetadata(Placement.Top));

        public Placement LabelPlacement {
            get => (Placement)GetValue(LabelPlacementProperty);
            set => SetValue(LabelPlacementProperty, value);
        }
        #endregion

        #region TextBoxHeight
        public static readonly DependencyProperty TextBoxHeightProperty =
            DependencyProperty.Register("TextBoxHeight", typeof(double), typeof(LabeledTextBox),
                new FrameworkPropertyMetadata(20.0));

        public double TextBoxHeight {
            get => (double)GetValue(TextBoxHeightProperty);
            set => SetValue(TextBoxHeightProperty, value);
        }
        #endregion

        public override void OnApplyTemplate() {
            base.OnApplyTemplate();

            _label = GetTemplateChild("PART_Label") as Border;
            _textBox = GetTemplateChild("PART_TextBox") as Border;

            if(_label != null) 
                _label.PreviewMouseDown += OnLabelPreviewMouseDown;
        }

        private void OnLabelPreviewMouseDown(object sender, MouseButtonEventArgs e) {
            if (_textBox != null)
                _textBox.Focus();
        }
    }
}