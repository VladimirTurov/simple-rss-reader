namespace NewsApplication.View.Pages
{
	using Windows.UI.Xaml.Navigation;

	public sealed partial class NewsFeedPage
	{
		public NewsFeedPage()
		{
			InitializeComponent();

			NavigationCacheMode = NavigationCacheMode.Required;
		}

		protected override void OnNavigatedTo(NavigationEventArgs e)
		{
		}
	}
}