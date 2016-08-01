using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;

namespace Google.Apis.YouTube.Samples
{
    class OrchestrationTask : TaskOrchestration<string, string>
    {
        public override async Task<string> RunTask(OrchestrationContext context, string input)
        {
            string path = await context.ScheduleTask<string>(typeof(VideoSelectorTask), input);
            string ret = await context.ScheduleTask<string>(typeof(VideoUploadTask), path);
            return ret;
        }
    }
}
