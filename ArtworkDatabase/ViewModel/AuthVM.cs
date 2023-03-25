using ArtworkDatabase.DbEntity;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace ArtworkDatabase.ViewModel
{
    public class AuthVM : BaseVM
    {
        private string _buttonSingIn = "Войти";

        private User _user;
        private string _login;
        private string _password;
        
        
        public string Login
        {
            get => _login;
            set
            {
                _login = value;
                OnPropertyChanged(nameof(Login));
            }
        }

        public string Password
        {
            get => _password;
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }


        public string ButtonSingIn
        {
            get => _buttonSingIn;
            set
            {
                _buttonSingIn = value;
                OnPropertyChanged(nameof(ButtonSingIn));
            }
        }


        private async Task<bool> Authorize(string login, string password)
        {
            try
            {
                var result = await DbStorage.DB_s.User.FirstOrDefaultAsync(_user => _user.Login == login &&
                            _user.Password == password);

                _user = result;

                if (result != null)
                {
                    return true;
                }

                return false;

            }
            catch (Exception ex)
            {
                MessageBox.Show(ex.Message, "Необработанное исключение",
                        MessageBoxButton.OK, MessageBoxImage.Stop);

                return false;
            }

        }

        public async void AuthInApp()
        {
            ButtonSingIn = "Подождите...";

            if (await Authorize(Login, Password))
            {
                var appWindow = new View.ApplicationWindow(_user);//_user??

                appWindow.Show();

                foreach (var item in App.Current.Windows)
                {
                    if (item is MainWindow)
                    {
                        (item as Window)?.Hide();
                    }
                }
                return;
            }

            MessageBox.Show("Неверный логин или пароль", "Авторизация",
                    MessageBoxButton.OK, MessageBoxImage.Error);

            ButtonSingIn = "Войти";

        }
    }
}
