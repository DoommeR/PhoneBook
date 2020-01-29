using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;
using Newtonsoft.Json;

namespace PhoneBookHW
{
    [Activity(Label = "ImageZoomActivity")]
    public class ImageZoomActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.activity_zoomImage);

            var url = JsonConvert.DeserializeObject<string>(Intent.GetStringExtra("url"));
            var dw = new ImageDownloaderFromUri(url, FindViewById<ImageView>(Resource.Id.zoom_img));

            dw.SetImageFromUrlTask();

        }
    }
}