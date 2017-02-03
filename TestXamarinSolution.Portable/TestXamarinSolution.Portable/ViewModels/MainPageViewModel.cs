using System.Windows.Input;
using Xamarin.Forms;

namespace TestXamarinSolution.Portable.ViewModels
{
    public class MainPageViewModel: BaseViewModel
    {
        private ICommand _connectCommand;
        public string DeviceName { get; set; }

        public ICommand ConnectCommand
        {
            get
            {
                return _connectCommand ?? (_connectCommand = new Command(() =>
                {

                }));
            }
        }
    }
}
