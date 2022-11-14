using Microsoft.Web.WebView2.Core;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using System.Windows.Threading;

namespace MainUI
{
    /// <summary>
    /// Interaction logic for MainWindow.xaml
    /// </summary>
    public partial class MainWindow : Window
    {
        string page = @"
<!DOCTYPE html>
<html>
<head>
<title>video</title>
</head>
<body style=""width:100%;height:100vh;padding:0;margin:0;overflow: hidden;"">
<iframe width=""100%"" height=""100%"" src=""https://www.youtube.com/embed/{id}"" frameborder=""0"" allowfullscreen></iframe>
</body>
</html>
";
        public MainWindow()
        {
            InitializeComponent();
            webView.EnsureCoreWebView2Async();
            DispatcherTimer timer = new DispatcherTimer
            {
                Interval = new TimeSpan(0, 0, 0, 0, 100)
            };
            timer.Tick += Timer_Tick;
            timer.Start();
        }

        private void Timer_Tick(object? sender, EventArgs e)
        {
            Time_Label.Content = DateTime.Now.ToString("HH:mm:ss");
            Date_Label.Content = DateTime.Now.ToString("MM月dd日 dddd");
        }

        private void webView_CoreWebView2InitializationCompleted(object sender, CoreWebView2InitializationCompletedEventArgs e)
        {
            nav_bar.IsEnabled = true;
        }

        private void Button_Click(object sender, RoutedEventArgs e)
        {
            string id = id_field.Text;
            if (string.IsNullOrEmpty(id)) return;
            nav_bar.IsEnabled = false;
            string url = page.Replace("{id}", id);
            webView.NavigateToString(url);
        }

        private void webView_NavigationCompleted(object sender, CoreWebView2NavigationCompletedEventArgs e)
        {
            nav_bar.IsEnabled = true;
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            Job_Label.Content = ((ListBoxItem)((ListBox)sender).SelectedItem).Content;
            Job_Label.ToolTip = Job_Label.Content;
        }
    }
}
