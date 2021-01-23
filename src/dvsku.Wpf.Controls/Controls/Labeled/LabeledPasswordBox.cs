using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;
using dvsku.Wpf.Themes;

namespace dvsku.Wpf.Controls {
    [TemplatePart(Name = "PART_Label", Type = typeof(Border))]
    [TemplatePart(Name = "PART_TextBox", Type = typeof(Border))]
    public class LabeledPasswordBox : TextBox {
        public enum Placement { Top, Left }

        private Border _label;
        private Border _textBox;

        static LabeledPasswordBox() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabeledPasswordBox), new FrameworkPropertyMetadata(typeof(LabeledPasswordBox)));
        }

        #region LabelContent
        public static readonly DependencyProperty LabelContentProperty =
                DependencyProperty.Register("LabelContent", typeof(object), typeof(LabeledPasswordBox),
                        new FrameworkPropertyMetadata(null));

        public object LabelContent {
            get => (object)GetValue(LabelContentProperty);
            set => SetValue(LabelContentProperty, value);
        }
        #endregion

        #region LabelContentTemplate
        public static readonly DependencyProperty LabelContentTemplateProperty =
                DependencyProperty.Register("LabelContentTemplate", typeof(DataTemplate), typeof(LabeledPasswordBox),
                        new FrameworkPropertyMetadata(null));

        [Bindable(true)]
        public DataTemplate LabelContentTemplate {
            get => (DataTemplate)GetValue(LabelContentTemplateProperty);
            set => SetValue(LabelContentTemplateProperty, value);
        }
        #endregion

        #region LabelPlacement
        public static readonly DependencyProperty LabelPlacementProperty =
            DependencyProperty.Register("LabelPlacement", typeof(Placement), typeof(LabeledPasswordBox),
                new FrameworkPropertyMetadata(Placement.Top));

        public Placement LabelPlacement {
            get => (Placement)GetValue(LabelPlacementProperty);
            set => SetValue(LabelPlacementProperty, value);
        }
        #endregion

        #region LabelFontFamily
        public static readonly DependencyProperty LabelFontFamilyProperty =
            DependencyProperty.Register("LabelFontFamily", typeof(FontFamily), typeof(LabeledPasswordBox),
                new FrameworkPropertyMetadata(SystemFonts.MessageFontFamily));

        public FontFamily LabelFontFamily {
            get => (FontFamily)GetValue(LabelFontFamilyProperty);
            set => SetValue(LabelFontFamilyProperty, value);
        }
        #endregion

        #region TextBoxHeight
        public static readonly DependencyProperty TextBoxHeightProperty =
            DependencyProperty.Register("TextBoxHeight", typeof(double), typeof(LabeledPasswordBox),
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

            FontFamily = FontExplorer.GetFont("Password");
            InputBindings.Add(new InputBinding(ApplicationCommands.NotACommand, new KeyGesture(Key.C, ModifierKeys.Control)));

            if (_label != null) 
                _label.PreviewMouseDown += OnLabelPreviewMouseDown;
        }

        private void OnLabelPreviewMouseDown(object sender, MouseButtonEventArgs e) {
            if (_textBox != null)
                _textBox.Focus();
        }
    }
}