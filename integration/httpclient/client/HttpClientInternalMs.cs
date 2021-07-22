using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Logging;
using System.Diagnostics;
using System.Net;

namespace Client
{
		

	  interface IHttpClientInternalMs
		{
				 Task<string> Get(string url );

		}


		public class HttpClientInternalMs : IHttpClientInternalMs
		{
			 private readonly IHttpClientFactory _clientFactory;

				public HttpClientInternalMs(IHttpClientFactory clientFactory)
				{
					  _clientFactory = clientFactory;
				}

				public async Task<string> Get(string url )
			  {

					 // Content from BBC One: Dr. Who website (©BBC)
            var request = new HttpRequestMessage(HttpMethod.Get, url);
            var client = _clientFactory.CreateClient();
            var response = await client.SendAsync(request);

            if (response.IsSuccessStatusCode)
            {
                return await response.Content.ReadAsStringAsync();
            }
            else
            {
                return $"StatusCode: {response.StatusCode}";
            }

				}

		}

}