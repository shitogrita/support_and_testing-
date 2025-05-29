using System;
using System.Windows;
using System.Windows.Controls;
using WpfApp2.Services;   // your AuthService
using WpfApp2;            // чтобы видеть RegPage

namespace WpfApp2
{
    public partial class AuthPage : Page
    {
        private readonly AuthService _authService = new AuthService();

        public AuthPage()
        {
            InitializeComponent();
        }

        private void LoginButton_Click(object sender, RoutedEventArgs e)
        {
            string login = LoginTextBox.Text.Trim();
            string password = PasswordBox.Password;

            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Пожалуйста, заполните оба поля.",
                                "Внимание",
                                MessageBoxButton.OK,
                                MessageBoxImage.Warning);
                return;
            }

            if (!_authService.Authenticate(login, password))
            {
                MessageBox.Show("Неверный логин или пароль.",
                                "Ошибка авторизации",
                                MessageBoxButton.OK,
                                MessageBoxImage.Error);
                return;
            }

            MessageBox.Show("Добро пожаловать!",
                            "Успешный вход",
                            MessageBoxButton.OK,
                            MessageBoxImage.Information);
        }

        private void RegisterNavButton_Click(object sender, RoutedEventArgs e)
        {
            this.NavigationService?.Navigate(new RegPage());
        }
    }
}
