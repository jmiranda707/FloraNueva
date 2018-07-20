using Android.Content;
using Android.Graphics.Drawables;
using Android.Views;
using Marvelapp.Customs;
using Marvelapp.Droid.Customs;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomDatePickerAndroid), typeof(CustomDatePickerAndroid))]
namespace Marvelapp.Droid.Customs
{
    public class CustomDatePickerAndroid : DatePickerRenderer
    {
        public CustomDatePickerAndroid(Context context)
            : base(context)
        {
        }

        public CustomDatePickerAndroid()
            : base(null)
        {
            // Default constructor needed for Xamarin Forms bug?
            throw new Exception("This constructor should not actually ever be used");
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.DatePicker> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                var gradientDrawable = new GradientDrawable();
                gradientDrawable.SetStroke(3, Android.Graphics.Color.Rgb(160, 160, 155));
                gradientDrawable.SetColor(Android.Graphics.Color.Rgb(244, 244, 242));
                Control.SetBackground(gradientDrawable);
                Control.SetPadding(10, 20, 10, 20);
                Control.TextSize = 14;
                //Control.Text = (Element as CustomDatePicker).PlaceHolder;
                Control.Gravity = GravityFlags.CenterHorizontal;
                //Control.Typeface = Control.Typeface = Android.Graphics.Typeface.CreateFromAsset(Forms.Context.Assets, "quicksand_bold.ttf");

            }
        }
    }
}