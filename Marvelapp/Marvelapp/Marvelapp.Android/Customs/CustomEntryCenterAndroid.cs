using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.Graphics.Drawables;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Marvelapp.Customs;
using Marvelapp.Droid.Customs;
using Xamarin.Forms;
using Xamarin.Forms.Platform.Android;

[assembly: ExportRenderer(typeof(CustomEntryCenter), typeof(CustomEntryCenterAndroid))]
namespace Marvelapp.Droid.Customs
{

    public class CustomEntryCenterAndroid : EntryRenderer
    {

        public CustomEntryCenterAndroid(Context context)
            : base(context)
        {
        }

        public CustomEntryCenterAndroid()
            : base(null)
        {
            // Default constructor needed for Xamarin Forms bug?
            throw new Exception("This constructor should not actually ever be used");
        }

        protected override void OnElementChanged(ElementChangedEventArgs<Entry> e)
        {
            base.OnElementChanged(e);

            if (e.OldElement == null)
            {
                //Control.SetBackgroundResource(Resource.Layout.rounded_shape);
                var gradientDrawable = new GradientDrawable();
                //gradientDrawable.SetCornerRadius(15f);
                gradientDrawable.SetStroke(3, Android.Graphics.Color.Rgb(160, 160, 155));
                gradientDrawable.SetColor(Android.Graphics.Color.Rgb(244, 244, 242));
                Control.SetBackground(gradientDrawable);
                Control.SetPadding(10, Control.PaddingTop, Control.PaddingRight,
                    Control.PaddingBottom);
                Control.Gravity = GravityFlags.CenterHorizontal;
            }
        }
    }
}