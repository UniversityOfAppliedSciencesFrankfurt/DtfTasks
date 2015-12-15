using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;
namespace PostFacebookGraphAPI
{
   public class FbTaskOrchestration : TaskOrchestration<string,string>
    {
        /// <summary>
        /// Task Orchestration for scheduling Tasks
        /// </summary>
        /// <param name="context"></param>
        /// <param name="input">To pass message to different Task Activities</param>
        /// <returns>It will return a string type value, can use another TaskOrchestration</returns>
        /// 
        public override async Task<string> RunTask(OrchestrationContext context, string message)
        {
            var token = await context.ScheduleTask<string>(typeof(AccessTokenTask),"");
           
            var result = await context.ScheduleTask<string>(typeof(PostTask), new Tuple<string,string>(message,token));
            return result;
        }
    }
}
