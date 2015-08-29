using MahApps.Metro.Controls;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Shapes;
namespace SuicSoft.LittleSoft.LittlesPDFMerge.Windows
{
    [System.CLSCompliant(false)]
    public partial class FScreenMetroWindow : MetroWindow
    {
        private static Button btn = new Button() { Content = new Path() { Fill = Brushes.White, Data = System.Windows.Media.Geometry.Parse("M5,5H10V7H7V10H5V5M14,5H19V10H17V7H14V5M17,14H19V19H14V17H17V14M10,17V19H5V14H7V17H10Z") } };
        public FScreenMetroWindow()
        {
            StateChanged += StateChange;
            btn.Click += btn_Click;
            var commands = new WindowCommands();
            commands.Items.Add(btn);
            RightWindowCommands = commands;
        }

        void btn_Click(object sender, RoutedEventArgs e)
        {
            if ((bool)GetValue(IsFullscreenProperty) == false)  
                SetValue(IsFullscreenProperty, true);
            else
                SetValue(IsFullscreenProperty, false);
        }

        public static bool GetIsFullscreen(DependencyObject obj)
        {
            return (bool)obj.GetValue(IsFullscreenProperty);
        }

        public static void SetIsFullscreen(DependencyObject obj, bool value)
        {
            obj.SetValue(IsFullscreenProperty, value);
        }
        static WindowStyle _WindowStyle;
        static WindowState _WindowState;
        public static readonly DependencyProperty IsFullscreenProperty =
            DependencyProperty.RegisterAttached("Fullscreen",
            typeof(bool), typeof(FScreenMetroWindow), new PropertyMetadata
            (false, new PropertyChangedCallback(IsFullscreenChangedChanged)));

        private static void IsFullscreenChangedChanged
        (DependencyObject d, DependencyPropertyChangedEventArgs e)
        {
            if ((bool)e.NewValue == true)
            {
                ((Path)btn.Content).Data = Geometry.Parse("M14,14H19V16H16V19H14V14M5,14H10V19H8V16H5V14M8,5H10V10H5V8H8V5M19,8V10H14V5H16V8H19Z");
                d.SetValue(IgnoreTaskbarOnMaximizeProperty, true);
                _WindowStyle = (WindowStyle)d.GetValue(Window.WindowStyleProperty);
                _WindowState = (WindowState)d.GetValue(Window.WindowStateProperty);
                d.SetValue(Window.WindowStyleProperty, WindowStyle.None);
                d.SetValue(Window.WindowStateProperty, WindowState.Maximized);
            }
            else
            {
                ((Path)btn.Content).Data = Geometry.Parse("M5,5H10V7H7V10H5V5M14,5H19V10H17V7H14V5M17,14H19V19H14V17H17V14M10,17V19H5V14H7V17H10Z");
                d.SetValue(IgnoreTaskbarOnMaximizeProperty, false);
                d.SetValue(Window.WindowStyleProperty, _WindowStyle);
                d.SetValue(Window.WindowStateProperty, _WindowState);
            }
        }
        void StateChange(object sender, System.EventArgs e)
        {
            if ((bool)GetValue(IsFullscreenProperty) == true & WindowState == System.Windows.WindowState.Normal)
                SetValue(IsFullscreenProperty, false);
        }
    }
}