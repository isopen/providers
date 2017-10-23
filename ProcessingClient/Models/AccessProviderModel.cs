using Catel.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EmulationProcessing.Models
{
    public class AccessProviderModel : ModelBase
    {
        public string ProviderName
        {
            get { return GetValue<string>(ProviderNameProperty); }
            set { SetValue(ProviderNameProperty, value); }
        }
        public static readonly PropertyData ProviderNameProperty = RegisterProperty("ProviderName", typeof(string), string.Empty);

        public string ProviderLogo
        {
            get { return GetValue<string>(ProviderLogoProperty); }
            set { SetValue(ProviderLogoProperty, value); }
        }
        public static readonly PropertyData ProviderLogoProperty = RegisterProperty("ProviderLogo", typeof(string), string.Empty);

        public string UserName
        {
            get { return GetValue<string>(UserNameProperty); }
            set { SetValue(UserNameProperty, value); }
        }
        public static readonly PropertyData UserNameProperty = RegisterProperty("UserName", typeof(string), string.Empty);
    }
}
