using Android.App;
using Android.Content.PM;
using Android.OS;
using Android.Views;

namespace HackerNewsMAUISemple
{
    [Activity(Theme = "@style/Maui.SplashTheme", MainLauncher = true, ScreenOrientation = ScreenOrientation.Behind, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize | ConfigChanges.Density)]
    public class MainActivity : MauiAppCompatActivity
    {
        protected override void OnCreate(Bundle? savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Platform.Init(this, savedInstanceState);

            this.Window.DecorView.SystemUiVisibility = (StatusBarVisibility)
                (SystemUiFlags.ImmersiveSticky | SystemUiFlags.HideNavigation |
                 SystemUiFlags.Fullscreen | SystemUiFlags.Immersive);
        }
    }
}
