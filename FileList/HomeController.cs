using Microsoft.AspNetCore.Mvc;
using Quartz;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Services;

namespace FileList
{
    class HomeController : Controller
    {
        private readonly IScheduler _scheduler;

        public HomeController(IScheduler factory)
        {
            _scheduler = factory;
        }

      
        

        public async Task<IActionResult> CheckAvailability()
        {
            ITrigger trigger = TriggerBuilder.Create()
            .WithIdentity($"Check Avalibility-{DateTime.Now}")
            .StartNow()
            .WithPriority(1)
            .Build();

            IJobDetail job = JobBuilder.Create<CheckAvailabilityTask>()
                .WithIdentity("Check Availability")
                .Build();

            await _scheduler.ScheduleJob(job, trigger);
            return RedirectToAction("Index");
        }
    }
}
