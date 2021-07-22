using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;
using System.Diagnostics;


namespace Client
{
		
	public class CustomHandler1 : DelegatingHandler
	{
		// Constructors and other code here.
		protected async override Task<HttpResponseMessage> SendAsync(	HttpRequestMessage request, CancellationToken cancellationToken)
		{
				// Process the HttpRequestMessage object here.
				Debug.WriteLine("Processing request in Custom Handler 1");

				// Once processing is done, call DelegatingHandler.SendAsync to pass it on the
				// inner handler.
				HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

				// Process the incoming HttpResponseMessage object here.
				Debug.WriteLine("Processing response in Custom Handler 1");

				return response;
		}
	}

public class CustomHandler2 : DelegatingHandler
{
		protected async override Task<HttpResponseMessage> SendAsync(	HttpRequestMessage request, CancellationToken cancellationToken)
		{
				// Process the HttpRequestMessage object here.
				Debug.WriteLine("Processing request in Custom Handler 2");

				// Once processing is done, call DelegatingHandler.SendAsync to pass it on the
				// inner handler.
				HttpResponseMessage response = await base.SendAsync(request, cancellationToken);

				// Process the incoming HttpResponseMessage object here.
				Debug.WriteLine("Processing response in Custom Handler 2");

				return response;
		}
}




}