namespace WebsiteForms.Loging.Models
{
    public class LoggerSettings
    {
        public string ConnectionString{ get; set; }
        public string MinLogLevel{ get; set; }
        public string[] LogFields{ get; set; }
        public LoggerSettings()
        {
                
        }
    }
}
