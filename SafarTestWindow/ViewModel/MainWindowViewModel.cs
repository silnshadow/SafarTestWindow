using Safar.UIService;
using Safar.UIService.Dto;
using SafarTestWindow.Command;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Net.Http;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace SafarTestWindow.ViewModel
{
    public class MainWindowViewModel : ViewModelBaseClass
    {
        private SafarService _safarService;
        private string _userName;
        public string UserName
        {
            get { return _userName; }
            set
            {
                _userName = value;
                OnPropertyChanged(nameof(UserName));
            }
        }
        private string _password;
        public string Password
        {
            get { return _password; }
            set
            {
                _password = value;
                OnPropertyChanged(nameof(Password));
            }
        }

        private bool _isEnable;
        public bool IsEnable
        {
            get { return _isEnable; }
            set
            {
                _isEnable = value;
                OnPropertyChanged(nameof(IsEnable));
            }
        }


        public MainWindowViewModel()
        {
            _safarService = new SafarService();
        }

        private ICommand loginCommand;
        public ICommand LoginCommand
        {
            get
            {
                return loginCommand ?? (loginCommand = new RelayCommand(obj => Login()));
            }
        }

        private void Login()
        {
            //Password for User 8 is Naga@123 for testing
            var user = _safarService.GetUserById(8);
            bool oldUser = CommonAuthenticationManager.PasswordHasherBase.VerifyHashedPassword(user.Password, Password);
            if (user != null && user.Deleted == 0 && user.UserName == UserName && oldUser)
            {
                MessageBox.Show("Welcome to Safar !. Enjoy your Safar.");
            }
            else
            {
                MessageBox.Show("Buddy Credentials is wrong !. Wanna join  our group");
            }

        }

        private ICommand saveCommand;
        public ICommand SaveCommand
        {
            get
            {
                return saveCommand ?? (saveCommand = new RelayCommand(obj => Save()));
            }
        }

        private async void Save()
        {
            if(Password != null && UserName != null)
            {
                var verifiedUser = new VerifiedUserDto
                {
                    UserName = UserName,
                    Password = CommonAuthenticationManager.PasswordHasherBase.HashPassword(Password),
                    UsersCategoryId = 1
                };

               _safarService.AddUser(verifiedUser);

                MessageBox.Show("User Got Added");
            }
        }

        //private void Save()
        //{
        //    var payload = new VerifiedUser()
        //    {
        //        UserName = UserName,
        //        Password = CommonAuthenticationManager.PasswordHasherBase.HashPassword(Password),
        //        UsersCategoryId = 1
        //    };
        //    string strPayload = JsonConvert.SerializeObject(payload);
        //    HttpContent content = new StringContent(strPayload, Encoding.UTF8, "application/json");

        //    try
        //    {
        //        var t = Task.Run(() => _safarService.GenricPostURI(content));
        //        MessageBox.Show(t.Result + " Successfully");
        //        IsEnable = false;
        //    }
        //    catch (Exception ex)
        //    {
        //        throw;
        //    }
        //}

    }

    public class ViewModelBaseClass : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public void OnPropertyChanged([CallerMemberName()] string name = null)
        {
            if (name != null) PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}