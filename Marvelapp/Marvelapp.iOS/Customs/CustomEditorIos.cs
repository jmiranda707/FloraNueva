using CoreGraphics;
using Marvelapp.iOS.Customs;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomEditorIos), typeof(CustomEditorIos))]
namespace Marvelapp.iOS.Customs
{
    public class CustomEditorIos : EditorRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Editor> e)
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

                //Control.LeftView = new UIKit.UIView(new CGRect(0, 0, 10, 0));
                //Control.LeftViewMode = UIKit.UITextFieldViewMode.Always;
            }
        }
    }
}