## Introduction ##

  This is a SMTP (Simple Mail Transfer Protocol) client based application. We can easily send Mail using Durable Task Framework. To        read more about [Durable Task Framework](http://developers.de/blogs/damir_dobric/archive/2015/09/16/introduction-to-durable-task-framework.aspx).

## Background ##

  The Service Bus Durable Task Framework allows programmer to write C# code and encapsulate it within ‘durable’ .Net Tasks. Task        Activities give us opportunity to write pieces of code for performing specific step of Orchestration. Here two Task Activities        have been written - 
    
### CredentialTask ###

This Task Activity will have all information about sending mail, for example from which email address mail will be sent, to              which email address mail will be sent, message etc. Here one object has been created, named uCredential, it is nothing but a             object of UserCredential class, it is a Form Application. UserCredential will take all information to send email.
          
### SendMailTask ###
      
This Task Activity will send email to specific email address. It will have all email sending information from CredentialTask             Task Activity throw Task Orchestration. Here mail is an instance of MailMessage, represent an e-mail message that can be                 sent the System.Net.Mail.SmtpClient class. SMTP Client has been created, allows application to send e-mail by using the                  Simple Mail Transfer Protocol. 

Here one Task Orchestration has been created, named MailOrchestration for scheduling Task Activities and build code orchestrations around the Tasks that represent the activities. 

