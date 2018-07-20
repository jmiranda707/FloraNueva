using Marvelapp.iOS.Customs;
using UIKit;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;

[assembly: ExportRenderer(typeof(CustomDatePickerIos), typeof(CustomDatePickerIos))]
namespace Marvelapp.iOS.Customs
{
    public class CustomDatePickerIos : DatePickerRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<DatePicker> e)
        {
            base.OnElementChanged(e);

            //Control is UITextField
            //var someFontWithName = UIFont.FromName("quicksand_bold", 10);
            UIFont font = Control.Font.WithSize(10);
            Control.Font = font;
            Control.Layer.BorderWidth = 3f;
            Control.Layer.BorderColor = Color.FromRgb(160, 160, 155).ToCGColor();
            Control.Layer.BackgroundColor = Color.FromRgb(244, 244, 242).ToCGColor();
            Control.TextAlignment = UITextAlignment.Center;
        }
    }
}