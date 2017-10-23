using Catel.Data;
using Catel.MVVM;
using EmulationProcessing.Models;
using Microsoft.Win32;
using System.Configuration;

namespace EmulationProcessing.ViewModels
{

    public class ProviderViewModel : ViewModelBase
    {

        public override string Title { get { return "Новый сервис"; } }

        [Model]
        public ProviderModel ProviderObject
        {
            get { return GetValue<ProviderModel>(ProviderObjectProperty); }
            set { SetValue(ProviderObjectProperty, value); }
        }
        public static readonly PropertyData ProviderObjectProperty = RegisterProperty("ProviderObject", typeof(ProviderModel));

        [ViewModelToModel("ProviderObject", "Name")]
        public string ProviderName
        {
            get { return GetValue<string>(ProviderNameProperty); }
            set { SetValue(ProviderNameProperty, value); }
        }
        public static readonly PropertyData ProviderNameProperty = RegisterProperty("ProviderName", typeof(string));

        [ViewModelToModel("ProviderObject", "Logo")]
        public string ProviderLogo
        {
            get { return GetValue<string>(ProviderLogoProperty); }
            set { SetValue(ProviderLogoProperty, value); }
        }
        public static readonly PropertyData ProviderLogoProperty = RegisterProperty("ProviderLogo", typeof(string));

        public ProviderViewModel(ProviderModel providerModel = null)
        {
            ProviderObject = providerModel ?? new ProviderModel();
        }

        public Command OpenCommand
        {
            get
            {
                Command command;
                return command = new Command(() =>
                {
                    OpenFileDialog openFileDialog = new OpenFileDialog();
                    openFileDialog.Filter = ConfigurationManager.AppSettings["mask_images"];
                    if (openFileDialog.ShowDialog() == true)
                    {
                        this.ProviderLogo = openFileDialog.FileName;
                    }
                });
            }
        }

    }
}
