using Android.App;
using Android.Content;
using Android.Content.PM;
using Android.OS;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

namespace TestXamarinSolution.Portable.Droid
{
	[Activity(Label = "TestXamarinSolution.Portable", Icon = "@drawable/icon", Theme = "@style/AppTheme",
		 ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
	[IntentFilter(new[] {Intent.ActionView}, Categories = new[] {"my.test.category"})]
	public class IntentActivity : FormsApplicationActivity
	{
		protected override void OnCreate(Bundle bundle)
		{
			base.OnCreate(bundle);

			Forms.Init(this, bundle);
			LoadApplication(new App());
		}
	}
}