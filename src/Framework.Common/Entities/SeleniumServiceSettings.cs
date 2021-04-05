namespace Framework.Common.Entities
{
    public class SeleniumServiceSettings
    {
        public string ExecutionEnvironment { get; set; }
        public string Browser { get; set; }
        public string ApplicationUrl { get; set; }
        public string HeadlessMode { get; set; }
        public long Timeout { get; set; } 
    }
}
