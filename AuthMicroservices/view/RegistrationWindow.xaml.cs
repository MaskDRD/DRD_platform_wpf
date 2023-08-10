using platform.AuthMicroservices.service;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace platform.AuthMicroservices.view
{
    /// <summary>
    /// Логика взаимодействия для RegistrationWindow.xaml
    /// </summary>
    public partial class RegistrationWindow : Window
    {
        public RegistrationWindow()
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
            bool checkError = false;
            if (Login.Value == "")
            {
                Login.UpdateVisibleTextError();
                checkError = true;
            }

            if (Password.Value == "")
            {
                Password.UpdateVisibleTextError();
                checkError = true;
            }

            if (PasswordRepeat.Value == "")
            {
                PasswordRepeat.UpdateVisibleTextError();
                checkError = true;
            }

            if (Email.Value == "")
            {
                Email.UpdateVisibleTextError();
                checkError = true;
            }

            if (Nik.Value == "")
            {
                Nik.UpdateVisibleTextError();
                checkError = true;
            }

            if(Password.Value != PasswordRepeat.Value)
            {
                checkError = true;
            }
            
            if (checkError == true)
            {
                return;
            }

            AuthService.Instance.Register(
                Login.Value,
                Password.Value,
                Email.Value,
                Nik.Value
            );
        }

    }
}
