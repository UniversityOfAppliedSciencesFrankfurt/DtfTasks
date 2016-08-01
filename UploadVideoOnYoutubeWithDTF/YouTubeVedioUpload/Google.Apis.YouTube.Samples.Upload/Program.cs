busing DurableTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Google.Apis.YouTube.Samples
{
    class Program
    {
        [STAThread]
        static void Main(string[] args)
        {
            DurableTask();
            
        }

        public static void DurableTask()
        {
            string connectionString = "Endpoint=sb://currencyservice.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=x2xL3iLu0CnQQn//yco9DZ/fyJCnYj2lueSCv0vVf9U=";
            TaskHubClient taskHubClient = new TaskHubClient("myHub", connectionString);
            TaskHubWorker taskHubWorker = new TaskHubWorker("myHub", connectionString);
            taskHubWorker.CreateHub();
            OrchestrationInstance instance = taskHubClient.CreateOrchestrationInstance(typeof(OrchestrationTask), "access");

            taskHubWorker.AddTaskOrchestrations(typeof(OrchestrationTask));
            taskHubWorker.AddTaskActivities(new VideoSelectorTask(), new VideoUploadTask());
            taskHubWorker.Start();

            Console.WriteLine("Press any key to quit.");
            Console.ReadLine();

            taskHubWorker.Stop(true);
        }
    }
}
