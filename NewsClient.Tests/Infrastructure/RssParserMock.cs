namespace NewsClient.Tests.Infrastructure
{
	using System;
	using NewsClient.Infrastructure;
	using NewsClient.Model;

	internal class RssParserMock : IRssParser
	{
		public NewsFeed Parse(string rss)
		{
			return null;
		}
	}
}