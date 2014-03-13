using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace papercut
{
    internal class Papercut
    {
        private HttpClient _httpClient;
        public void Start(string baseAddress, int requests)
        {
            // create client
            _httpClient = new HttpClient() { BaseAddress = new Uri(baseAddress) };

            // add accept json header
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            try
            {
                Console.WriteLine("Starting...");
                RunAsync(requests);
            }
            catch (AggregateException ae)
            {
                Console.WriteLine("one or more exceptions during outer Task: ");
                foreach (var innerException in ae.InnerExceptions)
                    Console.WriteLine(innerException.Message);
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception during outer Task - {0}\n\n{1}\n\n\n", ex.Message, ex.StackTrace);
            }

        }
        private void RunAsync(int requestsPerSecond)
        {
            var requests = new List<Task>();

            for (var i = 0; i < requestsPerSecond; i++)
                requests.Add(GetTask(i));

            Task.WaitAll(requests.ToArray());
        }

        private async Task<bool> GetTask(int i)
        {
            Console.WriteLine(i);
            var responseTask = _httpClient.GetAsync("/");

            var response = await responseTask;
            Console.WriteLine(response.IsSuccessStatusCode ? "success." : "failure.");
            return response.IsSuccessStatusCode;
        }
    }
}
