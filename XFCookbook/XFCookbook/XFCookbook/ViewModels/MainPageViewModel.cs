using Prism.Commands;
using Prism.Mvvm;
using Prism.Navigation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace XFCookbook.ViewModels
{
    public class MainPageViewModel : BindableBase
    {
        public MainPageViewModel()
        {
            LoadCommand = new Command(async () =>
            {
                var result = await EvaluateJavascript("document.getElementById('emailTxt');");
                WebViewSource = new UrlWebViewSource
                {
                    Url = SourceUrl
                };
            });
        }

        private string _sourceUrl = "https://smartfind.peopleadmin.com";
        public string SourceUrl
        {
            get { return _sourceUrl; }
            set { SetProperty(ref _sourceUrl, value); }
        }

        private Func<string, Task<string>> _evaluateJavascript;
        public Func<string, Task<string>> EvaluateJavascript
        {
            get { return _evaluateJavascript; }
            set { _evaluateJavascript = value; }
        }

        private WebViewSource _webViewSource;
        public WebViewSource WebViewSource
        {
            get { return _webViewSource; }
            set { SetProperty(ref _webViewSource, value); }
        }

        public ICommand LoadCommand { get; }
    }
}
