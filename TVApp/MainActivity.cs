using Android.App;
using Android.OS;
using Android.Runtime;
using Android.Webkit;
using AndroidX.AppCompat.App;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Threading;
using Xamarin.Essentials;

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
            webSettings.AllowFileAccess = true;
            webSettings.DatabaseEnabled = true;
            webSettings.DomStorageEnabled = true;
            webSettings.JavaScriptCanOpenWindowsAutomatically = true;
            wv.SetWebViewClient(new HaWebViewClient());

            new Action(async () => {

                string url = await SecureStorage.GetAsync("url");
                if (!string.IsNullOrEmpty(url))
                {
                    wv.LoadUrl(url);
                }
            
            }).Invoke();

            try
            {
                HttpListener httpListenner = new HttpListener();
                httpListenner.AuthenticationSchemes = AuthenticationSchemes.Anonymous;
                string url = $"http://{this.getIP()}:8124/";
                httpListenner.Prefixes.Add(url);
                httpListenner.Start();
                new System.Threading.Thread(new ThreadStart(delegate
                {
                    while (true)
                    {
                        try
                        {
                            HttpListenerContext context = httpListenner.GetContext();
                            HttpListenerRequest request = context.Request;
                            HttpListenerResponse response = context.Response;
                            string path = request.Url.LocalPath;
                            var query = request.QueryString;
                            MainThread.BeginInvokeOnMainThread(async () =>
                            {
                                if (request.HttpMethod == "POST")
                                {
                                    if (request.HasEntityBody)
                                    {
                                        using (System.IO.Stream body = request.InputStream)
                                        {
                                            using (System.IO.StreamReader reader = new System.IO.StreamReader(body, request.ContentEncoding))
                                            {
                                                Dictionary<string, string> p = JsonConvert.DeserializeObject<Dictionary<string, string>>(reader.ReadToEnd());
                                                wv.EvaluateJavascript(WebUtility.UrlDecode(p["js"]), null);
                                            }
                                        }
                                    }
                                }
                                else
                                {
                                    if (!string.IsNullOrEmpty(query["url"]))
                                    {
                                        string url = WebUtility.UrlDecode(query["url"]);
                                        await SecureStorage.SetAsync("url", url);
                                        wv.LoadUrl(url);
                                    }
                                }
                            });
                            Dictionary<string, string> dict = new Dictionary<string, string>();
                            dict.Add("time", DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss"));

                            string responseString = JsonConvert.SerializeObject(dict);
                            byte[] buffer = System.Text.Encoding.UTF8.GetBytes(responseString);
                            //对客户端输出相应信息.
                            response.ContentType = "application/json; charset=utf-8";
                            response.ContentLength64 = buffer.Length;
                            System.IO.Stream output = response.OutputStream;
                            output.Write(buffer, 0, buffer.Length);
                            //关闭输出流，释放相应资源
                            output.Close();
                        }
                        catch (System.Exception ex)
                        {
                            System.Console.WriteLine(ex);
                        }

                    }

                })).Start();
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }           
        }

        string getIP()
        {
            string ip = System.Net.NetworkInformation.NetworkInterface.GetAllNetworkInterfaces()
                .Select(p => p.GetIPProperties())
                .SelectMany(p => p.UnicastAddresses)
                .Where(p => p.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork && !System.Net.IPAddress.IsLoopback(p.Address))
                .FirstOrDefault()?.Address.ToString();
            return ip;
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }
    }

    public class HaWebViewClient: WebViewClient
    {
        [System.Obsolete]
        public override bool ShouldOverrideUrlLoading(WebView view, string url)
        {
            view.LoadUrl(url);
            return true;
        }
    }
}