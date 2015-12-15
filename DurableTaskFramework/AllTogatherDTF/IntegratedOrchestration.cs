using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;
using WeatherForecasts;
using PostFacebookGraphAPI;
using PostFacebookSDK;
using SendsMail;
using SendsSMS;
namespace AllTogatherDTF
{
    class IntegratedOrchestration : TaskOrchestration<string,string>
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
            var wForecasts = await context.CreateSubOrchestrationInstance<string>(typeof(WfTaskOrchestration), input);
            await context.CreateSubOrchestrationInstance<string>(typeof(FbTaskOrchestration), wForecasts);
            await context.CreateSubOrchestrationInstance<string>(typeof(MailOrchestration), wForecasts);
            await context.CreateSubOrchestrationInstance<string>(typeof(SMSOrchestration),wForecasts);
            await context.CreateSubOrchestrationInstance<string>(typeof(FbSDKTaskOrchestration), wForecasts);
            return wForecasts;
        }
    }
}
