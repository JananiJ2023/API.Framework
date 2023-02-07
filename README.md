# RestSharp API Testing using SpecFlow 
## Simple framework built to perform RestSharp API Testing

- Frameworks involved: Specflow for BDD, MSTest
- API.Framework - Consists of Modal folder that includes the data transfer objects for request and response 
- API.Helpder - Consists of reusable methods for serialization and deserialization 
- API.Test - Actual SpecFlow tests

## Case Study 
### Design and implement an automation framework which can test all the methods in https://reqres.in/
- Created RestSharp with SpecFlow API Testing framework that tests the possible CRUD operations on the given endpoint

### Make sure to add positive and negative cases
- SuccessfulRegistrationTest and LoginTest includes positive and negative scenarios differentiated with tags 

### Readme file is preferred
- Added 

### Verify that Lindsay Ferguson is a user by querying “List Users”
- Under GetUserTestFeature, Lindsay Ferugson can be queried from the List Users.  By replacing the username with any other username in the feature file, the same test can be reused 

### The framework should be able to run in multiple environment
- The base url is configured in appconfig file.  Based on requirement it can be altered for different environments 

### The framework should be able to use secrets/passwords/sensitive information effectively.
- Sensitive information such as username and password are not exposed in step definition file.  Example - SuccessRegistrationTestStep.  The username and password are retrived from appconfig file instead of being directly used in steps



