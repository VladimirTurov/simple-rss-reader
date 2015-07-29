namespace NewsClient.Model
{
	using System;

	public class NewsChannel
	{
		public NewsChannel(string name, Uri feedUri)
		{
			if (name == null) throw new ArgumentNullException("name", "Channel name cannot be null");
			if (feedUri == null) throw new ArgumentNullException("feedUri", "Channel feed uri cannot be null");

			Name = name;
			FeedUri = feedUri;
		}

		public string Name { get; private set; }
		public Uri FeedUri { get; private set; }
	}
}