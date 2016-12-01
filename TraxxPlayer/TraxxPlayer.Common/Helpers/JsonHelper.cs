using System.Net.Http;
using System.Threading.Tasks;

namespace TraxxPlayer.Common.Helpers
{
    public static class JsonHelper
    {
        public static async Task<string> GetjsonStream(string url)
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
