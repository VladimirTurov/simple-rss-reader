namespace NewsApplication.View.Controls
{
   using Windows.UI.Xaml;

   public sealed partial class NewsDetailsView
   {
      public NewsDetailsView()
      {
         this.InitializeComponent();
      }

      private void OnImageCoverLoaded(object sender, RoutedEventArgs e)
      {
         ImageFadeOutAnimation.Begin();
      }
   }
}