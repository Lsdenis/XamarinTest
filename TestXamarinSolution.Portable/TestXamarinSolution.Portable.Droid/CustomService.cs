using System;
using System.Threading;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Util;

namespace TestXamarinSolution.Portable.Droid
{
    [Service]
    public class CustomService : Service
    {
        private Timer _timer;
        private static readonly string Tag = "X:" + typeof(CustomService).Name;

        public override StartCommandResult OnStartCommand(Intent intent, StartCommandFlags flags, int startId)
        {
            Log.Debug(Tag, "OnStartCommand called at {2}, flags={0}, startid={1}", flags, startId, DateTime.UtcNow);
            _timer = new Timer(o => { Log.Debug(Tag, "Hello from SimpleService. {0}", DateTime.UtcNow); },
                               null,
                               0,
                               3000);
            return StartCommandResult.NotSticky;
        }

        public override void OnDestroy()
        {
            base.OnDestroy();

            _timer.Dispose();
            _timer = null;

            Log.Debug(Tag, "SimpleService destroyed at {0}.", DateTime.UtcNow);
        }

        public override IBinder OnBind(Intent intent)
        {
            return null;
        }
    }
}