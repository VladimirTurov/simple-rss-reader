namespace NewsApplication.Infrastructure
{
   using System;
   using System.Threading.Tasks;
   using Windows.UI.ViewManagement;
   using NewsClient.Infrastructure;

   public class StatusBarProxy : IProgressIndicator
   {
      private readonly StatusBar statusBar;

      public StatusBarProxy()
      {
         statusBar = StatusBar.GetForCurrentView();
      }

      public async Task ShowAsync(string text)
      {
         statusBar.ProgressIndicator.Text = text;
         await statusBar.ProgressIndicator.ShowAsync();
      }

      public async Task HideAsync()
      {
         await statusBar.ProgressIndicator.HideAsync();
      }
   }
}