using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace Moedas
{
    public class ApiConveter
    {
        HttpClient client = new();

        public async Task<T> Api<T>(string typeConvertion)
        {
            string contents = await client.GetStringAsync("https://economia.awesomeapi.com.br/last/" + typeConvertion);
            T moeda = JsonSerializer.Deserialize<T>(contents);
            return moeda;
        }
    }
}
