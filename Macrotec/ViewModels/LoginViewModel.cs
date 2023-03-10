using Macrotec.Services;
using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace Macrotec.ViewModels
{
    public class LoginViewModel : BaseViewModel
    {
        private string password;
        private string email;

        public LoginViewModel()
        {
            SignUpCommand = new Command(OnSignUp);
            SignInCommand = new Command(OnSignIn);
            ForgotPasswordCommand = new Command(OnForgotPassword);
        }

        private async void OnForgotPassword()
        {
            await Xamarin.Forms.Shell.Current.GoToAsync("//ForgotPasswordPage");
        }

        private async void OnSignIn()
        {
            try
            {
                var authService = DependencyService.Resolve<IAuthenticationService>();
                var token = await authService.SignIn(Email, Password);

                await Xamarin.Forms.Shell.Current.GoToAsync("//HomePage");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);

                await Xamarin.Forms.Shell.Current
                    .DisplayAlert("SignIn", "An error occurs", "OK");
            }
        }

        private async void OnSignUp()
            => await Xamarin.Forms.Shell.Current.GoToAsync("//NewUserPage");


        #region Properties
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

        #region Commands

        public ICommand ForgotPasswordCommand { get; }

        public ICommand SignInCommand { get; }

        public ICommand SignUpCommand { get; }

        #endregion
    }
}

