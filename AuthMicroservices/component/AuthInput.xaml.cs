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

        /// <summary>
        /// DependencyProperty зависимость текстовка у ошибки обязательное поле
        /// </summary>
        public static readonly DependencyProperty ErrorReqTextProperty = DependencyProperty.Register(
            "ErrorReqText",
            typeof(string),
            typeof(AuthInput)
        );

        public string ErrorReqText
        {
            get { return (string)GetValue(ErrorReqTextProperty); }
            set { SetValue(ErrorReqTextProperty, value); }
        }


        public string value
        {
            get { return Input.Text; }
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

        /// <summary>
        /// Фокус на элемент
        /// 1. обработка обязательности поля
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputFocusableChanged(object sender, RoutedEventArgs e)
        {
            if (Input.Text == "" && ErrorReqText != null)
            {
                TextError.Visibility = Visibility.Visible;
            }
        }

        /// <summary>
        /// изменения значения в элемент
        /// 1. проверяет и скрывает ошибку на обязательность поля если она не актуальна
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputTextChanged(object sender, TextChangedEventArgs e)
        {
            if (Input.Text != "")
            {
                TextError.Visibility = Visibility.Collapsed;
            }

            else if (Input.Text == "" && ErrorReqText != null)
            {
                TextError.Visibility = Visibility.Visible;
            }
        }
    }
}
