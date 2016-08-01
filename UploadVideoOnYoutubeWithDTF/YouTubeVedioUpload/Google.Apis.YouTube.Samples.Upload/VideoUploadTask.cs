using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;
namespace Google.Apis.YouTube.Samples
{
    class VideoUploadTask : TaskActivity<string, string>
    {
        protected override string Execute(TaskContext context, string input)
        {
            new UploadVideo().Run(input).Wait();
            return null;
        }
    }
}
