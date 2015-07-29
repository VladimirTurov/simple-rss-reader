namespace NewsApplication
{
	using System;
	using System.Diagnostics;
	using Windows.ApplicationModel;
	using Windows.ApplicationModel.Activation;
	using Windows.UI.Xaml;
	using Windows.UI.Xaml.Controls;
	using Windows.UI.Xaml.Media.Animation;
	using Windows.UI.Xaml.Navigation;
	using View.Pages;

	public sealed partial class App
	{
		private TransitionCollection transitions;

		public App()
		{
			InitializeComponent();
			Suspending += OnSuspending;
		}

		protected override void OnLaunched(LaunchActivatedEventArgs e)
		{
#if DEBUG
			if (Debugger.IsAttached)
			{
				DebugSettings.EnableFrameRateCounter = true;
			}
#endif

			var rootFrame = Window.Current.Content as Frame;
			if (rootFrame == null)
			{
				rootFrame = new Frame {CacheSize = 1};

				if (e.PreviousExecutionState == ApplicationExecutionState.Terminated)
				{
					// TODO: Load state from previously suspended application
				}

				Window.Current.Content = rootFrame;
			}

			if (rootFrame.Content == null)
			{
				if (rootFrame.ContentTransitions != null)
				{
					transitions = new TransitionCollection();
					foreach (var c in rootFrame.ContentTransitions)
						transitions.Add(c);
				}

				rootFrame.ContentTransitions = null;
				rootFrame.Navigated += RootFrame_FirstNavigated;

				// When the navigation stack isn't restored navigate to the first page,
				// configuring the new page by passing required information as a navigation
				// parameter
				if (!rootFrame.Navigate(typeof (NewsFeedPage), e.Arguments))
					throw new Exception("Failed to create initial page");
			}

			// Ensure the current window is active
			Window.Current.Activate();
		}

		private void RootFrame_FirstNavigated(object sender, NavigationEventArgs e)
		{
			var rootFrame = sender as Frame;
			rootFrame.ContentTransitions = transitions ?? new TransitionCollection {new NavigationThemeTransition()};
			rootFrame.Navigated -= RootFrame_FirstNavigated;
		}

		private void OnSuspending(object sender, SuspendingEventArgs e)
		{
			var deferral = e.SuspendingOperation.GetDeferral();

			// TODO: Save application state and stop any background activity
			deferral.Complete();
		}
	}
}