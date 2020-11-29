using APITest.Base;
using APITest.ResponsePayload;
using APITest.Util;
using NUnit.Framework;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Net;
using TechTalk.SpecFlow;

namespace APITest.Steps
{
    [Binding]
    public class GetUser
    {
        private Settings _settings;
        public GetUser(Settings settings) => _settings = settings;
        [Given(@"I perform ""(.*)"" operation for  ""(.*)""")]
        public void GivenIPerformOperationFor(string method, string url)
        {
            if (method == "GET")
                _settings.Request = new RestRequest(url, Method.GET);
            if (method == "POST")
                _settings.Request = new RestRequest(url, Method.POST);
            if(method=="PUT")
                _settings.Request = new RestRequest(url, Method.PUT);

            Console.WriteLine("*********************");
            Console.WriteLine(method);
        }



        [When(@"I send the '(.*)' as '(.*)' in the request")]
        public void WhenISendTheAsInTheRequest(string id, int idvalue)
        {
            _settings.Request.AddUrlSegment(id, idvalue);
        }

        [Then(@"I should see the result should have '(.*)' of '(.*)'")]
        public void ThenIShouldSeeTheResultShouldHaveOf(string element, int value)
        {
       
            _settings.Response = (RestResponse)_settings.RestClient.Execute(_settings.Request);
            Console.WriteLine("*********************");
            Console.WriteLine(_settings.Response.Content.ToString());

            var Jobj=_settings.Response.GetResponseObject();
            Data data = Jobj["data"].ToObject<Data>();
            if(element=="id")
            Assert.That(data.id, Is.EqualTo(value), "The right id is not returned");
            if (element == "email")
                Assert.That(data.email, Is.EqualTo(value), "The right email is not returned");
            if (element == "first_name")
                Assert.That(data.first_name, Is.EqualTo(value), "The right first_name is not returned");
            if (element == "last_name")
                Assert.That(data.last_name, Is.EqualTo(value), "The right last_name is not returned");
        }

        [Then(@"I should see that the result should have '(.*)' of '(.*)' and '(.*)'")]
        public void ThenIShouldSeeThatTheResultShouldHaveOf(string element, int value,string name)
        {
            _settings.Response = (RestResponse)_settings.RestClient.Execute(_settings.Request);
            Console.WriteLine("*********************");
            Console.WriteLine(_settings.Response.Content.ToString());

            var Jobj = _settings.Response.GetResponseObject();

            List<Datum> data =Jobj["data"].ToObject<List<Datum>>();


            foreach (var Content in data)
            {
                if (Content.id == value)
                {
                    Assert.That(Content.name.ToString(), Is.EqualTo(name), "The name is not coprrect");
                }

            }

        }

        [Then(@"I should see the result should have status code of '(.*)'")]
        public void ThenIShouldSeeTheResultShouldHaveStatusCodeOf(int code)
        {
            _settings.Response = (RestResponse)_settings.RestClient.Execute(_settings.Request);
            Console.WriteLine("*********************");
            Console.WriteLine(_settings.Response.Content.ToString());

            HttpStatusCode statusCode = _settings.Response.StatusCode;
            int status = (int)statusCode;
            Assert.That(status, Is.EqualTo(code), "The status code do not match");
        }

    }
}
