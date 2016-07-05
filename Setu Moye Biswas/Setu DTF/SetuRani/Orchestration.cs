using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;


namespace SetuRani
{
    class Orchestration:TaskOrchestration<string,string>
    {

        public override async Task<string> RunTask(OrchestrationContext context, string input)
        {
            var result = await context.ScheduleTask<string>(typeof(GoogleDriveAuthenticationTask), input) ;
            var file = await context.ScheduleTask<string>(typeof(GoogleUploadTask), result);
            return file;
        }
    }
}
