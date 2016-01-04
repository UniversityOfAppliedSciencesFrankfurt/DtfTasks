## Introduction ##

This app will give weather information about specific town using Yahoo! Weather API. It is easy to get weather information integrated with Service Buss Durable Task Framework and Yahoo Weather API. To read more about [Service Bus Durable Task Framework](http://developers.de/blogs/damir_dobric/archive/2015/09/16/introduction-to-durable-task-framework.aspx) and [Yahoo Weather API](https://developer.yahoo.com/weather/documentation.html).

## Background ##

We can get weather information using Yahoo! Weather API where WOEID (Where On Earth IDentifier) is used. An integral part of GeoPlanet is the WOEID, a unique 32-bit reference identifier, assigned by Yahoo! that identifies any feature on Earth. Durable Task Framework is a open source project started by Microsoft. It enabled programmers to write Orchestrations in pure C# using the .Net framework. Task Activity is a pieces of code for performing specific part of Orchestration. Here two Task Activities have been written – 

### WOEIDLookupTask ###

This Task Activity will have the WOEID for specific city. Here CityList is Windows Form Application, used for selecting specific city name under country by user. YQL (Yahoo Query Language) has been used for searching specific city’s WOEID and then pass it to WForecastsTask, next Task Activity, throw Task Orchestration. 

### WForecastsTask ###

This Task Activity will give information about Weather using Yahoo! Weather API with WOEID, getting from WOEIDLookupTask throw Task Orchestration. Yahoo! Weather API returns XML data.

Here one Task Orchestration has been created, named WFTaskOrchestration for scheduling Task Activities and build code orchestrations around the Tasks that represent the activities. 

