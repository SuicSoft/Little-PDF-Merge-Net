using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Shapes;

namespace SuicSoft.LittlesPDFMerge.Windows
{
    /// <summary>
    /// Interaction logic for ToastWindow.xaml
    /// </summary>
    public partial class ToastWindow : Window
    {
        public ToastWindow()
        {
            InitializeComponent();
        }
        /// <summary>
        /// Dependency property to set the orientation of the axis
        /// </summary>
        public static readonly DependencyProperty ControlProperty =
            DependencyProperty.RegisterAttached("Control",
            typeof(ToastWindow), typeof(UIElement));

        /// <summary>
        /// Sets the orientation.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <param name="value">The value.</param>
        public static void SetControl(UIElement element, UIElement value)
        {
            element.SetValue(ControlProperty, value);
        }

        /// <summary>
        /// Gets the orientation.
        /// </summary>
        /// <param name="element">The element.</param>
        /// <returns></returns>
        public static Orientation GetControl(UIElement element)
        {
            return (Orientation)element.GetValue(ControlProperty);
        }
    }
}
