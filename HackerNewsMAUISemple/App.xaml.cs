namespace HackerNewsMAUISemple
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new AppShell();
        }

        public static bool IsAndroid() =>
            DeviceInfo.Current.Platform == DevicePlatform.Android;

        public static bool IsWindows() => 
            DeviceInfo.Current.Platform == DevicePlatform.WinUI;
    }
}
