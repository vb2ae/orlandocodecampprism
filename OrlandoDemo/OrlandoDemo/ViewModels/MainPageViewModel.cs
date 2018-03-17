using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;

namespace OrlandoDemo.ViewModels
{
    public class MainPageViewModel : ViewModelBase
    {
        private bool isLoaded = false;

        private string _name;
        public string Name { 
            get
            {
                return _name;
            } 
            set
            {
                    _name = value;
                    //SayHello.RaiseCanExecuteChanged();
                    RaisePropertyChanged("Name");
                if(isLoaded)
                {
                    SayHello.RaiseCanExecuteChanged();
                }
            }
        }

        public MainPageViewModel(INavigationService navigationService, IPageDialogService dialogService)
            : base(navigationService)
        {
            Title = "Main Page";
            Name = string.Empty;

           ShowLaunchPage = new DelegateCommand(async () =>
            {
                await navigationService.NavigateAsync("LaunchSchedulePage");
            });
       
            SayHello = new DelegateCommand(async () =>
            {
                await dialogService.DisplayAlertAsync("Demo App", $"Hello {Name}", "OK");
            }, () => !string.IsNullOrEmpty(Name));
        }

        public DelegateCommand ShowLaunchPage { get; }
        public DelegateCommand SayHello { get; }


        public override void OnNavigatedTo(NavigationParameters parameters)
        {
            isLoaded = true;
        }

    }
}
