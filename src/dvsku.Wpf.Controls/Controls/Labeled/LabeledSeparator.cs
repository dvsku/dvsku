using System.ComponentModel;
using System.Windows;
using System.Windows.Controls;

namespace dvsku.Wpf.Controls {
    public class LabeledSeparator : Separator {
        static LabeledSeparator() {
            DefaultStyleKeyProperty.OverrideMetadata(typeof(LabeledSeparator), new FrameworkPropertyMetadata(typeof(LabeledSeparator)));
        }

        #region LabelContent
        public static readonly DependencyProperty LabelContentProperty =
                DependencyProperty.Register("LabelContent", typeof(object), typeof(LabeledSeparator),
                        new FrameworkPropertyMetadata(null));

        public object LabelContent {
            get => GetValue(LabelContentProperty);
            set => SetValue(LabelContentProperty, value);
        }
        #endregion

        #region LabelContentTemplate
        public static readonly DependencyProperty LabelContentTemplateProperty =
                DependencyProperty.Register("LabelContentTemplate", typeof(DataTemplate), typeof(LabeledSeparator),
                        new FrameworkPropertyMetadata(null));

        [Bindable(true)]
        public DataTemplate LabelContentTemplate {
            get => (DataTemplate)GetValue(LabelContentTemplateProperty);
            set => SetValue(LabelContentTemplateProperty, value);
        }
        #endregion

        public override void OnApplyTemplate() {
            base.OnApplyTemplate();
        }
    }
}