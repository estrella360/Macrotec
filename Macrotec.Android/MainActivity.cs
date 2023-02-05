using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.OS;
using Firebase;
using Firebase.Auth;
using static Android.Telephony.CarrierConfigManager;


namespace Macrotec.Droid
{
    [Activity(Label = "Macrotec", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize )]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());
            var app = FirebaseApp.InitializeApp(this);

        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        private void CreateUserWithEmailAndPassword(string email, string password)
        {
            FirebaseAuth auth = FirebaseAuth.GetInstance(app);
            auth.CreateUserWithEmailAndPasswordAsync(email, password)
                .ContinueWith(task =>
                {
                    if (task.IsSuccessful)
                    {
                        Log.Debug("Firebase", "User created successfully");
                    }
                    else
                    {
                        Log.Debug("Firebase", "User creation failed");
                    }
                });
        }

        private void SignInWithEmailAndPassword(string email, string password)
        {
            FirebaseAuth auth = FirebaseAuth.GetInstance(app);
            auth.SignInWithEmailAndPasswordAsync(email, password)
                .ContinueWith(task =>
                {
                    if (task.IsSuccessful)
                    {
                        Log.Debug("Firebase", "Sign in successful");
                    }
                    else
                    {
                        Log.Debug("Firebase", "Sign in failed");
                    }
                });
        }




    }
}