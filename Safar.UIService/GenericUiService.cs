using System;
using System.Diagnostics;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;


namespace Safar.UIService
{
    public class GenericUiService
    {
        public async Task<TReturn> GenericGetResult<TReturn>(string route, int criteria)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();
                TReturn result = default(TReturn);
                using(var client = new HttpClient())
                {
                    var baseAddress = "http://localhost:22715/" + route +criteria;
                    client.BaseAddress = new Uri(baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.GetAsync(baseAddress);
                    if (response.IsSuccessStatusCode)
                    {
                        sw.Stop();
                        var em = sw.ElapsedMilliseconds;
                        return await response.Content.ReadAsAsync<TReturn>();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception GenericGetResult: {ex}");
                throw;
            }
        }

        public async Task<TReturn> GenericPostResult<T,TReturn>(string route, T request)
        {
            try
            {
                Stopwatch sw = new Stopwatch();
                sw.Start();

                TReturn result = default(TReturn);
                using (var client = new HttpClient())
                {
                    client.Timeout = TimeSpan.FromMinutes(30);
                    var baseAddress = "http://localhost:22715/" + route;
                    client.BaseAddress = new Uri(baseAddress);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
                    var response = await client.PostAsJsonAsync(baseAddress, request);
                    if (response.IsSuccessStatusCode)
                    {
                        sw.Stop();
                        var em = sw.ElapsedMilliseconds;
                        return await response.Content.ReadAsAsync<TReturn>();
                    }
                }
                return result;
            }
            catch (Exception ex)
            {
                Debug.WriteLine($"Exception GenericPostResult: {ex}");
                throw;
            }
        }
    }
}
