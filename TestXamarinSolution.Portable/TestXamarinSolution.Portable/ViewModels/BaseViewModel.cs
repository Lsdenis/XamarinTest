using System;
using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace TestXamarinSolution.Portable.ViewModels
{
    /// <summary>
    /// Base class for ViewModels
    /// </summary>
    public class BaseViewModel : INotifyPropertyChanged, IDisposable
    {
        /// <summary>
        /// Shows wheather ViewModel is busy making some request or smth like this
        /// </summary>
        public bool IsBusy { get; set; }

        #region PropertyChanged
        public event PropertyChangedEventHandler PropertyChanged;

//        [NotifyPropertyChangedInvocator]
        protected internal virtual void NotifyPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        #endregion

        public void Dispose()
        {
        }

        public virtual void LoadData()
        {
        }
    }
}
