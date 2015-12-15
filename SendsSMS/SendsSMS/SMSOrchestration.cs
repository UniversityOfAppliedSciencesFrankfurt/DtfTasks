using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;

namespace SendsSMS
{
   public class SMSOrchestration : TaskOrchestration<string,string>
    {
        /// <summary>
        /// Task Orchestration for scheduling Tasks
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input">To pass message to different Task Activities</param>
        /// <returns>It will return a string type value, can use another TaskOrchestration</returns>
        /// 
        public override async Task<string> RunTask(OrchestrationContext context, string input)
        {
            var cradential = await context.ScheduleTask<Credentials>(typeof(SMSCredentialTask),input);
            var re = await context.ScheduleTask<string>(typeof(SendSMSTask),cradential);
            return re;
        }
    }
}
