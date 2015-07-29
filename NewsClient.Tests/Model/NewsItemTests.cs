namespace NewsClient.Tests.Model
{
	using System;
	using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
	using NewsClient.Model;

	[TestClass]
	public class NewsItemTests
	{
		[TestMethod]
		public void Constructor_NullTitle_ExceptionThrown()
		{
			// Fixture setup
			string title = null;
			var text = "News text";
			var publicationDate = DateTimeOffset.Now;
			var imageSource = new Uri("http://news.com/logo.png");

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentNullException>
				(() => new NewsItem(title, text, publicationDate, imageSource));

			// Teardown
		}

		[TestMethod]
		public void Constructor_NullText_ExceptionThrown()
		{
			// Fixture setup
			var title = "News title";
			string text = null;
			var publicationDate = DateTimeOffset.Now;
			var imageSource = new Uri("http://news.com/logo.png");

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentNullException>
				(() => new NewsItem(title, text, publicationDate, imageSource));

			// Teardown
		}

		[TestMethod]
		public void Constructor_PassingUninitializedPublishedDate_ExceptionThrown()
		{
			// Fixture setup
			var title = "News title";
			string text = "News text";
			DateTimeOffset publicationDate;
			var imageSource = new Uri("http://news.com/logo.png");

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentException>
				(() => new NewsItem(title, text, publicationDate, imageSource));

			// Teardown
		}
	}
}