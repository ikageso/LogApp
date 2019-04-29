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
using Xamarin.Forms;

[assembly: Dependency(typeof(StorageService))]

namespace LogApp.Droid.DependencyServices
{
    public class StorageService : IStorageService
    {
        public string GetLogFilePath()
        {
            return System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
        }
    }
}