namespace NewsClient.ViewModel
{
	using System;
	using Model;

	public class NewsDetailsViewModel
	{
		public NewsDetailsViewModel(NewsChannel newsChannel, NewsItem newsItem)
		{
			if (newsChannel == null) throw new ArgumentNullException("newsChannel", "News channel cannot be null");
			if (newsItem == null) throw new ArgumentNullException("newsItem", "Source news item cannot be null");

			UpdateDetails(newsItem);
			ComposePublicationDetails(newsChannel, newsItem);
		}

		public string Title { get; private set; }
		public string Text { get; private set; }
		public string PublicationDetails { get; private set; }
		public Uri ImageSource { get; private set; }

		private void UpdateDetails(NewsItem source)
		{
			Title = source.Title;
			Text = source.Text;
			ImageSource = source.ImageSource;
		}

		private void ComposePublicationDetails(NewsChannel newsChannel, NewsItem newsItem)
		{
			PublicationDetails = newsItem.PublicationDate.ToString("dd.MM.yyy - HH:mm") + " • " + newsChannel.Name;
		}
	}
}