## Introduction ##

Graph API for app to read and write to the Facebook social network. We can easily integrated Graph API and Durable Task Framework. To read more about [Graph API](https://developers.facebook.com/docs/graph-api) and [Durable Task Framework](http://developers.de/blogs/damir_dobric/archive/2015/09/16/introduction-to-durable-task-framework.aspx) . 

## Background ##

The Service Bus Durable Task Framework allows users to write C# code and encapsulate it within ‘durable’ .Net Tasks. Task Activities gives us opportunity to write pieces of code for performing specific step of Orchestration. Here two Task Activities have been written– 

### AccessTokenTask ###

This Task Activity will collect the access token from specific user using user credentials. Here one object has been created of RegisterBrowser (RegisterBrowser.cs) with an argument constructor link. Link nothing but a Facebook login URL with Facebook app ID and scope. Read [here](https://developers.facebook.com/docs/apps) more about Facebook apps. RegisterBrowser will load the web browser, has been created for taking user credentials, named Browser (Browser.cs), it is a Form application. After successfully logged in Facebook Navigated Event will be occurred for new document and has begun loading it, with the navigated URL will be access token. System.Windows.Forms.WebBrowser is not working with multithreaded apartment that’s why Thread has been created with single threaded apartment.

### PostTask ###

This Task Activity will post message on the Facebook wall. This Task will have message from user and access token throw Task Orchestration. Here Http Web Request has been created with Facebook Graph API URL and POST Http method.

Here one Task Orchestration has been created, named FbTaskOrchestration for scheduling Task Activities and build code orchestrations around the Tasks that represent the activities. 

