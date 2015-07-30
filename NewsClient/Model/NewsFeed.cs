namespace NewsClient.Model
{
	using System;
	using System.Collections.Generic;
	using System.Linq;

	public class NewsFeed
	{
		public NewsFeed(IEnumerable<NewsItem> items)
		{
			if (items == null) throw new ArgumentNullException("items", "Source items for news feed cannot be null");
			if (items.Count() == 0) throw new ArgumentException("Source items for news feed cannot be empty", "items");

			Items = items;
		}

		public IEnumerable<NewsItem> Items { get; private set; }
	}
}