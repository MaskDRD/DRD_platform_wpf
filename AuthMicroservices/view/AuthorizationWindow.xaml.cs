using System;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
 

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

        private void ButtonClick(object sender, RoutedEventArgs e)
        {
           if(Login.Value == "")
            {
                Login.UpdateVisibleTextError();
            }
            if (Password.Value == "")
            {
                Password.UpdateVisibleTextError();
            }
        }
    }
}
