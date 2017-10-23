using Catel.Data;
using Catel.MVVM;
using Catel.Services;
using EmulationProcessing.dbmodels;
using EmulationProcessing.Models;
using System.Collections.ObjectModel;
using System.Configuration;
using System.Linq;
using System.Threading.Tasks;

namespace EmulationProcessing.ViewModels
{

    public class MainWindowAdminViewModel : ViewModelBase
    {
        private readonly IUIVisualizerService _uiVisualizerService;
        private readonly IPleaseWaitService _pleaseWaitService;
        private readonly IMessageService _messageService;

        public override string Title { get { return "Админка"; } }

        public MainWindowAdminViewModel(IUIVisualizerService uiVisualizerService, IPleaseWaitService pleaseWaitService, IMessageService messageService)
        {
            _uiVisualizerService = uiVisualizerService;
            _pleaseWaitService = pleaseWaitService;
            _messageService = messageService;

            AccessProvidersCollection = new ObservableCollection<AccessProviderModel>();
            using (var db = new ProcessingContext())
            {
                var res = from ap in db.AccessProviders
                          join p in db.Providers on ap.Provider_id equals p.Id
                          join u in db.Users on ap.User_id equals u.Id
                          select new { ProviderName = p.Name, p.Logo, UserName = u.Name };
                foreach (var t in res)
                {
                    AccessProvidersCollection.Add(new AccessProviderModel()
                    {
                        ProviderName = t.ProviderName,
                        ProviderLogo = ConfigurationManager.AppSettings["images_folder"] + t.Logo,
                        UserName = t.UserName
                    });
                }
            }
        }

        public ObservableCollection<AccessProviderModel> AccessProvidersCollection
        {
            get { return GetValue<ObservableCollection<AccessProviderModel>>(AccessProvidersCollectionProperty); }
            set { SetValue(AccessProvidersCollectionProperty, value); }
        }
        public static readonly PropertyData AccessProvidersCollectionProperty = RegisterProperty("AccessProvidersCollection", typeof(ObservableCollection<AccessProviderModel>));

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
                            //AccessProvidersCollection.Add(viewModel.ProviderObject);
                        }
                    });
                });
            }
        }
    }
}
