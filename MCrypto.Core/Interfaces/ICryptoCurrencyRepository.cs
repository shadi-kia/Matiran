using MCrypto.Core.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace MCrypto.Core.Interfaces
{
    public interface ICryptoCurrencyRepository
    {
        Task<IEnumerable<CryptoCurrency>> GetAllAsync();
        Task<CryptoCurrency> GetByIdAsync(Guid id);
    }
}
