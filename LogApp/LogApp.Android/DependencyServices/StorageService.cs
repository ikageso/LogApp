using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using LogApp.DependencyServices;
using LogApp.Droid.DependencyServices;
using LogApp.Services;
using Prism.Logging;
using Xamarin.Forms;

[assembly: Dependency(typeof(StorageService))]

namespace LogApp.Droid.DependencyServices
{
    public class StorageService : IStorageService
    {
        public string GetLogFilePath()
        {
            var path = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);

            var logger = (ILoggerService)App.Current.Container.Resolve(typeof(ILoggerService));
            logger.Log($"path={path}");

            return path;
        }
    }
}