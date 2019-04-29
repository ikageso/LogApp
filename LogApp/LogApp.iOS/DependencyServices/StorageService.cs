using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

using Foundation;
using LogApp.DependencyServices;
using LogApp.iOS.DependencyServices;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(StorageService))]

namespace LogApp.iOS.DependencyServices
{
    public class StorageService : IStorageService
    {
        public string GetLogFilePath()
        {
            var documents
              = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);
            var localAppData = Path.Combine(documents, "..", "Library");
            return localAppData;
        }
    }
}