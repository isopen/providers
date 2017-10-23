using Catel.Data;
using System.Collections.Generic;

namespace EmulationProcessing.Models
{
    public class ProviderModel :ModelBase
    {
        public string Name {
            get { return GetValue<string>(NameProperty); }
            set { SetValue(NameProperty, value); }
        }
        public static readonly PropertyData NameProperty = RegisterProperty("Name", typeof(string), string.Empty);

        public string Logo
        {
            get { return GetValue<string>(LogoProperty); }
            set { SetValue(LogoProperty, value); }
        }
        public static readonly PropertyData LogoProperty = RegisterProperty("Logo", typeof(string), string.Empty);
    }
}
