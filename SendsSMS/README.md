## Introduction ##

This application can be sent Text SMS using C# SMS Toolkit, is a C# websms SDK. We can easily send Web SMS using Durable Task Framework. To read more about [Durable Task Framework](http://developers.de/blogs/damir_dobric/archive/2015/09/16/introduction-to-durable-task-framework.aspx) .

## Background ##

C# websms SDK is a third party SDK for sending web SMS. We have to create an account in www.websms.com for sending web SMS and download dll file for adding reference, for downloading C# SMS Toolkit click [here](https://websms.at/entwickler/sdks/csharp-toolkit). The Durable Task Framework provides developers a means to write code orchestrations in C# using the .Net Task framework and the async/await keywords added in .Net 4.5. Task Activities give us opportunity to write pieces of code for performing specific step of Orchestration. Here two Task Activities have been written – 

### SMSCredentialTask ###

This Task Activity will have all of information, for example to which number wants to send web SMS, message, username and password which has been given in www.websms.com for creating account. UserCredential is a Windows Form Application, has been created for taking information from user. 

### SendSMSTask ###

This Task Activity will send the web SMS to specific number using Web Service, provided by websms.com. Here has been created SMS Client using username, password and Web Service and Text Message has been created using receiver phone number and text message. This all information have been collected from SMSCredentialTask throw Task Orchestration.
Only Task Orchestration has been created, named SMSOrchestration for scheduling Task Activities and build code orchestrations around the Tasks that represent the activities.

