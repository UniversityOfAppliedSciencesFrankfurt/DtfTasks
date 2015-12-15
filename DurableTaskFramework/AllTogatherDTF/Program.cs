using DurableTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeatherForecasts;
using PostFacebookGraphAPI;
using PostFacebookSDK;
using SendsMail;
using SendsSMS;
using System.Configuration;

namespace AllTogatherDTF
{
    class Program
    {
        static void Main(string[] args)
        {
            DurableTask();
        }

        /// <summary>
        /// TaskHubWorker to pass messages  orchestrations and the activities that they are orchestrating. 
        /// TaskHubClient is a API for managing Task Orchestration Instances.
        /// TaskHubWorker and TaskHubClient both are configured with connection string.
        /// </summary>
        private static void DurableTask()
        {
            string message = string.Empty;
            string connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            string taskHubName = ConfigurationManager.AppSettings["HubName"];

            TaskHubClient taskHubClient = new TaskHubClient(taskHubName, connectionString);
            TaskHubWorker taskHubWorker = new TaskHubWorker(taskHubName, connectionString);
            taskHubWorker.CreateHub();
            OrchestrationInstance instance = taskHubClient.CreateOrchestrationInstance(typeof(IntegratedOrchestration), "");

            taskHubWorker.AddTaskOrchestrations(typeof(IntegratedOrchestration), typeof(WfTaskOrchestration), typeof(FbTaskOrchestration), typeof(MailOrchestration), typeof(SMSOrchestration), typeof(FbSDKTaskOrchestration));
            taskHubWorker.AddTaskActivities(new WOEIDLookupTask(), new WForecastsTask(), new AccessTokenTask(), new PostTask(), new CredentialTask(), new SendMailTask(), new SMSCredentialTask(), new SendSMSTask(), new SDKAccessTokenTask(), new SDKPostTask());
            taskHubWorker.Start();

            Console.WriteLine("Press any key to quit.");
            Console.ReadLine();


            taskHubWorker.Stop(true);
        }
    }
}
