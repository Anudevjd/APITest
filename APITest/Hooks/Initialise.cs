using APITest.Base;
using System;
using System.Collections.Generic;
using System.Text;
using TechTalk.SpecFlow;

namespace APITest.Hooks
{
    [Binding]
    public class Initialise
    {
        private Settings _settings;
        public Initialise(Settings setting)
        {
            _settings = setting;
        }
        [BeforeScenario]
        public void InitialiseTest()
        {
            _settings.BaseURL = new Uri("https://reqres.in/");
            _settings.RestClient.BaseUrl = _settings.BaseURL;
        }
    }
}
