using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;

namespace platform.AuthMicroservices.component
{
    /// <summary>
    /// Логика взаимодействия для AuthInput.xaml
    /// </summary>
    public partial class AuthInput : UserControl
    {
        /// <summary>
        /// DependencyProperty зависимость текстовка у label
        /// </summary>
        public static readonly DependencyProperty LabelTextProperty = DependencyProperty.Register(
            "LabelText",
            typeof(string),
            typeof(AuthInput)
        );

        public string LabelText
        {
            get { return (string)GetValue(LabelTextProperty); }
            set { SetValue(LabelTextProperty, value); }
        }

        public string value
        {
            get { return input.Text; }
        }

        /// <summary>
        /// Функция клик на label перенос фокуса на элемент
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void LabelMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Label label = (Label)sender;
            if (e.ClickCount == 1 && label.Target != null)
            {
                Keyboard.Focus(label.Target);
            }
        }

        public AuthInput()
        {
            InitializeComponent();
        }
    }
}
