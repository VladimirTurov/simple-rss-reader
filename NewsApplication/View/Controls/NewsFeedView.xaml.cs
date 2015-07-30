namespace NewsApplication.View.Controls
{
   using System;
   using Windows.UI.Xaml.Controls;
   using NewsClient.ViewModel;

   public sealed partial class NewsFeedView
   {
      public NewsFeedView()
      {
         this.InitializeComponent();
      }

      public event EventHandler<FeedItemSelectedArgs> FeedItemSelected;

      private void OnSelectionChanged(object sender, SelectionChangedEventArgs e)
      {
         var listView = (sender as ListView);
         var currentSelected = listView.SelectedItem;
         if (currentSelected == null) return;

         if (FeedItemSelected != null)
            FeedItemSelected(this, new FeedItemSelectedArgs(currentSelected as NewsDetailsViewModel));

         listView.SelectedItem = null;
      }
   }
}