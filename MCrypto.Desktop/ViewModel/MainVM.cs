using MCrypto.Applicaton.Services;
using MCrypto.Core.Models;
using System.Collections.ObjectModel;
using System.ComponentModel;

public class MainVM : INotifyPropertyChanged
{
    private readonly CryptoCurrencyService _service;
    public ObservableCollection<CryptoCurrency> Cryptocurrencies { get; set; } = new();

    public MainVM(CryptoCurrencyService service)
    {
        _service = service;
    }

    public async Task LoadCryptocurrenciesAsync()
    {
        var data = await _service.GetAllCryptocurrenciesAsync();
        Cryptocurrencies.Clear();
        foreach (var item in data)
        {
            Cryptocurrencies.Add(item);
        }
    }
}
