﻿using System;
using System.Collections.Generic;
using System.Linq;

using Foundation;
using UIKit;
using Erebus.Core.Mobile;
using ObjCRuntime;
using Erebus.Core.Mobile.Contracts;
using Autofac;

namespace Erebus.Mobile.iOS
{
    // The UIApplicationDelegate for the application. This class is responsible for launching the 
    // User Interface of the application, as well as listening (and optionally responding) to 
    // application events from iOS.
    [Register("AppDelegate")]
    public partial class AppDelegate : global::Xamarin.Forms.Platform.iOS.FormsApplicationDelegate
    {
        //
        // This method is invoked when the application has loaded and is ready to run. In this 
        // method you should instantiate the window, load the UI into it and then make the window
        // visible.
        //
        // You have 17 seconds to return from this method, or iOS will terminate your application.
        //
        public override bool FinishedLaunching(UIApplication app, NSDictionary options)
        {
            global::Xamarin.Forms.Forms.Init();
            LoadApplication(new App(new ContainerFactory()));

            return base.FinishedLaunching(app, options);
        }

        public override async void PerformFetch(UIApplication application, Action<UIBackgroundFetchResult> completionHandler)
        {
            try
            {
                var containerFactory = new ContainerFactory();
                containerFactory.AddRegistrations(builder =>
                {
                    var iosRegistrations = new iOSPlatformServicesRegistrator();
                    iosRegistrations.RegisterPlatformSpecificServices(builder);
                });

                var container = containerFactory.Build();
                var synchronizer = container.Resolve<ISynchronizer>();

                var serverOnline = await synchronizer.Synchronize();
                completionHandler(UIBackgroundFetchResult.NewData);
            }
            catch (Exception ex)
            {
                completionHandler(UIBackgroundFetchResult.Failed);
            }
        }
    }
}
