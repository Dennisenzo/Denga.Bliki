using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Denga.Bwiki.Web.Client.DataServices
{
    public static class Throttler
    {
        private static HashSet<Func<Task>> ThrottleTasks = new HashSet<Func<Task>>();

        public static async Task Throttle(int delayinMs, Func<Task> resultBody)
        {
            await Task.Delay(delayinMs);
            await resultBody.Invoke();
        }
    }
}