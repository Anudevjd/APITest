using APITest.Base;
using APITest.RequestPayload;
using APITest.Util;
using NUnit.Framework;
using RestSharp;
using System;
using TechTalk.SpecFlow;
namespace APITest.Steps
{
    public class Adduser
    {
            
        [Binding]
        public class CreateUsers
        {
            private Settings _settings;
            public CreateUsers(Settings settings)=> _settings = settings;

            [When(@"I send the ""(.*)"" and ""(.*)"" in the request")]
            public void WhenISendTheAndInTheRequest(string name, string job)
            {
                _settings.Request.AddJsonBody(new Post() { name = name, job = job });
                _settings.Response = (RestResponse)_settings.RestClient.Execute(_settings.Request);
                Console.WriteLine("*********************");
                Console.WriteLine(_settings.Response.Content.ToString());
            }

            [Then(@"I should see the the result should have ""(.*)"" and ""(.*)"" in '(.*)' and '(.*)'")]
            public void ThenIShouldSeeTheTheResultShouldHaveAndInAnd(string Euser, string Ejob, string User, string job)
            {
                Assert.That(_settings.Response.DeserialiseResponse()[User], Is.EqualTo(Euser), "The name has not been posted correctly");
                Assert.That(_settings.Response.DeserialiseResponse()[job], Is.EqualTo(Ejob), "The job has not been posted correctly");
            }

        }
    }

}


