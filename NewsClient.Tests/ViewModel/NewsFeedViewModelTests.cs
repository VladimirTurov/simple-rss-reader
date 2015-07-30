namespace NewsClient.Tests.ViewModel
{
	using System;
	using System.Threading.Tasks;
	using Infrastructure;
	using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
	using NewsClient.Infrastructure;
	using NewsClient.Model;
	using NewsClient.ViewModel;

	[TestClass]
	public class NewsFeedViewModelTests
	{
		[TestMethod]
		public void Constructor_NullHttpClient_ExceptionThrown()
		{
			// Fixture setup
			IHttpClient httpClient = null;
			IRssParser rssParser = new RssParserMock();
			IProgressIndicator progressIndicator = new ProgressIndicatorMock();

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentNullException>
				(() => new NewsFeedViewModel(httpClient, rssParser, progressIndicator));

			// Teardown
		}

		[TestMethod]
		public void Constructor_NullRssParser_ExceptionThrown()
		{
			// Fixture setup
			IHttpClient httpClient = new HttpClientMock();
			IRssParser rssParser = null;
			IProgressIndicator progressIndicator = new ProgressIndicatorMock();

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentNullException>
				(() => new NewsFeedViewModel(httpClient, rssParser, progressIndicator));

			// Teardown
		}

		[TestMethod]
		public void Constructor_NullProgressIndicator_ExceptionThrown()
		{
			// Fixture setup
			IHttpClient httpClient = new HttpClientMock();
			IRssParser rssParser = new RssParserMock();
			IProgressIndicator progressIndicator = null;

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentNullException>
				(() => new NewsFeedViewModel(httpClient, rssParser, progressIndicator));

			// Teardown
		}

		[TestMethod]
		public async Task GetLatestNewsAsync_CallWithoutParameters_ExceptionThrown()
		{
			// Fixture setup
			IHttpClient httpClient = new HttpClientMock();
			IRssParser rssParser = new RssParserMock();
			IProgressIndicator progressIndicator = new ProgressIndicatorMock();

			var viewModel = new NewsFeedViewModel(httpClient, rssParser, progressIndicator);

			// Exercise system
			var task = viewModel.GetLatestNewsAsync();

			// Verify outcome
			await AssertEx.ThrowsExceptionAsync<ArgumentException>(() => task);

			// Teardown
		}

		[TestMethod]
		public async Task GetLatestNewsAsync_NullNewsChannel_ExceptionThrown()
		{
			// Fixture setup
			IHttpClient httpClient = new HttpClientMock();
			IRssParser rssParser = new RssParserMock();
			IProgressIndicator progressIndicator = new ProgressIndicatorMock();

			var viewModel = new NewsFeedViewModel(httpClient, rssParser, progressIndicator);
			NewsChannel newsChannel = null;

			// Exercise system
			var task = viewModel.GetLatestNewsAsync(newsChannel);

			// Verify outcome
			await AssertEx.ThrowsExceptionAsync<ArgumentException>(() => task);

			// Teardown
		}

		[TestMethod]
		public async Task GetLatestNewsAsync_NullNewsFeedFromNewsChannel_ExceptionThrown()
		{
			// Fixture setup
			IHttpClient httpClient = new HttpClientMock();
			IRssParser rssParser = new RssParserMock();
			IProgressIndicator progressIndicator = new ProgressIndicatorMock();

			var viewModel = new NewsFeedViewModel(httpClient, rssParser, progressIndicator);
			var newsChannel = new NewsChannel("News channel", new Uri("http://news.com/rss"));

			// Exercise system
			var task = viewModel.GetLatestNewsAsync(newsChannel);

			// Verify outcome
			await AssertEx.ThrowsExceptionAsync<NullReferenceException>(() => task);

			// Teardown
		}

		[TestMethod]
		public async Task GetLatestNewsAsync_MockForTwoNewsChannels_ValidItemCount()
		{
			// Fixture setup
			var newsItem = new NewsItem("News item", "News text", DateTimeOffset.Now, null);
			Func<string, NewsFeed> parsingFunc = rss => new NewsFeed(new[] { newsItem });

			IHttpClient httpClient = new HttpClientMock();
			IRssParser rssParser = new RssParserMock { CustomParsingFunction = parsingFunc };
			IProgressIndicator progressIndicator = new ProgressIndicatorMock();

			var viewModel = new NewsFeedViewModel(httpClient, rssParser, progressIndicator);
			var newsChannel = new NewsChannel("News channel", new Uri("http://news.com/rss"));

			var expectedNewsCount = 2;

			// Exercise system
			await viewModel.GetLatestNewsAsync(newsChannel, newsChannel);

			// Verify outcome
			Assert.AreEqual(viewModel.News.Count, expectedNewsCount);

			// Teardown
		}

		[TestMethod]
		public async Task GetLatestNewsAsync_MockForTwoNewsChannels_ValidNewsItemsSortingOrder()
		{
			// Fixture setup
			var firstItem = new NewsItem("First item", "News text", DateTimeOffset.Now, null);
			var secondItem = new NewsItem("Second item", "News text", firstItem.PublicationDate.AddSeconds(1), null);

			var requestCounter = 0;
			Func<string, NewsFeed> parsingFunc = rss =>
			{
				requestCounter++;
				if (requestCounter == 1) return new NewsFeed(new[] { firstItem });
				return new NewsFeed(new[] { secondItem });
			};

			IHttpClient httpClient = new HttpClientMock();
			IRssParser rssParser = new RssParserMock { CustomParsingFunction = parsingFunc };
			IProgressIndicator progressIndicator = new ProgressIndicatorMock();

			var viewModel = new NewsFeedViewModel(httpClient, rssParser, progressIndicator);
			var newsChannel = new NewsChannel("News channel", new Uri("http://news.com/rss"));

			var expectedFirstItemTitle = secondItem.Title;

			// Exercise system
			await viewModel.GetLatestNewsAsync(newsChannel, newsChannel);

			// Verify outcome
			Assert.AreEqual(viewModel.News[0].Title, expectedFirstItemTitle);

			// Teardown
		}
	}
}