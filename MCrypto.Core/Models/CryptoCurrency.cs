using System.ComponentModel.DataAnnotations;

namespace MCrypto.Core.Models
{
    public class CryptoCurrency
    {
        public Guid Cryptoid { get; set; }

        [StringLength(1000,ErrorMessage ="نام نمی تواند بیش تر از 100 کاراکتر باشد")]
        public string CryptoName { get; set; }

        public decimal CurrentPrice { get; set; }
    }
}
