using Macrotec.Services;
using System;
using System.Collections.Generic;
using System.Text;
using Xamarin.Forms;

namespace Macrotec.ViewModels
{
    public class HomeViewModel : BaseViewModel
    {
        public HomeViewModel() 
        {
            CheckWetherTheUserIsSignIn();        
        }

        public async void CheckWetherTheUserIsSignIn()
        {
            try
            {
                var authenticationService = DependencyService.Resolve<IAuthenticationService>();
                if (!authenticationService.IsSignIn())
                    await Xamarin.Forms.Shell.Current.GoToAsync("//LoginPage");
            }
            catch (Exception e)
            {

                Console.WriteLine(e.Message);
            }
        }

    }
}
