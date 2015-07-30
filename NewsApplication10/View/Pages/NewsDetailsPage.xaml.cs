namespace NewsApplication.View.Pages
{
   using Windows.Phone.UI.Input;
   using Windows.UI.Xaml.Navigation;

   public sealed partial class NewsDetailsPage
   {
      public NewsDetailsPage()
      {
         this.InitializeComponent();

         HardwareButtons.BackPressed += OnBackPress;
      }

      protected override void OnNavigatedTo(NavigationEventArgs e)
      {
         if (e.NavigationMode == NavigationMode.New)
         {
            var vm = e.Parameter;
            Details.DataContext = vm;
         }
      }

      private void OnBackPress(object sender, BackPressedEventArgs e)
      {
         e.Handled = true;

         if (Frame.CanGoBack)
            Frame.GoBack();
      }
   }
}