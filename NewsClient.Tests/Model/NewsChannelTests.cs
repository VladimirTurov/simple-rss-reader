namespace NewsClient.Tests.Model
{
	using System;
	using System.Threading.Tasks;
	using Infrastructure;
	using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
	using NewsClient.Infrastructure;
	using NewsClient.Model;

	[TestClass]
	public class NewsChannelTests
	{
		[TestMethod]
		public void Constructor_NullName_ExceptionThrown()
		{
			// Fixture setup
			string name = null;
			var feedUri = new Uri("http://news.com/rss");

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentNullException>(() => new NewsChannel(name, feedUri));

			// Teardown
		}

		[TestMethod]
		public void Constructor_NullFeedUri_ExceptionThrown()
		{
			// Fixture setup
			var name = "News channel";
			Uri feedUri = null;

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentNullException>(() => new NewsChannel(name, feedUri));

			// Teardown
		}

		[TestMethod]
		public async Task GetLatestNewsAsync_NullHttpClient_ExceptionThrown()
		{
			// Fixture setup
			var name = "News channel";
			var feedUri = new Uri("http://news.com/rss");

			IHttpClient httpClient = null;
			IRssParser rssParser = new RssParserMock();

			var newsChannel = new NewsChannel(name, feedUri);

			// Exercise system
			var task = newsChannel.GetLatestNewsAsync(httpClient, rssParser);

			// Verify outcome
			await AssertEx.ThrowsExceptionAsync<ArgumentNullException>(() => task);

			// Teardown
		}

		[TestMethod]
		public async Task GetLatestNewsAsync_NullRssParser_ExceptionThrown()
		{
			// Fixture setup
			var name = "News channel";
			var feedUri = new Uri("http://news.com/rss");

			IHttpClient httpClient = new HttpClientMock();
			IRssParser rssParser = null;

			var newsChannel = new NewsChannel(name, feedUri);

			// Exercise system
			var task = newsChannel.GetLatestNewsAsync(httpClient, rssParser);

			// Verify outcome
			await AssertEx.ThrowsExceptionAsync<ArgumentNullException>(() => task);

			// Teardown
		}
	}
}