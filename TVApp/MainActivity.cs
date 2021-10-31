using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Webkit;
using AndroidX.AppCompat.App;

namespace TVApp
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.activity_main);
            WebView wv = this.FindViewById<WebView>(Resource.Id.wv);
            WebSettings webSettings = wv.Settings;
            webSettings.JavaScriptEnabled = true;
            webSettings.AllowContentAccess = true;
            webSettings.AllowFileAccess = true;
            webSettings.JavaScriptCanOpenWindowsAutomatically = true;
            wv.SetWebViewClient(new HaWebViewClient());
            wv.LoadUrl("http://192.168.1.112:8080");
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class HaWebViewClient: WebViewClient
    {
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.LoadUrl(url);
            return true;
        }
    }
}