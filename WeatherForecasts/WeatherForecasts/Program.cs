using DurableTask;
using System;
using System.Configuration;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeatherForecasts
{
    public class Program
    {
        [STAThread]
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
            string connectionString = ConfigurationManager.AppSettings["Microsoft.ServiceBus.ConnectionString"];
            string taskHubName = ConfigurationManager.AppSettings["HubName"];

            TaskHubClient taskHubClient = new TaskHubClient(taskHubName, connectionString);
            TaskHubWorker taskHubWorker = new TaskHubWorker(taskHubName, connectionString);
            taskHubWorker.CreateHub();
            OrchestrationInstance instance = taskHubClient.CreateOrchestrationInstance(typeof(WfTaskOrchestration), "Hello");
           
            taskHubWorker.AddTaskOrchestrations(typeof(WfTaskOrchestration));
            taskHubWorker.AddTaskActivities(new WOEIDLookupTask(), new WForecastsTask());
            taskHubWorker.Start();

            Console.WriteLine("Press any key to quit.");
            Console.ReadLine();


            taskHubWorker.Stop(true);
        }

    }
}
