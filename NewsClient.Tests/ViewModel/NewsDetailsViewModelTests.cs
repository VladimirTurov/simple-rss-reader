namespace NewsClient.Tests.ViewModel
{
	using System;
	using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
	using NewsClient.Model;
	using NewsClient.ViewModel;

	[TestClass]
	public class NewsDetailsViewModelTests
	{
		[TestMethod]
		public void Constructor_NullNewsChannel_ExceptionThrown()
		{
			// Fixture setup
			NewsChannel newsChannel = null;
			var newsItem = new NewsItem("News title", "News text", DateTimeOffset.Now, null);

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentNullException>
				(() => new NewsDetailsViewModel(newsChannel, newsItem));

			// Teardown
		}

		[TestMethod]
		public void Constructor_NullNewsItem_ExceptionThrown()
		{
			// Fixture setup
			var newsChannel = new NewsChannel("News channel", new Uri("http://news.com/rss"));
			NewsItem newsItem = null;

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentNullException>
				(() => new NewsDetailsViewModel(newsChannel, newsItem));

			// Teardown
		}

		[TestMethod]
		public void Constructor_ValidInput_DetailsCorrect()
		{
			// Fixture setup
			var expectedTitle = "News title";
			var expectedText = "News text";
			Uri expectedImageSource = null;

			var expectedPublicationDate = DateTimeOffset.Now;
			var channelName = "News channel";
			var expectedPublicationDetails = expectedPublicationDate.ToString("dd.MM.yyy - HH:mm") + " • " + channelName;

			var newsChannel = new NewsChannel(channelName, new Uri("http://news.com/rss"));
			var newsItem = new NewsItem(expectedTitle, expectedText, expectedPublicationDate, expectedImageSource);

			// Exercise system
			var viewModel = new NewsDetailsViewModel(newsChannel, newsItem);

			// Verify outcome
			Assert.AreEqual(viewModel.Title, expectedTitle);
			Assert.AreEqual(viewModel.Text, expectedText);
			Assert.AreEqual(viewModel.PublicationDate, expectedPublicationDate);
			Assert.AreEqual(viewModel.ImageSource, expectedImageSource);
			Assert.AreEqual(viewModel.PublicationDetails, expectedPublicationDetails);

			// Teardown
		}
	}
}