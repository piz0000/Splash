using System;
using System.Diagnostics;
using System.IO;
using System.Windows;
using System.Windows.Input;

namespace Splash
{
    /// <summary>
    /// MainWindow.xaml에 대한 상호 작용 논리
    /// </summary>
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            //중복 실행 방지
            Process[] procs = Process.GetProcessesByName(Process.GetCurrentProcess().ProcessName);
            if (procs.Length > 1)
            {
                Close();
            }

            InitializeComponent();

            string iniFullName = AppDomain.CurrentDomain.BaseDirectory + "\\" + Process.GetCurrentProcess().ProcessName + ".ini";

            if (File.Exists(iniFullName))
            {
                string[] contents = File.ReadAllLines(iniFullName);
                if (contents != null)
                {
                    if (contents.Length >= 2)
                    {
                        LabelTitle.Content = contents[0];
                        LabelMessage.Content = contents[1];
                    }
                    else if (contents.Length >= 1)
                    {
                        LabelTitle.Content = contents[0];
                    }
                }
            }
        }

        void MainWindow_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.Key == Key.Escape || e.Key == Key.Enter)
            {
                Close();
            }
        }

        void Window_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            Close();
        }

        void LabelMove_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            DragMove();
        }

    }
}
