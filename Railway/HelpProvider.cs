using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows;

namespace Railway
{
    public class HelpProvider
    {
        public static string GetHelpKey(DependencyObject obj)
        {
            string v = obj.GetValue(HelpKeyProperty) as string;
            return v;
        }

        public static void SetHelpKey(DependencyObject obj, string value)
        {
            obj.SetValue(HelpKeyProperty, value);
        }

        public static readonly DependencyProperty HelpKeyProperty =
            DependencyProperty.RegisterAttached("HelpKey", typeof(string), typeof(HelpProvider), new PropertyMetadata("index", HelpKey));
        public static void HelpKey(DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            //NOOP
        }

        public static void ShowHelp(string key, MainWindow originator)
        {
            HelpViewer hh = new HelpViewer(key, originator);
            hh.Show();
        }
    }
}
