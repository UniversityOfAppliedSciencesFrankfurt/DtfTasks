using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;

namespace SendsMail
{
   public class MailOrchestration : TaskOrchestration<string,string>
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
            var cradential = await context.ScheduleTask<Credentials>(typeof(CredentialTask),input);
            var re = await context.ScheduleTask<string>(typeof(SendMailTask),cradential);
            return re;
        }
    }
}
