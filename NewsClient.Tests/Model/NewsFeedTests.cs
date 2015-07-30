namespace NewsClient.Tests.Model
{
	using System;
	using System.Collections.Generic;
	using Microsoft.VisualStudio.TestPlatform.UnitTestFramework;
	using NewsClient.Model;

	[TestClass]
	public class NewsFeedTests
	{
		[TestMethod]
		public void Constructor_NullItems_ExceptionThrown()
		{
			// Fixture setup
			List<NewsItem> items = null;

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentNullException>(() => new NewsFeed(items));

			// Teardown
		}

		[TestMethod]
		public void Constructor_EmptyItems_ExceptionThrown()
		{
			// Fixture setup
			var items = new List<NewsItem>();

			// Exercise system
			// Verify outcome
			Assert.ThrowsException<ArgumentException>(() => new NewsFeed(items));

			// Teardown
		}
	}
}