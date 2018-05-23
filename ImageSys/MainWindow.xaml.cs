using System;
using System.Collections.Generic;
using System.IO;
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

namespace ImageSys
{
    public partial class MainWindow : Window
    {
        private string[] files;
        private int index;
        public MainWindow()
        {
            InitializeComponent();
            files = Directory.GetFiles(@"C:\Users\Game.User\source\repos\ImageSys\ImageSys\bin\Debug", "*.jpg", SearchOption.AllDirectories);

            Parallel.Invoke(Loading);
        }
        public void Loading()
        {
            int loadIndex = index + 2;
            for (int i = index; i < files.Length && i < loadIndex; i++)
            {
                Image image = new Image();
                image.Source = new BitmapImage(new Uri(files[i]));
                listBox.Items.Add(image);
            }
        }

        private void ScrollViewer_ScrollChanged(object sender, ScrollChangedEventArgs e)
        {
            if (scrollViewer.ScrollableHeight == e.VerticalOffset)
            {
                index = listBox.Items.Count - 1;
                Parallel.Invoke(Loading);
            }
        }

        private void ListBox_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (listBox.SelectedIndex == listBox.Items.Count - 1)
            {
                index = listBox.SelectedIndex;
                Parallel.Invoke(Loading);
            }
        }
    }
}
