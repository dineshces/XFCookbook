using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace XFCookbook.Controls
{
    public class ExtendedWebView : WebView
    {
        public static BindableProperty EvaluateJavascriptProperty = BindableProperty.Create(nameof(EvaluateJavascript), typeof(Func<string, Task<string>>), typeof(ExtendedWebView), null, BindingMode.OneWayToSource);

        public Func<string, Task<string>> EvaluateJavascript
        {
            get { return (Func<string, Task<string>>)GetValue(EvaluateJavascriptProperty); }
            set { SetValue(EvaluateJavascriptProperty, value); }
        }
    }
}