using Framework.Common.Entities;

namespace Framework.Common.Contracts
{
    public interface IAppSettingsManager
    {
        SeleniumServices SeleniumServices { get; set; }
        RestServices RestServices { get;  } 
        public string Browser { get;}
        public string ExecutionEnvironment { get;}
    }
}
