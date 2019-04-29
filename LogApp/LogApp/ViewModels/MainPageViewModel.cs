using Prism.Commands;
using Prism.Logging;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace LogApp.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        public MainPageViewModel(INavigationService navigationService)
            : base(navigationService)
        {
            Title = "Main Page";

            NextPageCommand = new DelegateCommand(async () => await navigationService.NavigateAsync("PrismContentPage1"));
            LogCommand = new DelegateCommand(() =>
            {
                Logger.Log("Log出力", Category.Debug, Priority.High);
            });
        }

        public DelegateCommand NextPageCommand { get; }
        public DelegateCommand LogCommand { get; }
    }
}
