using TestXamarinSolution.Portable.Pages;
using TestXamarinSolution.Portable.ViewModels;
using Xamarin.Forms;

namespace TestXamarinSolution.Portable
{
    public class App : Application
    {
        public App()
        {
            var mainPageViewModel = new MainPageViewModel();
            var page = new MainPage { BindingContext = mainPageViewModel };
            MainPage = page;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
