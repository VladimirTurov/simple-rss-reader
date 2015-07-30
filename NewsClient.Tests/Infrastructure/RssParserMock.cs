namespace NewsClient.Tests.Infrastructure
{
	using System;
	using NewsClient.Infrastructure;
	using NewsClient.Model;

	internal class RssParserMock : IRssParser
	{
		public Func<string, NewsFeed> CustomParsingFunction { get; set; } 

		public NewsFeed Parse(string rss)
		{
			if (CustomParsingFunction != null)
				return CustomParsingFunction(rss);

			return null;
		}
	}
}