# APITest

I have used Nuint test Project(.Net Core) in C#, Specflow 3.5.5, RestSharp 106.11.7

The Framework tests the follwong scenarios

1.Verify that a POST request can be posted to the API to create the single user and assert that the single user is created.
2.Verify that a GET request can be posted to the API to get the expected details of single user
3.Verify that a GET request can be posted to the API to get the expected details of the list of users
4.Verify that a PUT request can be posted to the API to update the single user and assert that the expected update was made. 
5.Verify that a GET request can be posted to the API to return a single user not found, which should return a “404” response. 

* I have categorised the tests based on the HTTP request
* Reused the Step definitions where possible
* I have kept test data customisable (the user can go and change the data in the feature file to test their required data scenario)
* Used Nunit for assertions
* Implemented context injection using settings class
* Created Util class for reusable code
* Used Hooks to initialise the Rest Client which is used across all the tests
