using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace BackgroundAudioShared.Helpers
{
    public static class JsonHelper
    {
        public static async Task<string> GetjsonStream(string url) //Function to read from given url
        {
            HttpClient client = new HttpClient();
            HttpResponseMessage response = await client.GetAsync(url);
            return await response.Content.ReadAsStringAsync();
        }
    }
}
