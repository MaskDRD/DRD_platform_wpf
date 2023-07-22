using System.Windows;
using System.Windows.Controls;

namespace platform.AuthMicroservices.component
{
    /// <summary>
    /// Логика взаимодействия для AuthTitle.xaml
    /// </summary>
    public partial class AuthTitle : UserControl
    {
        public static readonly DependencyProperty TitleProperty = DependencyProperty.Register(
            "Title",
            typeof(string),
            typeof(AuthTitle)
        );

        public string Title
        {
            get { return (string)GetValue(TitleProperty); }
            set { SetValue(TitleProperty, value); }
        }

        public AuthTitle()
        {
            InitializeComponent();
        }
    }
}
