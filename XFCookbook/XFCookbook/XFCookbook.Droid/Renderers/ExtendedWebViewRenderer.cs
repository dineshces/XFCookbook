using System;
using System.Threading;
using System.Threading.Tasks;
using Android.Webkit;
using Xamarin.Forms.Platform.Android;
using XFCookbook.Controls;
using Xamarin.Forms;
using XFCookbook.Droid.Renderers;

[assembly: ExportRenderer(typeof(ExtendedWebView), typeof(ExtendedWebViewRenderer))]

namespace XFCookbook.Droid.Renderers
{
    public class ExtendedWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(ElementChangedEventArgs<Xamarin.Forms.WebView> e)
        {
            base.OnElementChanged(e);

            var webView = e.NewElement as ExtendedWebView;
            if (webView != null)
                webView.EvaluateJavascript = async (js) =>
                {
                    var reset = new ManualResetEvent(false);
                    var response = string.Empty;
                    Device.BeginInvokeOnMainThread(() =>
                    {
                        Control?.EvaluateJavascript(js, new JavascriptCallback((r) =>
                        {
                            response = r;
                            reset.Set();
                        }));
                    });
                    await Task.Run(() => { reset.WaitOne(); });
                    return response;
                };
        }
    }

    internal class JavascriptCallback : Java.Lang.Object, IValueCallback
    {
        public JavascriptCallback(Action<string> callback)
        {
            _callback = callback;
        }

        private Action<string> _callback;

        public void OnReceiveValue(Java.Lang.Object value)
        {
            _callback?.Invoke(Convert.ToString(value));
        }
    }
}
