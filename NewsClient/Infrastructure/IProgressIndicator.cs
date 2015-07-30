namespace NewsClient.Infrastructure
{
	using System.Threading.Tasks;

	public interface IProgressIndicator
	{
		Task ShowAsync(string text);
		Task HideAsync();
	}
}