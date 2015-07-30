namespace NewsApplication.View.Pages
{
   using System;
   using Windows.UI.Xaml.Navigation;
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
            var vm = new NewsFeedViewModel(new HttpClientProxy(), new SyndicationFeedDecorator(), new StatusBarProxy());

            Feed.DataContext = vm;

            var lentaRu = new NewsChannel("Lenta.ru", new Uri("http://lenta.ru/rss"));
            var gazetaRu = new NewsChannel("Gazeta.ru", new Uri("http://www.gazeta.ru/export/rss/lenta.xml"));
            await vm.GetLatestNewsAsync(lentaRu, gazetaRu);
         }
      }
   }
}