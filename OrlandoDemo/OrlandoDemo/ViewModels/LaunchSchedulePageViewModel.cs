using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OrlandoDemo.Models;
using OrlandoDemo.Services;
using Prism.Navigation;

namespace OrlandoDemo.ViewModels
{
    public class LaunchSchedulePageViewModel: ViewModelBase
    {
        public ObservableCollection<LaunchInfo> Launches { get; set; }

        public LaunchSchedulePageViewModel(INavigationService navigationService, IGetLaunches getLaunches)
            : base(navigationService)
        {
            Launches = new ObservableCollection<LaunchInfo>();
            Title = "Launch Schedule";
            Welcome launches = null;
            Task.Run(async() =>
            {
                launches = await getLaunches.GetLaunches();
                if (launches != null)
                {
                    foreach (var hit in launches.Hits.HitsHits)
                    {
                        var source = hit.Source;
                        Launches.Add(new LaunchInfo{ Title=source.Title, 
                            LaunchDate=source.EventDate[0].Value.DateTime,
                            ImageUri=source.MasterImage.Uri});
                    }
                }
                if (Launches.Count == 0)
                {
                    Launches.Add(new LaunchInfo { Title = "Please Connect to the internet" });
                }       
            });
            Task.WaitAll();

        }
    }
}
