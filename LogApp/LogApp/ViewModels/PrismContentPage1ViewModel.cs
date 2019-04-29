using LogApp.DependencyServices;
using Prism.Commands;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace LogApp.ViewModels
{
    public class PrismContentPage1ViewModel : ViewModelBase
    {
        public PrismContentPage1ViewModel(INavigationService navigationService, ILoggerFacade loggerFacade, IStorageService strorageService) : base(navigationService)
        {
            LogCommand = new DelegateCommand(() =>
            {
                Logger.Log("Log出力", Category.Debug, Priority.High);
            });

            LoadCommand = new DelegateCommand(() =>
            {
                var path = strorageService.GetLogFilePath();
                var filename = Path.Combine(path, "Logs/log.log");
                if(File.Exists(filename))
                {
                    using (var sr = new StreamReader(filename))
                    {
                        var data = sr.ReadToEnd();
                        LogText = data;
                    }
                }
            });

            DeleteCommand = new DelegateCommand(() =>
            {
                var path = strorageService.GetLogFilePath();
                var filename = Path.Combine(path, "Logs/log.log");
                if (File.Exists(filename))
                {
                    File.Delete(filename);
                }
            });
        }

        public DelegateCommand LogCommand { get; }
        public DelegateCommand LoadCommand { get; }
        public DelegateCommand DeleteCommand { get; }

        private string _LogText;
        public string LogText
        {
            get { return _LogText; }
            set { SetProperty(ref _LogText, value); }
        }

    }
}
