namespace NewsClient.Model
{
	using System;

	public class NewsItem
	{
		public NewsItem(string title, string text, DateTimeOffset publicationDate, Uri imageSource)
		{
			if (title == null) throw new ArgumentNullException("title", "News title cannot be null");
			if (text == null) throw new ArgumentNullException("text", "News text cannot be null");
			if (publicationDate == default(DateTimeOffset))
				throw new ArgumentException("News publication date cannot be equal to default value");

			Title = title;
			Text = text;
			PublicationDate = publicationDate;
			ImageSource = imageSource;
		}

		public string Title { get; private set; }
		public string Text { get; private set; }
		public DateTimeOffset PublicationDate { get; private set; }
		public Uri ImageSource { get; private set; }
	}
}