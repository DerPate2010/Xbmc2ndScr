// (c) Copyright Microsoft Corporation.
// This source is subject to the Microsoft Public License (Ms-PL).
// Please see http://go.microsoft.com/fwlink/?LinkID=131993 for details.
// All other rights reserved.


namespace System.Windows.Threading
{
    public interface IDispatcher
    {
        bool DesignModeEnabled { get; }
        bool HasThreadAccess { get; }
        void RunAsync(Action a);
    }

    /// <summary>
    /// A smart dispatcher system for routing actions to the user interface
    /// thread.
    /// </summary>
    public static class SmartDispatcher
    {
        /// <summary>
        /// A single Dispatcher instance to marshall actions to the user
        /// interface thread.
        /// </summary>
        private static IDispatcher _instance;


        /// <summary>
        /// Backing field for a value indicating whether this is a design-time
        /// environment.
        /// </summary>
        private static bool? _designer;

        /// <summary>
        /// Requires an instance and attempts to find a Dispatcher if one has
        /// not yet been set.
        /// </summary>
        private static void RequireInstance()
        {

                throw new InvalidOperationException("The first time SmartDispatcher is used must be from a user interface thread. Consider having the application call Initialize, with or without an instance.");
        }

        /// <summary>
        /// Initializes the SmartDispatcher system, attempting to use the
        /// RootVisual of the plugin to retrieve a Dispatcher instance.
        /// </summary>
        public static void Initialize()
        {
            if (_instance == null)
            {
                RequireInstance();
            }
        }

        /// <summary>
        /// Initializes the SmartDispatcher system with the dispatcher
        /// instance.
        /// </summary>
        /// <param name="dispatcher">The dispatcher instance.</param>

        public static void Initialize(IDispatcher dispatcher)
        {
            if (dispatcher == null)
            {
                throw new ArgumentNullException("dispatcher");
            }

            _instance = dispatcher;

            if (_designer == null)
            {
                _designer = dispatcher.DesignModeEnabled;
            }
        }

        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public static bool HasThreadAccess
        {
            get
            {
                
                    if (_instance == null)
                    {
                        RequireInstance();
                    }

                    return _instance.HasThreadAccess;
                
            }
        }

        /// <summary>
        /// Executes the specified delegate asynchronously on the user interface
        /// thread. If the current thread is the user interface thread, the
        /// dispatcher if not used and the operation happens immediately.
        /// </summary>
        /// <param name="a">A delegate to a method that takes no arguments and 
        /// does not return a value, which is either pushed onto the Dispatcher 
        /// event queue or immediately run, depending on the current thread.</param>
        public static void RunAsync(Action a)
        {
            if (_instance == null)
            {
                RequireInstance();
            }

            // If the current thread is the user interface thread, skip the
            // dispatcher and directly invoke the Action.
            if (HasThreadAccess || _designer == true)
            {
                a();
            }
            else
            {
                _instance.RunAsync(a);
            }
        }
    }
}
