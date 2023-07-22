using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Media;

namespace platform.AuthMicroservices.view
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }


        private void LabelMouseLeftButtonUp(object sender, MouseButtonEventArgs e)
        {
            Label label = (Label)sender;
            if (e.ClickCount == 1 && label.Target != null)
            {
                Keyboard.Focus(label.Target);
            }
        }

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
            if(InputLogin.Text == "")
            {
                TextErrorNullLogin.Visibility = Visibility.Visible;
            }

            if(InputPassword.Password == "") { 
                TextErrorNullPassword.Visibility = Visibility.Visible;
            }
        }

        private void InputLoginFocusableChanged(object sender, TextChangedEventArgs e)
        {
            TextErrorNullLogin.Visibility = Visibility.Collapsed;
        }

        private void InputPasswordPasswordChanged(object sender, RoutedEventArgs e)
        {
            TextErrorNullPassword.Visibility = Visibility.Collapsed;
        }
    }
}
