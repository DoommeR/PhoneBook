using Android.Widget;
using FFImageLoading;
using FFImageLoading.Transformations;
namespace PhoneBookHW
{
    class ImageDownloaderFromUri
    {
        public string Uri { get; set; }
        public static ImageView ImageView { get; set; }

        public ImageDownloaderFromUri(string uri, ImageView imageView) {
            Uri = uri;
            ImageView = imageView;
        }

        public void SetImageFromUrlTask() {           
            SetImageBitmapFromUrl();
        }

        private void SetImageBitmapFromUrl()
        {
            ImageService.Instance.LoadUrl(Uri).Transform(new CircleTransformation()).LoadingPlaceholder(null).Into(ImageView);
        }

    }
 }

    