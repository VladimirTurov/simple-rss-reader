namespace NewsClient.Infrastructure
{
	using System;
	using System.Threading.Tasks;

	public interface IHttpClient
	{
		Task<string> GetStringAsync(Uri uri);
	}
}