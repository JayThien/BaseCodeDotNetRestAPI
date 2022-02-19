using System;
namespace ApplicationDomain.Infrastructures.Model
{
    public class AppSettings
    {
        public AppSettings()
        {
        }

		public string Name { get; set; }
		public string Version { get; set; }
		public string Salt { get; set; }
    }
}
