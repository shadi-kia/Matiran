using System.ComponentModel;
using System.Runtime.CompilerServices;

namespace MCrypto.Core.Interfaces
{
   
    public class BaseViewModel : INotifyPropertyChanged
    {
        // رویداد PropertyChanged برای اطلاع‌رسانی تغییرات
        public event PropertyChangedEventHandler? PropertyChanged;

        // متدی برای اطلاع‌رسانی تغییرات
        protected void OnPropertyChanged([CallerMemberName] string? propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }

}
