namespace NewsClient.Tests.Infrastructure
{
	using System.Threading.Tasks;
	using NewsClient.Infrastructure;

	public class ProgressIndicatorMock : IProgressIndicator
	{
		public string CurrentProgressText { get; private set; }

		public async Task ShowAsync(string text)
		{
			CurrentProgressText = text;
		}

		public async Task HideAsync()
		{
			CurrentProgressText = null;
		}
	}
}