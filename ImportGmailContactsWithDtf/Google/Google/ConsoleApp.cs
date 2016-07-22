//=======================================================================================
// Copyright © daenet GmbH Frankfurt am Main, University of Applied Sciences Frankfurt am Main
//
// LICENSED UNDER THE APACHE LICENSE, VERSION 2.0 (THE "LICENSE"); YOU MAY NOT USE THESE
// FILES EXCEPT IN COMPLIANCE WITH THE LICENSE. YOU MAY OBTAIN A COPY OF THE LICENSE AT
// http://www.apache.org/licenses/LICENSE-2.0
// UNLESS REQUIRED BY APPLICABLE LAW OR AGREED TO IN WRITING, SOFTWARE DISTRIBUTED UNDER THE
// LICENSE IS DISTRIBUTED ON AN "AS IS" BASIS, WITHOUT WARRANTIES OR CONDITIONS OF ANY
// KIND, EITHER EXPRESS OR IMPLIED. SEE THE LICENSE FOR THE SPECIFIC LANGUAGE GOVERNING
// PERMISSIONS AND LIMITATIONS UNDER THE LICENSE.
//=======================================================================================

using DurableTask;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Daenet.Integration
{
    class ConsoleApp
    {
        public static void Main()
        {
            DTF();
        }

        public static void DTF()
        {
            string connectionString = "Endpoint=sb://currencyservice.servicebus.windows.net/;SharedSecretIssuer=owner;SharedSecretValue=x2xL3iLu0CnQQn//yco9DZ/fyJCnYj2lueSCv0vVf9U=";

            TaskHubClient taskHubClient = new TaskHubClient("myHub", connectionString);
            TaskHubWorker taskHubWorker = new TaskHubWorker("myHub", connectionString);
            taskHubWorker.CreateHub();
            OrchestrationInstance instance = taskHubClient.CreateOrchestrationInstance(typeof(TaskOrchestration), "");

            taskHubWorker.AddTaskOrchestrations(typeof(TaskOrchestration));
            taskHubWorker.AddTaskActivities(new OAuthTask());
            taskHubWorker.AddTaskActivities(new ContractListTask());
            taskHubWorker.Start();
            //Thread.Sleep(200000);
            Console.WriteLine("Enter to exit!!");
            Console.Read();
            taskHubWorker.Stop(true);
        }
    }
}
