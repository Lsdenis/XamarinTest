using System;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Android.App;
using Android.Bluetooth;
using Android.Content;
using Android.Content.PM;
using Android.Widget;
using Android.OS;
using Gcm.Client;
using Java.Lang;
using Java.Util;
using Exception = System.Exception;
using Random = System.Random;

namespace TestXamarinSolution.Portable.Droid
{
	[Activity(Label = "TestXamarinSolution.Portable", Icon = "@drawable/icon", Theme = "@style/AppTheme",
		 MainLauncher = true,
		 ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			global::Xamarin.Forms.Forms.Init(this, bundle);
			LoadApplication(new App());

//            TestBluetooth();
//	        TestIntent();
			StartActivity("eu.notime.hubapp.testing");
		}

		private void TestIntent()
		{
			var intent = new Intent();
			intent.SetAction(Intent.ActionView);
			intent.SetFlags(ActivityFlags.NewTask);
			intent.AddCategory("my.test.category");
//		    intent.PutExtra("Test", 1);

			var resolveActivity = intent.ResolveActivity(PackageManager);

			if (resolveActivity == null)
			{
				intent.SetComponent(new ComponentName("eu.notime.hubapp", "IntentActivity"));
				resolveActivity = intent.ResolveActivity(PackageManager);
			}

			StartActivity(intent);

		}

		public bool StartActivity(string packageName)
		{
			try
			{
				var launchIntentForPackage = PackageManager.GetLaunchIntentForPackage(packageName);
//				var launchIntentForPackage = new Intent();

				if (launchIntentForPackage == null)
				{
					return false;
				}

				var a = new Bundle();
				a.PutString("AccountGuidIntentKey", "59c3fc68-2cad-4e23-a7e8-5cff1f723cb6");
				a.PutString("HubPointGuidIntentKey", "F0491A1B-5204-434E-9263-A72E0544DD38");
				launchIntentForPackage.PutExtras(a);

				launchIntentForPackage.Categories?.Clear();
				launchIntentForPackage.SetAction(Intent.ActionSend);
				launchIntentForPackage.AddCategory("HubAppRedirectIntentFilterCategory");
//				launchIntentForPackage.AddCategory(Intent.CategoryLauncher);
//				launchIntentForPackage.SetType("text/plain");
//				launchIntentForPackage.SetComponent(new ComponentName(packageName,
//					"md52c19317deedbba2dc112e8cb43f87a9b.MainActivity"));

				ApplicationContext.StartActivity(launchIntentForPackage);
			}
			catch (Exception ex)
			{
				return false;
			}

			return true;
		}

	    private void TestBluetooth()
        {
            BluetoothAdapter adapter = BluetoothAdapter.DefaultAdapter;
            if (adapter == null)
            {
                Toast.MakeText(this, "No Bluetooth adapter found.", ToastLength.Short);
                return;
            }

            if (!adapter.IsEnabled)
            {
                adapter.Enable();
            }

            var device = adapter.BondedDevices.First();

            if (device == null)
            {
                Toast.MakeText(this, "Named device not found.", ToastLength.Short);
            }
            else
            {
                var bluetoothSocketServer = adapter.ListenUsingRfcommWithServiceRecord("Hub App",
                    UUID.FromString("00001101-0000-1000-8000-00805F9B34FB"));

                if (bluetoothSocketServer != null)
                {
                    Task.Run(async () =>
                    {
                        var bluetoothSocket = await bluetoothSocketServer.AcceptAsync();

                        System.Diagnostics.Debug.WriteLine("Connected!");

                        var rnd = new Random(unchecked((int) DateTime.Now.Ticks));

                        while (true)
                        {
                            var val = rnd.Next(1, 10);
                            var bytes = new UnicodeEncoding().GetBytes(val.ToString());
                            await bluetoothSocket.OutputStream.WriteAsync(bytes, 0, bytes.Length);

                            Thread.Sleep(10000);
                        }
                    });
                }
            }
        }

        private void RegisterWithGcm()
        {
            // Check to ensure everything's setup right
            GcmClient.CheckDevice(this);
            GcmClient.CheckManifest(this);

            // Register for push notifications
            GcmClient.Register(this, Constants.SenderID);
        }
    }
}