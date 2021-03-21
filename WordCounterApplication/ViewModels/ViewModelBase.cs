using System.ComponentModel;

namespace WordCounterApplication.ViewModels
{
    /// <summary>
    /// ViewModelBase implements INotifyPropertyChanged and base for all view models.
    /// </summary>
    class ViewModelBase : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        // Create the OnPropertyChanged method to raise the event
        // The calling member's name will be used as the parameter.
        protected void OnPropertyChanged(string name = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }
    }
}
