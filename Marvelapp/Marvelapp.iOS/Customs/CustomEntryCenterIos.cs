using CoreGraphics;
using Marvelapp.iOS.Customs;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEntryCenterIos), typeof(CustomEntryCenterIos))]
namespace Marvelapp.iOS.Customs
{
    public class CustomEntryCenterIos : EntryRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                //Control.Layer.CornerRadius = 20;
                Control.Layer.BorderWidth = 3f;
                //Control.Layer.BorderColor = Color.DeepPink.ToCGColor();
                Control.Layer.BorderColor = Color.FromRgb(160, 160, 155).ToCGColor();
                //Control.Layer.BackgroundColor = Color.LightGray.ToCGColor();
                Control.Layer.BackgroundColor = Color.FromRgb(244, 244, 242).ToCGColor();

                Control.LeftView = new UIKit.UIView(new CGRect(0, 0, 10, 0));
                Control.LeftViewMode = UIKit.UITextFieldViewMode.Always;
                Control.TextAlignment = UITextAlignment.Center;
            }
        }
    }
}