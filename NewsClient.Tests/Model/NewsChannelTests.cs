namespace NewsClient.Tests.Model
{
	using System;
	using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
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
	}
}