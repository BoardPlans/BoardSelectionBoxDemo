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
using System.Windows.Navigation;
using System.Windows.Shapes;

namespace WpfApp2
{
    /// <summary>
    /// MainWindow.xaml 的交互逻辑
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
        }

        private bool _mouseDown;
        private Point? _mouseDownRelativePoint;
        private void RootCanvas_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _mouseDown = true;
            _mouseDownRelativePoint = e.GetPosition(SelectionBox);
        }

        private void RootCanvas_OnMouseUp(object sender, MouseButtonEventArgs e)
        {
            _mouseDown = false;
            _selectionBoxSelected = false;
        }

        private void RootCanvas_OnMouseMove(object sender, MouseEventArgs e)
        {
            if (_mouseDown && _selectionBoxSelected)
            {
                var position = e.GetPosition(RootCanvas);
                Canvas.SetTop(SelectionBox, position.Y - _mouseDownRelativePoint?.Y ?? 0);
                Canvas.SetLeft(SelectionBox, position.X - _mouseDownRelativePoint?.X ?? 0);
            }
        }

        private bool _selectionBoxSelected = false;
        private void SelectionBox_OnMouseDown(object sender, MouseButtonEventArgs e)
        {
            _selectionBoxSelected = true;
        }
    }
}
