namespace NewsClient.Tests.Model
{
	using System;
	using System.Linq;
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
			var httpClient = new HttpClientMock();
			var rssParser = new RssParserMock();

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentNullException>(() => new NewsChannel(name, feedUri, httpClient, rssParser));

			// Teardown
		}

		[TestMethod]
		public void Constructor_NullFeedUri_ExceptionThrown()
		{
			// Fixture setup
			var name = "News channel";
			Uri feedUri = null;
			var httpClient = new HttpClientMock();
			var rssParser = new RssParserMock();

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentNullException>(() => new NewsChannel(name, feedUri, httpClient, rssParser));

			// Teardown
		}

		[TestMethod]
		public void Constructor_NullHttpClient_ExceptionThrown()
		{
			// Fixture setup
			var name = "News channel";
			var feedUri = new Uri("http://news.com/rss");
			IHttpClient httpClient = null;
			var rssParser = new RssParserMock();

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentNullException>(() => new NewsChannel(name, feedUri, httpClient, rssParser));

			// Teardown
		}

		[TestMethod]
		public void Constructor_NullRssParser_ExceptionThrown()
		{
			// Fixture setup
			var name = "News channel";
			var feedUri = new Uri("http://news.com/rss");
			var httpClient = new HttpClientMock();
			IRssParser rssParser = null;

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentNullException>(() => new NewsChannel(name, feedUri, httpClient, rssParser));

			// Teardown
		}

		[TestMethod]
		public async Task GetLatestNewsAsync_UsingLentaRuSampleData_ValidNewsFeed()
		{
			// Fixture setup
			var name = "News channel";
			var feedUri = new Uri("http://news.com/rss");

			IHttpClient httpClient = new HttpClientMock { SampleDataPreference = SampleDataPreference.LentaRu };
			IRssParser rssParser = new SyndicationFeedDecorator();

			var newsChannel = new NewsChannel(name, feedUri, httpClient, rssParser);

			var expectedCount = 3;
			var expectedFirstItemTitle = "На побережье французского острова в Индийском океане нашли обломок самолета";
			var expectedFirstItemText = "На побережье французского острова Реюньон, расположенного в Индийском океане к востоку от Мадагаскара, найден обломок неизвестного самолета. Специалисты считают, что трехметровая деталь могла принадлежать малайзийскому «Боингу», который пропал в ночь на 8 марта 2014 года.";
			var expectedFirstItemPublicationDate = new DateTimeOffset(2015, 7, 29, 19, 23, 0, TimeSpan.FromHours(3));
			var expectedFirstItemImageSource = new Uri("http://icdn.lenta.ru/images/2015/07/29/18/20150729183227894/pic_df052e4cec4b74c4b14d369026bcef69.jpg");

			// Exercise system
			var newsFeed = await newsChannel.GetLatestNewsAsync();
			var feedItems = newsFeed.Items.ToList();
			var firstItem = feedItems[0];

			// Verify outcome
			Assert.AreEqual(feedItems.Count, expectedCount);
			Assert.AreEqual(firstItem.Title, expectedFirstItemTitle);
			Assert.AreEqual(firstItem.Text, expectedFirstItemText);
			Assert.AreEqual(firstItem.PublicationDate, expectedFirstItemPublicationDate);
			Assert.AreEqual(firstItem.ImageSource, expectedFirstItemImageSource);

			// Teardown
		}

		[TestMethod]
		public async Task GetLatestNewsAsync_UsingGazetaRuSampleData_ValidNewsFeed()
		{
			// Fixture setup
			var name = "News channel";
			var feedUri = new Uri("http://news.com/rss");

			IHttpClient httpClient = new HttpClientMock { SampleDataPreference = SampleDataPreference.GazetaRu };
			IRssParser rssParser = new SyndicationFeedDecorator();

			var newsChannel = new NewsChannel(name, feedUri, httpClient, rssParser);

			var expectedCount = 3;
			var expectedFirstItemTitle = "Минюст включил Национальный фонд в поддержку демократии в список нежелательных организаций";
			var expectedFirstItemText = "Министерство юстиции России включило Национальный фонд в поддержку демократии в список иностранных и международных неправительственных организаций, деятельность которых на территории страны признана нежелательной. Об этом сообщается на ...";
			var expectedFirstItemPublicationDate = new DateTimeOffset(2015, 7, 29, 19, 17, 5, TimeSpan.FromHours(3));
			Uri expectedFirstItemImageSource = null;

			// Exercise system
			var newsFeed = await newsChannel.GetLatestNewsAsync();
			var feedItems = newsFeed.Items.ToList();
			var firstItem = feedItems[0];

			// Verify outcome
			Assert.AreEqual(feedItems.Count, expectedCount);
			Assert.AreEqual(firstItem.Title, expectedFirstItemTitle);
			Assert.AreEqual(firstItem.Text, expectedFirstItemText);
			Assert.AreEqual(firstItem.PublicationDate, expectedFirstItemPublicationDate);
			Assert.AreEqual(firstItem.ImageSource, expectedFirstItemImageSource);

			// Teardown
		}

		[TestMethod]
		public async Task GetLatestNewsAsync_UsingGazetaRuSampleData_NoHtmlSpecialEntitiesInText()
		{
			// Fixture setup
			var name = "News channel";
			var feedUri = new Uri("http://news.com/rss");

			IHttpClient httpClient = new HttpClientMock { SampleDataPreference = SampleDataPreference.GazetaRu };
			IRssParser rssParser = new SyndicationFeedDecorator();

			var newsChannel = new NewsChannel(name, feedUri, httpClient, rssParser);

			var expectedResult = false;

			// Exercise system
			var newsFeed = await newsChannel.GetLatestNewsAsync();
			var feedItems = newsFeed.Items.ToList();
			var thirdItem = feedItems[2];
			var itemContainsQuotationMark = thirdItem.Text.Contains("&quot;");

			// Verify outcome
			Assert.AreEqual(itemContainsQuotationMark, expectedResult);

			// Teardown
		}
	}
}