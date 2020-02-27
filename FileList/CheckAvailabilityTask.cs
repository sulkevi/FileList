using Quartz;
using System;
using System.Diagnostics;
using System.Threading.Tasks;

namespace FileList
{
    public class CheckAvailabilityTask : IJob
    {
        public Task Execute(IJobExecutionContext context)
        {
            try
            {
                Debug.WriteLine("In Q");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
            return Task.FromResult(0);
        }
    }
}