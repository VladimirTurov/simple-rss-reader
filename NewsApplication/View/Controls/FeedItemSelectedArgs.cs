namespace NewsApplication.View.Controls
{
   using System;
   using NewsClient.ViewModel;

   public class FeedItemSelectedArgs : EventArgs
   {
      public FeedItemSelectedArgs(NewsDetailsViewModel selected)
      {
         Selected = selected;
      }

      public NewsDetailsViewModel Selected { get; private set; }
   }
}