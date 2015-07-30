namespace NewsApplication.Infrastructure
{
   using System;
   using System.Threading.Tasks;
   using Windows.Web.Http;
   using NewsClient.Infrastructure;

   public class HttpClientProxy : IHttpClient
   {
      public async Task<string> GetStringAsync(Uri uri)
      {
         using (var httpClient = new HttpClient())
            return await httpClient.GetStringAsync(uri);
      }
   }
}