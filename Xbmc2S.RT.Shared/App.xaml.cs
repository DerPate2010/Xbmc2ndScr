using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using System.Windows.Threading;
using Windows.UI.Popups;
using System;
using Windows.ApplicationModel;
using Windows.ApplicationModel.Activation;
using Windows.ApplicationModel.Background;
using Windows.Storage;
using Windows.UI.Xaml;
using Windows.UI.Xaml.Controls;
using Xbmc2S.Model;
using Xbmc2S.Model.Download;
using Xbmc2S.RT.Background;
using Xbmc2S.RT.Common;
using Xbmc2S.RT.PlatformServices;
using Xbmc2S.RT.SampleDataModel;
using Xbmc2S.RT.UPnP;
// The Grid App template is documented at http://go.microsoft.com/fwlink/?LinkId=234226



namespace Xbmc2S.RT
{
    /// <summary>
    /// Provides application-specific behavior to supplement the default Application class.
    /// </summary>
    sealed partial class App : Application
    {
        private static MainVm _mainVm;

        /// <summary>
        /// Initializes the singleton Application object.  This is the first line of authored code
        /// executed, and as such is the logical equivalent of main() or WinMain().
        /// </summary>
        public App()
        {
            this.InitializeComponent();
            this.Suspending += OnSuspending;
            Platform.Current= new Util();
            SuspensionManager.KnownTypes.Add(typeof(ItemsSourceReference));
        }

        public static MainVm MainVm
        {
            get
            {
                if (_mainVm == null)
                {
                    _mainVm = new MainVm(PlatformServices, new ViewHandler());
                }
                return _mainVm;
            }
        }

        private static PlatformServices.PlatformServices _platformServices;

        public static PlatformServices.PlatformServices PlatformServices
        {
            get
            {
                if (_platformServices == null)
                {
                    _platformServices = new PlatformServices.PlatformServices(ProgressIndicator, GetLauncher());
                }
                return _platformServices;
            }
        }


        /// <summary>
        /// Invoked when the application is launched normally by the end user.  Other entry points
        /// will be used when the application is launched to open a specific file, to display
        /// search results, and so forth.
        /// </summary>
        /// <param name="args">Details about the launch request and process.</param>
        protected override async void OnLaunched(LaunchActivatedEventArgs args)
        {
            await PrepareWindow(args);

            if (RootFrame.Content == null)
            {


                await MainVm.CurrentConnection.OnLaunch();

                //else
                {
                    // When the navigation stack isn't restored navigate to the first page,
                    // configuring the new page by passing required information as a navigation
                    // parameter
                    if (!RootFrame.Navigate(typeof(HubPage)))
                    {
                        throw new Exception("Failed to create initial page");
                    }
                }

            }
            
            // Ensure the current window is active
            Window.Current.Activate();

            await RegisterBackgroundTask();

            //new SampleDataSource();
        }

        private async Task PrepareWindow(IActivatedEventArgs args)
        {
            SmartDispatcher.Initialize(new SmartDispatcherRT());
            var grid = Window.Current.Content as Grid;

            // Do not repeat app initialization when the Window already has content,
            // just ensure that the window is active

            if (grid == null)
            {
                // Create a Frame to act as the navigation context and navigate to the first page
                RootFrame = new Frame();
                //Associate the frame with a SuspensionManager key                                
                SuspensionManager.RegisterFrame(RootFrame, "AppFrame");

                if (args.PreviousExecutionState == ApplicationExecutionState.Terminated)
                {
                    // Restore the saved session state only when appropriate
                    try
                    {
                        await SuspensionManager.RestoreAsync();
                    }
                    catch (SuspensionManagerException)
                    {
                        //Something went wrong restoring state.
                        //Assume there is no state and continue
                    }
                }

                // Place the frame in the current Window
                grid = new Grid();
                grid.Children.Add(RootFrame);
                if (ProgressIndicator is UIElement)
                {
                    grid.Children.Add((UIElement) ProgressIndicator);
                }
                Window.Current.Content = grid;

                DoPlatformDependentInitialization();

            }
            else
            {
                RootFrame = grid.Children[0] as Frame;
            }
        }

        private void GotoWelcomeWizard(IUICommand command)
        {
            var view = new ViewHandler();
            view.GotoWelcomeWizard();
        }



        internal static Frame RootFrame { get; private set; }


        private async Task RegisterBackgroundTask()
        {
            var taskName = typeof (DownloadWatcher).Name;
            var taskEntryPoint = typeof (DownloadWatcher).FullName;
            var l = BackgroundTaskRegistration.AllTasks.ToList();
            var bgTask=l.Select(t=>t.Value).FirstOrDefault(n=>n.Name==taskName);
            if (bgTask == null)
            {
                try
                {
                    await BackgroundExecutionManager.RequestAccessAsync();
                }
                catch (Exception)
                {
                    
                    throw;
                }

                var builder = new BackgroundTaskBuilder();

                builder.Name = taskName;
                builder.TaskEntryPoint = taskEntryPoint;
                builder.SetTrigger(new TimeTrigger(15, false));
                //builder.AddCondition(new SystemCondition(SystemConditionType.InternetAvailable));

                bgTask = builder.Register();
            }
        }

        /// <summary>
        /// Invoked when application execution is being suspended.  Application state is saved
        /// without knowing whether the application will be terminated or resumed with the contents
        /// of memory still intact.
        /// </summary>
        /// <param name="sender">The source of the suspend request.</param>
        /// <param name="e">Details about the suspend request.</param>
        private async void OnSuspending(object sender, SuspendingEventArgs e)
        {
            var deferral = e.SuspendingOperation.GetDeferral();
            await MainVm.Suspend();
            await SuspensionManager.SaveAsync();
            deferral.Complete();
        }

        /// <summary>
        /// Invoked when the application is activated to display search results.
        /// </summary>
        /// <param name="args">Details about the activation request.</param>
        protected async override void OnSearchActivated(Windows.ApplicationModel.Activation.SearchActivatedEventArgs args)
        {
            await PrepareWindow(args);

            //RootFrame.Navigate(typeof(SearchResultsPage), args.QueryText);

            // Ensure the current window is active
            Window.Current.Activate();
        }


    }
}
