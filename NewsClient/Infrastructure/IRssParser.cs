namespace NewsClient.Infrastructure
{
	using Model;

	public interface IRssParser
	{
		NewsFeed Parse(string rss);
	}
}