using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace papercut
{
    internal class Papercut
    {
        private HttpClient _httpClient;
        public Papercut()
        {
            ServicePointManager.DefaultConnectionLimit = 100;

            // ignore certificate errors
            ServicePointManager.ServerCertificateValidationCallback = delegate { return true; };
        }
        public async Task Start(string url, int requests)
        {
            // create client
            _httpClient = new HttpClient() { BaseAddress = new Uri(url) };

            // add accept json header
            _httpClient.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            Console.WriteLine("Starting...");
            try
            {
                await RunAsync(requests);
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

        private Task RunAsync(int numOfRequests)
        {
            var requests = new List<Task>();

            for (var i = 0; i < numOfRequests; i++)
                requests.Add(GetTask(i));

            return Task.WhenAll(requests.ToArray());

        }
        private async Task<bool> GetTask(int i)
        {
            Console.WriteLine(i);

            var responseTask = _httpClient.GetAsync("/");

            var response = await responseTask;
            Console.WriteLine("{0} : {1} ({2})", i, response.IsSuccessStatusCode ? "success." : "failure {0}", response.StatusCode);
            return response.IsSuccessStatusCode;
        }


    }
}
