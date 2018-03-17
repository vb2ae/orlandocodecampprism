using System;
using System.Collections.ObjectModel;
using System.Threading.Tasks;
using OrlandoDemo.Models;
using OrlandoDemo.Services;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;

namespace OrlandoDemo.ViewModels
{
    public class LaunchSchedulePageViewModel: ViewModelBase
    {
        public ObservableCollection<LaunchInfo> Launches { get; set; }

        private IPageDialogService pageDialog = null;

        public DelegateCommand ItemTappedCommand => new DelegateCommand(async ()=> {
            await pageDialog.DisplayAlertAsync("test","Item Tapped", "OK");
        });


        public LaunchSchedulePageViewModel(INavigationService navigationService, IGetLaunches getLaunches, IPageDialogService dialogService)
            : base(navigationService)
        {
            pageDialog = dialogService;
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
                        string uri = "https://www.nasa.gov/sites/all/themes/custom/nasatwo/images/nasa-logo.svg";
                        if (source.MasterImage != null)
                        {
                            string url = source.MasterImage.Uri.ToString();
                            uri = url.Replace("public://", "https://www.nasa.gov/sites/default/files/styles/image_card_4x3_ratio/public/");
                        }
                        Launches.Add(new LaunchInfo{ Title=source.Title, 
                            LaunchDate=source.EventDate[0].Value.DateTime,
                            ImageUri=uri});
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
