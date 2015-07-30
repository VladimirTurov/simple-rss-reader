namespace NewsClient.ViewModel
{
	using System;
	using System.Collections.Generic;
	using System.Collections.ObjectModel;
	using System.ComponentModel;
	using System.Runtime.CompilerServices;
	using System.Threading.Tasks;
	using Infrastructure;
	using Model;

	public class NewsFeedViewModel : INotifyPropertyChanged
	{
		private readonly IHttpClient httpClient;
		private readonly IProgressIndicator progressIndicator;
		private readonly IRssParser rssParser;

		private ObservableCollection<NewsDetailsViewModel> news;

		public NewsFeedViewModel(IHttpClient httpClient, IRssParser rssParser, IProgressIndicator progressIndicator)
		{
			if (httpClient == null) throw new ArgumentNullException("httpClient", "HTTP client cannot be null");
			if (rssParser == null) throw new ArgumentNullException("rssParser", "RSS parser cannot be null");
			if (progressIndicator == null) throw new ArgumentNullException("progressIndicator", "Progress indicator cannot be null");

			this.httpClient = httpClient;
			this.rssParser = rssParser;
			this.progressIndicator = progressIndicator;
		}

		public ObservableCollection<NewsDetailsViewModel> News
		{
			get { return news; }
			private set
			{
				if (value == news) return;
				news = value;
				OnPropertyChanged();
			}
		}

		public async Task GetLatestNewsAsync(params NewsChannel[] newsChannels)
		{
			if (newsChannels.Length == 0) throw new ArgumentException("Source news channels cannot be empty");
			foreach (var newsChannel in newsChannels)
				if (newsChannel == null) throw new ArgumentException("Source news channel cannot be null");

			await progressIndicator.ShowAsync("Обновляем список новостей");

			var viewModels = await Task.Run(async () => await GetNewsFromChannelsAsync(newsChannels));
			News = new ObservableCollection<NewsDetailsViewModel>(viewModels);

			await progressIndicator.HideAsync();
		}

		private async Task<List<NewsDetailsViewModel>> GetNewsFromChannelsAsync(params NewsChannel[] newsChannels)
		{
			var result = new List<NewsDetailsViewModel>();
			foreach (var newsChannel in newsChannels)
			{
				var newsFeed = await newsChannel.GetLatestNewsAsync(httpClient, rssParser);
				foreach (var newsItem in newsFeed.Items)
					result.Add(new NewsDetailsViewModel(newsChannel, newsItem));
			}
			return result;
		}

		#region INotifyPropertyChanged

		public event PropertyChangedEventHandler PropertyChanged;

		protected virtual void OnPropertyChanged([CallerMemberName] string propertyName = null)
		{
			var handler = PropertyChanged;
			if (handler != null) handler(this, new PropertyChangedEventArgs(propertyName));
		}

		#endregion
	}
}