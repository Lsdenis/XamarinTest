using Android.Support.Design.Widget;
using TestXamarinSolution.Portable.CustomControls;
using TestXamarinSolution.Portable.Droid;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;


[assembly: ExportRenderer(typeof(BottomSheet), typeof(BottomSheetRenderer))]
namespace TestXamarinSolution.Portable.Droid
{
	public class BottomSheetRenderer: ViewRenderer<BottomSheet, Android.Views.View>
	{
		protected override void OnElementChanged(ElementChangedEventArgs<BottomSheet> e)
		{
			base.OnElementChanged(e);

			if (e.NewElement != null)
			{
//				BottomSheetBehavior.From(e.NewElement.Content);
			}

			BottomSheetBehavior.From(Control);

		}
	}
}