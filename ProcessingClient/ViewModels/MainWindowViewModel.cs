using Catel.MVVM;
using Catel.Data;
using Catel.Services;
using System;
using System.Linq;
using System.Collections.ObjectModel;
using System.Configuration;
using EmulationProcessing.Models;
using EmulationProcessing.dbmodels;

namespace EmulationProcessing.ViewModels
{

    public class MainWindowViewModel : ViewModelBase
    {

        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IPleaseWaitService _pleaseWaitService;
        private readonly IMessageService _messageService;

        public override string Title { get { return "Эмуляция"; } }

        public MainWindowViewModel(IUIVisualizerService uiVisualizerService, IPleaseWaitService pleaseWaitService, IMessageService messageService)
        {
            _uiVisualizerService = uiVisualizerService;
            _pleaseWaitService = pleaseWaitService;
            _messageService = messageService;

            ProvidersCollection = new ObservableCollection<ProviderModel>();
            using (var db = new ProcessingContext())
            {
                var res = from ap in db.AccessProviders
                          join p in db.Providers on ap.Provider_id equals p.Id
                          join u in db.Users on ap.User_id equals u.Id
                          select new { p.Name, p.Logo };
                foreach (var t in res)
                {
                    ProvidersCollection.Add(new ProviderModel()
                    {
                        Name = t.Name,
                        Logo = ConfigurationManager.AppSettings["images_folder"] + t.Logo
                    });
                }
            }
        }

        public ObservableCollection<ProviderModel> ProvidersCollection
        {
            get { return GetValue<ObservableCollection<ProviderModel>>(ProvidersCollectionProperty); }
            set { SetValue(ProvidersCollectionProperty, value); }
        }
        public static readonly PropertyData ProvidersCollectionProperty = RegisterProperty("ProvidersCollection", typeof(ObservableCollection<ProviderModel>));

        public Command AddProvider
        {
            get
            {
                Command command;
                return command = new Command(() =>
                {
                    var viewModel = new ProviderViewModel();

                    _uiVisualizerService.ShowDialogAsync(viewModel, (sender, e) =>
                    {
                        if (e.Result ?? false)
                        {
                            ProvidersCollection.Add(viewModel.ProviderObject);
                        }
                    });
                });
            }
        }

    }
}
