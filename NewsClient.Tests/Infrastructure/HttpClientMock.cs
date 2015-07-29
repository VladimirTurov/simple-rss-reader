namespace NewsClient.Tests.Infrastructure
{
	using System;
	using System.Threading.Tasks;
	using NewsClient.Infrastructure;

	internal class HttpClientMock : IHttpClient
	{
		public async Task<string> GetStringAsync(Uri uri)
		{
			return string.Empty;
		}
	}
}