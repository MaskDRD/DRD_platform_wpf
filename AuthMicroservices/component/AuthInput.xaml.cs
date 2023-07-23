using platform.AuthMicroservices.enums;
using System;
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
        public AuthInput()
        {
            InitializeComponent();
        }

        public static readonly DependencyProperty AuthComponentProperty = DependencyProperty.Register(
            "AuthComponentParams",
            typeof(AuthComponent),
            typeof(AuthInput),
            new PropertyMetadata(AuthComponent.Input)
        );

        public AuthComponent AuthComponentParams
        {
            get { return (AuthComponent)GetValue(AuthComponentProperty); }
            set {  SetValue(AuthComponentProperty, value); }
        }


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

        /// <summary>
        /// Сигнал что нужно проверить валидацию
        /// </summary>
        public void UpdateVisibleTextError()
        {
            TextError.Visibility = Visibility.Visible;
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
        /// <summary>
        /// проверяет и скрывает ошибку на обязательность поля если она не актуальна
        /// </summary>
        /// <param name="val"></param>
        private void ChangedTextError(string val)
         {
            if (val == "" && ErrorReqText != null)
            {
                TextError.Visibility = Visibility.Visible;
                return;
            }
            TextError.Visibility = Visibility.Collapsed;
        }

        /// <summary>
        /// изменения значения в элемент input
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void InputTextChanged(object sender, TextChangedEventArgs e)
        {
            ChangedTextError(Input.Text);
        }

        /// <summary>
        /// Получить значения с input
        /// </summary>
        public string Value
        {
            get {
                if(AuthComponentParams.Equals(AuthComponent.Password))
                {
                    return Password.Password;
                }
                return Input.Text;
            }
        }

        /// <summary>
        /// изменения значения в элемент password
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void PasswordChanged(object sender, RoutedEventArgs e)
        {
            ChangedTextError(Password.Password);
        }

        /// <summary>
        /// Загрузка экрана прошла успешно
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void AuthInputUserComponentLoaded(object sender, RoutedEventArgs e)
        {
            if (AuthComponentParams.Equals(AuthComponent.Input))
            {
                Input.Visibility = Visibility.Visible;
                return;
            }

            if (AuthComponentParams.Equals(AuthComponent.Password))
            {
                Password.Visibility = Visibility.Visible;
            }
        }
    }
}
