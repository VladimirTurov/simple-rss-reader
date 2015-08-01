namespace NewsClient.Model
{
	using System;
	using System.Threading.Tasks;
	using Infrastructure;

	public class NewsChannel
	{
		private readonly IHttpClient httpClient;
		private readonly IRssParser rssParser;

		public NewsChannel(string name, Uri feedUri, IHttpClient httpClient, IRssParser rssParser)
		{
			if (name == null) throw new ArgumentNullException("name", "Channel name cannot be null");
			if (feedUri == null) throw new ArgumentNullException("feedUri", "Channel feed uri cannot be null");

			if (httpClient == null) throw new ArgumentNullException("httpClient", "HTTP client cannot be null");
			if (rssParser == null) throw new ArgumentNullException("rssParser", "RSS parser cannot be null");

			this.httpClient = httpClient;
			this.rssParser = rssParser;

			Name = name;
			FeedUri = feedUri;
		}

		public string Name { get; private set; }
		public Uri FeedUri { get; private set; }

		public async Task<NewsFeed> GetLatestNewsAsync()
		{
			var rss = await httpClient.GetStringAsync(FeedUri);
			return rssParser.Parse(rss);
		}
	}
}