// RegPage.xaml.cs
using System;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;

namespace WpfApp2
{
    /// <summary>
    /// Логика взаимодействия для RegPage.xaml
    /// </summary>
    public partial class RegPage : Page
    {
        public RegPage()
        {
            InitializeComponent();
        }

        /// <summary>
        /// Обработчик кнопки «Отмена» — очищает поля и возвращает на AuthPage
        /// </summary>
        private void CancelButton_Click(object sender, RoutedEventArgs e)
        {
            // Очищаем все вводимые поля
            TextBoxSurname.Clear();
            TextBoxName.Clear();
            TextBoxPatronymic.Clear();
            TextBoxLogin.Clear();
            PasswordBox.Clear();
            ConfirmPasswordBox.Clear();

            // Переходим назад
            this.NavigationService?.GoBack();
        }

        /// <summary>
        /// Обработчик кнопки «Регистрация» — валидация и запись в БД
        /// </summary>
        private void RegisterButton_Click(object sender, RoutedEventArgs e)
        {
            // Читаем значения из контролов
            string surname = TextBoxSurname.Text.Trim();
            string name = TextBoxName.Text.Trim();
            string patronymic = TextBoxPatronymic.Text.Trim();
            string login = TextBoxLogin.Text.Trim();
            string password = PasswordBox.Password;
            string confirmPassword = ConfirmPasswordBox.Password;

            // 1) Проверка заполненности всех полей
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

            // 2) Проверка на уникальность логина
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

            // 3) Проверка формата пароля: ≥6 символов, только ASCII, хотя бы одна цифра
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

            // 4) Проверка совпадения паролей
            if (password != confirmPassword)
            {
                MessageBox.Show(
                    "Пароли не совпадают.",
                    "Ошибка",
                    MessageBoxButton.OK,
                    MessageBoxImage.Warning);
                return;
            }

            // 5) Всё проверено — добавляем пользователя в БД
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

                // Возвращаемся на страницу авторизации
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
