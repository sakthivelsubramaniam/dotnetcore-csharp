using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net;

//https://docs.microsoft.com/en-us/archive/blogs/shacorn/best-practices-for-using-httpclient-on-services

// Note httpclient should be reused, re-creating and disposing httpclient is costly
// - Reuse connections when you can (httpClient.DefaultRequestHeaders.ConnectionClose = false or HttpWebRequest.KeepAlive = true)
// - reuse may not alway work if you are behind the loadbalancer
// - Don't hold those connections forever - 
// . In a situation where the HttpClient is instantiated as a singleton or a static object, it fails to handle the DNS changes
// - use IhttpClientFactory
// sample poly:  https://github.com/App-vNext
// reference sample
// https://github.com/dotnet/AspNetCore.Docs/tree/main/aspnetcore/fundamentals/http-requests/samples/5.x

namespace Client
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello World!");
             //setup our DI\

             var services = new ServiceCollection();
                 services.AddHttpClient();
                services.AddTransient<IHttpClientInternalMs, HttpClientInternalMs>();   
                var serviceProvider =   services.BuildServiceProvider();

         //   .SetHandlerLifetime(TimeSpan.FromMinutes(5))
                

            var client =  serviceProvider.GetRequiredService<IHttpClientInternalMs>();
            // issue request
            var result = client.Get("http://localhost:5000/Weatherforecast");

        }
    }

    class HttpHelper 
    {
        public static async Task WithDefaultHandler() 
        {   // note: not tested

            // note : HttpClientHandler is default handler
            // HttpClient myClient = new HttpClient(); will initailze with default httpClientHandler with default http stack settings
            // 
            HttpClientHandler myHandler = new HttpClientHandler();
            myHandler.AllowAutoRedirect = false;
            // to disable the proxy
            // HttpClientHandler.UseProxy = false;



            HttpClient myClient = new HttpClient(myHandler);

            // set the timeout for all request
            myClient.Timeout = TimeSpan.FromSeconds(30);

            // to add headers that will not change between the request
            myClient.DefaultRequestHeaders.Add("X-HeaderKey", "HeaderValue");
            myClient.DefaultRequestHeaders.Referrer = new Uri("http://www.contoso.com");

            HttpRequestMessage myrequest = new HttpRequestMessage();

            // to modify headers for specific headers
            myrequest.Headers.Add("X-HeaderKey", "HeaderValue");
            myrequest.Headers.Referrer = new Uri("http://www.contoso.com");

            var cts = new CancellationTokenSource();
            cts.CancelAfter(TimeSpan.FromSeconds(30));

            var resourceUri =  new Uri("http://localhost") ;

            try
            {
                  HttpResponseMessage response = await myClient.GetAsync(resourceUri, cts.Token);
            }
            catch (TaskCanceledException ex)
            {
                 // Handle request being canceled due to timeout.
            }
            catch (HttpRequestException ex)
            {
                    // Handle other possible exceptions.
            }
        }

        public static void withHandlerChain() 
        {   // note: note tested

            HttpClientHandler systemHandler = new HttpClientHandler();
            CustomHandler1 myHandler1 = new CustomHandler1();
            CustomHandler2 myHandler2 = new CustomHandler2();

            // Chain the handlers together.
            myHandler1.InnerHandler = myHandler2;
            myHandler2.InnerHandler = systemHandler;

            // Create the client object with the topmost handler in the chain.
            HttpClient myClient = new HttpClient(myHandler1);
        }

        public static void ToUserCredential() 
        {
            var  httpCLientHandler = new HttpClientHandler();
            httpCLientHandler.Credentials = new NetworkCredential("myUsername", "myPassword"); 
        }

        public static void toUseClientCertificate() 
        {
            var  httpCLientHandler = new HttpClientHandler();
           httpCLientHandler.ClientCertificateOptions = ClientCertificateOption.Automatic;
        }

        public static void cookieHandling()
        {
            var  httpCLientHandler = new HttpClientHandler();
            var resourceUri = new Uri("http://localhost") ;
            var cookie = new Cookie();

            httpCLientHandler.CookieContainer.Add(resourceUri, cookie);

             // for single request
             HttpRequestMessage myRequest = new HttpRequestMessage();
            myRequest.Headers.Add("Cookie", "user=foo; key=bar");
        }

        public static void MaxCOnnServer() 
        {
            // httpclient does not provide any method
            return;
        }
    }
}
