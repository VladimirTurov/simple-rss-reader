namespace NewsApplication.View.Pages
{
   using System;
   using Windows.UI.Xaml.Navigation;
   using Controls;
   using Infrastructure;
   using NewsClient.Infrastructure;
   using NewsClient.Model;
   using NewsClient.ViewModel;

   public sealed partial class NewsFeedPage
   {
      public NewsFeedPage()
      {
         InitializeComponent();

         NavigationCacheMode = NavigationCacheMode.Required;
      }

      protected override async void OnNavigatedTo(NavigationEventArgs e)
      {
         if (e.NavigationMode == NavigationMode.New)
         {
            var vm = new NewsFeedViewModel(new StatusBarProxy());

            Feed.DataContext = vm;
            Feed.FeedItemSelected += OnFeedItemSelected;

            IHttpClient httpClient = new HttpClientProxy();
            IRssParser rssParser = new SyndicationFeedDecorator();

            var lentaRu = new NewsChannel("Lenta.ru", new Uri("http://lenta.ru/rss"), httpClient, rssParser);
            var gazetaRu = new NewsChannel("Gazeta.ru", new Uri("http://www.gazeta.ru/export/rss/lenta.xml"), httpClient, rssParser);
            await vm.GetLatestNewsAsync(lentaRu, gazetaRu);
         }
      }

      private void OnFeedItemSelected(object sender, FeedItemSelectedArgs e)
      {
         NavigateToDetailsPage(e.Selected);
      }

      private void NavigateToDetailsPage(NewsDetailsViewModel dataContext)
      {
         Frame.Navigate(typeof (NewsDetailsPage), dataContext);
      }
   }
}