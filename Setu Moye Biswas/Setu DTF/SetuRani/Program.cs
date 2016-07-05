using DurableTask;
using Google.Apis.Drive.v2;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SetuRani
{
    class Program
    {
        public static DriveService service;
        static void Main(string[] args)
        {
            stupid();
        }

        static void stupid() {
            string connectionString = "Endpoint=sb://currencyservice.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=x2xL3iLu0CnQQn//yco9DZ/fyJCnYj2lueSCv0vVf9U=";

            TaskHubClient taskHubClient = new TaskHubClient("avikhub", connectionString);
            TaskHubWorker taskHubWorker = new TaskHubWorker("avikhub", connectionString);
            taskHubWorker.CreateHub();

            OrchestrationInstance instance = taskHubClient.CreateOrchestrationInstance(typeof(Orchestration), "");

            taskHubWorker.AddTaskOrchestrations(typeof(Orchestration));
            taskHubWorker.AddTaskActivities(typeof(GoogleDriveAuthenticationTask),typeof(GoogleUploadTask));
            taskHubWorker.Start();
            Console.ReadLine();
            taskHubWorker.Stop(true);
        }
    }
}
