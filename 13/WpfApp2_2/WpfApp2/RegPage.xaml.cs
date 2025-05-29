// RegPage.xaml.cs
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfApp2
{
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            TextBoxSurname.Clear();
            TextBoxName.Clear();
            TextBoxPatronymic.Clear();
            TextBoxLogin.Clear();
            PasswordBox.Clear();
            ConfirmPasswordBox.Clear();

            this.NavigationService?.GoBack();
        }

        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            string surname = TextBoxSurname.Text.Trim();
            string name = TextBoxName.Text.Trim();
            string patronymic = TextBoxPatronymic.Text.Trim();
            string login = TextBoxLogin.Text.Trim();
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            if (string.IsNullOrEmpty(surname) ||
                string.IsNullOrEmpty(name) ||
                string.IsNullOrEmpty(patronymic) ||
                string.IsNullOrEmpty(login) ||
                string.IsNullOrEmpty(password) ||
                string.IsNullOrEmpty(confirmPassword))
            {
                MessageBox.Show(
                    "Все поля обязательны для заполнения.",
                    "Внимание",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }
            using (var db = new akmetova_dbEntities())
            {
                if (db.User.Any(u => u.Login == login))
                {
                    MessageBox.Show(
                        "Пользователь с таким логином уже существует!",
                        "Ошибка",
                        MessageBoxButton.OK,
                        MessageBoxImage.Warning);
                    return;
                }
            }

            if (password.Length < 6 ||
                !password.All(c => c < 128) ||
                !password.Any(char.IsDigit))
            {
                MessageBox.Show(
                    "Пароль должен быть не менее 6 символов, содержать только английские символы и хотя бы одну цифру.",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }
            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "Пароли не совпадают.",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            try
            {
                using (var db = new akmetova_dbEntities())
                {
                    var userObject = new User
                    {
                        FIO = $"{surname} {name} {patronymic}",
                        Login = login,
                        Password = password
                    };
                    db.User.Add(userObject);
                    db.SaveChanges();
                }

                MessageBox.Show(
                    "Регистрация прошла успешно!",
                    "Успех",
                    MessageBoxButton.OK,
                    MessageBoxImage.Information);
                this.NavigationService?.GoBack();
            }
            catch (Exception ex)
            {
                MessageBox.Show(
                    "Ошибка при сохранении данных:\n" + ex.Message,
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Error);
            }
        }
    }
}
