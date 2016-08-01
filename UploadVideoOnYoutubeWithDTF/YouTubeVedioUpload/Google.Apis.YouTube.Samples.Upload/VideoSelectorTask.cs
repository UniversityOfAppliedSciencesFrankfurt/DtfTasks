using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DurableTask;
using System.Threading;

namespace Google.Apis.YouTube.Samples
{
    class VideoSelectorTask : TaskActivity<string, string>
    {
        protected override string Execute(TaskContext context, string input)
        {
            VideoSelector selector = new VideoSelector();
            string path = string.Empty;
            var thead = new Thread(delegate ()
            {
                 //selector = new VideoSelector();
                selector.ShowDialog();
                path = selector.vedioPath;
                
            }
            );
            thead.SetApartmentState(ApartmentState.STA);
            thead.Start();
            thead.Join();
            return path;
        }
    }
}
