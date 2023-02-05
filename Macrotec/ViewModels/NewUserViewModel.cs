using Macrotec.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Macrotec.ViewModels
{
    public class NewUserViewModel : BaseViewModel
    {
        private string password;
        private string email;
        private string username;

        public NewUserViewModel()
        {
            SignUpCommand = new Command(OnSignUp);
        }

        private async void OnSignUp()
        {
            try
            {
                var authService = DependencyService.Resolve<IAuthenticationService>();
                if (await authService.CreateUser(Username, Email, Password))
                {
                    await Xamarin.Forms.Shell.Current.GoToAsync("//HomePage");
                }
                else
                {
                    Console.WriteLine("A problem occurs when creating a user");
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                await Xamarin.Forms.Shell.Current
                    .DisplayAlert("Create User", "An error occurs", "OK");
            }
        }

        #region Properties
        public string Username
        {
            get => username;
            set => SetProperty(ref username, value);
        }

        public string Password
        {
            get => password;
            set => SetProperty(ref password, value);
        }

        public string Email
        {
            get => email;
            set => SetProperty(ref email, value);
        }
        #endregion

        public ICommand SignUpCommand { get; }
    }
}