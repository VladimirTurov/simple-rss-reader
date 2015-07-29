namespace NewsClient.Infrastructure
{
	using System;
	using System.Collections.Generic;
	using Windows.Web.Syndication;
	using Model;

	public class SyndicationFeedDecorator : IRssParser
	{
		public NewsFeed Parse(string rss)
		{
			var syndicationFeed = new SyndicationFeed();
			syndicationFeed.Load(rss);
			return new NewsFeed(TransformRssFeedToNewsItems(syndicationFeed));
		}

		private IEnumerable<NewsItem> TransformRssFeedToNewsItems(SyndicationFeed syndicationFeed)
		{
			var result = new List<NewsItem>();
			foreach (var syndicationItem in syndicationFeed.Items)
			{
				var title = syndicationItem.Title.Text;
				var text = syndicationItem.Summary.Text;
				var publicationDate = syndicationItem.PublishedDate;

				Uri imageSource;
				TryGetImageSource(syndicationItem, out imageSource);

				var newsItem = new NewsItem(title, text, publicationDate, imageSource);
				result.Add(newsItem);
			}
			return result;
		}

		private void TryGetImageSource(SyndicationItem syndicationItem, out Uri imageSource)
		{
			foreach (var link in syndicationItem.Links)
			{
				if (!link.MediaType.Contains("image")) continue;
				imageSource = link.Uri;
				return;
			}

			imageSource = null;
		}
	}
}