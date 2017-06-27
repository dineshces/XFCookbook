using System.Threading.Tasks;
using Xamarin.Forms;
using Xamarin.Forms.Platform.iOS;
using XFCookbook.Controls;
using XFCookbook.iOS.Renderers;

[assembly: ExportRenderer(typeof(ExtendedWebView), typeof(ExtendedWebViewRenderer))]
namespace XFCookbook.iOS.Renderers
{
    public class ExtendedWebViewRenderer : WebViewRenderer
    {
        protected override void OnElementChanged(VisualElementChangedEventArgs e)
        {
            base.OnElementChanged(e);

            var webView = e.NewElement as ExtendedWebView;
            if (webView != null)
                webView.EvaluateJavascript = (js) =>
                {
                    return Task.FromResult(this.EvaluateJavascript(js));
                };
        }
    }
}